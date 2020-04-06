using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionApplication
{
    /// <summary>
    /// Serial connection to remote
    /// </summary>
    public class RemoteConnection
    {
        // Constant declarations
        private const int baudRate = 19200; // Baud rate to use
        private const string handshakeString = "CONNECTIONREQUEST"; // Initiates handshake
        private const string handshakeResponse = "REQUESTACCEPTED"; // The correct response to receive

        // Variable definitions
        private readonly System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort(); // Serial port
        private bool connected;

        CommandHandler commandHandler;

        /// <summary>
        /// Initiates a serial connection with the remote
        /// </summary>
        public RemoteConnection(CommandHandler commandHandler) // Constructor
        {
            // Shorthand access to application settings
            var settings = Properties.Settings.Default;

            this.commandHandler = commandHandler = new CommandHandler(this);

            List<string> systemPorts = new List<string>(); // Define list of system ports
            //Try last used port first
            if (settings.connectedPortName != "") // If not empty
            {
                systemPorts.Add(settings.connectedPortName); // Add last used port to front of list
            }

            systemPorts.AddRange(System.IO.Ports.SerialPort.GetPortNames()); // Add remaining ports
            int count = 0;
            // Try each port five times
            int tries = 5;

            connected = false;

            while (!connected && (count < tries))
            {
                // Increment counter to keep track of number of connection attempts
                count++;

                int listIndex = 0;
                bool outOfPorts = false;
                while (!connected && !outOfPorts) // While not successfully connected to a port
                {
                    try
                    {
                        serialPort.Close(); // Close existing connection
                        serialPort.PortName = systemPorts[listIndex]; // Sets the port to connect to
                        serialPort.BaudRate = baudRate; // Sets the baud rate
                        serialPort.Encoding = UnicodeEncoding.UTF8; // Sets text encoding to default
                        serialPort.NewLine = "\r\n"; 
                        serialPort.ReadTimeout = 1000; // 1000 ms read timeout
                        serialPort.Open(); // Opens the port

                        serialPort.WriteLine(handshakeString); // Sends string to remote

                        // Give time for the arduino to respond
                        System.Threading.Thread.Sleep(200);

                        string response = serialPort.ReadLine(); // Read line into variable
                        Console.WriteLine(response);
                        if (response.Contains(handshakeResponse)) // If correct response
                        {
                            Console.WriteLine("CONNECTED AT " + serialPort.PortName);
                            connected = true;

                            //// Initialise delegates so data can be handled
                            //serialReceivedDelegate = new HandleSerialReceived(DataReceived);
                            serialPort.DataReceived += DataReceived;
                        }
                        else
                        {
                            Console.WriteLine("Not present at " + serialPort.PortName);
                            listIndex++; // Next port
                        }
                    }
                    catch (System.TimeoutException) // Do not throw fatal exception when timeout occurs
                    {
                        Console.WriteLine("Not present at " + serialPort.PortName);
                        listIndex++; // Next port
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("NO MORE PORTS");
                        outOfPorts = true;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Unauthorised access on " + serialPort.PortName);
                        listIndex++;
                    }
                }

                // If successfully connected, set the name of the port
                if (connected)
                {
                    settings.connectedPortName = serialPort.PortName;
                    settings.Save();

                    // Request current device mode
                    Send("MODEQUERY");
                }
            }
            if (!connected) { throw new System.IO.IOException("Iterated through all (" + systemPorts.Count + ") ports and remote was not found"); }
        }

        /// <summary>
        /// Send string to remote
        /// </summary>
        /// <param name="value">String to send</param>
        public void Send(string value) {
            // Send Data
            serialPort.WriteLine(value);

            // Write to console with timestamp
            Console.WriteLine(DateTime.Now.Second + "." + DateTime.Now.Millisecond + ": " + value);
        }

        /// <summary>
        /// Send list of strings to remote
        /// </summary>
        /// <param name="lines">List of strings to send</param>
        public void Send(List<string> lines)
        {
            foreach (string line in lines)
            {
                Send(line);
            }
        }

        /// <summary>
        /// Called when data is received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) 
        {
            while (serialPort.BytesToRead > 0)
            {
                string line = serialPort.ReadLine().Trim();
                // Providing the line is not empty
                if (line != null) {
                    // Write line to console with timestamp
                    Console.WriteLine(DateTime.Now.Second + "." + DateTime.Now.Millisecond + ": " + line);

                    // Split line on space, first element should be command identifier
                    if (line.Contains("("))
                    {
                        int parametersStart = line.IndexOf("(") + 1;
                        int parametersEnd = line.LastIndexOf(")");
                        string key = line.Substring(0, parametersStart - 1);
                        string parametersStr = line.Substring(parametersStart, parametersEnd - parametersStart);

                        // Parse parameters, create list
                        List<string> parameters = new List<string>();
                        if (line.Contains(CommandHandler.separator))
                        {
                            parameters.AddRange(parametersStr.Split(CommandHandler.separator));
                        }
                        else
                        {
                            parameters.Add(parametersStr);
                        }

                        // Pass command to command handler
                        commandHandler.HandleCommand(key, parameters);
                    }
                }
            }
        }


        /// <summary>
        /// Updates settings of remote
        /// </summary>
        public void UpdateRemote()
        {
            // Shorthand settings
            var settings = Properties.Settings.Default;

            // Send scroll long text bool
            int val;
            if (settings.ScrollLongText) { val = 1; } else { val = 0; }
            Send("UPDSCROLL(" + val + ")");

            // Send display album bool
            if (settings.DisplayAlbum) { val = 1; } else { val = 0; }
            Send("UPDALBUM(" + val + ")");
        }

    }
}
