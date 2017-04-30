using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Toolbox.Language;
using NetworkLib;

namespace Toolbox
{
	public partial class FormLinuxAccount : Form
	{

		//private Dictionary<int, Dictionary<string, string>> _account = new Dictionary<int, Dictionary<string, string>>();
		private Network _network = new Network();
		private int _selectedid;
		private string _certificate = null;
		private Parameter _systemparameter;

		public FormLinuxAccount(Parameter SystemParameter)
		{
			InitializeComponent();

			_systemparameter = SystemParameter;

			// TextBoxen mit Standardparameteren belegen
			textboxinit();

			for(int i=0; i < _systemparameter.SystemAccount.Count; i++)
			{
				if (_systemparameter.SystemAccount[i][ResourceText.keyMode] == ResourceText.AuthModePWD)
				{
					string[] listviewitem = { listViewAccount.Items.Count.ToString(), _systemparameter.SystemAccount[i][ResourceText.keyUsername], ResourceText.SpacerPassword, _systemparameter.SystemAccount[i][ResourceText.keyServer], _systemparameter.SystemAccount[i][ResourceText.keyPort] };

					ListViewItem item;
					item = new ListViewItem(listviewitem);
					listViewAccount.Items.Add(item);
				}
			}

			listViewAccount.Items[0].Focused = true;
			listViewAccount.Items[0].Selected = true;
		}

		private void listViewAccount_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewAccount.SelectedItems.Count < 1)
				return;

			labelAccount.Text = listViewAccount.SelectedItems[0].SubItems[1].Text;
			labelAccount.Visible = true;

			_selectedid = Convert.ToInt16(listViewAccount.SelectedItems[0].SubItems[0].Text);

