using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi.CoreAudio;

namespace CompanionApplication.SystemMedia
{
    /// <summary>
    /// Controls system audio
    /// </summary>
    class SystemAudioController
    {
        // Creates enumerator for all playback devices
        private List<CoreAudioDevice> devices = new CoreAudioController().GetPlaybackDevices().ToList();

        /// <summary>
        /// Shorthand function to get the default multimedia playback device
        /// </summary>
        /// <returns>Default multimedia playback device</returns>
        public CoreAudioDevice GetDefault()
        {
            CoreAudioDevice toReturn = null;
            foreach (CoreAudioDevice device in devices)
            {
                if (device.IsDefaultDevice) { toReturn = device; }
            }
            return toReturn;
        }

        /// <summary>
        /// Updates the list of connected devices
        /// </summary>
        /// <returns>True if changed</returns>
        public bool Update()
        {
            List<CoreAudioDevice> oldList = new List<CoreAudioDevice>(devices);
            devices = new CoreAudioController().GetPlaybackDevices().ToList();
            if (Object.Equals(devices, oldList)) { return false; }
            else { return true; }
        }

        /// <summary>
        /// Returns list of playback device names
        /// </summary>
        /// <returns>List of names</returns>
        public List<string> GetDeviceNames()
        {
            List<string> toReturn = new List<string>();
            foreach (CoreAudioDevice device in devices)
            {
                toReturn.Add(device.Name);
            }
            return toReturn;
        }

        /// <summary>
        /// Increments or decrements volume, returns new value
        /// </summary>
        /// <param name="change">Signed integer change in volume</param>
        /// <returns>New volume</returns>
        public double Adjust(int change = 1)
        {
            CoreAudioDevice defaultDevice = GetDefault();
            defaultDevice.Volume += change;
            return defaultDevice.Volume;
        }
    }
}
