using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionApplication.SystemMedia
{
    class SystemMediaInterface
    {
        public enum MultimediaKey : byte
        {
            Next = 0xB0,
            Pause = 0xB3,
            Prev = 0xB1,
        }

        private RemoteConnection remoteConnection;
        //private SystemAudioController audioController;

        public SystemMediaInterface(ref RemoteConnection remoteConnection)
        {
            this.remoteConnection = remoteConnection;
            //audioController = new SystemAudioController();
        }

        /// <summary>
        /// Needed to simulate key presses
        /// </summary>
        /// <param name="virtualKey"></param>
        /// <param name="scanCode"></param>
        /// <param name="flags"></param>
        /// <param name="extraInfo"></param>
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        /// <summary>
        /// Simulate a keypress (down + up)
        /// </summary>
        /// <param name="key"></param>
        private void SendKey(MultimediaKey key)
        {
            uint EXTENDEDKEY = 0x0001;
            uint KEYUP = 0x0002;

            keybd_event((byte)key, 0, EXTENDEDKEY, IntPtr.Zero);
            keybd_event((byte)key, 0, KEYUP, IntPtr.Zero);
        }

        public void Next() { SendKey(MultimediaKey.Next); }
        public void Prev() { SendKey(MultimediaKey.Prev); }
        public void Pause() { SendKey(MultimediaKey.Pause); }

        /// <summary>
        /// Change volume and update remote
        /// </summary>
        /// <param name="change"></param>
        public void VolumeAdjust(int change)
        {
            //remoteConnection.Send(new Command("VOLUME", (int)audioController.Adjust(change)));
        }
    }
}
