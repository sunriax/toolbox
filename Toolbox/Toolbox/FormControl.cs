using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolbox.Language;
using Toolbox.UART;
using NetworkLib;
using VersionLib;

namespace Toolbox
{

	public partial class FormControl : Form
	{
		// Systemparameter
		private Parameter _systemparameter;

		public FormControl(Parameter SystemParameter)
		{
			InitializeComponent();

			_systemparameter = SystemParameter;
		}

		#region Start
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Start						+++|
		//	+--------------------------------------------------+
		private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void FileLoadToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Abfragen ob Dialog wirklich geschlossen werden soll wenn keine Verbindung hergestellt
			DialogResult result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				return;

			// Programm beenden
			Close();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Hilfe
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Hilfe						+++|
		//	+--------------------------------------------------+
		private void VersionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Hilfe -> Version
			// Versionsfenster öffnen
			FormVersion FormPointer = new FormVersion(_systemparameter);
			DialogResult Form = FormPointer.ShowDialog();

			// Rücksprung aus Versionsfenster behandeln
			if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
				return;
		}

		private void HelpSupportToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Form
		//	+--------------------------------------------------+
		//	|+++	Form -> Funktionen						+++|
		//	+--------------------------------------------------+
		private void FormControl_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Abfragen ob Dialog wirklich geschlossen werden soll wenn keine Verbindung hergestellt
			DialogResult result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				e.Cancel = true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
}
