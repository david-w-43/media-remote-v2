using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CompanionApplication.ApplicationMedia
{
    public enum Interface { VLC, iTunes };
    public enum RepeatMode { off, all, one };
    public enum PlayStatus { playing, paused, stopped, fastforward, rewind };
    public enum MediaType { audio, video };

    /// <summary>
    /// Stores playback values
    /// </summary>
    public struct Values
    {
        public volatile Interface player;
        public volatile string title;
        public volatile string artist;
        public volatile string album;
        public volatile int trackLength;
        public volatile int playbackPos;
        public volatile int volume; // 0 - 100
        public volatile RepeatMode repeatMode;
        public volatile bool shuffle;
        public volatile string filepath;
        public volatile PlayStatus playStatus;
        public volatile MediaType mediaType;
    }

    /// <summary>
    /// Provides methods for interfacing with media player applications
    /// </summary>
    class ApplicationInterface
    {
        protected Values currentValues, prevValues = new Values();

        protected RemoteConnection remoteConnection;
        protected Discord.DiscordRichPresence richPresence;
        protected CommandHandler commandHandler;

        protected Timer updateTimer = new Timer {
            AutoReset = true,
            Interval = 100,
        };

        /// <summary>
        /// Goes to the next track
        /// </summary>
        public virtual void Next() { }

        /// <summary>
        /// Goes to the beginning of the track or previous if at beginning of current track
        /// </summary>
        public virtual void Prev() { }

        /// <summary>
        /// Toggles pause
        /// </summary>
        public virtual void PlayPause() { }

        /// <summary>
        /// Toggles shuffle
        /// </summary>
        public virtual void ShuffleToggle()
        {
            currentValues.shuffle = !currentValues.shuffle;
            Shuffle(currentValues.shuffle);
        }

        /// <summary>
        /// Sets shuffle to either on or off
        /// </summary>
        /// <param name="enabled"></param>
        public virtual void Shuffle (bool enabled) { }

        /// <summary>
        /// Increments repeat mode (Off -> All -> One)
        /// </summary>
        public virtual void RepeatInc()
        {
            // If not the last repeat mode
            if (currentValues.repeatMode != (RepeatMode)2)
            {
                // Increment it
                currentValues.repeatMode += 1;
            }
            else
            {
                // Set to off
                currentValues.repeatMode = RepeatMode.off;
            }

            Repeat(currentValues.repeatMode);
        }

        /// <summary>
        /// Sets repeat mode to particular value
        /// </summary>
        /// <param name="mode"></param>
        public virtual void Repeat(RepeatMode mode) { }

        /// <summary>
        /// Adjusts volume by set signed amount
        /// </summary>
        /// <param name="change"></param>
        public virtual void VolumeAdjust(int change) { }

        /// <summary>
        /// Disconnects from interface
        /// </summary>
        public virtual void Disconnect() { }

        /// <summary>
        /// Returns the current values
        /// </summary>
        /// <returns></returns>
        public Values GetValues()
        {
            return currentValues;
        }

        /// <summary>
        /// Pushes updated values to remote and Discord
        /// </summary>
        /// <param name="commands"></param>
        protected void PushUpdate(List<Command> commands)
        {
            // Push commands to remote
            remoteConnection.Send(commands);

            // Update Discord RP
            if (!richPresence.IsDisposed())
            {
                richPresence.UpdatePresence(currentValues);
            }

            // Update previous values
            prevValues = currentValues;
        }
    }
}
