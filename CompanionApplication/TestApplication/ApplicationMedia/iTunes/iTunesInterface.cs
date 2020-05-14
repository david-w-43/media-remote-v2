using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using iTunesLib;

namespace CompanionApplication.ApplicationMedia.iTunes
{
    class Interface : ApplicationInterface
    {
        iTunesApp application;


        public Interface(ref RemoteConnection remoteConnection, CommandHandler commandHandler, ref Discord.DiscordRichPresence richPresence)
        {
            currentValues.player = ApplicationMedia.Interface.iTunes;

            // Stopped by default
            currentValues.playStatus = PlayStatus.stopped;

            this.remoteConnection = remoteConnection;
            this.richPresence = richPresence;
            this.commandHandler = commandHandler;

            if (richPresence.IsDisposed()) { richPresence = new Discord.DiscordRichPresence(); }

            application = new iTunesApp();

            updateTimer.Elapsed += UpdateInformation;
            updateTimer.Start();

            // Experimental event listeners
            application.OnPlayerPlayEvent += Application_OnPlayerPlayEvent;
            application.OnPlayerStopEvent += Application_OnPlayerStopEvent;
            application.OnAboutToPromptUserToQuitEvent += OnQuitEvent;
            application.OnSoundVolumeChangedEvent += Application_OnSoundVolumeChangedEvent;

            remoteConnection.Send(new Command(TxCommand.SetMediaAppConnected, true));

            // Push current values
            Application_OnSoundVolumeChangedEvent(application.SoundVolume);
            if (application.PlayerState != ITPlayerState.ITPlayerStateStopped)
            {
                Application_OnPlayerPlayEvent(application.CurrentTrack);
            }
        }

        /// <summary>
        /// Called when volume is changed and when new track starts playing
        /// </summary>
        /// <param name="newVolume"></param>
        private void Application_OnSoundVolumeChangedEvent(int newVolume)
        {
            //Console.WriteLine("Volume: " + newVolume);
            currentValues.volume = newVolume;
            if (currentValues.volume != prevValues.volume)
            {
                PushUpdate(new List<Command>() { new Command(TxCommand.SetVolume, currentValues.volume) });
            }
        }

        ///// <summary>
        ///// Called when user attempts to quit iTunes
        ///// </summary>
        //private void Application_OnAboutToPromptUserToQuitEvent()
        //{
        //    Console.WriteLine("About to quit");

        //    Disconnect();

        //    // Disconnect, return to clock mode
        //    commandHandler.ModeSwitch(DeviceMode.Clock);
        //}

        /// <summary>
        /// Called when iTunes stops playing a track
        /// </summary>
        /// <param name="iTrack"></param>
        private void Application_OnPlayerStopEvent(object iTrack)
        {
            //Console.WriteLine("Stopped playing");
            currentValues.playStatus = PlayStatus.stopped;
        }

        /// <summary>
        /// Called when iTunes starts playing a track
        /// </summary>
        /// <param name="iTrack"></param>
        private void Application_OnPlayerPlayEvent(object iTrack)
        {
            // Use new track to update information
            Console.WriteLine("New track: " + ((IITTrack)iTrack).Name);
            UpdateTrackInformation((IITTrack)iTrack);
        }

        private void UpdateTrackInformation(IITTrack currentTrack)
        {
            // Grab values
            currentValues.title = currentTrack.Name;
            currentValues.artist = currentTrack.Artist;
            currentValues.album = currentTrack.Album;
            currentValues.trackLength = currentTrack.Duration;

            currentValues.playStatus = PlayStatus.playing;

            // List of commands to send
            List<Command> toSend = new List<Command>();

            // Send title
            //if (currentValues.title != prevValues.title) {
                toSend.Add(new Command(TxCommand.SetTitle, currentValues.title));
            //}

            // Send subtitle
            if (Properties.Settings.Default.DisplayAlbum)
            {
                //if (currentValues.album != prevValues.album)
                //{
                    toSend.Add(new Command(TxCommand.SetSubtitle, currentValues.album));
                //}
            }
            else
            {
                //if (currentValues.artist != prevValues.artist)
                //{
                    toSend.Add(new Command(TxCommand.SetSubtitle, currentValues.artist));
                //}
            }

            // Send track length
            //if (currentValues.trackLength != prevValues.trackLength) {
                toSend.Add(new Command(TxCommand.SetLength, currentValues.trackLength));
            //}

            // Send time
            toSend.Add(new Command(TxCommand.SetTime, application.PlayerPosition));

            PushUpdate(toSend);
        }

