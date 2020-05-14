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
            this.tableVLCControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblVLCFilepath = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtVLCFilepath = new System.Windows.Forms.TextBox();
            this.btnFindVLC = new System.Windows.Forms.Button();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanelTabs = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageDevice = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClockSync = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageApplication = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxScroll = new System.Windows.Forms.CheckBox();
            this.radioGroup = new System.Windows.Forms.GroupBox();
            this.radioAlbum = new System.Windows.Forms.RadioButton();
            this.radioArtist = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageVLC = new System.Windows.Forms.TabPage();
            this.tabPageMedia = new System.Windows.Forms.TabPage();
            this.groupWheelSensitivity = new System.Windows.Forms.GroupBox();
            this.radioSensitivity100 = new System.Windows.Forms.RadioButton();
            this.radioSensitivity50 = new System.Windows.Forms.RadioButton();
            this.radioSensitivity25 = new System.Windows.Forms.RadioButton();
            this.tableVLCControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.tableLayoutPanelTabs.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageDevice.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPageApplication.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.radioGroup.SuspendLayout();
            this.tabPageVLC.SuspendLayout();
            this.groupWheelSensitivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableVLCControls
            // 
            this.tableVLCControls.ColumnCount = 2;
            this.tableVLCControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.05855F));
            this.tableVLCControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.94145F));
            this.tableVLCControls.Controls.Add(this.lblVLCFilepath, 0, 0);
            this.tableVLCControls.Controls.Add(this.lblHostname, 0, 1);
            this.tableVLCControls.Controls.Add(this.lblPort, 0, 2);
            this.tableVLCControls.Controls.Add(this.txtHostname, 1, 1);
            this.tableVLCControls.Controls.Add(this.txtPort, 1, 2);
            this.tableVLCControls.Controls.Add(this.tableLayoutPanel1, 1, 0);
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
            this.lblHostname.Location = new System.Drawing.Point(22, 106);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(82, 13);
            this.lblHostname.TabIndex = 2;
            this.lblHostname.Text = "TCP Hostname:";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(51, 132);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(53, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "TCP Port:";
            // 
            // txtHostname
            // 
            this.txtHostname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHostname.Location = new System.Drawing.Point(110, 109);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(314, 20);
            this.txtHostname.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(110, 135);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(314, 20);
            this.txtPort.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.98089F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.01911F));
            this.tableLayoutPanel1.Controls.Add(this.txtVLCFilepath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFindVLC, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(110, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 100);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // txtVLCFilepath
            // 
            this.txtVLCFilepath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVLCFilepath.Location = new System.Drawing.Point(3, 3);
            this.txtVLCFilepath.Multiline = true;
            this.txtVLCFilepath.Name = "txtVLCFilepath";
            this.txtVLCFilepath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVLCFilepath.Size = new System.Drawing.Size(241, 94);
            this.txtVLCFilepath.TabIndex = 1;
            // 
            // btnFindVLC
            // 
            this.btnFindVLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFindVLC.Location = new System.Drawing.Point(250, 3);
            this.btnFindVLC.Name = "btnFindVLC";
            this.btnFindVLC.Size = new System.Drawing.Size(61, 94);
            this.btnFindVLC.TabIndex = 2;
            this.btnFindVLC.Text = "Find...";
            this.btnFindVLC.UseVisualStyleBackColor = true;
            this.btnFindVLC.Click += new System.EventHandler(this.btnFindVLC_Click);
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
            this.tabControlSettings.Controls.Add(this.tabPageApplication);
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
            this.tabPageDevice.Controls.Add(this.tableLayoutPanel3);
            this.tabPageDevice.Location = new System.Drawing.Point(4, 22);
            this.tabPageDevice.Name = "tabPageDevice";
            this.tabPageDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDevice.Size = new System.Drawing.Size(433, 255);
            this.tabPageDevice.TabIndex = 0;
            this.tabPageDevice.Text = "Device";
            this.tabPageDevice.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.33724F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.66277F));
            this.tableLayoutPanel3.Controls.Add(this.btnClockSync, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupWheelSensitivity, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.31727F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.68273F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(427, 249);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnClockSync
            // 
            this.btnClockSync.Location = new System.Drawing.Point(123, 3);
            this.btnClockSync.Name = "btnClockSync";
            this.btnClockSync.Size = new System.Drawing.Size(159, 23);
            this.btnClockSync.TabIndex = 0;
            this.btnClockSync.Text = "Synchronise Clock";
            this.btnClockSync.UseVisualStyleBackColor = true;
            this.btnClockSync.Click += new System.EventHandler(this.btnClockSync_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Synchronise Real Time Clock";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Wheel Sensitivity";
            // 
            // tabPageApplication
            // 
            this.tabPageApplication.Controls.Add(this.tableLayoutPanel2);
            this.tabPageApplication.Location = new System.Drawing.Point(4, 22);
            this.tabPageApplication.Name = "tabPageApplication";
            this.tabPageApplication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApplication.Size = new System.Drawing.Size(433, 255);
            this.tabPageApplication.TabIndex = 3;
            this.tabPageApplication.Text = "Application Media";
            this.tabPageApplication.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.44497F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.55504F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxScroll, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioGroup, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(427, 249);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // checkBoxScroll
            // 
            this.checkBoxScroll.AutoSize = true;
            this.checkBoxScroll.Location = new System.Drawing.Point(133, 86);
            this.checkBoxScroll.Name = "checkBoxScroll";
            this.checkBoxScroll.Size = new System.Drawing.Size(15, 14);
            this.checkBoxScroll.TabIndex = 9;
            this.checkBoxScroll.UseVisualStyleBackColor = true;
            // 
            // radioGroup
            // 
            this.radioGroup.Controls.Add(this.radioAlbum);
            this.radioGroup.Controls.Add(this.radioArtist);
            this.radioGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup.Location = new System.Drawing.Point(133, 3);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Size = new System.Drawing.Size(291, 77);
            this.radioGroup.TabIndex = 8;
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Scroll long text:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Display artist / album:";
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
            // groupWheelSensitivity
            // 
            this.groupWheelSensitivity.Controls.Add(this.radioSensitivity25);
            this.groupWheelSensitivity.Controls.Add(this.radioSensitivity50);
            this.groupWheelSensitivity.Controls.Add(this.radioSensitivity100);
            this.groupWheelSensitivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupWheelSensitivity.Location = new System.Drawing.Point(123, 76);
            this.groupWheelSensitivity.Name = "groupWheelSensitivity";
            this.groupWheelSensitivity.Size = new System.Drawing.Size(301, 170);
            this.groupWheelSensitivity.TabIndex = 2;
            this.groupWheelSensitivity.TabStop = false;
            this.groupWheelSensitivity.Text = "Wheel Sensitivity";
            // 
            // radioSensitivity100
            // 
            this.radioSensitivity100.AutoSize = true;
            this.radioSensitivity100.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioSensitivity100.Location = new System.Drawing.Point(7, 20);
            this.radioSensitivity100.Name = "radioSensitivity100";
            this.radioSensitivity100.Size = new System.Drawing.Size(51, 17);
            this.radioSensitivity100.TabIndex = 0;
            this.radioSensitivity100.TabStop = true;
            this.radioSensitivity100.Text = "100%";
            this.radioSensitivity100.UseVisualStyleBackColor = true;
            this.radioSensitivity100.CheckedChanged += new System.EventHandler(this.SensitivityChanged);
            // 
            // radioSensitivity50
            // 
            this.radioSensitivity50.AutoSize = true;
            this.radioSensitivity50.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioSensitivity50.Location = new System.Drawing.Point(7, 43);
            this.radioSensitivity50.Name = "radioSensitivity50";
            this.radioSensitivity50.Size = new System.Drawing.Size(45, 17);
            this.radioSensitivity50.TabIndex = 0;
            this.radioSensitivity50.TabStop = true;
            this.radioSensitivity50.Text = "50%";
            this.radioSensitivity50.UseVisualStyleBackColor = true;
            this.radioSensitivity50.CheckedChanged += new System.EventHandler(this.SensitivityChanged);
            // 
            // radioSensitivity25
            // 
            this.radioSensitivity25.AutoSize = true;
            this.radioSensitivity25.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioSensitivity25.Location = new System.Drawing.Point(6, 66);
            this.radioSensitivity25.Name = "radioSensitivity25";
            this.radioSensitivity25.Size = new System.Drawing.Size(45, 17);
            this.radioSensitivity25.TabIndex = 0;
            this.radioSensitivity25.TabStop = true;
            this.radioSensitivity25.Text = "25%";
            this.radioSensitivity25.UseVisualStyleBackColor = true;
            this.radioSensitivity25.CheckedChanged += new System.EventHandler(this.SensitivityChanged);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableButtons.ResumeLayout(false);
            this.tableLayoutPanelTabs.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageDevice.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPageApplication.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.radioGroup.ResumeLayout(false);
            this.radioGroup.PerformLayout();
            this.tabPageVLC.ResumeLayout(false);
            this.groupWheelSensitivity.ResumeLayout(false);
            this.groupWheelSensitivity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableVLCControls;
        private System.Windows.Forms.Label lblVLCFilepath;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTabs;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageDevice;
        private System.Windows.Forms.TabPage tabPageVLC;
        private System.Windows.Forms.TabPage tabPageMedia;
        private System.Windows.Forms.Button btnClockSync;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtVLCFilepath;
        private System.Windows.Forms.Button btnFindVLC;
        private System.Windows.Forms.TabPage tabPageApplication;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBoxScroll;
        private System.Windows.Forms.GroupBox radioGroup;
        private System.Windows.Forms.RadioButton radioAlbum;
        private System.Windows.Forms.RadioButton radioArtist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupWheelSensitivity;
        private System.Windows.Forms.RadioButton radioSensitivity100;
        private System.Windows.Forms.RadioButton radioSensitivity50;
        private System.Windows.Forms.RadioButton radioSensitivity25;
    }
}