using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace CompanionApplication.Discord
{
    public enum DiscordVerbosity { off, full, limited };

    public class DiscordRichPresence
    {
        private DiscordRpcClient client;
        private DiscordVerbosity verbosity;

        private const string key = "697575193358368899";

        public DiscordRichPresence()
        {
            UpdateVerbosity((DiscordVerbosity)Properties.Settings.Default.DiscordRPVerbosity);
        }

        /// <summary>
        /// Updates rich presence with current values
        /// </summary>
        /// <param name="values"></param>
        public void UpdatePresence(ApplicationMedia.Values values)
        {
            
            if (client != null)
            {
                // Client needs to be initialised first
                if (client.IsDisposed) { InitialiseClient(); }

                if (!client.IsDisposed && client.IsInitialized)
                {
                    if (values.playStatus == ApplicationMedia.PlayStatus.playing || values.playStatus == ApplicationMedia.PlayStatus.paused)
                    {
                        // Get large image
                        Assets images = new Assets();
                        switch (values.player)
                        {
                            case ApplicationMedia.Interface.VLC:
                                images.LargeImageKey = "vlc";
                                images.LargeImageText = "VLC Media Player";
                                break;
                            case ApplicationMedia.Interface.iTunes:
                                images.LargeImageKey = "itunes";
                                images.LargeImageText = "iTunes";
                                break;
                        }

                        string prefix, hiddenTitle, artist;
                        switch (values.mediaType)
                        {
                            case ApplicationMedia.MediaType.video:
                                prefix = "Watching video: ";
                                hiddenTitle = "Watching a video";
                                artist = "";
                                break;
                            default:
                                prefix = "Listening to: ";
                                hiddenTitle = "Listening to music";
                                artist = "by " + values.artist;
                                break;
                        }

                        switch (verbosity)
                        {
                            case DiscordVerbosity.full:

                                // Shorten title and artist if necessary
                                string title = prefix + values.title;
                                if (title.Length >= 127) { title = title.Substring(0, 123) + "..."; }
                                if (artist.Length >= 127) { artist = artist.Substring(0, 123) + "..."; }

                                client.SetPresence(new RichPresence()
                                {
                                    Details = title,
                                    State = artist,
                                    Assets = images,
                                    Timestamps = new Timestamps()
                                    {
                                        End = DateTime.UtcNow + TimeSpan.FromSeconds(values.trackLength - values.playbackPos)
                                    }
                                });
                                break;
                            case DiscordVerbosity.limited:
                                client.SetPresence(new RichPresence()
                                {
                                    Details = hiddenTitle,
                                    State = "https://github.com/david-w-43/media-remote-v2",
                                    Assets = images
                                });
                                break;
                        }
                    }
                    else
                    {
                        // If not playing anything
                        client.ClearPresence();
                    }
                }
            }
        }

        /// <summary>
        /// Updates verbosity of rich presence
        /// </summary>
        /// <param name="verbosity"></param>
        public void UpdateVerbosity(DiscordVerbosity verbosity)
        {
            this.verbosity = verbosity;
            if (verbosity == DiscordVerbosity.off) { Dispose(); }
            else
            {
                if (client != null ) { client.Dispose(); }
                InitialiseClient();
            }
        }

        /// <summary>
        /// Initialises Discord RP client
        /// </summary>
        public void InitialiseClient()
        {
            client = new DiscordRpcClient(key);
            client.Initialize();
        }

        /// <summary>
        /// Disposes of the Discord RP client
        /// </summary>
        public void Dispose()
        {
            if (client != null)
            {
                client.ClearPresence();
                client.Dispose();
            }
        }

        /// <summary>
        /// Returns true if client is disposed or null
        /// </summary>
        /// <returns></returns>
        public bool IsDisposed()
        {
            if ((client == null) || (client.IsDisposed))
            {
                return true;
            } else { return false; }
        }
    }
}
