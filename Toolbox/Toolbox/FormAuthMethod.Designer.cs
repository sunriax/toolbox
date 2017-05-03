namespace Toolbox
{
	partial class FormAuthMethod
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
			this.FileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageUser = new System.Windows.Forms.TabPage();
			this.textBoxAccountPort = new System.Windows.Forms.TextBox();
			this.buttonAccountNew = new System.Windows.Forms.Button();
			this.textBoxAccountServer = new System.Windows.Forms.TextBox();
			this.textBoxAccountPassword = new System.Windows.Forms.TextBox();
			this.textBoxAccountUsername = new System.Windows.Forms.TextBox();
			this.buttonAccountAdd = new System.Windows.Forms.Button();
			this.buttonAccountDelete = new System.Windows.Forms.Button();
			this.listViewAccount = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageCertificate = new System.Windows.Forms.TabPage();
			this.textBoxCertificateName = new System.Windows.Forms.TextBox();
			this.buttonCertificatePath = new System.Windows.Forms.Button();
			this.textBoxCertificatePort = new System.Windows.Forms.TextBox();
			this.buttonCertificateNew = new System.Windows.Forms.Button();
			this.textBoxCertificateServer = new System.Windows.Forms.TextBox();
			this.textBoxCertificatePassphrase = new System.Windows.Forms.TextBox();
			this.buttonCertificateAdd = new System.Windows.Forms.Button();
			this.buttonCertificateDelete = new System.Windows.Forms.Button();
			this.listViewCertificate = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelHelp = new System.Windows.Forms.Label();
			this.labelAuthParameter = new System.Windows.Forms.Label();
			this.labelChoosed = new System.Windows.Forms.Label();
			this.openFileDialogCertificate = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageUser.SuspendLayout();
			this.tabPageCertificate.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(534, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveToolStripMenuItem,
            this.FileOpenToolStripMenuItem,
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
			this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileSaveToolStripMenuItem.Text = "Datei speichern";
			this.FileSaveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveToolStripMenuItem_Click);
			// 
			// FileOpenToolStripMenuItem
			// 
			this.FileOpenToolStripMenuItem.Image = global::Toolbox.ResourceImage.Folder;
			this.FileOpenToolStripMenuItem.Name = "FileOpenToolStripMenuItem";
			this.FileOpenToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileOpenToolStripMenuItem.Text = "Datei öffnen";
			this.FileOpenToolStripMenuItem.Click += new System.EventHandler(this.FileOpenToolStripMenuItem_Click);
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
			this.hilfeToolStripMenuItem.Image = global::Toolbox.ResourceImage.Question;
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// VersionToolStripMenuItem
			// 
			this.VersionToolStripMenuItem.Image = global::Toolbox.ResourceImage.VersionTime;
			this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
			this.VersionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.VersionToolStripMenuItem.Text = "Version";
			this.VersionToolStripMenuItem.Click += new System.EventHandler(this.VersionToolStripMenuItem_Click);
			// 
			// HelpSupportToolStripMenuItem
			// 
			this.HelpSupportToolStripMenuItem.Image = global::Toolbox.ResourceImage.Star;
			this.HelpSupportToolStripMenuItem.Name = "HelpSupportToolStripMenuItem";
			this.HelpSupportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.HelpSupportToolStripMenuItem.Text = "Hilfe/Support";
			this.HelpSupportToolStripMenuItem.Click += new System.EventHandler(this.HelpSupportToolStripMenuItem_Click);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageUser);
			this.tabControl.Controls.Add(this.tabPageCertificate);
			this.tabControl.Location = new System.Drawing.Point(12, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(510, 150);
			this.tabControl.TabIndex = 1;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// tabPageUser
			// 
			this.tabPageUser.Controls.Add(this.textBoxAccountPort);
			this.tabPageUser.Controls.Add(this.buttonAccountNew);
			this.tabPageUser.Controls.Add(this.textBoxAccountServer);
			this.tabPageUser.Controls.Add(this.textBoxAccountPassword);
			this.tabPageUser.Controls.Add(this.textBoxAccountUsername);
			this.tabPageUser.Controls.Add(this.buttonAccountAdd);
			this.tabPageUser.Controls.Add(this.buttonAccountDelete);
			this.tabPageUser.Controls.Add(this.listViewAccount);
			this.tabPageUser.Location = new System.Drawing.Point(4, 22);
			this.tabPageUser.Name = "tabPageUser";
			this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUser.Size = new System.Drawing.Size(502, 124);
			this.tabPageUser.TabIndex = 0;
			this.tabPageUser.Text = "Benutzer";
			this.tabPageUser.UseVisualStyleBackColor = true;
			// 
			// textBoxAccountPort
			// 
			this.textBoxAccountPort.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxAccountPort.Location = new System.Drawing.Point(390, 97);
			this.textBoxAccountPort.Name = "textBoxAccountPort";
			this.textBoxAccountPort.Size = new System.Drawing.Size(34, 20);
			this.textBoxAccountPort.TabIndex = 15;
			this.textBoxAccountPort.Text = "Port";
			this.textBoxAccountPort.Enter += new System.EventHandler(this.textBoxAccountPort_Enter);
			this.textBoxAccountPort.Leave += new System.EventHandler(this.textBoxAccountPort_Leave);
			// 
			// buttonAccountNew
			// 
			this.buttonAccountNew.Image = global::Toolbox.ResourceImage.Action;
			this.buttonAccountNew.Location = new System.Drawing.Point(7, 95);
			this.buttonAccountNew.Name = "buttonAccountNew";
			this.buttonAccountNew.Size = new System.Drawing.Size(30, 23);
			this.buttonAccountNew.TabIndex = 14;
			this.buttonAccountNew.UseVisualStyleBackColor = true;
			this.buttonAccountNew.Click += new System.EventHandler(this.buttonAccountNew_Click);
			// 
			// textBoxAccountServer
			// 
			this.textBoxAccountServer.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxAccountServer.Location = new System.Drawing.Point(255, 97);
			this.textBoxAccountServer.Name = "textBoxAccountServer";
			this.textBoxAccountServer.Size = new System.Drawing.Size(129, 20);
			this.textBoxAccountServer.TabIndex = 13;
			this.textBoxAccountServer.Text = "Server";
			this.textBoxAccountServer.Enter += new System.EventHandler(this.textBoxAccountServer_Enter);
			this.textBoxAccountServer.Leave += new System.EventHandler(this.textBoxAccountServer_Leave);
			this.textBoxAccountServer.MouseEnter += new System.EventHandler(this.textBoxAccountServer_MouseEnter);
			this.textBoxAccountServer.MouseLeave += new System.EventHandler(this.textBoxAccountServer_MouseLeave);
			// 
			// textBoxAccountPassword
			// 
			this.textBoxAccountPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxAccountPassword.Location = new System.Drawing.Point(149, 97);
			this.textBoxAccountPassword.Name = "textBoxAccountPassword";
			this.textBoxAccountPassword.PasswordChar = '*';
			this.textBoxAccountPassword.Size = new System.Drawing.Size(100, 20);
			this.textBoxAccountPassword.TabIndex = 12;
			this.textBoxAccountPassword.Text = "Passwort";
			this.textBoxAccountPassword.Enter += new System.EventHandler(this.textBoxAccountPassword_Enter);
			this.textBoxAccountPassword.Leave += new System.EventHandler(this.textBoxAccountPassword_Leave);
			// 
			// textBoxAccountUsername
			// 
			this.textBoxAccountUsername.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxAccountUsername.Location = new System.Drawing.Point(43, 97);
			this.textBoxAccountUsername.Name = "textBoxAccountUsername";
			this.textBoxAccountUsername.Size = new System.Drawing.Size(100, 20);
			this.textBoxAccountUsername.TabIndex = 11;
			this.textBoxAccountUsername.Text = "Benutzername";
			this.textBoxAccountUsername.Enter += new System.EventHandler(this.textBoxAccountUsername_Enter);
			this.textBoxAccountUsername.Leave += new System.EventHandler(this.textBoxAccountUsername_Leave);
			// 
			// buttonAccountAdd
			// 
			this.buttonAccountAdd.Image = global::Toolbox.ResourceImage.Add;
			this.buttonAccountAdd.Location = new System.Drawing.Point(430, 95);
			this.buttonAccountAdd.Name = "buttonAccountAdd";
			this.buttonAccountAdd.Size = new System.Drawing.Size(30, 23);
			this.buttonAccountAdd.TabIndex = 10;
			this.buttonAccountAdd.UseVisualStyleBackColor = true;
			this.buttonAccountAdd.Click += new System.EventHandler(this.buttonAccountAdd_Click);
			// 
			// buttonAccountDelete
			// 
			this.buttonAccountDelete.Image = global::Toolbox.ResourceImage.Delete;
			this.buttonAccountDelete.Location = new System.Drawing.Point(466, 95);
			this.buttonAccountDelete.Name = "buttonAccountDelete";
			this.buttonAccountDelete.Size = new System.Drawing.Size(30, 23);
			this.buttonAccountDelete.TabIndex = 9;
			this.buttonAccountDelete.UseVisualStyleBackColor = true;
			this.buttonAccountDelete.Click += new System.EventHandler(this.buttonAccountDelete_Click);
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
			this.listViewAccount.Location = new System.Drawing.Point(7, 7);
			this.listViewAccount.MultiSelect = false;
			this.listViewAccount.Name = "listViewAccount";
			this.listViewAccount.Size = new System.Drawing.Size(489, 84);
			this.listViewAccount.TabIndex = 1;
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
			// tabPageCertificate
			// 
			this.tabPageCertificate.Controls.Add(this.textBoxCertificateName);
			this.tabPageCertificate.Controls.Add(this.buttonCertificatePath);
			this.tabPageCertificate.Controls.Add(this.textBoxCertificatePort);
			this.tabPageCertificate.Controls.Add(this.buttonCertificateNew);
			this.tabPageCertificate.Controls.Add(this.textBoxCertificateServer);
			this.tabPageCertificate.Controls.Add(this.textBoxCertificatePassphrase);
			this.tabPageCertificate.Controls.Add(this.buttonCertificateAdd);
			this.tabPageCertificate.Controls.Add(this.buttonCertificateDelete);
			this.tabPageCertificate.Controls.Add(this.listViewCertificate);
			this.tabPageCertificate.Location = new System.Drawing.Point(4, 22);
			this.tabPageCertificate.Name = "tabPageCertificate";
			this.tabPageCertificate.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCertificate.Size = new System.Drawing.Size(502, 124);
			this.tabPageCertificate.TabIndex = 1;
			this.tabPageCertificate.Text = "Zertifikat";
			this.tabPageCertificate.UseVisualStyleBackColor = true;
			// 
			// textBoxCertificateName
			// 
			this.textBoxCertificateName.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCertificateName.Location = new System.Drawing.Point(43, 97);
			this.textBoxCertificateName.Name = "textBoxCertificateName";
			this.textBoxCertificateName.Size = new System.Drawing.Size(59, 20);
			this.textBoxCertificateName.TabIndex = 25;
			this.textBoxCertificateName.Text = "Name";
			this.textBoxCertificateName.Enter += new System.EventHandler(this.textBoxCertificateName_Enter);
			this.textBoxCertificateName.Leave += new System.EventHandler(this.textBoxCertificateName_Leave);
			// 
			// buttonCertificatePath
			// 
			this.buttonCertificatePath.Image = global::Toolbox.ResourceImage.Certificate;
			this.buttonCertificatePath.Location = new System.Drawing.Point(108, 95);
			this.buttonCertificatePath.Name = "buttonCertificatePath";
			this.buttonCertificatePath.Size = new System.Drawing.Size(35, 23);
			this.buttonCertificatePath.TabIndex = 24;
			this.buttonCertificatePath.UseVisualStyleBackColor = true;
			this.buttonCertificatePath.Click += new System.EventHandler(this.buttonCertificatePath_Click);
			// 
			// textBoxCertificatePort
			// 
			this.textBoxCertificatePort.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCertificatePort.Location = new System.Drawing.Point(390, 97);
			this.textBoxCertificatePort.Name = "textBoxCertificatePort";
			this.textBoxCertificatePort.Size = new System.Drawing.Size(34, 20);
			this.textBoxCertificatePort.TabIndex = 23;
			this.textBoxCertificatePort.Text = "Port";
			this.textBoxCertificatePort.Enter += new System.EventHandler(this.textBoxCertificatePort_Enter);
			this.textBoxCertificatePort.Leave += new System.EventHandler(this.textBoxCertificatePort_Leave);
			// 
			// buttonCertificateNew
			// 
			this.buttonCertificateNew.Image = global::Toolbox.ResourceImage.Action;
			this.buttonCertificateNew.Location = new System.Drawing.Point(7, 95);
			this.buttonCertificateNew.Name = "buttonCertificateNew";
			this.buttonCertificateNew.Size = new System.Drawing.Size(30, 23);
			this.buttonCertificateNew.TabIndex = 22;
			this.buttonCertificateNew.UseVisualStyleBackColor = true;
			this.buttonCertificateNew.Click += new System.EventHandler(this.buttonCertificateNew_Click);
			// 
			// textBoxCertificateServer
			// 
			this.textBoxCertificateServer.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCertificateServer.Location = new System.Drawing.Point(255, 97);
			this.textBoxCertificateServer.Name = "textBoxCertificateServer";
			this.textBoxCertificateServer.Size = new System.Drawing.Size(129, 20);
			this.textBoxCertificateServer.TabIndex = 21;
			this.textBoxCertificateServer.Text = "Server";
			this.textBoxCertificateServer.Enter += new System.EventHandler(this.textBoxCertificateServer_Enter);
			this.textBoxCertificateServer.Leave += new System.EventHandler(this.textBoxCertificateServer_Leave);
			// 
			// textBoxCertificatePassphrase
			// 
			this.textBoxCertificatePassphrase.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBoxCertificatePassphrase.Location = new System.Drawing.Point(149, 97);
			this.textBoxCertificatePassphrase.Name = "textBoxCertificatePassphrase";
			this.textBoxCertificatePassphrase.PasswordChar = '*';
			this.textBoxCertificatePassphrase.Size = new System.Drawing.Size(100, 20);
			this.textBoxCertificatePassphrase.TabIndex = 20;
			this.textBoxCertificatePassphrase.Text = "Passwort";
			this.textBoxCertificatePassphrase.Enter += new System.EventHandler(this.textBoxCertificatePassphrase_Enter);
			this.textBoxCertificatePassphrase.Leave += new System.EventHandler(this.textBoxCertificatePassphrase_Leave);
			// 
			// buttonCertificateAdd
			// 
			this.buttonCertificateAdd.Image = global::Toolbox.ResourceImage.Add;
			this.buttonCertificateAdd.Location = new System.Drawing.Point(430, 95);
			this.buttonCertificateAdd.Name = "buttonCertificateAdd";
			this.buttonCertificateAdd.Size = new System.Drawing.Size(30, 23);
			this.buttonCertificateAdd.TabIndex = 19;
			this.buttonCertificateAdd.UseVisualStyleBackColor = true;
			this.buttonCertificateAdd.Click += new System.EventHandler(this.buttonCertificateAdd_Click);
			// 
			// buttonCertificateDelete
			// 
			this.buttonCertificateDelete.Image = global::Toolbox.ResourceImage.Delete;
			this.buttonCertificateDelete.Location = new System.Drawing.Point(466, 95);
			this.buttonCertificateDelete.Name = "buttonCertificateDelete";
			this.buttonCertificateDelete.Size = new System.Drawing.Size(30, 23);
			this.buttonCertificateDelete.TabIndex = 18;
			this.buttonCertificateDelete.UseVisualStyleBackColor = true;
			this.buttonCertificateDelete.Click += new System.EventHandler(this.buttonCertificateDelete_Click);
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
			this.listViewCertificate.Location = new System.Drawing.Point(7, 7);
			this.listViewCertificate.MultiSelect = false;
			this.listViewCertificate.Name = "listViewCertificate";
			this.listViewCertificate.Size = new System.Drawing.Size(489, 84);
			this.listViewCertificate.TabIndex = 2;
			this.listViewCertificate.UseCompatibleStateImageBehavior = false;
			this.listViewCertificate.View = System.Windows.Forms.View.Details;
			this.listViewCertificate.SelectedIndexChanged += new System.EventHandler(this.listViewCertificate_SelectedIndexChanged);
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
			// labelHelp
			// 
			this.labelHelp.AutoSize = true;
			this.labelHelp.Location = new System.Drawing.Point(222, 189);
			this.labelHelp.Name = "labelHelp";
			this.labelHelp.Size = new System.Drawing.Size(29, 13);
			this.labelHelp.TabIndex = 7;
			this.labelHelp.Text = "Help";
			this.labelHelp.Visible = false;
			// 
			// labelAuthParameter
			// 
			this.labelAuthParameter.AutoSize = true;
			this.labelAuthParameter.Location = new System.Drawing.Point(117, 189);
			this.labelAuthParameter.Name = "labelAuthParameter";
			this.labelAuthParameter.Size = new System.Drawing.Size(55, 13);
			this.labelAuthParameter.TabIndex = 6;
			this.labelAuthParameter.Text = "Username";
			this.labelAuthParameter.Visible = false;
			// 
			// labelChoosed
			// 
			this.labelChoosed.AutoSize = true;
			this.labelChoosed.Location = new System.Drawing.Point(13, 189);
			this.labelChoosed.Name = "labelChoosed";
			this.labelChoosed.Size = new System.Drawing.Size(101, 13);
			this.labelChoosed.TabIndex = 5;
			this.labelChoosed.Text = "Gewählter Account:";
			// 
			// openFileDialogCertificate
			// 
			this.openFileDialogCertificate.FileName = "openFileDialog1";
			// 
			// FormAuthMethod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 211);
			this.Controls.Add(this.labelHelp);
			this.Controls.Add(this.labelAuthParameter);
			this.Controls.Add(this.labelChoosed);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormAuthMethod";
			this.Text = "Benutzer/Zertifikat Verwaltung";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAuthMethod_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageUser.ResumeLayout(false);
			this.tabPageUser.PerformLayout();
			this.tabPageCertificate.ResumeLayout(false);
			this.tabPageCertificate.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileOpenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageUser;
		private System.Windows.Forms.TabPage tabPageCertificate;
		private System.Windows.Forms.ListView listViewAccount;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderUsername;
		private System.Windows.Forms.ColumnHeader columnHeaderPassword;
		private System.Windows.Forms.ColumnHeader columnHeaderServer;
		private System.Windows.Forms.ColumnHeader columnHeaderPort;
		private System.Windows.Forms.ListView listViewCertificate;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label labelHelp;
		private System.Windows.Forms.Label labelAuthParameter;
		private System.Windows.Forms.Label labelChoosed;
		private System.Windows.Forms.TextBox textBoxAccountPort;
		private System.Windows.Forms.Button buttonAccountNew;
		private System.Windows.Forms.TextBox textBoxAccountServer;
		private System.Windows.Forms.TextBox textBoxAccountPassword;
		private System.Windows.Forms.TextBox textBoxAccountUsername;
		private System.Windows.Forms.Button buttonAccountAdd;
		private System.Windows.Forms.Button buttonAccountDelete;
		private System.Windows.Forms.TextBox textBoxCertificateName;
		private System.Windows.Forms.Button buttonCertificatePath;
		private System.Windows.Forms.TextBox textBoxCertificatePort;
		private System.Windows.Forms.Button buttonCertificateNew;
		private System.Windows.Forms.TextBox textBoxCertificateServer;
		private System.Windows.Forms.TextBox textBoxCertificatePassphrase;
		private System.Windows.Forms.Button buttonCertificateAdd;
		private System.Windows.Forms.Button buttonCertificateDelete;
		private System.Windows.Forms.OpenFileDialog openFileDialogCertificate;
	}
}