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

        public Interface(ref RemoteConnection remoteConnection, ref Discord.DiscordRichPresence richPresence)
        {
            currentValues.player = ApplicationMedia.Interface.iTunes;

            this.remoteConnection = remoteConnection;
            this.richPresence = richPresence;

            if (richPresence.IsDisposed()) { richPresence = new Discord.DiscordRichPresence(); }

            application = new iTunesApp();

            //application.OnPlayerPlayEvent += PlayEventHandler;
            //application.OnSoundVolumeChangedEvent += VolumeChangedHandler;
            //application.OnAboutToPromptUserToQuitEvent += Disconnect;

            updateTimer.Elapsed += UpdateInformation;
            updateTimer.Start();

            remoteConnection.Send(new Command("PLAYING", true));
        }

        //private void VolumeChangedHandler(int newVolume)
        //{
        //    Console.WriteLine("Volume " + newVolume);
        //}

        //private void PlayEventHandler(object iTrack)
        //{
        //    //Console.WriteLine("Play");
        //    IITTrack currentTrack = (IITTrack)iTrack;
        //    //Console.WriteLine(track.Name);

        //    currentValues.title = currentTrack.Name;
        //    currentValues.artist = currentTrack.Artist;
        //    currentValues.album = currentTrack.Album;
        //    currentValues.trackLength = currentTrack.Duration;
        //}

        protected override void UpdateInformation(object sender, ElapsedEventArgs e)
        {
            // Get current track
            IITTrack currentTrack = application.CurrentTrack;

            // Convert iTunes play status
            ITPlayerState state = application.PlayerState;
            switch (state)
            {
                case ITPlayerState.ITPlayerStateStopped:
                    currentValues.playStatus = PlayStatus.stopped;
                    break;
                case ITPlayerState.ITPlayerStatePlaying:
                    currentValues.playStatus = PlayStatus.playing;
                    break;
                case ITPlayerState.ITPlayerStateFastForward:
                    currentValues.playStatus = PlayStatus.fastforward;
                    break;
                case ITPlayerState.ITPlayerStateRewind:
                    currentValues.playStatus = PlayStatus.rewind;
                    break;
            }

            //if (state != ITPlayerState.ITPlayerStateStopped)
            //{
                // Grab values
                currentValues.title = currentTrack.Name;
                currentValues.artist = currentTrack.Artist;
                currentValues.album = currentTrack.Album;
                currentValues.trackLength = currentTrack.Duration;

                currentValues.playbackPos = application.PlayerPosition;
                currentValues.volume = application.SoundVolume;
                currentValues.shuffle = application.CurrentPlaylist.Shuffle;

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
            // If values have changed, update remote display
            if (!Equals(currentValues, prevValues)) { UpdateRemote(); }
        }

        private void UpdateRemote()
        {
            // List of commands to send
            List<Command> toSend = new List<Command>();

            // Shorthand for settings
            var settings = Properties.Settings.Default;

            // If changed, add to list of commands to send
            if ((currentValues.title != prevValues.title)) { toSend.Add(new Command("TITLE", currentValues.title)); }
            if (((currentValues.artist != prevValues.artist)) && !settings.DisplayAlbum) { toSend.Add(new Command("ARTIST", currentValues.artist)); }
            if ((currentValues.trackLength != prevValues.trackLength)) { toSend.Add(new Command("LENGTH", currentValues.trackLength)); }
            if (((currentValues.album != prevValues.album)) && settings.DisplayAlbum) { toSend.Add(new Command("ALBUM", currentValues.album)); }

            // Send updated data to remote
            if ((currentValues.volume != prevValues.volume)) { toSend.Add(new Command("VOLUME", (int)currentValues.volume)); }
            if (currentValues.playStatus != prevValues.playStatus) { toSend.Add(new Command("STATUS", (int)currentValues.playStatus)); }
            if (currentValues.playbackPos != prevValues.playbackPos) { toSend.Add(new Command("TIME", currentValues.playbackPos)); }

            // Shuffle
            if (currentValues.shuffle != prevValues.shuffle)
            {
                toSend.Add(new Command("SHUFFLE", currentValues.shuffle));
            }

            // Repeat mode
            if (currentValues.repeatMode != prevValues.repeatMode)
            {
                toSend.Add(new Command("REPEATMODE", (int)currentValues.repeatMode));
            }

            // Send data to remote
            PushUpdate(toSend);
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
            remoteConnection.Send(new Command("PLAYING", false));

            updateTimer.Stop();

            try
            {
                // Pause playback
                application.Pause();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
                System.GC.Collect();
            }
            catch (System.Runtime.InteropServices.InvalidComObjectException ex)
            {
                Console.WriteLine(ex.Message);
            }

            richPresence.Dispose();
        }
    }
}
