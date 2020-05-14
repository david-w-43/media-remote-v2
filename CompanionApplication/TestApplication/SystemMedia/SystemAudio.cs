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
        CoreAudioDevice defaultDevice;
        CoreAudioController controller;

        public SystemAudioController()
        {
            controller = new CoreAudioController();
            defaultDevice = controller.DefaultPlaybackDevice;
        }

        /// <summary>
        /// Increments or decrements volume, returns new value
        /// </summary>
        /// <param name="change">Signed integer change in volume</param>
        /// <returns>New volume</returns>
        public int Adjust(int change = 1)
        {
            defaultDevice.Volume += change;
            return (int)defaultDevice.Volume;
        }

        //private class DefaultDeviceObserver : IObserver<DefaultDeviceChangedArgs>
        //{
        //    public void OnCompleted()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnError(Exception error)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnNext(DefaultDeviceChangedArgs deviceChangedArgs)
        //    {
        //        // Do something with device
        //    }
        //}

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
        //        Console.WriteLine("Changed to " + value.Volume);
        //    }
        //}
    }
}
