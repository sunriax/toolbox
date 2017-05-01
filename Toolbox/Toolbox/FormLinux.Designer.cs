namespace Toolbox
{
	partial class FormLinux
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
			this.labelVersion = new System.Windows.Forms.Label();
			this.groupBoxSetting = new System.Windows.Forms.GroupBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.textBoxIPByte1 = new System.Windows.Forms.TextBox();
			this.textBoxIPByte2 = new System.Windows.Forms.TextBox();
			this.textBoxIPByte4 = new System.Windows.Forms.TextBox();
			this.textBoxIPByte3 = new System.Windows.Forms.TextBox();
			this.labelIP = new System.Windows.Forms.Label();
			this.labelDotpoint = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.einstellungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.authentifizierungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usernamePasswortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.certToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelConnection = new System.Windows.Forms.Label();
			this.groupBoxAuth = new System.Windows.Forms.GroupBox();
			this.labelAuthMethod = new System.Windows.Forms.Label();
			this.groupBoxSetting.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBoxAuth.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelVersion.Location = new System.Drawing.Point(176, 165);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(53, 14);
			this.labelVersion.TabIndex = 19;
			this.labelVersion.Text = "Version";
			// 
			// groupBoxSetting
			// 
			this.groupBoxSetting.Controls.Add(this.textBoxPort);
			this.groupBoxSetting.Controls.Add(this.buttonConnect);
			this.groupBoxSetting.Controls.Add(this.textBoxIPByte1);
			this.groupBoxSetting.Controls.Add(this.textBoxIPByte2);
			this.groupBoxSetting.Controls.Add(this.textBoxIPByte4);
			this.groupBoxSetting.Controls.Add(this.textBoxIPByte3);
			this.groupBoxSetting.Controls.Add(this.labelIP);
			this.groupBoxSetting.Controls.Add(this.labelDotpoint);
			this.groupBoxSetting.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
			this.groupBoxSetting.Location = new System.Drawing.Point(12, 27);
			this.groupBoxSetting.Name = "groupBoxSetting";
			this.groupBoxSetting.Size = new System.Drawing.Size(260, 84);
			this.groupBoxSetting.TabIndex = 18;
			this.groupBoxSetting.TabStop = false;
			this.groupBoxSetting.Text = "SSH Server";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxPort.Location = new System.Drawing.Point(211, 21);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(35, 22);
			this.textBoxPort.TabIndex = 17;
			this.textBoxPort.Text = "22";
			this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Font = new System.Drawing.Font("Verdana", 9F);
			this.buttonConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonConnect.Location = new System.Drawing.Point(15, 48);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(231, 23);
			this.buttonConnect.TabIndex = 15;
			this.buttonConnect.Text = "Verbindungstest";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// textBoxIPByte1
			// 
			this.textBoxIPByte1.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxIPByte1.Location = new System.Drawing.Point(44, 21);
			this.textBoxIPByte1.Name = "textBoxIPByte1";
			this.textBoxIPByte1.Size = new System.Drawing.Size(35, 22);
			this.textBoxIPByte1.TabIndex = 0;
			this.textBoxIPByte1.Text = "192";
			this.textBoxIPByte1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxIPByte2
			// 
			this.textBoxIPByte2.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxIPByte2.Location = new System.Drawing.Point(85, 21);
			this.textBoxIPByte2.Name = "textBoxIPByte2";
			this.textBoxIPByte2.Size = new System.Drawing.Size(35, 22);
			this.textBoxIPByte2.TabIndex = 2;
			this.textBoxIPByte2.Text = "168";
			this.textBoxIPByte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxIPByte4
			// 
			this.textBoxIPByte4.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxIPByte4.Location = new System.Drawing.Point(167, 21);
			this.textBoxIPByte4.Name = "textBoxIPByte4";
			this.textBoxIPByte4.Size = new System.Drawing.Size(35, 22);
			this.textBoxIPByte4.TabIndex = 4;
			this.textBoxIPByte4.Text = "10";
			this.textBoxIPByte4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxIPByte3
			// 
			this.textBoxIPByte3.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxIPByte3.Location = new System.Drawing.Point(126, 21);
			this.textBoxIPByte3.Name = "textBoxIPByte3";
			this.textBoxIPByte3.Size = new System.Drawing.Size(35, 22);
			this.textBoxIPByte3.TabIndex = 3;
			this.textBoxIPByte3.Text = "0";
			this.textBoxIPByte3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelIP
			// 
			this.labelIP.AutoSize = true;
			this.labelIP.Font = new System.Drawing.Font("Lucida Console", 11.25F);
			this.labelIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelIP.Location = new System.Drawing.Point(13, 24);
			this.labelIP.Name = "labelIP";
			this.labelIP.Size = new System.Drawing.Size(34, 15);
			this.labelIP.TabIndex = 1;
			this.labelIP.Text = "IP:";
			// 
			// labelDotpoint
			// 
			this.labelDotpoint.AutoSize = true;
			this.labelDotpoint.Font = new System.Drawing.Font("Lucida Console", 11.25F);
			this.labelDotpoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelDotpoint.Location = new System.Drawing.Point(199, 24);
			this.labelDotpoint.Name = "labelDotpoint";
			this.labelDotpoint.Size = new System.Drawing.Size(16, 15);
			this.labelDotpoint.TabIndex = 16;
			this.labelDotpoint.Text = ":";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
			this.menuStrip1.TabIndex = 17;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveToolStripMenuItem,
            this.FileLoadToolStripMenuItem,
            this.toolStripSeparator1,
            this.QuitToolStripMenuItem});
			this.dateiToolStripMenuItem.Image = global::Toolbox.ResourceImage.Application;
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.dateiToolStripMenuItem.Text = "Start";
			// 
			// FileSaveToolStripMenuItem
			// 
			this.FileSaveToolStripMenuItem.Image = global::Toolbox.ResourceImage.Save;
			this.FileSaveToolStripMenuItem.Name = "FileSaveToolStripMenuItem";
			this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileSaveToolStripMenuItem.Text = "Datei speichern";
			this.FileSaveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
			// 
			// FileLoadToolStripMenuItem
			// 
			this.FileLoadToolStripMenuItem.Image = global::Toolbox.ResourceImage.Folder;
			this.FileLoadToolStripMenuItem.Name = "FileLoadToolStripMenuItem";
			this.FileLoadToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileLoadToolStripMenuItem.Text = "Datei öffnen";
			this.FileLoadToolStripMenuItem.Click += new System.EventHandler(this.FileLoadToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// QuitToolStripMenuItem
			// 
			this.QuitToolStripMenuItem.Image = global::Toolbox.ResourceImage.Close;
			this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
			this.QuitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.QuitToolStripMenuItem.Text = "Beenden";
			this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
			// 
			// einstellungToolStripMenuItem
			// 
			this.einstellungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.toolStripSeparator2,
            this.authentifizierungToolStripMenuItem});
			this.einstellungToolStripMenuItem.Image = global::Toolbox.ResourceImage.Gear;
			this.einstellungToolStripMenuItem.Name = "einstellungToolStripMenuItem";
			this.einstellungToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.einstellungToolStripMenuItem.Text = "Einstellung";
			// 
			// accountToolStripMenuItem
			// 
			this.accountToolStripMenuItem.Image = global::Toolbox.ResourceImage.Team_16xLG;
			this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
			this.accountToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.accountToolStripMenuItem.Text = "Verwaltung";
			this.accountToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
			// 
			// authentifizierungToolStripMenuItem
			// 
			this.authentifizierungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernamePasswortToolStripMenuItem,
            this.certToolStripMenuItem});
			this.authentifizierungToolStripMenuItem.Image = global::Toolbox.ResourceImage.Lock;
			this.authentifizierungToolStripMenuItem.Name = "authentifizierungToolStripMenuItem";
			this.authentifizierungToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.authentifizierungToolStripMenuItem.Text = "Authentifizierung";
			// 
			// usernamePasswortToolStripMenuItem
			// 
			this.usernamePasswortToolStripMenuItem.Image = global::Toolbox.ResourceImage.Key;
			this.usernamePasswortToolStripMenuItem.Name = "usernamePasswortToolStripMenuItem";
			this.usernamePasswortToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.usernamePasswortToolStripMenuItem.Text = "Benutzer/Passwort";
			this.usernamePasswortToolStripMenuItem.Click += new System.EventHandler(this.usernamePasswortToolStripMenuItem_Click);
			// 
			// certToolStripMenuItem
			// 
			this.certToolStripMenuItem.Image = global::Toolbox.ResourceImage.Certificate;
			this.certToolStripMenuItem.Name = "certToolStripMenuItem";
			this.certToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.certToolStripMenuItem.Text = "Zertifikat";
			this.certToolStripMenuItem.Click += new System.EventHandler(this.certToolStripMenuItem_Click);
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
			// labelConnection
			// 
			this.labelConnection.AutoSize = true;
			this.labelConnection.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelConnection.Location = new System.Drawing.Point(13, 165);
			this.labelConnection.Name = "labelConnection";
			this.labelConnection.Size = new System.Drawing.Size(78, 14);
			this.labelConnection.TabIndex = 21;
			this.labelConnection.Text = "Connection";
			this.labelConnection.Visible = false;
			// 
			// groupBoxAuth
			// 
			this.groupBoxAuth.Controls.Add(this.labelAuthMethod);
			this.groupBoxAuth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxAuth.Location = new System.Drawing.Point(12, 117);
			this.groupBoxAuth.Name = "groupBoxAuth";
			this.groupBoxAuth.Size = new System.Drawing.Size(260, 39);
			this.groupBoxAuth.TabIndex = 22;
			this.groupBoxAuth.TabStop = false;
			this.groupBoxAuth.Text = "Authentifizierung";
			// 
			// labelAuthMethod
			// 
			this.labelAuthMethod.AutoSize = true;
			this.labelAuthMethod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAuthMethod.Location = new System.Drawing.Point(12, 17);
			this.labelAuthMethod.Name = "labelAuthMethod";
			this.labelAuthMethod.Size = new System.Drawing.Size(138, 13);
			this.labelAuthMethod.TabIndex = 23;
			this.labelAuthMethod.Text = "Benutzer und Passwort";
			this.labelAuthMethod.Visible = false;
			// 
			// FormLinux
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 182);
			this.Controls.Add(this.groupBoxAuth);
			this.Controls.Add(this.labelConnection);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.groupBoxSetting);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLinux";
			this.Text = "Arietta G25 IP Einstellung";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLinux_FormClosing);
			this.groupBoxSetting.ResumeLayout(false);
			this.groupBoxSetting.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxAuth.ResumeLayout(false);
			this.groupBoxAuth.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.GroupBox groupBoxSetting;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.TextBox textBoxIPByte1;
		private System.Windows.Forms.TextBox textBoxIPByte2;
		private System.Windows.Forms.TextBox textBoxIPByte4;
		private System.Windows.Forms.TextBox textBoxIPByte3;
		private System.Windows.Forms.Label labelIP;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportToolStripMenuItem;
		private System.Windows.Forms.Label labelConnection;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Label labelDotpoint;
		private System.Windows.Forms.ToolStripMenuItem einstellungToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem authentifizierungToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usernamePasswortToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxAuth;
		private System.Windows.Forms.Label labelAuthMethod;
		private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem certToolStripMenuItem;
	}
}