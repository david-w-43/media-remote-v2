using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanionApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if program already running
            string applicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(applicationName);

            // Exits application if more than one exist
            if (processes.Count() > 1) {
                Application.Exit();
            }
            else
            {
                // Continue as normal
                // Runs the system tray icon
                Application.Run(new ControlIcon());
            }
        }
    }
}
