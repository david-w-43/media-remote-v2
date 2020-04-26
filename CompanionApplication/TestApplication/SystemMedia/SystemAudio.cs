using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi;
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

        CoreAudioDevice defaultDevice;

        public SystemAudioController()
        {
            Update();
            GetDefault();
        }

        /// <summary>
        /// Shorthand function to get the default multimedia playback device, very slow
        /// </summary>
        /// <returns>Default multimedia playback device</returns>
        public CoreAudioDevice GetDefault()
        {
            CoreAudioDevice toReturn = null;
            foreach (CoreAudioDevice device in devices)
            {
                if (device.IsDefaultDevice) { toReturn = device; }
            }
            defaultDevice = toReturn;
            return toReturn;
        }

        /// <summary>
        /// Updates the list of connected devices
        /// </summary>
        /// <returns>True if changed</returns>
        public bool Update()
        {
            List<CoreAudioDevice> oldList = new List<CoreAudioDevice>(devices);
            this.devices = new CoreAudioController().GetPlaybackDevices().ToList();
            if (Object.Equals(devices, oldList))
            {
                return false;
            }
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
            if ((defaultDevice != null) && (defaultDevice.State == DeviceState.Active))
            {
                defaultDevice.Volume += change;
                return defaultDevice.Volume;
            } else { return -1; }
            
        }

        //private class VolumeObserver : IObserver<AudioSwitcher.AudioApi.DeviceVolumeChangedArgs>
        //{
        //    public void OnCompleted()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnError(Exception error)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnNext(DeviceVolumeChangedArgs value)
        //    {
        //        // Do something with value.Volume
        //    }
        //}
    }
}
