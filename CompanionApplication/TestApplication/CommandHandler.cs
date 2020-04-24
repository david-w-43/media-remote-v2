using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanionApplication.ApplicationMedia;

namespace CompanionApplication
{
    public enum DeviceMode { Clock, ApplicationControl, SystemMedia, Menu };

    public class CommandHandler
    {
        public const char separator = (char)0x7c;
        
        public RemoteConnection remoteConnection;
        private ApplicationInterface applicationInterface;

        public Discord.DiscordRichPresence richPresence;

        private DeviceMode deviceMode;

        public CommandHandler(RemoteConnection remoteConnection, Discord.DiscordRichPresence richPresence)
        {
            this.remoteConnection = remoteConnection;
            this.richPresence = richPresence;
        }

        public DeviceMode GetDeviceMode()
        {
            return this.deviceMode;
        }

        // Changes device mode
        public void ModeSwitch(DeviceMode mode)
        {
            remoteConnection.Send(new Command("MODESET", (int)mode));

            deviceMode = mode;
            switch (mode)
            {
                case DeviceMode.Clock:
                    Console.WriteLine("Clock mode");
                    // Disconnect if not null
                    if (applicationInterface != null)
                    {
                        applicationInterface.Disconnect();
                        applicationInterface = null;
                    }
                    break;
                case DeviceMode.ApplicationControl:
                    Console.WriteLine("Application control mode");

                    // Disconnect if not null
                    if (applicationInterface != null) {
                        applicationInterface.Disconnect();
                        applicationInterface = null;
                    }
                    

                    // Instantiate appropriate connection
                    switch ((Interface)Properties.Settings.Default.ApplicationMediaInterface)
                    {
                        case Interface.VLC:
                            int i = 0;
                            while (Equals(applicationInterface, null) && i < 3)
                            {
                                try
                                {
                                    applicationInterface = new ApplicationMedia.VLC.Interface(ref remoteConnection, ref richPresence);
                                }
                                catch (System.Net.Sockets.SocketException)
                                {
                                    i++;
                                    // Wait a small amount of time before second attempt
                                    System.Threading.Thread.Sleep(50);
                                }
                            }
                            break;
                        case Interface.iTunes:
                            applicationInterface = new ApplicationMedia.iTunes.Interface(ref remoteConnection, ref richPresence);
                            break;
                    }
                    break;
                case DeviceMode.SystemMedia:
                    Console.WriteLine("Media mode");
                    applicationInterface = null;
                    break;
                case DeviceMode.Menu:
                    Console.WriteLine("Menu mode");
                    break;
                default:
                    Console.WriteLine("Invalid mode " + mode);
                    break;
            }
        }

        public void ModeSwitch(int mode) { ModeSwitch((DeviceMode)mode); }

        public void HandleCommand(string identifier, string parameter)
        {
            // Commands for all modes
            switch (identifier)
            {
                case "MODESWITCH":
                    // Handles the changing of mode
                    ModeSwitch(int.Parse(parameter));
                    break;
            }

            // Commands for specific mode
            switch (deviceMode)
            {
                case DeviceMode.Clock:
                    break;
                case DeviceMode.ApplicationControl:
                    switch (identifier)
                    {
                        case "VOLCHANGE":
                            applicationInterface.VolumeAdjust(int.Parse(parameter));
                            break;
                        case "NEXT":
                            applicationInterface.Next();
                            break;
                        case "PREV":
                            applicationInterface.Prev();
                            break;
                        case "PAUSE":
                            applicationInterface.PlayPause();
                            break;
                        case "SHUFFLE":
                            applicationInterface.ShuffleToggle();
                            break;
                        case "REPEAT":
                            applicationInterface.RepeatInc();
                            break;
                    }

                    break;
                case DeviceMode.SystemMedia:
                    break;
                case DeviceMode.Menu:
                    break;
            }
        }

        //public void RefreshApplication()
        //{
        //    applicationInterface.Disconnect();
        //    switch ((Interface)Properties.Settings.Default.ApplicationMediaInterface)
        //    {
        //        case Interface.VLC:
        //            applicationInterface = new ApplicationMedia.VLC.Interface(ref remoteConnection, ref richPresence);
        //            break;
        //        case Interface.iTunes:
        //            applicationInterface = new ApplicationMedia.iTunes.Interface(ref remoteConnection, ref richPresence);
        //            break;
        //    }
            
        //}

        public void Disconnect()
        {
            if (applicationInterface != null) { applicationInterface.Disconnect(); }
            if (remoteConnection != null) { remoteConnection.Disconnect(); }
        }
    }
}