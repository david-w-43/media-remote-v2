namespace CompanionApplication
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.txtVLCFilepath = new System.Windows.Forms.TextBox();
            this.tableVLCControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblVLCFilepath = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioGroup = new System.Windows.Forms.GroupBox();
            this.radioAlbum = new System.Windows.Forms.RadioButton();
            this.radioArtist = new System.Windows.Forms.RadioButton();
            this.checkBoxScroll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanelTabs = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageDevice = new System.Windows.Forms.TabPage();
            this.tabPageVLC = new System.Windows.Forms.TabPage();
            this.tabPageMedia = new System.Windows.Forms.TabPage();
            this.btnClockSync = new System.Windows.Forms.Button();
            this.tableVLCControls.SuspendLayout();
            this.radioGroup.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.tableLayoutPanelTabs.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageDevice.SuspendLayout();
            this.tabPageVLC.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVLCFilepath
            // 
            this.txtVLCFilepath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVLCFilepath.Location = new System.Drawing.Point(110, 3);
            this.txtVLCFilepath.Multiline = true;
            this.txtVLCFilepath.Name = "txtVLCFilepath";
            this.txtVLCFilepath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVLCFilepath.Size = new System.Drawing.Size(314, 78);
            this.txtVLCFilepath.TabIndex = 0;
            // 
            // tableVLCControls
            // 
            this.tableVLCControls.ColumnCount = 2;
            this.tableVLCControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.05855F));
            this.tableVLCControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.94145F));
            this.tableVLCControls.Controls.Add(this.txtVLCFilepath, 1, 0);
            this.tableVLCControls.Controls.Add(this.lblVLCFilepath, 0, 0);
            this.tableVLCControls.Controls.Add(this.lblHostname, 0, 1);
            this.tableVLCControls.Controls.Add(this.lblPort, 0, 2);
            this.tableVLCControls.Controls.Add(this.txtHostname, 1, 1);
            this.tableVLCControls.Controls.Add(this.txtPort, 1, 2);
            this.tableVLCControls.Controls.Add(this.label1, 0, 3);
            this.tableVLCControls.Controls.Add(this.radioGroup, 1, 3);
            this.tableVLCControls.Controls.Add(this.checkBoxScroll, 1, 4);
            this.tableVLCControls.Controls.Add(this.label2, 0, 4);
            this.tableVLCControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableVLCControls.Location = new System.Drawing.Point(3, 3);
            this.tableVLCControls.Name = "tableVLCControls";
            this.tableVLCControls.RowCount = 5;
            this.tableVLCControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableVLCControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableVLCControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableVLCControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableVLCControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableVLCControls.Size = new System.Drawing.Size(427, 249);
            this.tableVLCControls.TabIndex = 2;
            // 
            // lblVLCFilepath
            // 
            this.lblVLCFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVLCFilepath.AutoSize = true;
            this.lblVLCFilepath.Location = new System.Drawing.Point(37, 0);
            this.lblVLCFilepath.Name = "lblVLCFilepath";
            this.lblVLCFilepath.Size = new System.Drawing.Size(67, 13);
            this.lblVLCFilepath.TabIndex = 1;
            this.lblVLCFilepath.Text = "VLC filepath:";
            // 
            // lblHostname
            // 
            this.lblHostname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHostname.AutoSize = true;
            this.lblHostname.Location = new System.Drawing.Point(22, 84);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(82, 13);
            this.lblHostname.TabIndex = 2;
            this.lblHostname.Text = "TCP Hostname:";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(51, 110);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(53, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "TCP Port:";
            // 
            // txtHostname
            // 
            this.txtHostname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHostname.Location = new System.Drawing.Point(110, 87);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(314, 20);
            this.txtHostname.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(110, 113);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(314, 20);
            this.txtPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Display artist / album:";
            // 
            // radioGroup
            // 
            this.radioGroup.Controls.Add(this.radioAlbum);
            this.radioGroup.Controls.Add(this.radioArtist);
            this.radioGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup.Location = new System.Drawing.Point(110, 139);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Size = new System.Drawing.Size(314, 72);
            this.radioGroup.TabIndex = 4;
            this.radioGroup.TabStop = false;
            // 
            // radioAlbum
            // 
            this.radioAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioAlbum.AutoSize = true;
            this.radioAlbum.Location = new System.Drawing.Point(6, 43);
            this.radioAlbum.Name = "radioAlbum";
            this.radioAlbum.Size = new System.Drawing.Size(54, 17);
            this.radioAlbum.TabIndex = 1;
            this.radioAlbum.TabStop = true;
            this.radioAlbum.Text = "Album";
            this.radioAlbum.UseVisualStyleBackColor = true;
            // 
            // radioArtist
            // 
            this.radioArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioArtist.AutoSize = true;
            this.radioArtist.Location = new System.Drawing.Point(6, 19);
            this.radioArtist.Name = "radioArtist";
            this.radioArtist.Size = new System.Drawing.Size(48, 17);
            this.radioArtist.TabIndex = 0;
            this.radioArtist.TabStop = true;
            this.radioArtist.Text = "Artist";
            this.radioArtist.UseVisualStyleBackColor = true;
            // 
            // checkBoxScroll
            // 
            this.checkBoxScroll.AutoSize = true;
            this.checkBoxScroll.Location = new System.Drawing.Point(110, 217);
            this.checkBoxScroll.Name = "checkBoxScroll";
            this.checkBoxScroll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxScroll.TabIndex = 5;
            this.checkBoxScroll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scroll long text:";
            // 
            // tableButtons
            // 
            this.tableButtons.ColumnCount = 2;
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.Controls.Add(this.btnOK, 1, 0);
            this.tableButtons.Controls.Add(this.btnCancel, 0, 0);
            this.tableButtons.Location = new System.Drawing.Point(3, 290);
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.RowCount = 1;
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.Size = new System.Drawing.Size(441, 59);
            this.tableButtons.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(230, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(201, 39);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(10, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanelTabs
            // 
            this.tableLayoutPanelTabs.ColumnCount = 1;
            this.tableLayoutPanelTabs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTabs.Controls.Add(this.tableButtons, 0, 1);
            this.tableLayoutPanelTabs.Controls.Add(this.tabControlSettings, 0, 0);
            this.tableLayoutPanelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTabs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTabs.Name = "tableLayoutPanelTabs";
            this.tableLayoutPanelTabs.RowCount = 2;
            this.tableLayoutPanelTabs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTabs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTabs.Size = new System.Drawing.Size(447, 352);
            this.tableLayoutPanelTabs.TabIndex = 3;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageDevice);
            this.tabControlSettings.Controls.Add(this.tabPageVLC);
            this.tabControlSettings.Controls.Add(this.tabPageMedia);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(3, 3);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(441, 281);
            this.tabControlSettings.TabIndex = 3;
            // 
            // tabPageDevice
            // 
            this.tabPageDevice.Controls.Add(this.btnClockSync);
            this.tabPageDevice.Location = new System.Drawing.Point(4, 22);
            this.tabPageDevice.Name = "tabPageDevice";
            this.tabPageDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDevice.Size = new System.Drawing.Size(433, 255);
            this.tabPageDevice.TabIndex = 0;
            this.tabPageDevice.Text = "Device";
            this.tabPageDevice.UseVisualStyleBackColor = true;
            // 
            // tabPageVLC
            // 
            this.tabPageVLC.Controls.Add(this.tableVLCControls);
            this.tabPageVLC.Location = new System.Drawing.Point(4, 22);
            this.tabPageVLC.Name = "tabPageVLC";
            this.tabPageVLC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVLC.Size = new System.Drawing.Size(433, 255);
            this.tabPageVLC.TabIndex = 1;
            this.tabPageVLC.Text = "VLC";
            this.tabPageVLC.UseVisualStyleBackColor = true;
            // 
            // tabPageMedia
            // 
            this.tabPageMedia.Location = new System.Drawing.Point(4, 22);
            this.tabPageMedia.Name = "tabPageMedia";
            this.tabPageMedia.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMedia.Size = new System.Drawing.Size(433, 255);
            this.tabPageMedia.TabIndex = 2;
            this.tabPageMedia.Text = "System Media";
            this.tabPageMedia.UseVisualStyleBackColor = true;
            // 
            // btnClockSync
            // 
            this.btnClockSync.Location = new System.Drawing.Point(122, 67);
            this.btnClockSync.Name = "btnClockSync";
            this.btnClockSync.Size = new System.Drawing.Size(159, 23);
            this.btnClockSync.TabIndex = 0;
            this.btnClockSync.Text = "Synchronise Clock";
            this.btnClockSync.UseVisualStyleBackColor = true;
            this.btnClockSync.Click += new System.EventHandler(this.btnClockSync_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 352);
            this.Controls.Add(this.tableLayoutPanelTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableVLCControls.ResumeLayout(false);
            this.tableVLCControls.PerformLayout();
            this.radioGroup.ResumeLayout(false);
            this.radioGroup.PerformLayout();
            this.tableButtons.ResumeLayout(false);
            this.tableLayoutPanelTabs.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageDevice.ResumeLayout(false);
            this.tabPageVLC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVLCFilepath;
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableVLCControls;
        private System.Windows.Forms.Label lblVLCFilepath;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox radioGroup;
        private System.Windows.Forms.RadioButton radioAlbum;
        private System.Windows.Forms.RadioButton radioArtist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTabs;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageDevice;
        private System.Windows.Forms.TabPage tabPageVLC;
        private System.Windows.Forms.TabPage tabPageMedia;
        private System.Windows.Forms.CheckBox checkBoxScroll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClockSync;
    }
}