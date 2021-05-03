using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionApplication
{
    /// <summary>
    /// Facilitates construction and formatting of commands to be sent to remote
    /// </summary>
    public class Command
    {
        public readonly string identifier, parameter;
        public readonly int parameterLength;

        /// <summary>
        /// Constructs a new command
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="parameter">String parameter</param>
        public Command(string identifier, string parameter)
        {
            this.identifier = identifier;

            // Remove diacritics
            this.parameter = ASCIIconverter(parameter);
            this.parameterLength = this.parameter.Length;
        }

        /// <summary>
        /// Constructs a new command
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="parameter">Integer parameter</param>
        public Command(string identifier, int parameter)
        {
            this.identifier = identifier;
            this.parameter = parameter.ToString();
            this.parameterLength = this.parameter.Length;
        }

        /// <summary>
        /// Constructs a new command
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="parameter">Boolean parameter</param>
        public Command(string identifier, bool parameter)
        {
            this.identifier = identifier;
            if (parameter == true)
            {
                this.parameter = "1";
            } else
            {
                this.parameter = "0";
            }
            this.parameterLength = 1;
        }

        /// <summary>
        /// Constructs a new command without parameter
        /// </summary>
        /// <param name="identifier"></param>
        public Command(string identifier)
        {
            this.identifier = identifier;
            this.parameter = "";
            parameterLength = 0;
        }

        /// <summary>
        /// Returns command as string, formatted for sending
        /// </summary>
        /// <returns></returns>
        public string Format()
        {
            return identifier + "(" + parameterLength + "|" + parameter + ")";
        }

        public string ASCIIconverter(string input)
        {
            byte[] temp;
            temp = Encoding.GetEncoding("ISO-8859-8").GetBytes(input);
            return Encoding.ASCII.GetString(temp);
        }
    }

    /// <summary>
    /// Buffer of commands
    /// </summary>
    public class CommandCache
    {
        private const int cacheSize = 10;
        private List<Command> cache = new List<Command>(cacheSize);
        //private Command[] cache = new Command[cacheSize];

        /// <summary>
        /// Adds command to the cache
        /// </summary>
        /// <param name="command"></param>
        public void Add(Command command) {
            if (cache.Count < cacheSize) { cache.Add(command); }
            else
            {
                // Move items down
                for (int i = 0; i < cacheSize - 1; i++)
                {
                    cache[i] = cache[i + 1];
                }

                // Add latest
                cache[cacheSize - 1] = command;
            }
        }

        /// <summary>
        /// Searches for the most recently issued command with given identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Command Search(string identifier)
        {
            //// Search, most recent first
            //for (int i = cache.; i >= 0; i--)
            //{
            //    if (cache[i].identifier == identifier) { return cache[i]; }
            //}

            //return null;
            return cache.FindLast(x => x.identifier == identifier);
        }

        /// <summary>
        /// Returns the cache as a list
        /// </summary>
        /// <returns></returns>
        public List<Command> ListCommands()
        {
            return cache;
        }
    }

    /// <summary>
    /// Serial connection to remote
    /// </summary>
    public class RemoteConnection
    {
        // Constant declarations
        private const int baudRate = 19200; // Baud rate to use
        private string handshakeString = TxCommand.ConnectionRequest; // Initiates handshake
        private const string handshakeResponse = "REQUESTACCEPTED"; // The correct response to receive

        CommandCache sentCache = new CommandCache();

        // Variable definitions
        private readonly System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort(); // Serial port
        private bool connected;

        CommandHandler commandHandler;

        /// <summary>
        /// Initiates a serial connection with the remote
        /// </summary>
        public RemoteConnection(ref CommandHandler commandHandler, ref Discord.DiscordRichPresence richPresence) // Constructor
        {
            // Shorthand access to application settings
            var settings = Properties.Settings.Default;

            this.commandHandler = commandHandler = new CommandHandler(this, richPresence);

            List<string> systemPorts = new List<string>(); // Define list of system ports
            //Try last used port first
            if ((settings.connectedPortName != "") && (System.IO.Ports.SerialPort.GetPortNames().Contains(settings.connectedPortName))) // If not empty
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

                        serialPort.WriteLine(new Command(handshakeString).Format()); // Sends string to remote

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

                    // Indicate that remote is connected
                    Send(new Command(TxCommand.Connected, true));

                    // Request current device mode
                    Send(new Command(TxCommand.ModeQuery));

                    // Update RTC with system time
                    Settings.SyncRTC(this);
                }
            }
            if (!connected) { throw new System.IO.IOException("Iterated through all (" + systemPorts.Count + ") ports and remote was not found"); }
        }

        /// <summary>
        /// Send string to remote
        /// </summary>
        /// <param name="value">String to send</param>
        public void Send(Command command) {
            // Send Data
            if (serialPort.IsOpen)
            {
                serialPort.WriteLine(command.Format());

                // Add data to cache
                sentCache.Add(command);

                // Write to console with timestamp
                Console.WriteLine("S " + DateTime.Now.Second + "." + DateTime.Now.Millisecond + ": " + command.Format());
            }
            else
            {
                Console.WriteLine("Serial port closed");
            }
        }

        /// <summary>
        /// Send list of strings to remote
        /// </summary>
        /// <param name="commands">List of commands to send</param>
        public void Send(List<Command> commands)
        {
            foreach (Command command in commands)
            {
                Send(command);
            }
        }

        /// <summary>
        /// Called when remote requests a value is resent
        /// </summary>
        /// <param name="identifier"></param>
        private void Resend(string identifier)
        {
            // Get the command recently sent with the same identifier
            Command toSend = sentCache.Search(identifier);
            // If it exists, resend it
            if (toSend != null) { Send(toSend); }
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
                    Console.WriteLine("R " + DateTime.Now.Second + "." + DateTime.Now.Millisecond + ": " + line);

                    // Split line on space, first element should be command identifier
                    if (line.Contains("("))
                    {
                        int parametersStart = line.IndexOf("(") + 1;
                        int parametersEnd = line.LastIndexOf(")");
                        string identifier = line.Substring(0, parametersStart - 1);
                        string parameter = line.Substring(parametersStart, parametersEnd - parametersStart);

                        // Pass command to command handler
                        if (identifier != "RESEND")
                        {
                            commandHandler.HandleCommand(identifier, parameter);
                        } else
                        {
                            Resend(parameter);
                        }
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
            //Send("UPDSCROLL(" + val + ")");
            Send(new Command(TxCommand.UpdateScroll, val));

            //// Send display album bool
            //if (settings.DisplayAlbum) { val = 1; } else { val = 0; }
            ////Send("UPDALBUM(" + val + ")");
            //Send(new Command("UPDALBUM", val));
        }

        public void Disconnect()
        {
            Send(new Command(TxCommand.Connected, false));

            serialPort.Dispose();
        }
    }
}
