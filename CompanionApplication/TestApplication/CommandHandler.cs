using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionApplication
{
    public enum DeviceMode { CLOCK, VLC, MEDIA, MENU };

    public class CommandHandler
    {
        public const char separator = (char)0x7c;

        // Commands that can be recieved
        // Take the form
        //      COMMAND (parameter1|parameter2|...|parameter3)

        
        public RemoteConnection remoteConnection;
        private VLC.Interface vlcInterface;

        private DeviceMode deviceMode;

        public CommandHandler(RemoteConnection remoteConnection)
        {
            this.remoteConnection = remoteConnection;
        }

        public DeviceMode GetDeviceMode()
        {
            return this.deviceMode;
        }

        // Changes device mode
        public void ModeSwitch(DeviceMode mode)
        {
            deviceMode = mode;
            switch (mode)
            {
                case DeviceMode.CLOCK:
                    Console.WriteLine("Clock mode");
                    break;
                case DeviceMode.VLC:
                    Console.WriteLine("VLC mode");
                    vlcInterface = new VLC.Interface(ref remoteConnection);
                    break;
                case DeviceMode.MEDIA:
                    Console.WriteLine("Media mode");
                    break;
                case DeviceMode.MENU:
                    Console.WriteLine("Menu mode");
                    break;
                default:
                    Console.WriteLine("Invalid mode " + mode);
                    break;
            }
        }

        public void ModeSwitch(int mode) { ModeSwitch((DeviceMode)mode); }

        public void HandleCommand(string identifier, List<string> parameters)
        {
            // Commands for all modes
            switch (identifier)
            {
                case "MODESWITCH":
                    // Handles the changing of mode
                    ModeSwitch(int.Parse(parameters[0]));
                    break;
            }

            // Commands for specific mode
            switch (deviceMode)
            {
                case DeviceMode.CLOCK:
                    break;
                case DeviceMode.VLC:
                    switch (identifier)
                    {
                        case "VOLCHANGE":
                            vlcInterface.VolumeAdjust(int.Parse(parameters[0]));
                            break;
                        case "NEXT":
                            vlcInterface.Next();
                            break;
                        case "PREV":
                            vlcInterface.Prev();
                            break;
                        case "PAUSE":
                            vlcInterface.Pause();
                            break;
                        case "SHUFFLE":
                            vlcInterface.ShuffleToggle();
                            break;
                        case "REPEAT":
                            vlcInterface.RepeatInc();
                            break;
                    }

                    break;
                case DeviceMode.MEDIA:
                    break;
                case DeviceMode.MENU:
                    break;
            }
        }

        public void Disconnect()
        {

        }
        

    }
}
