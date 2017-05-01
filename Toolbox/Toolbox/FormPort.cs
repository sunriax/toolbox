#define DEBUG
//#undef DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Toolbox.Language;
using Toolbox.UART;
using VersionLib;

namespace Toolbox
{
	public partial class FormPort : Form
	{
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklaration					+++|
		//	+--------------------------------------------------+

		private bool _saved = false;
		private Parameter _systemparameter;

		private string[] _combobox_type = { ResourceText.PleaseChoose, ResourceUART.Config, ResourceUART.Console, ResourceUART.Debug, ResourceUART.Update, ResourceUART.Hardware };
		private string[] _combobox_speed = { ResourceUART.SPEED_921600, ResourceUART.SPEED_115200, ResourceUART.SPEED_19200, ResourceUART.SPEED_9600 };
		private string[] _combobox_method = { ResourceUART.COM8N1, ResourceUART.COM8N2, ResourceUART.COM8E1, ResourceUART.COM8E2, ResourceUART.COM8O1, ResourceUART.COM8O2 };
		private string[] _combobox_ports = SerialPort.GetPortNames();
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Initialisierung
		//	+--------------------------------------------------+
		//	|+++	Initialisierung							+++|
		//	+--------------------------------------------------+

		public FormPort(Parameter SystemParameter)
		{
			InitializeComponent();
			_systemparameter = SystemParameter;

			// ComboBox Beschreibung Initialisieren
			comboBoxPort.DataSource = _combobox_ports;	
			comboBoxType.DataSource = _combobox_type;
			comboBoxSpeed.DataSource = _combobox_speed;
			comboBoxMethod.DataSource = _combobox_method;

			// Listbox Beschreibung Initialisieren
			if (_systemparameter.SystemPorts != null)
			{
				for (int i = 0; i < _systemparameter.SystemPorts.Count; i++)
					listBoxUART.Items.Add(string.Format("Type: {0} \tPort: {1}\tFormat:{2}|{3}", _systemparameter.SystemPorts[i][0], _systemparameter.SystemPorts[i][1], _systemparameter.SystemPorts[i][2], _systemparameter.SystemPorts[i][3]));

				buttonRemove.Enabled = true;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Start
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Start						+++|
		//	+--------------------------------------------------+
		private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Fenster schließen
			_saved = true;
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
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Events
		//	+--------------------------------------------------+
		//	|+++	Form -> Events							+++|
		//	+--------------------------------------------------+
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			listBoxUART.Items.Add(string.Format("Type: {0} \tPort: {1}\tFormat:{2}|{3}", comboBoxType.Text, comboBoxPort.Text, comboBoxMethod.Text, comboBoxSpeed.Text));

			buttonRemove.Enabled = true;

			string[] _item = { comboBoxType.Text, comboBoxPort.Text, comboBoxMethod.Text, comboBoxSpeed.Text };
			_systemparameter.SystemPorts.Add(_item);

		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			if (listBoxUART.SelectedIndex >= 0 && listBoxUART.SelectedIndex < listBoxUART.Items.Count)
				listBoxUART.Items.RemoveAt(listBoxUART.SelectedIndex);
			if (listBoxUART.Items.Count <= 0)
			{
				buttonRemove.Enabled = false;
				_systemparameter.SystemPorts.RemoveRange(0, _systemparameter.SystemPorts.Count);
			}
			else
				MessageBox.Show(ResourceText.MsgObjectMark, ResourceText.Hint, MessageBoxButtons.OK);
		}

		private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			for (int i = 1; i < _combobox_type.Length; i++)
			{
				// Überprüfen ob Componenten List = Componenten Type
				if (_combobox_type[i] == comboBoxType.Text)
				{
					// Symbole in Bearbeitungsmodus
					comboBoxPort.Enabled = true;
					comboBoxSpeed.Enabled = true;
					comboBoxMethod.Enabled = true;
					buttonAdd.Enabled = true;

					// Schleife verlassen
					break;
				}
				else
				{
					// Symbole in Speermodus
					comboBoxPort.Enabled = false;
					comboBoxSpeed.Enabled = false;
					comboBoxMethod.Enabled = false;
					buttonAdd.Enabled = false;

					// Schleife fortsetzen
					continue;
				}
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Form
		//	+--------------------------------------------------+
		//	|+++	Form -> Funktionen						+++|
		//	+--------------------------------------------------+
		private void FormPort_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = DialogResult.OK;

			if (_saved == false)
			// Abfragen ob Programm wirklich geschlossen werden soll
				result = MessageBox.Show(ResourceText.MsgProgramExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen beenden
			if (result == DialogResult.Cancel)
				e.Cancel = true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Properties
		//	+--------------------------------------------------+
		//	|+++	System -> Properties					+++|
		//	+--------------------------------------------------+
		public List<string[]> GetPorts
		{
			get
			{
				return _systemparameter.SystemPorts;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
}
