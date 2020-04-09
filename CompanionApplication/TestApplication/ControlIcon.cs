using System;
using System.Windows.Forms;

namespace CompanionApplication
{
    /// <summary>
    /// System tray icon
    /// </summary>
    public class ControlIcon : ApplicationContext
    {
        private NotifyIcon trayIcon;
        
        public RemoteConnection connection;
        public CommandHandler commandHandler;
        private Discord.DiscordRichPresence richPresence;

        private MenuItem VLCSwitch, iTunesSwitch;
        private MenuItem DVOff, DVFull, DVLimited;

        /// <summary>
        /// Initialises a system tray icon
        /// </summary>
        public ControlIcon()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.display,
                ContextMenu = new ContextMenu(new MenuItem[] {

                new MenuItem("Settings", OpenSettings), // Opens the settings form
                new MenuItem("-"), // Separator
                new MenuItem("Discord", new MenuItem[]
                {
                    DVFull = new MenuItem("Full", SetDiscordVerbosity) { RadioCheck = true },
                    DVLimited = new MenuItem("Limited", SetDiscordVerbosity) { RadioCheck = true },
                    DVOff = new MenuItem("Off", SetDiscordVerbosity) { RadioCheck = true },
                }),
                new MenuItem("-"), // Separator
                VLCSwitch = new MenuItem("VLC", MediaApplicationChange) { RadioCheck = true },
                iTunesSwitch = new MenuItem("iTunes", MediaApplicationChange) { RadioCheck = true },
                new MenuItem("-"), // Separator
                new MenuItem("Exit", Exit), // Exits application
            }),
                Visible = true
            };

            if ((ApplicationMedia.Interface)Properties.Settings.Default.ApplicationMediaInterface 
                == ApplicationMedia.Interface.VLC)
            {
                VLCSwitch.Checked = true;
                iTunesSwitch.Checked = false;
            }
            else
            {
                VLCSwitch.Checked = false;
                iTunesSwitch.Checked = true;
            }

            switch ((Discord.DiscordVerbosity)Properties.Settings.Default.DiscordRPVerbosity)
            {
                case Discord.DiscordVerbosity.off:
                    DVOff.Checked = true;
                    break;
                case Discord.DiscordVerbosity.full:
                    DVFull.Checked = true;
                    break;
                case Discord.DiscordVerbosity.limited:
                    DVLimited.Checked = true;
                    break;
            }

            // Create new connection, remote and SAC
            richPresence = new Discord.DiscordRichPresence();
            connection = new RemoteConnection(ref commandHandler, ref richPresence);
        }

        /// <summary>
        /// Cleanly exits the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            richPresence.Dispose();

            Application.Exit();
        }

        void OpenSettings(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            DialogResult result = settingsForm.ShowDialog();
            // If user pressed OK
            if (result == DialogResult.OK)
            {
                // Update remote with relevant settings
                connection.UpdateRemote();
            }
        }

        void MediaApplicationChange(object sender, EventArgs e)
        {
            // Change settings and 
            if (sender == VLCSwitch)
            {
                VLCSwitch.Checked = true;
                iTunesSwitch.Checked = false;
                Properties.Settings.Default.ApplicationMediaInterface = 0;
            }
            else if (sender == iTunesSwitch)
            {
                VLCSwitch.Checked = false;
                iTunesSwitch.Checked = true;
                Properties.Settings.Default.ApplicationMediaInterface = 1;
            }

            Properties.Settings.Default.Save();

            DeviceMode mode = commandHandler.GetDeviceMode();
            if (mode == DeviceMode.ApplicationControl)
            {
                // Restart application with new applicaiton
                //Application.Restart();
                commandHandler.RefreshApplication();
            }
        }

        void SetDiscordVerbosity(object sender, EventArgs e)
        {
            if (sender == DVOff)
            {
                Properties.Settings.Default.DiscordRPVerbosity = (int)Discord.DiscordVerbosity.off;
                DVOff.Checked = true;
                DVFull.Checked = false;
                DVLimited.Checked = false;
            }
            else if (sender == DVFull)
            {
                Properties.Settings.Default.DiscordRPVerbosity = (int)Discord.DiscordVerbosity.full;
                DVOff.Checked = false;
                DVFull.Checked = true;
                DVLimited.Checked = false;
            }
            else if (sender == DVLimited)
            {
                Properties.Settings.Default.DiscordRPVerbosity = (int)Discord.DiscordVerbosity.limited;
                DVOff.Checked = false;
                DVFull.Checked = false;
                DVLimited.Checked = true;
            }
            richPresence.UpdateVerbosity((Discord.DiscordVerbosity)Properties.Settings.Default.DiscordRPVerbosity);
        }
    }
}