        /// <summary>
        /// Called by timer, used to get playback position, shuffle and repeat modes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInformation(object sender, ElapsedEventArgs e)
        {
            try
            {
                currentValues.playbackPos = application.PlayerPosition;
                currentValues.shuffle = application.CurrentPlaylist.Shuffle/* && application.CanSetShuffle[application.CurrentPlaylist]*/;

                //if (application.CanSetSongRepeat[application.CurrentPlaylist])
                //{
                    // Convert iTunes repeat mode enum
                    switch (application.CurrentPlaylist.SongRepeat)
                    {
                        case ITPlaylistRepeatMode.ITPlaylistRepeatModeOff:
                            currentValues.repeatMode = RepeatMode.off;
                            break;
                        case ITPlaylistRepeatMode.ITPlaylistRepeatModeOne:
                            currentValues.repeatMode = RepeatMode.one;
                            break;
                        case ITPlaylistRepeatMode.ITPlaylistRepeatModeAll:
                            currentValues.repeatMode = RepeatMode.all;
                            break;
                    }
                //}
                //else
                //{
                //    currentValues.repeatMode = RepeatMode.off;
                //}

                //// If values have changed, update remote display
                //if (!Equals(currentValues, prevValues)) { UpdateRemote(); }

                List<Command> toSend = new List<Command>();
                if (currentValues.playbackPos != prevValues.playbackPos) { toSend.Add(new Command(TxCommand.SetTime, currentValues.playbackPos)); }
                
                //Shuffle
                if (currentValues.shuffle != prevValues.shuffle)
                {
                    toSend.Add(new Command(TxCommand.SetShuffle, currentValues.shuffle));
                }

                // Repeat mode
                if (currentValues.repeatMode != prevValues.repeatMode)
                {
                    toSend.Add(new Command(TxCommand.SetRepeatMode, (int)currentValues.repeatMode));
                }
                PushUpdate(toSend);

            }
            catch (Exception)
            {
            }
            
        }

        public override void Next() { application.NextTrack(); }

        public override void Prev() { application.BackTrack(); }

        public override void PlayPause() { application.PlayPause(); }

        public override void Shuffle(bool enabled)
        {
            application.CurrentPlaylist.Shuffle = enabled;
        }

        public override void Repeat(RepeatMode mode)
        {
            switch (mode)
            {
                case RepeatMode.off:
                    application.CurrentPlaylist.SongRepeat = ITPlaylistRepeatMode.ITPlaylistRepeatModeOff;
                    break;
                case RepeatMode.all:
                    application.CurrentPlaylist.SongRepeat = ITPlaylistRepeatMode.ITPlaylistRepeatModeAll;
                    break;
                case RepeatMode.one:
                    application.CurrentPlaylist.SongRepeat = ITPlaylistRepeatMode.ITPlaylistRepeatModeOne;
                    break;
            }
        }

        public override void VolumeAdjust(int change)
        {
            application.SoundVolume += change;
        }

        public override void Disconnect()
        {
            remoteConnection.Send(new Command(TxCommand.SetMediaAppConnected, false));

            // Unsubscribe from event and stop timer
            updateTimer.Elapsed -= UpdateInformation;
            updateTimer.Stop();

            // Experimental event listeners
            application.OnPlayerPlayEvent -= Application_OnPlayerPlayEvent;
            application.OnPlayerStopEvent -= Application_OnPlayerStopEvent;
            application.OnAboutToPromptUserToQuitEvent -= OnQuitEvent;
            application.OnSoundVolumeChangedEvent -= Application_OnSoundVolumeChangedEvent;

            System.Threading.Thread.Sleep(100);

            try
            {
                // Pause playback
                application.Pause();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
                GC.Collect();
            }
            catch (System.Runtime.InteropServices.InvalidComObjectException ex)
            {
                Console.WriteLine(ex.Message);
            }

            richPresence.Dispose();
        }
    }
}
