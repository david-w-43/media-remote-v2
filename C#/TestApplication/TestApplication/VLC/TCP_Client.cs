using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace TestApplication.VLC.Networking
{
    /// <summary>
    /// Implements a simple TCP client which connects to a specified server
    /// </summary>
    public class Client
    {
        private TcpClient tcpClient;
        private NetworkStream clientStream;
        private StreamReader streamReader;
        private byte[] readBuffer = new byte[4096];
        private int port;
        private bool started = false;

        /// <summary>
        /// Constructs a new client
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Constructs a new client and immediately connects to server
        /// </summary>
        /// <param name="ipAddress">The IP address (IPV4) of the server</param>
        /// <param name="port">The port the server is listening on</param>
        public Client(string ipAddress, int port)
        {
            ConnectToServer(ipAddress, port);
        }

        /// <summary>
        /// Initiates a TCP connection to a TCP server with a given address and port
        /// </summary>
        /// <param name="ipAddress">The IP address (IPV4) of the server</param>
        /// <param name="port">The port the server is listening on</param>
        public void ConnectToServer(string ipAddress, int port)
        {
            this.port = port;

            tcpClient = new TcpClient(ipAddress, port);
            clientStream = tcpClient.GetStream();
            streamReader = new StreamReader(tcpClient.GetStream(), Encoding.UTF8);

            Console.WriteLine("Connected to server, listening for packets");

            //Thread t = new Thread(new ThreadStart(ListenForPackets));
            //started = true;
            //t.Start();
        }

        /// <summary>
        /// Reads lines from the server, returns as list of strings
        /// </summary>
        /// <returns></returns>
        public List<string> ReadLines()
        {
            string line;
            bool outputCompleteFlag = false;
            List<string> output = new List<string>();

            while (!outputCompleteFlag)
            {
                if ((streamReader.EndOfStream) || (streamReader.Peek() == ">"[0]))
                {
                    outputCompleteFlag = true;
                    streamReader.DiscardBufferedData();
                }
                else
                {
                    // Read line
                    line = streamReader.ReadLine();
                    //Console.WriteLine(line);

                    // If line not null
                    if (line != null)
                    {
                        // Remove chevrons and trim
                        string formatted = line.Trim();

                        //Console.WriteLine(formatted);

                        output.Add(formatted);
                    }
                }
            }

            // Get rid of excess
            streamReader.DiscardBufferedData();

            return output;

            //List<string> lines = new List<string>();

            //string readData = streamReader.ReadToEnd();
            //Console.WriteLine(readData);

            //// Add lines to list
            //lines.AddRange(readData.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

            //// Remove "> " from list
            //while (lines.Contains("> ")) { lines.Remove("> "); }

            //return lines;
        }

        /// <summary>
        /// Immediately sends string followed by newline (CRLF) to the server
        /// </summary>
        /// <param name="data"></param>
        public void SendLine(string data)
        {
            //Console.WriteLine("Sending: " + data);

            data += "\r\n";
            byte[] writeBuffer = Encoding.UTF8.GetBytes(data);
            clientStream.Write(writeBuffer, 0, writeBuffer.Length);
        }

        /// <summary>
        /// Returns true if connected to the server
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return started && tcpClient.Connected;
        }

        /// <summary>
        /// Disconnect from the server
        /// </summary>
        public void Disconnect()
        {
            if (tcpClient == null)
            {
                return;
            }

            Console.WriteLine("Disconnected from server");

            tcpClient.Close();

            started = false;
        }
    }
}