			listViewAccount.Invalidate();
		}


		private void buttonAdd_Click(object sender, EventArgs e)
		{
			DialogResult datapattern = DialogResult.OK;

			// Überprüfen ob Eingabefelder leer sind
			if (!checkfield(textBoxUsername, ResourceText.EMPTY)	||
				!checkfield(textBoxPassword, ResourceText.EMPTY)	||
				!checkfield(textBoxServer, ResourceText.EMPTY)		||
				!checkfield(textBoxPort, ResourceText.EMPTY))
					return;

			// Überprüfen ob Eingabefelder gleich den Standardeingabefeldern
			if (textBoxUsername.Text == ResourceText.ValueUsername &&
				textBoxPassword.Text == ResourceText.ValuePassword)
					datapattern = MessageBox.Show(ResourceText.MsgSameData, ResourceText.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			// Überprüfen ob bei Standardeingabe Abbruch erfolgen soll
			if (datapattern == DialogResult.No)
				return;

			// Überprüfen ob Porteingabe zulässig (1 - 65535)
			if (!checkfield(textBoxPort, 1, 65536))
				return;

			// Überprüfen ob Server TextBox kein Standard Initiator enthält
			if (textBoxServer.Text != ResourceText.AuthAllServer)
				// Überprüfen ob ungültige Zeichen eingegeben wurden

				// Überprüfen ob eingegebene IP-Addresse zulässig
				if (_network.checkip(textBoxServer.Text) == false)
					return;

			int listviewid = listViewAccount.Items.Count;
			string[] listviewitem = { listviewid.ToString(), textBoxUsername.Text, ResourceText.SpacerPassword, textBoxServer.Text, textBoxPort.Text};

			// ListView mit neuem Eintrag ergänzen
			ListViewItem item;
			item = new ListViewItem(listviewitem);
			listViewAccount.Items.Add(item);

			// Account Liste mit neuem Eintrag ergänzen
			_systemparameter.SystemAccount[listviewid] = new Dictionary<string, string>();
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyMode,		ResourceText.AuthModePWD);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyUsername,	textBoxUsername.Text);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyPassword,	textBoxPassword.Text);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyServer,		textBoxServer.Text);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyPort,		textBoxPort.Text);

			// TextBoxen mit Standardparameteren belegen
			textboxinit();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (listViewAccount.SelectedItems.Count < 1)
				return;

			if (listViewAccount.Items.Count < 2)
				return;

			int listviewid = Convert.ToInt16(listViewAccount.SelectedItems[0].SubItems[0].Text);

			_systemparameter.SystemAccount.Remove(listviewid);

			listViewAccount.SelectedItems[0].Remove();

			listViewAccount.Items[0].Focused = true;
			listViewAccount.Items[0].Selected = true;
		}

		private void buttonNew_Click(object sender, EventArgs e)
		{
			// TextBoxen mit Standardparameteren belegen
			textboxinit();
		}

		private void textBoxUsername_Enter(object sender, EventArgs e)
		{
			if(textBoxUsername.Text == ResourceText.ValueUsername)
				textBoxUsername.Text = ResourceText.EMPTY;

			textBoxUsername.ForeColor = Color.Black;
		}

		private void textBoxUsername_Leave(object sender, EventArgs e)
		{
			if (textBoxUsername.Text == ResourceText.EMPTY)
				textBoxUsername.Text = ResourceText.ValueUsername;
		}

		private void textBoxPassword_Enter(object sender, EventArgs e)
		{
			if (textBoxPassword.Text == ResourceText.ValuePassword)
				textBoxPassword.Text = ResourceText.EMPTY;
			textBoxPassword.ForeColor = Color.Black;
		}

		private void textBoxPassword_Leave(object sender, EventArgs e)
		{
			if (textBoxPassword.Text == ResourceText.EMPTY)
				textBoxPassword.Text = ResourceText.ValuePassword;
		}

		private void textBoxServer_Enter(object sender, EventArgs e)
		{
			if (textBoxServer.Text == ResourceText.ValueServer)
				textBoxServer.Text = ResourceText.EMPTY;
			textBoxServer.ForeColor = Color.Black;
		}

		private void textBoxServer_Leave(object sender, EventArgs e)
		{
			if (textBoxServer.Text == ResourceText.EMPTY)
				textBoxServer.Text = ResourceText.ValueServer;
		}

		private void textBoxPort_Enter(object sender, EventArgs e)
		{
			if (textBoxPort.Text == ResourceText.ValuePort)
				textBoxPort.Text = ResourceText.EMPTY;
			textBoxPort.ForeColor = Color.Black;
		}

		private void textBoxPort_Leave(object sender, EventArgs e)
		{
			if (textBoxPort.Text == ResourceText.EMPTY)
				textBoxPort.Text = ResourceText.ValuePort;
		}

		private bool checkfield(TextBox inputTextBox, string check)
		{
			inputTextBox.BackColor = Color.Empty;

				if (inputTextBox.Text != ResourceText.EMPTY)
					return true;
			
			inputTextBox.BackColor = Color.Red;
			inputTextBox.SelectAll();

			MessageBox.Show(ResourceText.MsgIPFault, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		private bool checkfield(TextBox inputTextBox, int MIN, int MAX)
		{
			int variable = 0;
			inputTextBox.BackColor = Color.Empty;

			if (int.TryParse(inputTextBox.Text, out variable))
			{
				if (variable <= MAX && variable >= MIN)
					return true;
			}

			inputTextBox.BackColor = Color.Red;
			inputTextBox.SelectAll();

			MessageBox.Show(ResourceText.MsgIPFault, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		private void textBoxServer_MouseEnter(object sender, EventArgs e)
		{
			labelHelp.Text = ResourceText.MsgServerHelp;
			labelHelp.Visible = true;
		}

		private void textBoxServer_MouseLeave(object sender, EventArgs e)
		{
			labelHelp.Visible = false;
			
		}

		private void textboxinit()
		{
			textBoxUsername.Text = ResourceText.ValueUsername;
			textBoxPassword.Text = ResourceText.ValuePassword;
			textBoxServer.Text = ResourceText.ValueServer;
			textBoxPort.Text = ResourceText.ValuePort;

			textBoxCert.Text = ResourceText.ValueCertificate;

			textBoxUsername.ForeColor = Color.LightGray;
			textBoxPassword.ForeColor = Color.LightGray;
			textBoxServer.ForeColor = Color.LightGray;
			textBoxPort.ForeColor = Color.LightGray;
		}

		private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				return;

			// Programm beenden
			Close();
		}

		private void FormLinuxAccount_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				e.Cancel = true;
		}

		public int GetId
		{
			get
			{
				return _selectedid;
			}
		}

		private void buttonCert_Click(object sender, EventArgs e)
		{
			openFileDialogCert.Filter = ResourceText.CertificateFileFilter;

			DialogResult FilePointer = openFileDialogCert.ShowDialog();

			if (FilePointer == DialogResult.Cancel || FilePointer == DialogResult.Abort)
				return;

			string _certificate = openFileDialogCert.FileName;

			if (textBoxCert.Text == ResourceText.ValueCertificate)
				textBoxCert.Text = Path.GetFileNameWithoutExtension(_certificate);

		}

		private void buttonCertAdd_Click(object sender, EventArgs e)
		{
			if (_certificate == null)
				return;

			// string certificate_name = Path.GetFileName(_certificate);
			// string certificate_path = ResourceText.CertificateFileFilter;

			/*if (!Directory.Exists(certificate_path))
				try
				{
					DirectoryInfo DirectoryPointer = Directory.CreateDirectory(certificate_path);
				}
				catch
				{
					MessageBox.Show("Fehler Zertifikatordner konnte nicht erstellt werden");
					return;
				}

			if(!File.Exists(certificate_path + certificate_name))
				try
				{
					File.Copy(_certificate, certificate_path + certificate_name);
				}
				catch
				{
					MessageBox.Show("Fehler Datei konnte nicht kopiert werden");
					return;
				}
			*/

		}

		private void buttonCertDelete_Click(object sender, EventArgs e)
		{

		}

		private void buttonNewCert_Click(object sender, EventArgs e)
		{

		}

		private void textBoxPhassphrase_Enter(object sender, EventArgs e)
		{
			if (textBoxPhassphrase.Text == ResourceText.EMPTY)
				textBoxPort.Text = ResourceText.ValuePort;
		}

		private void textBoxPhassphrase_Leave(object sender, EventArgs e)
		{

		}

		private void textBoxCertServer_Enter(object sender, EventArgs e)
		{

		}

		private void textBoxCertServer_Leave(object sender, EventArgs e)
		{

		}

		private void textBoxCertPort_Enter(object sender, EventArgs e)
		{

		}

		private void textBoxCertPort_Leave(object sender, EventArgs e)
		{

		}

		private void VersionToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
