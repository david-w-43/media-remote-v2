using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public enum DeviceMode { CLOCK, VLC, MEDIA, MENU };

    public class CommandHandler
    {
        public const char separator = (char)0x7c;

        // Commands that can be recieved
        // Take the form
        //      COMMAND (parameter1|parameter2|...|parameter3)

        
        public RemoteConnection remoteConnection;
        private static VLC.Interface vlcInterface;

        private DeviceMode deviceMode;

        public CommandHandler(RemoteConnection remoteConnection)
        {
            this.remoteConnection = remoteConnection;
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

        public void Disconnect()
        {

        }
        

    }
}
