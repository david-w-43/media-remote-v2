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

        public void UpdatePresence(ApplicationMedia.Values values)
        {
            if (client != null)
            {
                // Client needs to be initialised first
                if (client.IsDisposed) { InitialiseClient(); }

                if (!client.IsDisposed && client.IsInitialized)
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
                            client.SetPresence(new RichPresence()
                            {
                                Details = prefix + values.title,
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
            }
        }

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

        public void InitialiseClient()
        {
            client = new DiscordRpcClient(key);
            client.Initialize();
        }

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
        }

        public bool IsDisposed()
        {
            if ((client == null) || (client.IsDisposed))
            {
                return true;
            } else { return false; }
        }
    }
}
