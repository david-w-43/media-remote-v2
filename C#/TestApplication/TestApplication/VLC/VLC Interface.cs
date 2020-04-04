using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.VLC
{
    /// <summary>
    /// Interface for VLC Media Player using TCP socket
    /// </summary>
    class Interface
    {
        public enum RepeatMode { off, all, one };
        // Play status
        public enum PlayStatus { playing, paused, stopped };
        private RemoteConnection remoteConnection;

        /// <summary>
        /// Stores the values relating to VLC
        /// </summary>
        public struct VLCValues
        {
            public string title;
            public string artist;
            public string album;
            public int trackLength;
            public int playbackPos;
            public int volume;
            public RepeatMode repeatMode;
            public bool shuffle;
            public string filepath;
            public PlayStatus playStatus;
        };

        private const int updateInterval = 100;

        private VLCValues currentValues, prevValues;

        private Networking.Client client;

        // Creates timer
        private System.Timers.Timer updateTimer = new System.Timers.Timer { AutoReset = true, Interval = updateInterval };

        /// <summary>
        /// Initiates connection to TCP socket
        /// </summary>
        /// <param name="remoteConnection">Serial connection to remote</param>
        public Interface(ref RemoteConnection remoteConnection)
        {
            // Initialise TCP client
            client = new Networking.Client();

            this.remoteConnection = remoteConnection;

            // Grab settings
            string hostname = Properties.Settings.Default.TCPHostname;
            int port = Properties.Settings.Default.TCPPort;

            // Connect to socket
            client.ConnectToServer(hostname, port);

            // Start timer to update metadata
            updateTimer.Elapsed += UpdateInformation;
            updateTimer.Start();
        }

        /// <summary>
        /// Updates information about current track and playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInformation(object sender, System.Timers.ElapsedEventArgs e)
        {
            // List of commands to send to remote
            List<string> toSend = new List<string>();

            // Gets filepath, volume and playback status
            client.SendLine("status");
            List<string> received = client.ReadLines();

            foreach (string line in received)
            {
                //Console.WriteLine(line);
                if (line.Contains("new input"))
                {
                    // Parse filepath
                    //Console.WriteLine(line);
                    int start = line.IndexOf(":"[0]) + 2;
                    int end = line.LastIndexOf(" )");
                    currentValues.filepath = line.Substring(start, end - start);
                    //Console.WriteLine(currentValues.filepath);
                } else if (line.Contains("audio volume"))
                {
                    // Parse volume
                    //Console.WriteLine(line);
                    int start = line.IndexOf(":"[0]) + 2;
                    int end = line.LastIndexOf(" )");
                    string substring = line.Substring(start, end - start);
                    //Console.WriteLine(substring);
                    int.TryParse(substring, out currentValues.volume);
                    //Console.WriteLine(currentValues.volume);
                } else if (line.Contains("state"))
                {
                    // Parse play status
                    //Console.WriteLine(line);
                    int start = line.IndexOf(" "[0]);
                    int end = line.LastIndexOf(" )");
                    string parsed = line.Substring(start, end - start);
                    switch (parsed)
                    {
                        case "playing":
                            currentValues.playStatus = PlayStatus.playing;
                            break;
                        case "paused":
                            currentValues.playStatus = PlayStatus.paused;
                            break;
                        case "stopped":
                            currentValues.playStatus = PlayStatus.stopped;
                            break;
                        default:
                            break;
                    }
                    //Console.WriteLine(currentValues.volume);
                }
            }
            
            // Get current time
            client.SendLine("get_time");
            received = client.ReadLines();
            foreach (string line in received)
            {
                //Console.WriteLine(line);
                string trimmed = line.Trim();
                if (int.TryParse(line, out int parsed)) { currentValues.playbackPos = parsed; }
                //Console.WriteLine(currentValues.playbackPos);
            }

            // Checks if the track is new
            if (!Equals(currentValues.filepath, prevValues.filepath))
            {
                // Request track metadata
                client.SendLine("info");
                received = client.ReadLines();
                foreach (string line in received)
                {
                    //Console.WriteLine(line);
                    if (line.StartsWith("| artist:"))
                    {
                        // Parse artist
                        int start = line.IndexOf(":"[0]) + 2;
                        currentValues.artist = line.Substring(start);
                    }
                    else if (line.StartsWith("| album:"))
                    {
                        // Parse album
                        int start = line.IndexOf(":"[0]) + 2;
                        currentValues.album = line.Substring(start);
                    }
                    else if (line.StartsWith("| title:"))
                    {
                        // Parse title
                        int start = line.IndexOf(":"[0]) + 2;
                        currentValues.title = line.Substring(start);
                    }
                }

                // Get track length
                client.SendLine("get_length");
                received = client.ReadLines();
                foreach (string line in received)
                {
                    //Console.WriteLine(line);
                    string trimmed = line.Trim();
                    if (int.TryParse(line, out int parsed)) { currentValues.trackLength = parsed; }
                }

                // If changed, add to list of commands to send
                if (currentValues.title != prevValues.title) { toSend.Add("TITLE(" + currentValues.title + ")"); }
                if (currentValues.artist != prevValues.artist) { toSend.Add("ARTIST(" + currentValues.artist + ")"); }
                if (currentValues.trackLength != prevValues.trackLength) { toSend.Add("LENGTH(" + currentValues.trackLength + ")"); }
                if (currentValues.album != prevValues.album) { toSend.Add("ALBUM(" + currentValues.album + ")"); }
            }

            // Send updated data to remote
            if (currentValues.volume != prevValues.volume) { toSend.Add("VOLUME(" + MapTo100(currentValues.volume) + ")"); }
            if (currentValues.playStatus != prevValues.playStatus) { toSend.Add("STATUS(" + currentValues.playStatus + ")"); }
            if (currentValues.playbackPos != prevValues.playbackPos) { toSend.Add("TIME(" + currentValues.playbackPos + ")"); }

            //// Write all data to console
            //Console.WriteLine("------------------------");
            //Console.WriteLine(currentValues.filepath);
            //Console.WriteLine(currentValues.title);
            //Console.WriteLine(currentValues.artist);
            //Console.WriteLine(currentValues.album);
            //Console.WriteLine(currentValues.trackLength);
            //Console.WriteLine(currentValues.volume);
            //Console.WriteLine(currentValues.playStatus);
            //Console.WriteLine(currentValues.playbackPos);
            //Console.WriteLine("------------------------");

            remoteConnection.Send(toSend);

            // Set previous values equal to current values
            prevValues = currentValues;
        }

        /// <summary>
        /// Internally, VLC uses 100% volume = 256
        /// </summary>
        /// <param name="input">256=100% volume</param>
        /// <returns>Volume mapped to 0 - 100%</returns>
        private int MapTo100(int input)
        {
            return (int)(input * (100f / 256f));
        }
    }
}
