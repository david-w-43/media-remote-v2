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

        private MenuItem VLCSwitch, iTunesSwitch;

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

            // Create new connection, remote and SAC
            connection = new RemoteConnection(commandHandler);
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
        }
    }
}
