namespace Toolbox
{
	partial class FormMain
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.groupBoxDebug = new System.Windows.Forms.GroupBox();
			this.labelError = new System.Windows.Forms.Label();
			this.labelDebug = new System.Windows.Forms.Label();
			this.groupBoxLinux = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBoxTool = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBoxFunction = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBoxFPGA = new System.Windows.Forms.GroupBox();
			this.gb_FPGA_Text = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.labelVersionNr = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.UARTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eepromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ds1307ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.JTAGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xilinxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.interfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.funktionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.image2RawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.raw2ImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deutschAustriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.englishGreatBritanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.espanolSpainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SystemSpeakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.AriettaG25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GithubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxDebug.SuspendLayout();
			this.groupBoxLinux.SuspendLayout();
			this.groupBoxTool.SuspendLayout();
			this.groupBoxFunction.SuspendLayout();
			this.groupBoxFPGA.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxDebug
			// 
			this.groupBoxDebug.BackColor = System.Drawing.SystemColors.Control;
			this.groupBoxDebug.Controls.Add(this.labelError);
			this.groupBoxDebug.Controls.Add(this.labelDebug);
			this.groupBoxDebug.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			this.groupBoxDebug.Location = new System.Drawing.Point(21, 366);
			this.groupBoxDebug.Name = "groupBoxDebug";
			this.groupBoxDebug.Size = new System.Drawing.Size(163, 63);
			this.groupBoxDebug.TabIndex = 19;
			this.groupBoxDebug.TabStop = false;
			this.groupBoxDebug.Text = "Debug Modus";
			this.groupBoxDebug.Visible = false;
			// 
			// labelError
			// 
			this.labelError.AutoSize = true;
			this.labelError.BackColor = System.Drawing.SystemColors.Control;
			this.labelError.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			this.labelError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelError.Location = new System.Drawing.Point(7, 35);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(144, 14);
			this.labelError.TabIndex = 1;
			this.labelError.Text = "keine Fehler erkannt";
			// 
			// labelDebug
			// 
			this.labelDebug.AutoSize = true;
			this.labelDebug.BackColor = System.Drawing.Color.Red;
			this.labelDebug.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			this.labelDebug.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelDebug.Location = new System.Drawing.Point(7, 20);
			this.labelDebug.Name = "labelDebug";
			this.labelDebug.Size = new System.Drawing.Size(64, 14);
			this.labelDebug.TabIndex = 0;
			this.labelDebug.Text = "Aktiviert";
			// 
			// groupBoxLinux
			// 
			this.groupBoxLinux.Controls.Add(this.label3);
			this.groupBoxLinux.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.groupBoxLinux.Location = new System.Drawing.Point(224, 299);
			this.groupBoxLinux.Name = "groupBoxLinux";
			this.groupBoxLinux.Size = new System.Drawing.Size(180, 51);
			this.groupBoxLinux.TabIndex = 18;
			this.groupBoxLinux.TabStop = false;
			this.groupBoxLinux.Text = "Linux";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(6, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 30);
			this.label3.TabIndex = 0;
			this.label3.Text = "SSH / Web / File";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBoxTool
			// 
			this.groupBoxTool.Controls.Add(this.label4);
			this.groupBoxTool.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.groupBoxTool.Location = new System.Drawing.Point(21, 182);
			this.groupBoxTool.Name = "groupBoxTool";
			this.groupBoxTool.Size = new System.Drawing.Size(200, 51);
			this.groupBoxTool.TabIndex = 17;
			this.groupBoxTool.TabStop = false;
			this.groupBoxTool.Text = "Tools";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(6, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(188, 30);
			this.label4.TabIndex = 0;
			this.label4.Text = "I2C EEPROMer / FIFO Bridge / UART Interface";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBoxFunction
			// 
			this.groupBoxFunction.Controls.Add(this.label5);
			this.groupBoxFunction.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.groupBoxFunction.Location = new System.Drawing.Point(407, 182);
			this.groupBoxFunction.Name = "groupBoxFunction";
			this.groupBoxFunction.Size = new System.Drawing.Size(200, 51);
			this.groupBoxFunction.TabIndex = 16;
			this.groupBoxFunction.TabStop = false;
			this.groupBoxFunction.Text = "Funktionen";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(6, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(188, 30);
			this.label5.TabIndex = 0;
			this.label5.Text = "PatternGenerator";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBoxFPGA
			// 
			this.groupBoxFPGA.Controls.Add(this.gb_FPGA_Text);
			this.groupBoxFPGA.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.groupBoxFPGA.Location = new System.Drawing.Point(224, 62);
			this.groupBoxFPGA.Name = "groupBoxFPGA";
			this.groupBoxFPGA.Size = new System.Drawing.Size(180, 51);
			this.groupBoxFPGA.TabIndex = 15;
			this.groupBoxFPGA.TabStop = false;
			this.groupBoxFPGA.Text = "FPGA";
			// 
			// gb_FPGA_Text
			// 
			this.gb_FPGA_Text.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.gb_FPGA_Text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gb_FPGA_Text.Location = new System.Drawing.Point(6, 18);
			this.gb_FPGA_Text.Name = "gb_FPGA_Text";
			this.gb_FPGA_Text.Size = new System.Drawing.Size(168, 30);
			this.gb_FPGA_Text.TabIndex = 0;
			this.gb_FPGA_Text.Text = "Konfiguration / Debug / JTAG";
			this.gb_FPGA_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.toolboxToolStripMenuItem,
            this.funktionenToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 20;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// labelVersionNr
			// 
			this.labelVersionNr.AutoSize = true;
			this.labelVersionNr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelVersionNr.Location = new System.Drawing.Point(568, 418);
			this.labelVersionNr.Name = "labelVersionNr";
			this.labelVersionNr.Size = new System.Drawing.Size(27, 14);
			this.labelVersionNr.TabIndex = 22;
			this.labelVersionNr.Text = "1.0";
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelVersion.Location = new System.Drawing.Point(509, 418);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(53, 14);
			this.labelVersion.TabIndex = 21;
			this.labelVersion.Text = "Version";
			// 
			// pictureBoxLogo
			// 
			this.pictureBoxLogo.BackgroundImage = global::Toolbox.ResourceImage.elmLogo;
			this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pictureBoxLogo.Location = new System.Drawing.Point(224, 116);
			this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBoxLogo.Name = "pictureBoxLogo";
			this.pictureBoxLogo.Size = new System.Drawing.Size(180, 180);
			this.pictureBoxLogo.TabIndex = 14;
			this.pictureBoxLogo.TabStop = false;
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
			this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.FileSaveToolStripMenuItem.Text = "Datei Speichern";
			this.FileSaveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
			// 
			// FileLoadToolStripMenuItem
			// 
			this.FileLoadToolStripMenuItem.Image = global::Toolbox.ResourceImage.Folder;
			this.FileLoadToolStripMenuItem.Name = "FileLoadToolStripMenuItem";
			this.FileLoadToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.FileLoadToolStripMenuItem.Text = "Datei Laden";
			this.FileLoadToolStripMenuItem.Click += new System.EventHandler(this.FileLoadToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
			// 
			// QuitToolStripMenuItem
			// 
			this.QuitToolStripMenuItem.Image = global::Toolbox.ResourceImage.Close;
			this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
			this.QuitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.QuitToolStripMenuItem.Text = "Beenden";
			this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
			// 
			// toolboxToolStripMenuItem
			// 
			this.toolboxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UARTToolStripMenuItem,
            this.JTAGToolStripMenuItem,
            this.NetworkToolStripMenuItem});
			this.toolboxToolStripMenuItem.Image = global::Toolbox.ResourceImage.Toolbox;
			this.toolboxToolStripMenuItem.Name = "toolboxToolStripMenuItem";
			this.toolboxToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.toolboxToolStripMenuItem.Text = "Toolbox";
			// 
			// UARTToolStripMenuItem
			// 
			this.UARTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eepromToolStripMenuItem,
            this.ds1307ToolStripMenuItem,
            this.debugToolStripMenuItem1});
			this.UARTToolStripMenuItem.Image = global::Toolbox.ResourceImage.Hardware;
			this.UARTToolStripMenuItem.Name = "UARTToolStripMenuItem";
			this.UARTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.UARTToolStripMenuItem.Text = "UART";
			// 
			// eepromToolStripMenuItem
			// 
			this.eepromToolStripMenuItem.Enabled = false;
			this.eepromToolStripMenuItem.Image = global::Toolbox.ResourceImage.Processor;
			this.eepromToolStripMenuItem.Name = "eepromToolStripMenuItem";
			this.eepromToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.eepromToolStripMenuItem.Text = "E²PROM";
			this.eepromToolStripMenuItem.Click += new System.EventHandler(this.eepromToolStripMenuItem_Click);
			// 
			// ds1307ToolStripMenuItem
			// 
			this.ds1307ToolStripMenuItem.Enabled = false;
			this.ds1307ToolStripMenuItem.Image = global::Toolbox.ResourceImage.Clock;
			this.ds1307ToolStripMenuItem.Name = "ds1307ToolStripMenuItem";
			this.ds1307ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.ds1307ToolStripMenuItem.Text = "DS1307";
			this.ds1307ToolStripMenuItem.Click += new System.EventHandler(this.ds1307ToolStripMenuItem_Click);
			// 
			// debugToolStripMenuItem1
			// 
			this.debugToolStripMenuItem1.Enabled = false;
			this.debugToolStripMenuItem1.Image = global::Toolbox.ResourceImage.WindowsForm;
			this.debugToolStripMenuItem1.Name = "debugToolStripMenuItem1";
			this.debugToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
			this.debugToolStripMenuItem1.Text = "Debug";
			this.debugToolStripMenuItem1.Click += new System.EventHandler(this.debugToolStripMenuItem1_Click);
			// 
			// JTAGToolStripMenuItem
			// 
			this.JTAGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xilinxToolStripMenuItem});
			this.JTAGToolStripMenuItem.Image = global::Toolbox.ResourceImage.Deploy;
			this.JTAGToolStripMenuItem.Name = "JTAGToolStripMenuItem";
			this.JTAGToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.JTAGToolStripMenuItem.Text = "JTAG";
			// 
			// xilinxToolStripMenuItem
			// 
			this.xilinxToolStripMenuItem.Enabled = false;
			this.xilinxToolStripMenuItem.Image = global::Toolbox.ResourceImage.Processor;
			this.xilinxToolStripMenuItem.Name = "xilinxToolStripMenuItem";
			this.xilinxToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.xilinxToolStripMenuItem.Text = "Xilinx";
			this.xilinxToolStripMenuItem.Click += new System.EventHandler(this.xilinxToolStripMenuItem_Click);
			// 
			// NetworkToolStripMenuItem
			// 
			this.NetworkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sshToolStripMenuItem,
            this.interfaceToolStripMenuItem,
            this.controlToolStripMenuItem});
			this.NetworkToolStripMenuItem.Image = global::Toolbox.ResourceImage.NetworkDiagram;
			this.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem";
			this.NetworkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.NetworkToolStripMenuItem.Text = "Network";
			this.NetworkToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// sshToolStripMenuItem
			// 
			this.sshToolStripMenuItem.Enabled = false;
			this.sshToolStripMenuItem.Image = global::Toolbox.ResourceImage.Console;
			this.sshToolStripMenuItem.Name = "sshToolStripMenuItem";
			this.sshToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.sshToolStripMenuItem.Text = "SSH";
			this.sshToolStripMenuItem.Click += new System.EventHandler(this.sshToolStripMenuItem_Click);
			// 
			// interfaceToolStripMenuItem
			// 
			this.interfaceToolStripMenuItem.Enabled = false;
			this.interfaceToolStripMenuItem.Image = global::Toolbox.ResourceImage.WebBrowser;
			this.interfaceToolStripMenuItem.Name = "interfaceToolStripMenuItem";
			this.interfaceToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.interfaceToolStripMenuItem.Text = "Web";
			this.interfaceToolStripMenuItem.Click += new System.EventHandler(this.interfaceToolStripMenuItem_Click);
			// 
			// controlToolStripMenuItem
			// 
			this.controlToolStripMenuItem.Enabled = false;
			this.controlToolStripMenuItem.Image = global::Toolbox.ResourceImage.Application;
			this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
			this.controlToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.controlToolStripMenuItem.Text = "Control";
			this.controlToolStripMenuItem.Click += new System.EventHandler(this.controlToolStripMenuItem_Click);
			// 
			// funktionenToolStripMenuItem
			// 
			this.funktionenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageToolStripMenuItem});
			this.funktionenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Book;
			this.funktionenToolStripMenuItem.Name = "funktionenToolStripMenuItem";
			this.funktionenToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.funktionenToolStripMenuItem.Text = "Funktionen";
			// 
			// ImageToolStripMenuItem
			// 
			this.ImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.image2RawToolStripMenuItem,
            this.raw2ImageToolStripMenuItem});
			this.ImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImageToolStripMenuItem.Image")));
			this.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem";
			this.ImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.ImageToolStripMenuItem.Text = "Bild";
			// 
			// image2RawToolStripMenuItem
			// 
			this.image2RawToolStripMenuItem.Image = global::Toolbox.ResourceImage.Binary;
			this.image2RawToolStripMenuItem.Name = "image2RawToolStripMenuItem";
			this.image2RawToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.image2RawToolStripMenuItem.Text = "Image2Raw";
			this.image2RawToolStripMenuItem.Click += new System.EventHandler(this.image2RawToolStripMenuItem_Click);
			// 
			// raw2ImageToolStripMenuItem
			// 
			this.raw2ImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("raw2ImageToolStripMenuItem.Image")));
			this.raw2ImageToolStripMenuItem.Name = "raw2ImageToolStripMenuItem";
			this.raw2ImageToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.raw2ImageToolStripMenuItem.Text = "Raw2Image";
			this.raw2ImageToolStripMenuItem.Click += new System.EventHandler(this.raw2ImageToolStripMenuItem_Click);
			// 
			// einstellungenToolStripMenuItem
			// 
			this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageToolStripMenuItem,
            this.toolStripSeparator3,
            this.AriettaG25ToolStripMenuItem,
            this.PortToolStripMenuItem});
			this.einstellungenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Gear;
			this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
			this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
			this.einstellungenToolStripMenuItem.Text = "Einstellungen";
			// 
			// LanguageToolStripMenuItem
			// 
			this.LanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deutschAustriaToolStripMenuItem,
            this.englishGreatBritanToolStripMenuItem,
            this.espanolSpainToolStripMenuItem,
            this.SystemSpeakToolStripMenuItem});
			this.LanguageToolStripMenuItem.Image = global::Toolbox.ResourceImage.Glasses;
			this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
			this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.LanguageToolStripMenuItem.Text = "Sprache";
			// 
			// deutschAustriaToolStripMenuItem
			// 
			this.deutschAustriaToolStripMenuItem.Image = global::Toolbox.ResourceFlag.de_AT;
			this.deutschAustriaToolStripMenuItem.Name = "deutschAustriaToolStripMenuItem";
			this.deutschAustriaToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			this.deutschAustriaToolStripMenuItem.Text = "Deutsch (Österreich)";
			this.deutschAustriaToolStripMenuItem.Click += new System.EventHandler(this.deutschAustriaToolStripMenuItem_Click);
			// 
			// englishGreatBritanToolStripMenuItem
			// 
			this.englishGreatBritanToolStripMenuItem.Image = global::Toolbox.ResourceFlag.en_GB;
			this.englishGreatBritanToolStripMenuItem.Name = "englishGreatBritanToolStripMenuItem";
			this.englishGreatBritanToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			this.englishGreatBritanToolStripMenuItem.Text = "English (Great Britan)";
			this.englishGreatBritanToolStripMenuItem.Click += new System.EventHandler(this.englishGreatBritanToolStripMenuItem_Click);
			// 
			// espanolSpainToolStripMenuItem
			// 
			this.espanolSpainToolStripMenuItem.Image = global::Toolbox.ResourceFlag.es_ES;
			this.espanolSpainToolStripMenuItem.Name = "espanolSpainToolStripMenuItem";
			this.espanolSpainToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			this.espanolSpainToolStripMenuItem.Text = "Espanol (Espana)";
			this.espanolSpainToolStripMenuItem.Click += new System.EventHandler(this.espanolSpainToolStripMenuItem_Click);
			// 
			// SystemSpeakToolStripMenuItem
			// 
			this.SystemSpeakToolStripMenuItem.Name = "SystemSpeakToolStripMenuItem";
			this.SystemSpeakToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
			this.SystemSpeakToolStripMenuItem.Text = "Standard (Systemsprache)";
			this.SystemSpeakToolStripMenuItem.Click += new System.EventHandler(this.SystemSpeakToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
			// 
			// AriettaG25ToolStripMenuItem
			// 
			this.AriettaG25ToolStripMenuItem.Image = global::Toolbox.ResourceImage.Server;
			this.AriettaG25ToolStripMenuItem.Name = "AriettaG25ToolStripMenuItem";
			this.AriettaG25ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.AriettaG25ToolStripMenuItem.Text = "Arietta G25";
			this.AriettaG25ToolStripMenuItem.Click += new System.EventHandler(this.AriettaG25ToolStripMenuItem_Click);
			// 
			// PortToolStripMenuItem
			// 
			this.PortToolStripMenuItem.Image = global::Toolbox.ResourceImage.Class;
			this.PortToolStripMenuItem.Name = "PortToolStripMenuItem";
			this.PortToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.PortToolStripMenuItem.Text = "Port Konfiguration";
			this.PortToolStripMenuItem.Click += new System.EventHandler(this.PortToolStripMenuItem_Click);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionToolStripMenuItem,
            this.HelpSupportToolStripMenuItem,
            this.toolStripSeparator2,
            this.UpdateToolStripMenuItem,
            this.GithubToolStripMenuItem});
			this.hilfeToolStripMenuItem.Image = global::Toolbox.ResourceImage.Question;
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// VersionToolStripMenuItem
			// 
			this.VersionToolStripMenuItem.Image = global::Toolbox.ResourceImage.VersionTime;
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// UpdateToolStripMenuItem
			// 
			this.UpdateToolStripMenuItem.Enabled = false;
			this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
			this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.UpdateToolStripMenuItem.Text = "Aktualisieren";
			this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
			// 
			// GithubToolStripMenuItem
			// 
			this.GithubToolStripMenuItem.Image = global::Toolbox.ResourceImage.WebBrowser;
			this.GithubToolStripMenuItem.Name = "GithubToolStripMenuItem";
			this.GithubToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.GithubToolStripMenuItem.Text = "elm|Github";
			this.GithubToolStripMenuItem.Click += new System.EventHandler(this.GithubToolStripMenuItem_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.labelVersionNr);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.groupBoxDebug);
			this.Controls.Add(this.groupBoxLinux);
			this.Controls.Add(this.groupBoxTool);
			this.Controls.Add(this.groupBoxFunction);
			this.Controls.Add(this.groupBoxFPGA);
			this.Controls.Add(this.pictureBoxLogo);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "FormMain";
			this.Text = "Toolbox";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.groupBoxDebug.ResumeLayout(false);
			this.groupBoxDebug.PerformLayout();
			this.groupBoxLinux.ResumeLayout(false);
			this.groupBoxTool.ResumeLayout(false);
			this.groupBoxFunction.ResumeLayout(false);
			this.groupBoxFPGA.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxDebug;
		private System.Windows.Forms.Label labelError;
		private System.Windows.Forms.Label labelDebug;
		private System.Windows.Forms.GroupBox groupBoxLinux;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBoxTool;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBoxFunction;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBoxFPGA;
		private System.Windows.Forms.Label gb_FPGA_Text;
		private System.Windows.Forms.PictureBox pictureBoxLogo;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolboxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UARTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eepromToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ds1307ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem JTAGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xilinxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem funktionenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem image2RawToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem raw2ImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem AriettaG25ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem PortToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem GithubToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem NetworkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sshToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem interfaceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deutschAustriaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem englishGreatBritanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem espanolSpainToolStripMenuItem;
		private System.Windows.Forms.Label labelVersionNr;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SystemSpeakToolStripMenuItem;
	}
}

