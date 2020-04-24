using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanionApplication
{
    public partial class Settings : Form
    {
        RemoteConnection remoteConnection;
        public Settings(ref RemoteConnection remoteConnection)
        {
            InitializeComponent();
            this.remoteConnection = remoteConnection;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // Shorthand name for settings
            var settings = Properties.Settings.Default;

            // Load settings into form
            txtVLCFilepath.Text = settings.VLCPath;
            txtHostname.Text = settings.TCPHostname;
            txtPort.Text = settings.TCPPort.ToString();

            if (settings.DisplayAlbum) { radioAlbum.Checked = true; radioArtist.Checked = false; }
            else { radioAlbum.Checked = false; radioArtist.Checked = true; }

            if (settings.ScrollLongText) { checkBoxScroll.Checked = true; }
            else {checkBoxScroll.Checked = false; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Shorthand name for settings
            var settings = Properties.Settings.Default;

            bool allOK = true;

            // Validate and save all settings

            // Filepath
            if (System.IO.File.Exists(txtVLCFilepath.Text)) { settings.VLCPath = txtVLCFilepath.Text; }
            else
            {
                MessageBox.Show("File \"" + txtVLCFilepath.Text + "\" does not exist", "Invalid settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOK = false;
            }

            // Hostname
            settings.TCPHostname = txtHostname.Text;

            // Port number
            if (int.TryParse(txtPort.Text, out int port))
            {
                settings.TCPPort = port;
            }
            else
            {
                MessageBox.Show("TCP Port must be an integer", "Invalid settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOK = false;
            }

            if (radioAlbum.Checked) { settings.DisplayAlbum = true; }
            else { settings.DisplayAlbum = false; }

            if (checkBoxScroll.Checked) { settings.ScrollLongText = true; }
            else { settings.ScrollLongText = false; }

            if (allOK)
            {
                settings.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClockSync_Click(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;

            // Chip uses 2-digit year
            int year = t.Year - 2000;

            string timeString = t.Second.ToString() + '|' + t.Minute.ToString() + '|' + t.Hour.ToString() +
                '|' + ((int)t.DayOfWeek).ToString() + '|' + t.Day.ToString() + '|' + t.Month.ToString() +
                '|' + year.ToString();

            remoteConnection.Send(new Command("UPDTIME", timeString));
        }
    }
}
