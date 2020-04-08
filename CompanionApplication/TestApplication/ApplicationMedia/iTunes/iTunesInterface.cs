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

        public Interface(ref RemoteConnection remoteConnection)
        {
            this.remoteConnection = remoteConnection;
            application = new iTunesApp();

            updateTimer.Elapsed += UpdateInformation;
            updateTimer.Start();
        }

        protected override void UpdateInformation(object sender, ElapsedEventArgs e)
        {
            // Get current track
            IITTrack currentTrack = application.CurrentTrack;
            
            // Grab values
            currentValues.title = currentTrack.Name;
            currentValues.artist = currentTrack.Artist;
            currentValues.album = currentTrack.Album;
            currentValues.trackLength = currentTrack.Duration;

            currentValues.playbackPos = application.PlayerPosition;
            currentValues.volume = application.SoundVolume;
            currentValues.shuffle = application.CurrentPlaylist.Shuffle;
            currentValues.filepath = application.CurrentStreamURL;

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

            // Convert iTunes play status
            switch (application.PlayerState)
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

            // If values have changed, update remote display
            if (!Equals(currentValues, prevValues)) { UpdateRemote(); }
        }

        private void UpdateRemote()
        {
            // List of commands to send
            List<string> toSend = new List<string>();

            // Shorthand for settings
            var settings = Properties.Settings.Default;

            // If changed, add to list of commands to send
            if ((currentValues.title != prevValues.title)) { toSend.Add("TITLE(" + currentValues.title + ")"); }
            if (((currentValues.artist != prevValues.artist)) && !settings.DisplayAlbum) { toSend.Add("ARTIST(" + currentValues.artist + ")"); }
            if ((currentValues.trackLength != prevValues.trackLength)) { toSend.Add("LENGTH(" + currentValues.trackLength + ")"); }
            if (((currentValues.album != prevValues.album)) && settings.DisplayAlbum) { toSend.Add("ALBUM(" + currentValues.album + ")"); }

            // Send updated data to remote
            if ((currentValues.volume != prevValues.volume)) { toSend.Add("VOLUME(" + currentValues.volume + ")"); }
            if (currentValues.playStatus != prevValues.playStatus) { toSend.Add("STATUS(" + currentValues.playStatus + ")"); }
            if (currentValues.playbackPos != prevValues.playbackPos) { toSend.Add("TIME(" + currentValues.playbackPos + ")"); }

            // Shuffle
            if (currentValues.shuffle != prevValues.shuffle)
            {
                string onOff = null;
                if (currentValues.shuffle) { onOff = "on"; } else { onOff = "off"; }
                toSend.Add("SHUFFLE(" + onOff + ")");
            }

            // Repeat mode
            if (currentValues.repeatMode != prevValues.repeatMode)
            {
                remoteConnection.Send("REPEATMODE(" + (int)currentValues.repeatMode + ")");
            }

            // Send data to remote
            remoteConnection.Send(toSend);

            // update previous values
            prevValues = currentValues;
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
            // Stop playback
            application.Stop();
        }
    }
}
