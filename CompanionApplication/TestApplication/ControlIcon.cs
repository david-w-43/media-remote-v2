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

        private MenuItem VLCSwitch, iTunesSwitch, clockSwitch, systemSwitch;
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
                    new MenuItem("Backlight", new MenuItem[]
                    {
                        new MenuItem("100%", SetBacklight),
                        new MenuItem("80%", SetBacklight),
                        new MenuItem("60%", SetBacklight),
                        new MenuItem("40%", SetBacklight),
                        new MenuItem("20%", SetBacklight),
                        new MenuItem("10%", SetBacklight)
                    }),
                    new MenuItem("-"), // Separator
                    new MenuItem("Discord", new MenuItem[]
                    {
                        DVFull = new MenuItem("Full", SetDiscordVerbosity) { RadioCheck = true },
                        DVLimited = new MenuItem("Limited", SetDiscordVerbosity) { RadioCheck = true },
                        DVOff = new MenuItem("Off", SetDiscordVerbosity) { RadioCheck = true },
                    }),
                    new MenuItem("-"), // Separator
                    //VLCSwitch = new MenuItem("VLC", MediaApplicationChange) { RadioCheck = true },
                    //iTunesSwitch = new MenuItem("iTunes", MediaApplicationChange) { RadioCheck = true },

                    clockSwitch = new MenuItem("Clock", SetMode) {RadioCheck = true },
                    iTunesSwitch = new MenuItem("iTunes", SetMode) {RadioCheck = true },
                    VLCSwitch = new MenuItem("VLC", SetMode) {RadioCheck = true },
                    systemSwitch = new MenuItem("System", SetMode) {RadioCheck = true },

                    new MenuItem("-"), // Separator
                    new MenuItem("Exit", Exit), // Exits application
                }),
                Visible = true
            };

            trayIcon.ContextMenu.Popup += UpdateValues;


            //if ((ApplicationMedia.Interface)Properties.Settings.Default.ApplicationMediaInterface 
            //    == ApplicationMedia.Interface.VLC)
            //{
            //    VLCSwitch.Checked = true;
            //    iTunesSwitch.Checked = false;
            //}
            //else
            //{
            //    VLCSwitch.Checked = false;
            //    iTunesSwitch.Checked = true;
            //}

            //switch ((Discord.DiscordVerbosity)Properties.Settings.Default.DiscordRPVerbosity)
            //{
            //    case Discord.DiscordVerbosity.off:
            //        DVOff.Checked = true;
            //        break;
            //    case Discord.DiscordVerbosity.full:
            //        DVFull.Checked = true;
            //        break;
            //    case Discord.DiscordVerbosity.limited:
            //        DVLimited.Checked = true;
            //        break;
            //}

            // Create new connection, remote and SAC
            richPresence = new Discord.DiscordRichPresence();
            connection = new RemoteConnection(ref commandHandler, ref richPresence);
        }

        /// <summary>
        /// Updates values when opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateValues(object sender, EventArgs e)
        {
            // Update mode
            DeviceMode mode = commandHandler.GetDeviceMode();

            // Set all to unchecked
            clockSwitch.Checked = iTunesSwitch.Checked = VLCSwitch.Checked = systemSwitch.Checked = false;

            // Set appropriate checkbox
            switch (mode)
            {
                case DeviceMode.Clock:
                    clockSwitch.Checked = true;
                    break;
                case DeviceMode.ApplicationControl:
                    switch ((ApplicationMedia.Interface)Properties.Settings.Default.ApplicationMediaInterface)
                    {
                        case ApplicationMedia.Interface.VLC:
                            VLCSwitch.Checked = true;
                            break;
                        case ApplicationMedia.Interface.iTunes:
                            iTunesSwitch.Checked = true;
                            break;
                    }
                    break;
                case DeviceMode.SystemMedia:
                    systemSwitch.Checked = true;
                    break;
            }

            // Update Discord RP verbosity
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

            commandHandler.Disconnect();
            richPresence.Dispose();

            Application.Exit();
        }

        void OpenSettings(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(ref connection);
            DialogResult result = settingsForm.ShowDialog();
            // If user pressed OK
            if (result == DialogResult.OK)
            {
                // Update remote with relevant settings
                connection.UpdateRemote();
            }
        }

        //void MediaApplicationChange(object sender, EventArgs e)
        //{
        //    // Change settings and 
        //    if (sender == VLCSwitch && !VLCSwitch.Checked)
        //    {
        //        VLCSwitch.Checked = true;
        //        iTunesSwitch.Checked = false;
        //        Properties.Settings.Default.ApplicationMediaInterface = 0;
        //    }
        //    else if (sender == iTunesSwitch && !iTunesSwitch.Checked)
        //    {
        //        VLCSwitch.Checked = false;
        //        iTunesSwitch.Checked = true;
        //        Properties.Settings.Default.ApplicationMediaInterface = 1;
        //    }

        //    Properties.Settings.Default.Save();

        //    DeviceMode mode = commandHandler.GetDeviceMode();
        //    if (mode == DeviceMode.ApplicationControl)
        //    {
        //        // Restart application with new applicaiton
        //        //Application.Restart();
        //        commandHandler.RefreshApplication();
        //    }
        //}

        void SetMode(object sender, EventArgs e)
        {
            // Uncheck all menuitems and check sender
            foreach (MenuItem item in ((MenuItem)sender).Parent.MenuItems)
            {
                item.Checked = false;
            }
            ((MenuItem)sender).Checked = true;

            switch (((MenuItem)sender).Text)
            {
                case "VLC":
                    Properties.Settings.Default.ApplicationMediaInterface = 0;
                    Properties.Settings.Default.Save();
                    commandHandler.ModeSwitch(DeviceMode.ApplicationControl);
                    //commandHandler.RefreshApplication();
                    break;
                case "iTunes":
                    Properties.Settings.Default.ApplicationMediaInterface = 1;
                    Properties.Settings.Default.Save();
                    commandHandler.ModeSwitch(DeviceMode.ApplicationControl);
                    //commandHandler.RefreshApplication();
                    break;
                case "System":
                    commandHandler.ModeSwitch(DeviceMode.SystemMedia);
                    break;
                case "Clock":
                    commandHandler.ModeSwitch(DeviceMode.Clock);
                    break;
            }
        }

        void SetDiscordVerbosity(object sender, EventArgs e)
        {
            // If verbosity switched
            if (sender == DVOff && !DVOff.Checked)
            {
                // Write to settings
                Properties.Settings.Default.DiscordRPVerbosity = (int)Discord.DiscordVerbosity.off;

                // Check buttons as appropriate
                DVOff.Checked = true;
                DVFull.Checked = false;
                DVLimited.Checked = false;
            }
            else if (sender == DVFull && !DVFull.Checked)
            {
                Properties.Settings.Default.DiscordRPVerbosity = (int)Discord.DiscordVerbosity.full;
                DVOff.Checked = false;
                DVFull.Checked = true;
                DVLimited.Checked = false;
            }
            else if (sender == DVLimited && !DVLimited.Checked)
            {
                Properties.Settings.Default.DiscordRPVerbosity = (int)Discord.DiscordVerbosity.limited;
                DVOff.Checked = false;
                DVFull.Checked = false;
                DVLimited.Checked = true;
            }
            richPresence.UpdateVerbosity((Discord.DiscordVerbosity)Properties.Settings.Default.DiscordRPVerbosity);

            // Save settings
            Properties.Settings.Default.Save();
        }

        void SetBacklight(object sender, EventArgs e)
        {
            //// Uncheck all menuitems and check sender
            //foreach (MenuItem item in ((MenuItem)sender).Parent.MenuItems)
            //{
            //    item.Checked = false;
            //}
            //((MenuItem)sender).Checked = true;


            // Get value of button
            float value = int.Parse(((MenuItem)sender).Text.TrimEnd('%')) / 100f;
            // Use quadratic approximation for perceived brightness
            int scaled = (int)Math.Round((Math.Pow(value, 2) * 255));

            connection.Send(new Command(TxCommand.SetBrightness, scaled));
        }
    }
}