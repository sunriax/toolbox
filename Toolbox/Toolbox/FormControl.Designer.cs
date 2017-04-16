namespace Toolbox
{
	partial class FormControl
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelVersionNr = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.progressBarExecute = new System.Windows.Forms.ProgressBar();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBoxApache = new System.Windows.Forms.GroupBox();
			this.labelWebStatus = new System.Windows.Forms.Label();
			this.pictureBoxWebStatus = new System.Windows.Forms.PictureBox();
			this.listBoxReturn = new System.Windows.Forms.ListBox();
			this.buttonWebExecute = new System.Windows.Forms.Button();
			this.checkBoxWebRestart = new System.Windows.Forms.CheckBox();
			this.checkBoxWebStart = new System.Windows.Forms.CheckBox();
			this.checkBoxWebStop = new System.Windows.Forms.CheckBox();
			this.linkLabelWebserver = new System.Windows.Forms.LinkLabel();
			this.groupBoxCommand = new System.Windows.Forms.GroupBox();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.groupBoxSetting = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.checkBoxAutorefresh = new System.Windows.Forms.CheckBox();
			this.labelRefreshUnit = new System.Windows.Forms.Label();
			this.checkBoxAutoreconnect = new System.Windows.Forms.CheckBox();
			this.groupBoxUpload = new System.Windows.Forms.GroupBox();
			this.labelPath = new System.Windows.Forms.Label();
			this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dateiHochladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.neuStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.herunterfahrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verzeichnisHochladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxFTPserver = new System.Windows.Forms.GroupBox();
			this.linkLabelFTPserver = new System.Windows.Forms.LinkLabel();
			this.checkBoxFTPstop = new System.Windows.Forms.CheckBox();
			this.checkBoxFTPstart = new System.Windows.Forms.CheckBox();
			this.checkBoxFTPrestart = new System.Windows.Forms.CheckBox();
			this.buttonFTPExecute = new System.Windows.Forms.Button();
			this.pictureBoxFTPStatus = new System.Windows.Forms.PictureBox();
			this.labelFTPStatus = new System.Windows.Forms.Label();
			this.checkBoxSSHrestart = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelBootImage = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.labelBootWireless = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonBootSearch = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.buttonBootProgram = new System.Windows.Forms.Button();
			this.labelBootInfo = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.groupBoxApache.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebStatus)).BeginInit();
			this.groupBoxCommand.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.groupBoxSetting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBoxUpload.SuspendLayout();
			this.groupBoxFTPserver.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFTPStatus)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveToolStripMenuItem,
            this.FileLoadToolStripMenuItem,
            this.toolStripSeparator1,
            this.QuitToolStripMenuItem});
			this.startToolStripMenuItem.Image = global::Toolbox.ResourceImage.Application;
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.startToolStripMenuItem.Text = "Start";
			// 
			// FileSaveToolStripMenuItem
			// 
			this.FileSaveToolStripMenuItem.Image = global::Toolbox.ResourceImage.Save;
			this.FileSaveToolStripMenuItem.Name = "FileSaveToolStripMenuItem";
			this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.FileSaveToolStripMenuItem.Text = "Datei speicher";
			this.FileSaveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
			// 
			// FileLoadToolStripMenuItem
			// 
			this.FileLoadToolStripMenuItem.Enabled = false;
			this.FileLoadToolStripMenuItem.Image = global::Toolbox.ResourceImage.Folder;
			this.FileLoadToolStripMenuItem.Name = "FileLoadToolStripMenuItem";
			this.FileLoadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.FileLoadToolStripMenuItem.Text = "Datei öffnen";
			this.FileLoadToolStripMenuItem.Click += new System.EventHandler(this.FileLoadToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// QuitToolStripMenuItem
			// 
			this.QuitToolStripMenuItem.Image = global::Toolbox.ResourceImage.Close;
			this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
			this.QuitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.QuitToolStripMenuItem.Text = "Beenden";
			this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionToolStripMenuItem,
            this.HelpSupportToolStripMenuItem});
			this.hilfeToolStripMenuItem.Image = global::Toolbox.ResourceImage.Question;
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// VersionToolStripMenuItem
			// 
			this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
			this.VersionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.VersionToolStripMenuItem.Text = "Version";
			this.VersionToolStripMenuItem.Click += new System.EventHandler(this.VersionToolStripMenuItem_Click);
			// 
			// HelpSupportToolStripMenuItem
			// 
			this.HelpSupportToolStripMenuItem.Image = global::Toolbox.ResourceImage.Star;
			this.HelpSupportToolStripMenuItem.Name = "HelpSupportToolStripMenuItem";
			this.HelpSupportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.HelpSupportToolStripMenuItem.Text = "Hilfe/Support";
			this.HelpSupportToolStripMenuItem.Click += new System.EventHandler(this.HelpSupportToolStripMenuItem_Click);
			// 
			// labelVersionNr
			// 
			this.labelVersionNr.AutoSize = true;
			this.labelVersionNr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVersionNr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelVersionNr.Location = new System.Drawing.Point(573, 418);
			this.labelVersionNr.Name = "labelVersionNr";
			this.labelVersionNr.Size = new System.Drawing.Size(27, 14);
			this.labelVersionNr.TabIndex = 22;
			this.labelVersionNr.Text = "1.0";
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelVersion.Location = new System.Drawing.Point(514, 418);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(53, 14);
			this.labelVersion.TabIndex = 21;
			this.labelVersion.Text = "Version";
			// 
			// progressBarExecute
			// 
			this.progressBarExecute.Location = new System.Drawing.Point(6, 19);
			this.progressBarExecute.Name = "progressBarExecute";
			this.progressBarExecute.Size = new System.Drawing.Size(200, 21);
			this.progressBarExecute.TabIndex = 24;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(7, 19);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(363, 21);
			this.comboBox1.TabIndex = 26;
			// 
			// groupBoxApache
			// 
			this.groupBoxApache.Controls.Add(this.linkLabelWebserver);
			this.groupBoxApache.Controls.Add(this.checkBoxWebStop);
			this.groupBoxApache.Controls.Add(this.checkBoxWebStart);
			this.groupBoxApache.Controls.Add(this.checkBoxWebRestart);
			this.groupBoxApache.Controls.Add(this.buttonWebExecute);
			this.groupBoxApache.Controls.Add(this.pictureBoxWebStatus);
			this.groupBoxApache.Controls.Add(this.labelWebStatus);
			this.groupBoxApache.Location = new System.Drawing.Point(12, 88);
			this.groupBoxApache.Name = "groupBoxApache";
			this.groupBoxApache.Size = new System.Drawing.Size(182, 145);
			this.groupBoxApache.TabIndex = 28;
			this.groupBoxApache.TabStop = false;
			this.groupBoxApache.Text = "Webserver";
			// 
			// labelWebStatus
			// 
			this.labelWebStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWebStatus.Location = new System.Drawing.Point(6, 20);
			this.labelWebStatus.Name = "labelWebStatus";
			this.labelWebStatus.Size = new System.Drawing.Size(51, 14);
			this.labelWebStatus.TabIndex = 0;
			this.labelWebStatus.Text = "Status";
			this.labelWebStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pictureBoxWebStatus
			// 
			this.pictureBoxWebStatus.Location = new System.Drawing.Point(63, 20);
			this.pictureBoxWebStatus.Name = "pictureBoxWebStatus";
			this.pictureBoxWebStatus.Size = new System.Drawing.Size(91, 14);
			this.pictureBoxWebStatus.TabIndex = 1;
			this.pictureBoxWebStatus.TabStop = false;
			// 
			// listBoxReturn
			// 
			this.listBoxReturn.BackColor = System.Drawing.SystemColors.Control;
			this.listBoxReturn.FormattingEnabled = true;
			this.listBoxReturn.Location = new System.Drawing.Point(6, 46);
			this.listBoxReturn.Name = "listBoxReturn";
			this.listBoxReturn.Size = new System.Drawing.Size(200, 69);
			this.listBoxReturn.TabIndex = 0;
			// 
			// buttonWebExecute
			// 
			this.buttonWebExecute.Location = new System.Drawing.Point(10, 93);
			this.buttonWebExecute.Name = "buttonWebExecute";
			this.buttonWebExecute.Size = new System.Drawing.Size(144, 23);
			this.buttonWebExecute.TabIndex = 5;
			this.buttonWebExecute.Text = "Ausführen";
			this.buttonWebExecute.UseVisualStyleBackColor = true;
			// 
			// checkBoxWebRestart
			// 
			this.checkBoxWebRestart.AutoSize = true;
			this.checkBoxWebRestart.Location = new System.Drawing.Point(43, 40);
			this.checkBoxWebRestart.Name = "checkBoxWebRestart";
			this.checkBoxWebRestart.Size = new System.Drawing.Size(83, 17);
			this.checkBoxWebRestart.TabIndex = 6;
			this.checkBoxWebRestart.Text = "Neu Starten";
			this.checkBoxWebRestart.UseVisualStyleBackColor = true;
			// 
			// checkBoxWebStart
			// 
			this.checkBoxWebStart.AutoSize = true;
			this.checkBoxWebStart.Location = new System.Drawing.Point(43, 55);
			this.checkBoxWebStart.Name = "checkBoxWebStart";
			this.checkBoxWebStart.Size = new System.Drawing.Size(60, 17);
			this.checkBoxWebStart.TabIndex = 7;
			this.checkBoxWebStart.Text = "Starten";
			this.checkBoxWebStart.UseVisualStyleBackColor = true;
			// 
			// checkBoxWebStop
			// 
			this.checkBoxWebStop.AutoSize = true;
			this.checkBoxWebStop.Location = new System.Drawing.Point(43, 70);
			this.checkBoxWebStop.Name = "checkBoxWebStop";
			this.checkBoxWebStop.Size = new System.Drawing.Size(66, 17);
			this.checkBoxWebStop.TabIndex = 8;
			this.checkBoxWebStop.Text = "Stoppen";
			this.checkBoxWebStop.UseVisualStyleBackColor = true;
			// 
			// linkLabelWebserver
			// 
			this.linkLabelWebserver.AutoSize = true;
			this.linkLabelWebserver.Location = new System.Drawing.Point(7, 119);
			this.linkLabelWebserver.Name = "linkLabelWebserver";
			this.linkLabelWebserver.Size = new System.Drawing.Size(104, 13);
			this.linkLabelWebserver.TabIndex = 9;
			this.linkLabelWebserver.TabStop = true;
			this.linkLabelWebserver.Text = "Link zum Webserver";
			// 
			// groupBoxCommand
			// 
			this.groupBoxCommand.Controls.Add(this.comboBox1);
			this.groupBoxCommand.Location = new System.Drawing.Point(12, 27);
			this.groupBoxCommand.Name = "groupBoxCommand";
			this.groupBoxCommand.Size = new System.Drawing.Size(378, 55);
			this.groupBoxCommand.TabIndex = 29;
			this.groupBoxCommand.TabStop = false;
			this.groupBoxCommand.Text = "Befehl";
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.Controls.Add(this.listBoxReturn);
			this.groupBoxStatus.Controls.Add(this.progressBarExecute);
			this.groupBoxStatus.Location = new System.Drawing.Point(399, 27);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Size = new System.Drawing.Size(213, 125);
			this.groupBoxStatus.TabIndex = 30;
			this.groupBoxStatus.TabStop = false;
			this.groupBoxStatus.Text = "Status";
			// 
			// groupBoxSetting
			// 
			this.groupBoxSetting.Controls.Add(this.checkBoxSSHrestart);
			this.groupBoxSetting.Controls.Add(this.checkBoxAutoreconnect);
			this.groupBoxSetting.Controls.Add(this.labelRefreshUnit);
			this.groupBoxSetting.Controls.Add(this.checkBoxAutorefresh);
			this.groupBoxSetting.Controls.Add(this.numericUpDown1);
			this.groupBoxSetting.Location = new System.Drawing.Point(399, 160);
			this.groupBoxSetting.Name = "groupBoxSetting";
			this.groupBoxSetting.Size = new System.Drawing.Size(200, 101);
			this.groupBoxSetting.TabIndex = 31;
			this.groupBoxSetting.TabStop = false;
			this.groupBoxSetting.Text = "Einstellungen";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(103, 19);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(55, 20);
			this.numericUpDown1.TabIndex = 0;
			// 
			// checkBoxAutorefresh
			// 
			this.checkBoxAutorefresh.AutoSize = true;
			this.checkBoxAutorefresh.Location = new System.Drawing.Point(6, 20);
			this.checkBoxAutorefresh.Name = "checkBoxAutorefresh";
			this.checkBoxAutorefresh.Size = new System.Drawing.Size(80, 17);
			this.checkBoxAutorefresh.TabIndex = 1;
			this.checkBoxAutorefresh.Text = "Autorefresh";
			this.checkBoxAutorefresh.UseVisualStyleBackColor = true;
			// 
			// labelRefreshUnit
			// 
			this.labelRefreshUnit.AutoSize = true;
			this.labelRefreshUnit.Location = new System.Drawing.Point(164, 21);
			this.labelRefreshUnit.Name = "labelRefreshUnit";
			this.labelRefreshUnit.Size = new System.Drawing.Size(30, 13);
			this.labelRefreshUnit.TabIndex = 2;
			this.labelRefreshUnit.Text = "[sec]";
			// 
			// checkBoxAutoreconnect
			// 
			this.checkBoxAutoreconnect.AutoSize = true;
			this.checkBoxAutoreconnect.Location = new System.Drawing.Point(6, 43);
			this.checkBoxAutoreconnect.Name = "checkBoxAutoreconnect";
			this.checkBoxAutoreconnect.Size = new System.Drawing.Size(162, 17);
			this.checkBoxAutoreconnect.TabIndex = 3;
			this.checkBoxAutoreconnect.Text = "Verbindung Wiederherstellen";
			this.checkBoxAutoreconnect.UseVisualStyleBackColor = true;
			// 
			// groupBoxUpload
			// 
			this.groupBoxUpload.Controls.Add(this.labelPath);
			this.groupBoxUpload.Location = new System.Drawing.Point(399, 267);
			this.groupBoxUpload.Name = "groupBoxUpload";
			this.groupBoxUpload.Size = new System.Drawing.Size(200, 75);
			this.groupBoxUpload.TabIndex = 32;
			this.groupBoxUpload.TabStop = false;
			this.groupBoxUpload.Text = "Datei Hochladen (Drag/Drop)";
			// 
			// labelPath
			// 
			this.labelPath.AutoSize = true;
			this.labelPath.Location = new System.Drawing.Point(6, 59);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(53, 13);
			this.labelPath.TabIndex = 33;
			this.labelPath.Text = "Dateipfad";
			// 
			// serverToolStripMenuItem
			// 
			this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiHochladenToolStripMenuItem,
            this.verzeichnisHochladenToolStripMenuItem,
            this.toolStripSeparator2,
            this.neuStartenToolStripMenuItem,
            this.herunterfahrenToolStripMenuItem});
			this.serverToolStripMenuItem.Image = global::Toolbox.ResourceImage.Server;
			this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
			this.serverToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.serverToolStripMenuItem.Text = "Server";
			// 
			// dateiHochladenToolStripMenuItem
			// 
			this.dateiHochladenToolStripMenuItem.Enabled = false;
			this.dateiHochladenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Toggle;
			this.dateiHochladenToolStripMenuItem.Name = "dateiHochladenToolStripMenuItem";
			this.dateiHochladenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.dateiHochladenToolStripMenuItem.Text = "Datei hochladen";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
			// 
			// neuStartenToolStripMenuItem
			// 
			this.neuStartenToolStripMenuItem.Enabled = false;
			this.neuStartenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Timer;
			this.neuStartenToolStripMenuItem.Name = "neuStartenToolStripMenuItem";
			this.neuStartenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.neuStartenToolStripMenuItem.Text = "Neu Starten";
			// 
			// herunterfahrenToolStripMenuItem
			// 
			this.herunterfahrenToolStripMenuItem.Enabled = false;
			this.herunterfahrenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Delete;
			this.herunterfahrenToolStripMenuItem.Name = "herunterfahrenToolStripMenuItem";
			this.herunterfahrenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.herunterfahrenToolStripMenuItem.Text = "Herunterfahren";
			// 
			// verzeichnisHochladenToolStripMenuItem
			// 
			this.verzeichnisHochladenToolStripMenuItem.Enabled = false;
			this.verzeichnisHochladenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Class;
			this.verzeichnisHochladenToolStripMenuItem.Name = "verzeichnisHochladenToolStripMenuItem";
			this.verzeichnisHochladenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.verzeichnisHochladenToolStripMenuItem.Text = "Verzeichnis hochladen";
			// 
			// groupBoxFTPserver
			// 
			this.groupBoxFTPserver.Controls.Add(this.linkLabelFTPserver);
			this.groupBoxFTPserver.Controls.Add(this.checkBoxFTPstop);
			this.groupBoxFTPserver.Controls.Add(this.checkBoxFTPstart);
			this.groupBoxFTPserver.Controls.Add(this.checkBoxFTPrestart);
			this.groupBoxFTPserver.Controls.Add(this.buttonFTPExecute);
			this.groupBoxFTPserver.Controls.Add(this.pictureBoxFTPStatus);
			this.groupBoxFTPserver.Controls.Add(this.labelFTPStatus);
			this.groupBoxFTPserver.Location = new System.Drawing.Point(208, 88);
			this.groupBoxFTPserver.Name = "groupBoxFTPserver";
			this.groupBoxFTPserver.Size = new System.Drawing.Size(182, 145);
			this.groupBoxFTPserver.TabIndex = 33;
			this.groupBoxFTPserver.TabStop = false;
			this.groupBoxFTPserver.Text = "FTP-Server";
			// 
			// linkLabelFTPserver
			// 
			this.linkLabelFTPserver.AutoSize = true;
			this.linkLabelFTPserver.Location = new System.Drawing.Point(7, 119);
			this.linkLabelFTPserver.Name = "linkLabelFTPserver";
			this.linkLabelFTPserver.Size = new System.Drawing.Size(106, 13);
			this.linkLabelFTPserver.TabIndex = 9;
			this.linkLabelFTPserver.TabStop = true;
			this.linkLabelFTPserver.Text = "Link zum FTP-Server";
			// 
			// checkBoxFTPstop
			// 
			this.checkBoxFTPstop.AutoSize = true;
			this.checkBoxFTPstop.Location = new System.Drawing.Point(43, 70);
			this.checkBoxFTPstop.Name = "checkBoxFTPstop";
			this.checkBoxFTPstop.Size = new System.Drawing.Size(66, 17);
			this.checkBoxFTPstop.TabIndex = 8;
			this.checkBoxFTPstop.Text = "Stoppen";
			this.checkBoxFTPstop.UseVisualStyleBackColor = true;
			// 
			// checkBoxFTPstart
			// 
			this.checkBoxFTPstart.AutoSize = true;
			this.checkBoxFTPstart.Location = new System.Drawing.Point(43, 55);
			this.checkBoxFTPstart.Name = "checkBoxFTPstart";
			this.checkBoxFTPstart.Size = new System.Drawing.Size(60, 17);
			this.checkBoxFTPstart.TabIndex = 7;
			this.checkBoxFTPstart.Text = "Starten";
			this.checkBoxFTPstart.UseVisualStyleBackColor = true;
			// 
			// checkBoxFTPrestart
			// 
			this.checkBoxFTPrestart.AutoSize = true;
			this.checkBoxFTPrestart.Location = new System.Drawing.Point(43, 40);
			this.checkBoxFTPrestart.Name = "checkBoxFTPrestart";
			this.checkBoxFTPrestart.Size = new System.Drawing.Size(83, 17);
			this.checkBoxFTPrestart.TabIndex = 6;
			this.checkBoxFTPrestart.Text = "Neu Starten";
			this.checkBoxFTPrestart.UseVisualStyleBackColor = true;
			// 
			// buttonFTPExecute
			// 
			this.buttonFTPExecute.Location = new System.Drawing.Point(10, 93);
			this.buttonFTPExecute.Name = "buttonFTPExecute";
			this.buttonFTPExecute.Size = new System.Drawing.Size(144, 23);
			this.buttonFTPExecute.TabIndex = 5;
			this.buttonFTPExecute.Text = "Ausführen";
			this.buttonFTPExecute.UseVisualStyleBackColor = true;
			// 
			// pictureBoxFTPStatus
			// 
			this.pictureBoxFTPStatus.Location = new System.Drawing.Point(63, 20);
			this.pictureBoxFTPStatus.Name = "pictureBoxFTPStatus";
			this.pictureBoxFTPStatus.Size = new System.Drawing.Size(91, 14);
			this.pictureBoxFTPStatus.TabIndex = 1;
			this.pictureBoxFTPStatus.TabStop = false;
			// 
			// labelFTPStatus
			// 
			this.labelFTPStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFTPStatus.Location = new System.Drawing.Point(6, 20);
			this.labelFTPStatus.Name = "labelFTPStatus";
			this.labelFTPStatus.Size = new System.Drawing.Size(51, 14);
			this.labelFTPStatus.TabIndex = 0;
			this.labelFTPStatus.Text = "Status";
			this.labelFTPStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxSSHrestart
			// 
			this.checkBoxSSHrestart.AutoSize = true;
			this.checkBoxSSHrestart.Location = new System.Drawing.Point(6, 66);
			this.checkBoxSSHrestart.Name = "checkBoxSSHrestart";
			this.checkBoxSSHrestart.Size = new System.Drawing.Size(142, 17);
			this.checkBoxSSHrestart.TabIndex = 4;
			this.checkBoxSSHrestart.Text = "SSH Server Neu Starten";
			this.checkBoxSSHrestart.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelBootInfo);
			this.groupBox1.Controls.Add(this.buttonBootProgram);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.buttonBootSearch);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.labelBootWireless);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.labelBootImage);
			this.groupBox1.Location = new System.Drawing.Point(12, 239);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(378, 103);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Boot Argumente";
			// 
			// labelBootImage
			// 
			this.labelBootImage.AutoSize = true;
			this.labelBootImage.Location = new System.Drawing.Point(7, 20);
			this.labelBootImage.Name = "labelBootImage";
			this.labelBootImage.Size = new System.Drawing.Size(36, 13);
			this.labelBootImage.TabIndex = 0;
			this.labelBootImage.Text = "Binary";
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "boot256.bin",
            "boot128.bin"});
			this.comboBox2.Location = new System.Drawing.Point(63, 17);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(79, 21);
			this.comboBox2.TabIndex = 1;
			// 
			// labelBootWireless
			// 
			this.labelBootWireless.AutoSize = true;
			this.labelBootWireless.Location = new System.Drawing.Point(7, 46);
			this.labelBootWireless.Name = "labelBootWireless";
			this.labelBootWireless.Size = new System.Drawing.Size(47, 13);
			this.labelBootWireless.TabIndex = 2;
			this.labelBootWireless.Text = "Wireless";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(63, 43);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(79, 20);
			this.textBox1.TabIndex = 3;
			// 
			// buttonBootSearch
			// 
			this.buttonBootSearch.Location = new System.Drawing.Point(295, 41);
			this.buttonBootSearch.Name = "buttonBootSearch";
			this.buttonBootSearch.Size = new System.Drawing.Size(75, 23);
			this.buttonBootSearch.TabIndex = 4;
			this.buttonBootSearch.Text = "Suchen";
			this.buttonBootSearch.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(148, 43);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(141, 20);
			this.textBox2.TabIndex = 5;
			// 
			// buttonBootProgram
			// 
			this.buttonBootProgram.Location = new System.Drawing.Point(63, 69);
			this.buttonBootProgram.Name = "buttonBootProgram";
			this.buttonBootProgram.Size = new System.Drawing.Size(226, 23);
			this.buttonBootProgram.TabIndex = 6;
			this.buttonBootProgram.Text = "Übernehmen";
			this.buttonBootProgram.UseVisualStyleBackColor = true;
			// 
			// labelBootInfo
			// 
			this.labelBootInfo.AutoSize = true;
			this.labelBootInfo.Location = new System.Drawing.Point(145, 20);
			this.labelBootInfo.Name = "labelBootInfo";
			this.labelBootInfo.Size = new System.Drawing.Size(227, 13);
			this.labelBootInfo.TabIndex = 7;
			this.labelBootInfo.Text = "Abhängig von der Speichergröße des Linux uC";
			// 
			// FormControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBoxFTPserver);
			this.Controls.Add(this.groupBoxUpload);
			this.Controls.Add(this.groupBoxSetting);
			this.Controls.Add(this.groupBoxStatus);
			this.Controls.Add(this.groupBoxCommand);
			this.Controls.Add(this.groupBoxApache);
			this.Controls.Add(this.labelVersionNr);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormControl";
			this.Text = "Server Verwaltung";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormControl_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxApache.ResumeLayout(false);
			this.groupBoxApache.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebStatus)).EndInit();
			this.groupBoxCommand.ResumeLayout(false);
			this.groupBoxStatus.ResumeLayout(false);
			this.groupBoxSetting.ResumeLayout(false);
			this.groupBoxSetting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBoxUpload.ResumeLayout(false);
			this.groupBoxUpload.PerformLayout();
			this.groupBoxFTPserver.ResumeLayout(false);
			this.groupBoxFTPserver.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFTPStatus)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportToolStripMenuItem;
		private System.Windows.Forms.Label labelVersionNr;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.ProgressBar progressBarExecute;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBoxApache;
		private System.Windows.Forms.PictureBox pictureBoxWebStatus;
		private System.Windows.Forms.Label labelWebStatus;
		private System.Windows.Forms.ListBox listBoxReturn;
		private System.Windows.Forms.Button buttonWebExecute;
		private System.Windows.Forms.CheckBox checkBoxWebStop;
		private System.Windows.Forms.CheckBox checkBoxWebStart;
		private System.Windows.Forms.CheckBox checkBoxWebRestart;
		private System.Windows.Forms.LinkLabel linkLabelWebserver;
		private System.Windows.Forms.GroupBox groupBoxCommand;
		private System.Windows.Forms.GroupBox groupBoxStatus;
		private System.Windows.Forms.GroupBox groupBoxSetting;
		private System.Windows.Forms.Label labelRefreshUnit;
		private System.Windows.Forms.CheckBox checkBoxAutorefresh;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.CheckBox checkBoxAutoreconnect;
		private System.Windows.Forms.GroupBox groupBoxUpload;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dateiHochladenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem neuStartenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem herunterfahrenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verzeichnisHochladenToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxFTPserver;
		private System.Windows.Forms.LinkLabel linkLabelFTPserver;
		private System.Windows.Forms.CheckBox checkBoxFTPstop;
		private System.Windows.Forms.CheckBox checkBoxFTPstart;
		private System.Windows.Forms.CheckBox checkBoxFTPrestart;
		private System.Windows.Forms.Button buttonFTPExecute;
		private System.Windows.Forms.PictureBox pictureBoxFTPStatus;
		private System.Windows.Forms.Label labelFTPStatus;
		private System.Windows.Forms.CheckBox checkBoxSSHrestart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelBootImage;
		private System.Windows.Forms.Button buttonBootSearch;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label labelBootWireless;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button buttonBootProgram;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label labelBootInfo;
	}
}