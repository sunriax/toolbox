namespace Toolbox
{
	partial class FormLinuxAccount
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageUser = new System.Windows.Forms.TabPage();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.buttonNew = new System.Windows.Forms.Button();
			this.textBoxServer = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.listViewAccount = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageCert = new System.Windows.Forms.TabPage();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelChoose = new System.Windows.Forms.Label();
			this.labelAccount = new System.Windows.Forms.Label();
			this.labelHelp = new System.Windows.Forms.Label();
			this.listViewCertificate = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBoxCertPort = new System.Windows.Forms.TextBox();
			this.buttonNewCert = new System.Windows.Forms.Button();
			this.textBoxCertServer = new System.Windows.Forms.TextBox();
			this.textBoxPhassphrase = new System.Windows.Forms.TextBox();
			this.buttonCertAdd = new System.Windows.Forms.Button();
			this.buttonCertDelete = new System.Windows.Forms.Button();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.buttonCert = new System.Windows.Forms.Button();
			this.textBoxCert = new System.Windows.Forms.TextBox();
			this.tabControl.SuspendLayout();
			this.tabPageUser.SuspendLayout();
			this.tabPageCert.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageUser);
			this.tabControl.Controls.Add(this.tabPageCert);
			this.tabControl.Location = new System.Drawing.Point(12, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(510, 150);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageUser
			// 
			this.tabPageUser.Controls.Add(this.textBoxPort);
			this.tabPageUser.Controls.Add(this.buttonNew);
			this.tabPageUser.Controls.Add(this.textBoxServer);
			this.tabPageUser.Controls.Add(this.textBoxPassword);
			this.tabPageUser.Controls.Add(this.textBoxUsername);
			this.tabPageUser.Controls.Add(this.buttonAdd);
			this.tabPageUser.Controls.Add(this.buttonDelete);
			this.tabPageUser.Controls.Add(this.listViewAccount);
			this.tabPageUser.Location = new System.Drawing.Point(4, 22);
			this.tabPageUser.Name = "tabPageUser";
			this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUser.Size = new System.Drawing.Size(502, 124);
			this.tabPageUser.TabIndex = 0;
			this.tabPageUser.Text = "Benutzer";
			this.tabPageUser.UseVisualStyleBackColor = true;
			// 
			// textBoxPort
			// 
			this.textBoxPort.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxPort.Location = new System.Drawing.Point(389, 97);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(34, 20);
			this.textBoxPort.TabIndex = 8;
			this.textBoxPort.Text = "Port";
			this.textBoxPort.Enter += new System.EventHandler(this.textBoxPort_Enter);
			this.textBoxPort.Leave += new System.EventHandler(this.textBoxPort_Leave);
			// 
			// buttonNew
			// 
			this.buttonNew.Image = global::Toolbox.ResourceImage.Action;
			this.buttonNew.Location = new System.Drawing.Point(6, 95);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.Size = new System.Drawing.Size(30, 23);
			this.buttonNew.TabIndex = 7;
			this.buttonNew.UseVisualStyleBackColor = true;
			this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
			// 
			// textBoxServer
			// 
			this.textBoxServer.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxServer.Location = new System.Drawing.Point(254, 97);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(129, 20);
			this.textBoxServer.TabIndex = 6;
			this.textBoxServer.Text = "Server";
			this.textBoxServer.Enter += new System.EventHandler(this.textBoxServer_Enter);
			this.textBoxServer.Leave += new System.EventHandler(this.textBoxServer_Leave);
			this.textBoxServer.MouseEnter += new System.EventHandler(this.textBoxServer_MouseEnter);
			this.textBoxServer.MouseLeave += new System.EventHandler(this.textBoxServer_MouseLeave);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxPassword.Location = new System.Drawing.Point(148, 97);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
			this.textBoxPassword.TabIndex = 5;
			this.textBoxPassword.Text = "Passwort";
			this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
			this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxUsername.Location = new System.Drawing.Point(42, 97);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
			this.textBoxUsername.TabIndex = 4;
			this.textBoxUsername.Text = "Benutzername";
			this.textBoxUsername.Enter += new System.EventHandler(this.textBoxUsername_Enter);
			this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = global::Toolbox.ResourceImage.Add;
			this.buttonAdd.Location = new System.Drawing.Point(429, 95);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(30, 23);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Image = global::Toolbox.ResourceImage.Delete;
			this.buttonDelete.Location = new System.Drawing.Point(465, 95);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(30, 23);
			this.buttonDelete.TabIndex = 1;
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// listViewAccount
			// 
			this.listViewAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderUsername,
            this.columnHeaderPassword,
            this.columnHeaderServer,
            this.columnHeaderPort});
			this.listViewAccount.FullRowSelect = true;
			this.listViewAccount.HideSelection = false;
			this.listViewAccount.Location = new System.Drawing.Point(6, 6);
			this.listViewAccount.MultiSelect = false;
			this.listViewAccount.Name = "listViewAccount";
			this.listViewAccount.Size = new System.Drawing.Size(489, 84);
			this.listViewAccount.TabIndex = 0;
			this.listViewAccount.UseCompatibleStateImageBehavior = false;
			this.listViewAccount.View = System.Windows.Forms.View.Details;
			this.listViewAccount.SelectedIndexChanged += new System.EventHandler(this.listViewAccount_SelectedIndexChanged);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "Id";
			this.columnHeaderId.Width = 26;
			// 
			// columnHeaderUsername
			// 
			this.columnHeaderUsername.Text = "Benutzer";
			this.columnHeaderUsername.Width = 106;
			// 
			// columnHeaderPassword
			// 
			this.columnHeaderPassword.Text = "Passwort";
			this.columnHeaderPassword.Width = 107;
			// 
			// columnHeaderServer
			// 
			this.columnHeaderServer.Text = "Server";
			this.columnHeaderServer.Width = 133;
			// 
			// columnHeaderPort
			// 
			this.columnHeaderPort.Text = "Port";
			// 
			// tabPageCert
			// 
			this.tabPageCert.Controls.Add(this.textBoxCert);
			this.tabPageCert.Controls.Add(this.buttonCert);
			this.tabPageCert.Controls.Add(this.textBoxCertPort);
			this.tabPageCert.Controls.Add(this.buttonNewCert);
			this.tabPageCert.Controls.Add(this.textBoxCertServer);
			this.tabPageCert.Controls.Add(this.textBoxPhassphrase);
			this.tabPageCert.Controls.Add(this.buttonCertAdd);
			this.tabPageCert.Controls.Add(this.buttonCertDelete);
			this.tabPageCert.Controls.Add(this.listViewCertificate);
			this.tabPageCert.Location = new System.Drawing.Point(4, 22);
			this.tabPageCert.Name = "tabPageCert";
			this.tabPageCert.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCert.Size = new System.Drawing.Size(502, 124);
			this.tabPageCert.TabIndex = 1;
			this.tabPageCert.Text = "Zertifikat";
			this.tabPageCert.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(534, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveToolStripMenuItem,
            this.FileOpenToolStripMenuItem,
            this.toolStripSeparator1,
            this.QuitToolStripMenuItem});
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.startToolStripMenuItem.Text = "Start";
			// 
			// FileSaveToolStripMenuItem
			// 
			this.FileSaveToolStripMenuItem.Image = global::Toolbox.ResourceImage.Save;
			this.FileSaveToolStripMenuItem.Name = "FileSaveToolStripMenuItem";
			this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileSaveToolStripMenuItem.Text = "Datei speichern";
			// 
			// FileOpenToolStripMenuItem
			// 
			this.FileOpenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Folder;
			this.FileOpenToolStripMenuItem.Name = "FileOpenToolStripMenuItem";
			this.FileOpenToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileOpenToolStripMenuItem.Text = "Datei öffnen";
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
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionToolStripMenuItem,
            this.HelpSupportToolStripMenuItem});
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// VersionToolStripMenuItem
			// 
			this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
			this.VersionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.VersionToolStripMenuItem.Text = "Version";
			// 
			// HelpSupportToolStripMenuItem
			// 
			this.HelpSupportToolStripMenuItem.Image = global::Toolbox.ResourceImage.Star;
			this.HelpSupportToolStripMenuItem.Name = "HelpSupportToolStripMenuItem";
			this.HelpSupportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.HelpSupportToolStripMenuItem.Text = "Hilfe/Support";
			// 
			// labelChoose
			// 
			this.labelChoose.AutoSize = true;
			this.labelChoose.Location = new System.Drawing.Point(16, 184);
			this.labelChoose.Name = "labelChoose";
			this.labelChoose.Size = new System.Drawing.Size(101, 13);
			this.labelChoose.TabIndex = 2;
			this.labelChoose.Text = "Gewählter Account:";
			// 
			// labelAccount
			// 
			this.labelAccount.AutoSize = true;
			this.labelAccount.Location = new System.Drawing.Point(120, 184);
			this.labelAccount.Name = "labelAccount";
			this.labelAccount.Size = new System.Drawing.Size(55, 13);
			this.labelAccount.TabIndex = 3;
			this.labelAccount.Text = "Username";
			this.labelAccount.Visible = false;
			// 
			// labelHelp
			// 
			this.labelHelp.AutoSize = true;
			this.labelHelp.Location = new System.Drawing.Point(225, 184);
			this.labelHelp.Name = "labelHelp";
			this.labelHelp.Size = new System.Drawing.Size(29, 13);
			this.labelHelp.TabIndex = 4;
			this.labelHelp.Text = "Help";
			this.labelHelp.Visible = false;
			// 
			// listViewCertificate
			// 
			this.listViewCertificate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.listViewCertificate.FullRowSelect = true;
			this.listViewCertificate.HideSelection = false;
			this.listViewCertificate.Location = new System.Drawing.Point(6, 6);
			this.listViewCertificate.MultiSelect = false;
			this.listViewCertificate.Name = "listViewCertificate";
			this.listViewCertificate.Size = new System.Drawing.Size(489, 84);
			this.listViewCertificate.TabIndex = 1;
			this.listViewCertificate.UseCompatibleStateImageBehavior = false;
			this.listViewCertificate.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Id";
			this.columnHeader1.Width = 26;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Zertifikat";
			this.columnHeader2.Width = 106;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Schlüssel";
			this.columnHeader3.Width = 107;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Server";
			this.columnHeader4.Width = 133;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Port";
			// 
			// textBoxCertPort
			// 
			this.textBoxCertPort.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCertPort.Location = new System.Drawing.Point(389, 97);
			this.textBoxCertPort.Name = "textBoxCertPort";
			this.textBoxCertPort.Size = new System.Drawing.Size(34, 20);
			this.textBoxCertPort.TabIndex = 15;
			this.textBoxCertPort.Text = "Port";
			// 
			// buttonNewCert
			// 
			this.buttonNewCert.Image = global::Toolbox.ResourceImage.Action;
			this.buttonNewCert.Location = new System.Drawing.Point(6, 95);
			this.buttonNewCert.Name = "buttonNewCert";
			this.buttonNewCert.Size = new System.Drawing.Size(30, 23);
			this.buttonNewCert.TabIndex = 14;
			this.buttonNewCert.UseVisualStyleBackColor = true;
			// 
			// textBoxCertServer
			// 
			this.textBoxCertServer.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCertServer.Location = new System.Drawing.Point(254, 97);
			this.textBoxCertServer.Name = "textBoxCertServer";
			this.textBoxCertServer.Size = new System.Drawing.Size(129, 20);
			this.textBoxCertServer.TabIndex = 13;
			this.textBoxCertServer.Text = "Server";
			// 
			// textBoxPhassphrase
			// 
			this.textBoxPhassphrase.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxPhassphrase.Location = new System.Drawing.Point(148, 97);
			this.textBoxPhassphrase.Name = "textBoxPhassphrase";
			this.textBoxPhassphrase.PasswordChar = '*';
			this.textBoxPhassphrase.Size = new System.Drawing.Size(100, 20);
			this.textBoxPhassphrase.TabIndex = 12;
			this.textBoxPhassphrase.Text = "Passwort";
			// 
			// buttonCertAdd
			// 
			this.buttonCertAdd.Image = global::Toolbox.ResourceImage.Add;
			this.buttonCertAdd.Location = new System.Drawing.Point(429, 95);
			this.buttonCertAdd.Name = "buttonCertAdd";
			this.buttonCertAdd.Size = new System.Drawing.Size(30, 23);
			this.buttonCertAdd.TabIndex = 10;
			this.buttonCertAdd.UseVisualStyleBackColor = true;
			// 
			// buttonCertDelete
			// 
			this.buttonCertDelete.Image = global::Toolbox.ResourceImage.Delete;
			this.buttonCertDelete.Location = new System.Drawing.Point(465, 95);
			this.buttonCertDelete.Name = "buttonCertDelete";
			this.buttonCertDelete.Size = new System.Drawing.Size(30, 23);
			this.buttonCertDelete.TabIndex = 9;
			this.buttonCertDelete.UseVisualStyleBackColor = true;
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// buttonCert
			// 
			this.buttonCert.Image = global::Toolbox.ResourceImage.Certificate;
			this.buttonCert.Location = new System.Drawing.Point(107, 95);
			this.buttonCert.Name = "buttonCert";
			this.buttonCert.Size = new System.Drawing.Size(35, 23);
			this.buttonCert.TabIndex = 16;
			this.buttonCert.UseVisualStyleBackColor = true;
			// 
			// textBoxCert
			// 
			this.textBoxCert.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCert.Location = new System.Drawing.Point(42, 97);
			this.textBoxCert.Name = "textBoxCert";
			this.textBoxCert.Size = new System.Drawing.Size(59, 20);
			this.textBoxCert.TabIndex = 17;
			this.textBoxCert.Text = "Port";
			// 
			// FormLinuxAccount
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 211);
			this.Controls.Add(this.labelHelp);
			this.Controls.Add(this.labelAccount);
			this.Controls.Add(this.labelChoose);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormLinuxAccount";
			this.Text = "Benutzer/Zertifikat Verwaltung";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLinuxAccount_FormClosing);
			this.tabControl.ResumeLayout(false);
			this.tabPageUser.ResumeLayout(false);
			this.tabPageUser.PerformLayout();
			this.tabPageCert.ResumeLayout(false);
			this.tabPageCert.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageUser;
		private System.Windows.Forms.TabPage tabPageCert;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileOpenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ListView listViewAccount;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderUsername;
		private System.Windows.Forms.ColumnHeader columnHeaderPassword;
		private System.Windows.Forms.ColumnHeader columnHeaderServer;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.TextBox textBoxServer;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Button buttonNew;
		private System.Windows.Forms.Label labelChoose;
		private System.Windows.Forms.Label labelAccount;
		private System.Windows.Forms.Label labelHelp;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.ColumnHeader columnHeaderPort;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportToolStripMenuItem;
		private System.Windows.Forms.TextBox textBoxCertPort;
		private System.Windows.Forms.Button buttonNewCert;
		private System.Windows.Forms.TextBox textBoxCertServer;
		private System.Windows.Forms.TextBox textBoxPhassphrase;
		private System.Windows.Forms.Button buttonCertAdd;
		private System.Windows.Forms.Button buttonCertDelete;
		private System.Windows.Forms.ListView listViewCertificate;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.TextBox textBoxCert;
		private System.Windows.Forms.Button buttonCert;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
	}
}