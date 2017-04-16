namespace Toolbox
{
	partial class FormPort
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
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBoxPort = new System.Windows.Forms.ComboBox();
			this.comboBoxMethod = new System.Windows.Forms.ComboBox();
			this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
			this.listBoxUART = new System.Windows.Forms.ListBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(484, 24);
			this.menuStrip1.TabIndex = 18;
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
			// 
			// FileLoadToolStripMenuItem
			// 
			this.FileLoadToolStripMenuItem.Image = global::Toolbox.ResourceImage.Folder;
			this.FileLoadToolStripMenuItem.Name = "FileLoadToolStripMenuItem";
			this.FileLoadToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.FileLoadToolStripMenuItem.Text = "Datei öffnen";
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
			// 
			// comboBoxPort
			// 
			this.comboBoxPort.Enabled = false;
			this.comboBoxPort.FormattingEnabled = true;
			this.comboBoxPort.Location = new System.Drawing.Point(147, 39);
			this.comboBoxPort.Name = "comboBoxPort";
			this.comboBoxPort.Size = new System.Drawing.Size(70, 22);
			this.comboBoxPort.TabIndex = 19;
			// 
			// comboBoxMethod
			// 
			this.comboBoxMethod.Enabled = false;
			this.comboBoxMethod.FormattingEnabled = true;
			this.comboBoxMethod.Location = new System.Drawing.Point(223, 39);
			this.comboBoxMethod.Name = "comboBoxMethod";
			this.comboBoxMethod.Size = new System.Drawing.Size(70, 22);
			this.comboBoxMethod.TabIndex = 21;
			// 
			// comboBoxSpeed
			// 
			this.comboBoxSpeed.Enabled = false;
			this.comboBoxSpeed.FormattingEnabled = true;
			this.comboBoxSpeed.Location = new System.Drawing.Point(299, 39);
			this.comboBoxSpeed.Name = "comboBoxSpeed";
			this.comboBoxSpeed.Size = new System.Drawing.Size(99, 22);
			this.comboBoxSpeed.TabIndex = 22;
			// 
			// listBoxUART
			// 
			this.listBoxUART.FormattingEnabled = true;
			this.listBoxUART.ItemHeight = 14;
			this.listBoxUART.Location = new System.Drawing.Point(12, 67);
			this.listBoxUART.Name = "listBoxUART";
			this.listBoxUART.Size = new System.Drawing.Size(460, 88);
			this.listBoxUART.TabIndex = 23;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Enabled = false;
			this.buttonAdd.Image = global::Toolbox.ResourceImage.Add;
			this.buttonAdd.Location = new System.Drawing.Point(404, 38);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(31, 23);
			this.buttonAdd.TabIndex = 24;
			this.buttonAdd.Text = " ";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// comboBoxType
			// 
			this.comboBoxType.FormattingEnabled = true;
			this.comboBoxType.Location = new System.Drawing.Point(12, 39);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(129, 22);
			this.comboBoxType.TabIndex = 25;
			this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Enabled = false;
			this.buttonRemove.Image = global::Toolbox.ResourceImage.Delete;
			this.buttonRemove.Location = new System.Drawing.Point(441, 38);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(31, 23);
			this.buttonRemove.TabIndex = 26;
			this.buttonRemove.Text = " ";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// FormPort
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 211);
			this.Controls.Add(this.buttonRemove);
			this.Controls.Add(this.comboBoxType);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.listBoxUART);
			this.Controls.Add(this.comboBoxSpeed);
			this.Controls.Add(this.comboBoxMethod);
			this.Controls.Add(this.comboBoxPort);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "FormPort";
			this.Text = "COM Einstellung";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPort_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBoxPort;
		private System.Windows.Forms.ComboBox comboBoxMethod;
		private System.Windows.Forms.ComboBox comboBoxSpeed;
		private System.Windows.Forms.ListBox listBoxUART;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.ComboBox comboBoxType;
		private System.Windows.Forms.Button buttonRemove;
	}
}