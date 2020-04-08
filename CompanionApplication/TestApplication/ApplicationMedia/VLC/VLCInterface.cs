﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionApplication.ApplicationMedia.VLC
{
    /// <summary>
    /// Interface for VLC Media Player using TCP socket
    /// </summary>
    class Interface : ApplicationInterface
    {
        private Networking.Client client;

        /// <summary>
        /// Initiates connection to TCP socket
        /// </summary>
        /// <param name="remoteConnection">Serial connection to remote</param>
        public Interface(ref RemoteConnection remoteConnection)
        {
            try
            {
                // Initialise TCP client
                client = new Networking.Client();

                this.remoteConnection = remoteConnection;

                // Grab settings
                string hostname = Properties.Settings.Default.TCPHostname;
                int port = Properties.Settings.Default.TCPPort;

                // Connect to socket
                client.ConnectToServer(hostname, port);

                // Initialise values, these cannot be read from VLC console
                Shuffle(false);
                Repeat(RepeatMode.off);
                System.Threading.Thread.Sleep(50);

                // Start timer to update metadata
                updateTimer.Elapsed += UpdateInformation;
                updateTimer.Start();
            }
            catch (System.Net.Sockets.SocketException)
            {
                var settings = Properties.Settings.Default;
                string arguments = "--cli-host=\"" + settings.TCPHostname + ":" + settings.TCPPort + "\"";
                System.Diagnostics.Process.Start(Properties.Settings.Default.VLCPath, arguments);
                throw;
            }
            
        }


        private bool filepathFound, titleFound, stateFound, artistFound, albumFound, volumeFound, lengthFound = false;
        /// <summary>
        /// Updates information about current track and playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void UpdateInformation(object sender, System.Timers.ElapsedEventArgs e)
        {
            // List of commands to send to remote
            List<string> toSend = new List<string>();

            // Gets filepath, volume and playback status
            client.SendLine("status");
            List<string> received = client.ReadLines();

            filepathFound = stateFound = volumeFound = false;

            foreach (string line in received)
            {
                //Console.WriteLine(line);
                if (line.Contains("new input"))
                {
                    // Parse filepath
                    //Console.WriteLine(line);
                    int start = line.IndexOf(':') + 2;
                    int end = line.LastIndexOf(" )");
                    currentValues.filepath = line.Substring(start, end - start);
                    filepathFound = true;
                    //Console.WriteLine(currentValues.filepath);
                } else if (line.Contains("audio volume"))
                {
                    // Parse volume
                    //Console.WriteLine(line);
                    int start = line.IndexOf(':') + 2;
                    int end = line.LastIndexOf(" )");
                    string substring = line.Substring(start, end - start);
                    //Console.WriteLine(substring);
                    int.TryParse(substring, out int volume);
                    currentValues.volume = MapTo100(volume);
                    volumeFound = true;
                    //Console.WriteLine(currentValues.volume);
                } else if (line.Contains("state"))
                {
                    // Parse play status
                    //Console.WriteLine(line);
                    int start = line.IndexOf(' ');
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
                    stateFound = true;
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
            if (!Equals(currentValues.filepath, prevValues.filepath) || !lengthFound)
            {
                artistFound = albumFound = titleFound = lengthFound = false;

                // Request track metadata
                client.SendLine("info");
                received = client.ReadLines();
                foreach (string line in received)
                {
                    //Console.WriteLine(line);
                    if (line.StartsWith("| artist:"))
                    {
                        // Parse artist
                        int start = line.IndexOf(':') + 2;
                        currentValues.artist = line.Substring(start);
                        artistFound = true;
                    }
                    else if (line.StartsWith("| album:"))
                    {
                        // Parse album
                        int start = line.IndexOf(':') + 2;
                        currentValues.album = line.Substring(start);
                        albumFound = true;
                    }
                    else if (line.StartsWith("| title:"))
                    {
                        // Parse title
                        int start = line.IndexOf(':') + 2;
                        currentValues.title = line.Substring(start);
                        titleFound = true;
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
                    lengthFound = true;
                }

                // If values not found, substitute
                if (!titleFound) { currentValues.title = currentValues.filepath.Split('/').Last(); } // File name
                if (!artistFound) { currentValues.artist = "Unknown Artist"; }
                if (!albumFound) { currentValues.album = "Unknown Album"; }

                // Shorthand for settings
                var settings = Properties.Settings.Default;

                // If changed, add to list of commands to send
                if ((currentValues.title != prevValues.title) || !titleFound) { toSend.Add("TITLE(" + currentValues.title + ")"); }
                if (((currentValues.artist != prevValues.artist) || !artistFound) &&  !settings.DisplayAlbum) { toSend.Add("ARTIST(" + currentValues.artist + ")"); }
                if ((currentValues.trackLength != prevValues.trackLength) || !lengthFound ) { toSend.Add("LENGTH(" + currentValues.trackLength + ")"); }
                if (((currentValues.album != prevValues.album) || !albumFound) && settings.DisplayAlbum) { toSend.Add("ALBUM(" + currentValues.album + ")"); }
            }

            // Send updated data to remote
            if ((currentValues.volume != prevValues.volume) || !volumeFound) { toSend.Add("VOLUME(" + currentValues.volume + ")"); }
            if (currentValues.playStatus != prevValues.playStatus) { toSend.Add("STATUS(" + currentValues.playStatus + ")"); }
            if (currentValues.playbackPos != prevValues.playbackPos) { toSend.Add("TIME(" + currentValues.playbackPos + ")"); }

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

        /// <summary>
        /// Internally, VLC uses 100% volume = 256
        /// </summary>
        /// <param name="input">256=100% volume</param>
        /// <returns>Volume mapped to 0 - 256</returns>
        private int MapTo256(int input)
        {
            return (int)(input / (100f / 256f));
        }

        /// <summary>
        /// Changes volume by set amount
        /// </summary>
        /// <param name="change">Signed change in volume</param>
        public override void VolumeAdjust(int change)
        {
            currentValues.volume += change;
            if (currentValues.volume < 0) { currentValues.volume = 0; }
            else if (currentValues.volume > 125) { currentValues.volume = 125; }
            client.SendLine("volume " + MapTo256(currentValues.volume));
        }

        public override void Next() { client.SendLine("next"); }
        public override void Prev()
        {
            // If at beginning of track, go to previous
            if (currentValues.playbackPos < 3)
            {
                client.SendLine("prev");
            } else
            {
                // Else go to beginning of track
                client.SendLine("seek 0");
            }
        }
        public override void PlayPause() { client.SendLine("pause"); }

        /// <summary>
        /// Toggles shuffle mode
        /// </summary>
        public override void ShuffleToggle()
        {
            // Toggle shuffle
            currentValues.shuffle = !currentValues.shuffle;
            Shuffle(currentValues.shuffle);
        }

        /// <summary>
        /// Sets shuffle mode 
        /// </summary>
        /// <param name="enabled"></param>
        public override void Shuffle(bool enabled)
        {
            currentValues.shuffle = enabled;

            string onOff = null;
            if (enabled) { onOff = "on"; } else { onOff = "off"; }
            client.SendLine("random " + onOff);
            remoteConnection.Send("SHUFFLE(" + onOff + ")");
        }

        /// <summary>
        /// Increments the repeat mode and updates display and VLC
        /// </summary>
        public override void RepeatInc()
        {
            // If not the last repeat mode
            if (currentValues.repeatMode != (RepeatMode)2)
            {
                // Increment it
                currentValues.repeatMode += 1;
            } else {
                // Set to off
                currentValues.repeatMode = RepeatMode.off;
            }

            Repeat(currentValues.repeatMode);
        }

        /// <summary>
        /// Updates repeat mode
        /// </summary>
        /// <param name="mode"></param>
        public override void Repeat(RepeatMode mode)
        {
            // Update VLC
            switch (mode)
            {
                case RepeatMode.off:
                    client.SendLine("loop off");
                    client.SendLine("repeat off");
                    break;
                case RepeatMode.all:
                    client.SendLine("loop on");
                    client.SendLine("repeat off");
                    break;
                case RepeatMode.one:
                    client.SendLine("loop off");
                    client.SendLine("repeat on");
                    break;
            }

            // Set current values
            currentValues.repeatMode = mode;

            // Update display
            remoteConnection.Send("REPEATMODE(" + (int)currentValues.repeatMode + ")");
        }

        public override void Disconnect()
        {
            // Stop playback
            client.SendLine("stop");
        }
    }
}