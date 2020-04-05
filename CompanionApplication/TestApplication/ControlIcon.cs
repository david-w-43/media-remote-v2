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
        SystemAudioController systemAudio;

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
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

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
    }
}
