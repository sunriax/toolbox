﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolbox.Language;
using ToolboxLib;
using NetworkLib;

namespace Toolbox
{
	public partial class FormAuthMethod : Form
	{
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklartion						+++|
		//	+--------------------------------------------------+

		private int _accountid = -1;
		private bool _authentification = false;
		private string _certificate = null;
		private Parameter _systemparameter;

		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		public FormAuthMethod(Parameter SystemParameter)
		{
			InitializeComponent();
			_systemparameter = SystemParameter;

			_accountid = _systemparameter.AccountId;
			_authentification = _systemparameter.AccountType;

			// TextBoxen mit Standardparameteren belegen
			textboxinit();

			if (_systemparameter.SystemAccount.Count > 0)
				Tool.ListviewInit(listViewAccount, _systemparameter.SystemAccount);

			if (_systemparameter.SystemCertificate.Count > 0)
				Tool.ListviewInit(listViewCertificate, _systemparameter.SystemCertificate);

			if (_authentification == false && listViewAccount.Items.Count > 0)
			{
				if(_accountid >= 0)
				{
					listViewAccount.Items[_accountid].Focused = true;
					listViewAccount.Items[_accountid].Selected = true;
				}
				else
				{
					listViewAccount.Items[0].Focused = true;
					listViewAccount.Items[0].Selected = true;
				}

				tabControl.SelectedIndex = 0;
			}
			else if (_authentification == true && listViewCertificate.Items.Count > 0)
			{
				if (_accountid >= 0)
				{
					listViewCertificate.Items[_accountid].Focused = true;
					listViewCertificate.Items[_accountid].Selected = true;
				}
				else
				{
					listViewCertificate.Items[0].Focused = true;
					listViewCertificate.Items[0].Selected = true;
				}

				tabControl.SelectedIndex = 1;
			}
		}

		#region Start
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Start						+++|
		//	+--------------------------------------------------+

		private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Einstellen der Datenformate für speichern der Benutzerdaten
			saveFileDialogData.Filter = ResourceText.AccountFileFilter;
			
			// Datei speichern Dialog anzeigen
			DialogResult FilePointer = saveFileDialogData.ShowDialog();

			// Überprüfen ob Dateidialog ohne Eingabe
			if (FilePointer == DialogResult.Cancel || FilePointer == DialogResult.Abort)
				return;

			string filename = saveFileDialogData.FileName;	// Datenpfad auf lokale Variable legen
			string[][] data = new string[_systemparameter.SystemAccount.Count + _systemparameter.SystemCertificate.Count][];    // 2D-Array zur Speicherung der Accountdaten

			// ??? Programmabschnitt eventuell optimierbar !!!
			// Überprüfen ob Accountdaten vorhanden
			if (_systemparameter.SystemAccount.Count > 0)
				for(int i=0; i < _systemparameter.SystemAccount.Count; i++)
				{
					data[i] = new string[_systemparameter.SystemAccount[i].Count + 1];
					data[i] = _systemparameter.SystemAccount[i].Values.ToArray();
				}
			// Überprüfen ob Zertifikatdaten vorhanden
			if (_systemparameter.SystemCertificate.Count > 0)
				for (int j = 0; j < _systemparameter.SystemCertificate.Count; j++)
				{
					data[_systemparameter.SystemAccount.Count + j] = new string[_systemparameter.SystemCertificate[j].Count + 1];
					data[_systemparameter.SystemAccount.Count + j] = _systemparameter.SystemCertificate[j].Values.ToArray();
				}
			// ???????????????????????????????????????????????

			bool crypt = true;	// Variable zum einstellen der Dateiverschlüsselung

			// !!! Nur vorübergehende Lösung (unsauber) !!!
			string passphrase = Interaction.InputBox("Bitte Passphrase zum Verschlüsseln der Kennwortdaten eingeben, bei leerer Eingabe werden die Daten unverschlüsselt gespeichert, (Kennwörter werden immer verschlüsselt!)", "Eingabeaufforderung");

			if (passphrase == ResourceText.EMPTY)
				crypt = false;
			// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

			// Verschlüsselte Accountdatei erzeugen
			if (!Handler.WriteCSV(Path.GetDirectoryName(filename), Path.GetFileName(filename), '|', data, crypt, passphrase))
				MessageBox.Show(ResourceText.MsgSaveUserdata, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Einstellen der Datenformate für auslesen der Accountdaten
			openFileDialogData.Filter = ResourceText.AccountFileFilter;

			// Datei öffnen Dialog anzeigen
			DialogResult FilePointer = openFileDialogData.ShowDialog();

			// Überprüfen ob Dateidialog ohne Eingabe
			if (FilePointer == DialogResult.Cancel || FilePointer == DialogResult.Abort)
				return;

			DialogResult Abort = DialogResult.OK;	// Variable zum späteren überprüfen ob auslesen abgebrochen

			// Überprüfen ob Daten in Datensätzen vorhanden
			if (listViewAccount.Items.Count > 0 || listViewCertificate.Items.Count > 0)
				Abort = MessageBox.Show(ResourceText.MsgFileOpenOverwrite, ResourceText.Warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);

			// Überprüfen ob überschreiben abgebrochen
			if (Abort == DialogResult.Cancel)
				return;

			string filename = openFileDialogData.FileName;	// Datenpfad auf lokale Variable legen
			string[][] data;                                // interne Datenvariable

			bool crypt = true;  // Variable zum einstellen der Dateiverschlüsselung

			// !!! Nur vorübergehende Lösung (unsauber) !!!
			string passphrase = Interaction.InputBox("Bitte Passphrase zum Entschlüsseln der Kennwortdaten eingeben, bei leerer Eingabe werden die Daten unverschlüsselt gespeichert, (Kennwörter werden immer verschlüsselt!)", "Eingabeaufforderung");

			if (passphrase == ResourceText.EMPTY)
				crypt = false;
			// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

			// Überprüfen ob Daten ausgelesen und vorhanden
			if ((data = Handler.ReadCSV(Path.GetDirectoryName(filename), Path.GetFileName(filename), '|', crypt, passphrase)) == null)
				return;

			// Vorhandene Daten aus Wörterbüchern entfernen
			_systemparameter.SystemAccount.Clear();
			_systemparameter.SystemCertificate.Clear();

			// Neue Daten in Wörterbücher sowie Listbox Schreiben
			Tool.Account2Dict(data, _systemparameter.SystemAccount, listViewAccount, true);
			Tool.Certificate2Dict(data, _systemparameter.SystemCertificate, listViewCertificate, true);

			_accountid = -1;			// Accountid Rücksetzen
			_authentification = false;	// Authentifizierungsmethode rücksetzen
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
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Hilfe
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Hilfe						+++|
		//	+--------------------------------------------------+

		private void HelpSupportToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

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

		#region Form
		//	+--------------------------------------------------+
		//	|+++	Form -> Funktionen						+++|
		//	+--------------------------------------------------+

		private void FormAuthMethod_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				e.Cancel = true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Events
		//	+--------------------------------------------------+
		//	|+++	Form -> Events							+++|
		//	+--------------------------------------------------+

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			//	if (tabControl.SelectedTab.Name == ResourceText.AuthTabUser)
			//		_authentification = false;
			//	else if (tabControl.SelectedTab.Name == ResourceText.AuthTabCertificate)
			//		_authentification = true;
		}

		private void listViewAccount_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewAccount.SelectedItems.Count < 1)
				return;

			labelAuthParameter.Text = listViewAccount.SelectedItems[0].SubItems[1].Text;
			labelAuthParameter.Visible = true;

			_authentification = false;
			_accountid = Convert.ToInt32(listViewAccount.SelectedItems[0].SubItems[0].Text);

			listViewAccount.Invalidate();
		}

		private void buttonAccountNew_Click(object sender, EventArgs e)
		{
			// TextBoxen mit Standardparameteren belegen
			textboxinit();
		}

		private void buttonAccountAdd_Click(object sender, EventArgs e)
		{
			DialogResult datapattern = DialogResult.OK;
			bool resolve = false;
			bool noresolve = false;

			// Überprüfen ob Eingabefelder leer sind
			if (!Tool.CheckString(textBoxAccountUsername) ||
				!Tool.CheckString(textBoxAccountPassword) ||
				!Tool.CheckString(textBoxAccountServer	) ||
				!Tool.CheckString(textBoxAccountPort	))
				return;

			// Überprüfen ob Eingabefelder gleich den Standardeingabefeldern
			if (textBoxAccountUsername.Text == ResourceText.ValueUsername &&
				textBoxAccountPassword.Text == ResourceText.ValuePassword)
				datapattern = MessageBox.Show(ResourceText.MsgSameData, ResourceText.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			// Überprüfen ob bei Standardeingabe Abbruch erfolgen soll
			if (datapattern == DialogResult.No)
				return;

			if (textBoxAccountServer.Text == ResourceText.ValueServer)
				textBoxAccountServer.Text = ResourceText.AuthServer;

			// Überprüfen ob Porteingabe zulässig (1 - 65535)
			if (!Tool.CheckString(textBoxAccountPort, 1, 65536))
				return;

			// Überprüfen ob Server TextBox kein Standard Initiator enthält
			if (textBoxAccountServer.Text != ResourceText.AuthServer)
			{
				// Überprüfen ob eingegebene IP-Addresse zulässig
				if (!Network.CheckIP(textBoxAccountServer.Text))
				{
					if (!Network.CheckHost(textBoxAccountServer.Text))
					{
						textBoxAccountServer.BackColor = Color.Red;
						textBoxAccountServer.SelectAll();

						MessageBox.Show(ResourceText.MsgServerFault, ResourceText.Warning, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					else
					{
						if (Network.PingHost(textBoxAccountServer.Text, 4))
							resolve = true;
					}
				}
				else
				{
					if (Network.PingIP(textBoxAccountServer.Text, 4))
						resolve = true;
				}
			}
			else
			{
				noresolve = true;
			}

			int listviewid = listViewAccount.Items.Count;
			string[] listviewitem = { listviewid.ToString(), textBoxAccountUsername.Text, ResourceText.SpacerPassword, textBoxAccountServer.Text, textBoxAccountPort.Text };

			// ListView mit neuem Eintrag ergänzen
			ListViewItem item;
			item = new ListViewItem(listviewitem);
			listViewAccount.Items.Add(item);

			// ListView Eintrag Server erreichbarkeit prüfen
			if (resolve == true && noresolve == false)
				listViewAccount.Items[listviewid].ForeColor = Color.Green;
			else if (resolve == false && noresolve == false)
				listViewAccount.Items[listviewid].ForeColor = Color.Red;

			// Account Liste mit neuem Eintrag ergänzen
			_systemparameter.SystemAccount[listviewid] = new Dictionary<string, string>();
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyMode,		ResourceText.AuthModePWD);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyUsername,	textBoxAccountUsername.Text);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyPassword,	Chiper.Encrypt(textBoxAccountPassword.Text, ResourceText.Passphrase));
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyServer,		textBoxAccountServer.Text);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyPort,		textBoxAccountPort.Text);
			_systemparameter.SystemAccount[listviewid].Add(ResourceText.keyEmpty,		ResourceText.EMPTY);

			// TextBoxen mit Standardparameteren belegen
			textboxinit();
		}

		private void buttonAccountDelete_Click(object sender, EventArgs e)
		{
			if (listViewAccount.SelectedItems.Count < 1 || listViewAccount.Items.Count < 2)
				return;

			int listviewid = Convert.ToInt16(listViewAccount.SelectedItems[0].SubItems[0].Text);

			_systemparameter.SystemAccount.Remove(listviewid);
			
			listViewAccount.SelectedItems[0].Remove();

			listViewAccount.Items[0].Focused = true;
			listViewAccount.Items[0].Selected = true;
		}

		private void textBoxAccountUsername_Enter(object sender, EventArgs e)
		{
			if (textBoxAccountUsername.Text == ResourceText.ValueUsername)
				textBoxAccountUsername.Text = ResourceText.EMPTY;

			textBoxAccountUsername.ForeColor = Color.Black;
		}

		private void textBoxAccountUsername_Leave(object sender, EventArgs e)
		{
			if (textBoxAccountUsername.Text == ResourceText.EMPTY)
				textBoxAccountUsername.Text = ResourceText.ValueUsername;
		}

		private void textBoxAccountPassword_Enter(object sender, EventArgs e)
		{
			if (textBoxAccountPassword.Text == ResourceText.ValuePassword)
				textBoxAccountPassword.Text = ResourceText.EMPTY;
			textBoxAccountPassword.ForeColor = Color.Black;
		}

		private void textBoxAccountPassword_Leave(object sender, EventArgs e)
		{
			if (textBoxAccountPassword.Text == ResourceText.EMPTY)
				textBoxAccountPassword.Text = ResourceText.ValuePassword;
		}

		private void textBoxAccountServer_Enter(object sender, EventArgs e)
		{
			if (textBoxAccountServer.Text == ResourceText.ValueServer)
				textBoxAccountServer.Text = ResourceText.EMPTY;
			textBoxAccountServer.ForeColor = Color.Black;
		}

		private void textBoxAccountServer_Leave(object sender, EventArgs e)
		{
			if (textBoxAccountServer.Text == ResourceText.EMPTY)
				textBoxAccountServer.Text = ResourceText.ValueServer;
		}

		private void textBoxAccountServer_MouseEnter(object sender, EventArgs e)
		{
			labelHelp.Text = ResourceText.MsgServerHelp;
			labelHelp.Visible = true;
		}

		private void textBoxAccountServer_MouseLeave(object sender, EventArgs e)
		{
			labelHelp.Visible = false;
		}

		private void textBoxAccountPort_Enter(object sender, EventArgs e)
		{
			if (textBoxAccountPort.Text == ResourceText.ValuePort)
				textBoxAccountPort.Text = ResourceText.EMPTY;
			textBoxAccountPort.ForeColor = Color.Black;
		}

		private void textBoxAccountPort_Leave(object sender, EventArgs e)
		{
			if (textBoxAccountPort.Text == ResourceText.EMPTY)
				textBoxAccountPort.Text = ResourceText.ValuePort;
		}
		// ------------------------------------------------------------------------------

		private void listViewCertificate_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewCertificate.SelectedItems.Count < 1)
				return;

			labelAuthParameter.Text = listViewCertificate.SelectedItems[0].SubItems[1].Text;
			labelAuthParameter.Visible = true;

			_authentification = true;
			_accountid = Convert.ToInt32(listViewCertificate.SelectedItems[0].SubItems[0].Text);

			listViewAccount.Invalidate();
		}

		private void buttonCertificateNew_Click(object sender, EventArgs e)
		{
			// TextBoxen mit Standardparameteren belegen
			textboxinit();
		}

		private void buttonCertificatePath_Click(object sender, EventArgs e)
		{
			openFileDialogCertificate.Filter = ResourceText.CertificateFileFilter;

			DialogResult FilePointer = openFileDialogCertificate.ShowDialog();

			if (FilePointer == DialogResult.Cancel || FilePointer == DialogResult.Abort)
				return;

			_certificate = openFileDialogCertificate.FileName;

			if (textBoxCertificateName.Text == ResourceText.ValueCertificate)
				textBoxCertificateName.Text = Path.GetFileNameWithoutExtension(_certificate);
		}

		private void buttonCertificateAdd_Click(object sender, EventArgs e)
		{
			DialogResult datapattern = DialogResult.OK;
			bool resolve = false;
			bool noresolve = false;

			// Überprüfen ob Zertifikat eingegeben
			if (_certificate == null)
			{
				datapattern = MessageBox.Show(ResourceText.MsgNoFileSelected, ResourceText.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Überprüfen ob Eingabefelder leer sind
			if (!Tool.CheckString(textBoxCertificateName) ||
				!Tool.CheckString(textBoxCertificatePassphrase) ||
				!Tool.CheckString(textBoxCertificateServer) ||
				!Tool.CheckString(textBoxCertificatePort))
				return;

			// Überprüfen ob Eingabefelder gleich den Standardeingabefeldern
			if (textBoxCertificateName.Text == ResourceText.ValueCertificate &&
				textBoxCertificatePassphrase.Text == ResourceText.ValuePassword)
				datapattern = MessageBox.Show(ResourceText.MsgSameData, ResourceText.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			// Überprüfen ob bei Standardeingabe Abbruch erfolgen soll
			if (datapattern == DialogResult.No)
				return;

			if (textBoxCertificateServer.Text == ResourceText.ValueServer)
				textBoxCertificateServer.Text = ResourceText.AuthServer;

			// Überprüfen ob Porteingabe zulässig (1 - 65535)
			if (!Tool.CheckString(textBoxCertificatePort, 1, 65536))
				return;

			// Überprüfen ob Server TextBox kein Standard Initiator enthält
			if (textBoxCertificateServer.Text != ResourceText.AuthServer)
			{
				// Überprüfen ob eingegebene IP-Addresse zulässig
				if (!Network.CheckIP(textBoxCertificateServer.Text))
				{
					if (!Network.CheckHost(textBoxCertificateServer.Text))
					{
						textBoxCertificateServer.BackColor = Color.Red;
						textBoxCertificateServer.SelectAll();

						MessageBox.Show(ResourceText.MsgServerFault, ResourceText.Warning, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					else
					{
						if (Network.PingHost(textBoxCertificateServer.Text, 4))
							resolve = true;
					}
				}
				else
				{
					if (Network.PingIP(textBoxCertificateServer.Text, 4))
						resolve = true;
				}
			}
			else
			{
				noresolve = true;
			}

			if (!Handler.FileCopy(_certificate, Application.StartupPath + ResourceText.AuthCertificatePath, true))
			{
				MessageBox.Show(ResourceText.MsgFileCopyFault, ResourceText.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int listviewid = listViewCertificate.Items.Count;
			string[] listviewitem = { listviewid.ToString(), textBoxCertificateName.Text, ResourceText.SpacerPassword, textBoxCertificateServer.Text, textBoxCertificatePort.Text };

			// ListView mit neuem Eintrag ergänzen
			ListViewItem item;
			item = new ListViewItem(listviewitem);
			listViewCertificate.Items.Add(item);

			// ListView Eintrag Server erreichbarkeit prüfen
			if (resolve == true && noresolve == false)
				listViewCertificate.Items[listviewid].ForeColor = Color.Green;
			else if (resolve == false && noresolve == false)
				listViewCertificate.Items[listviewid].ForeColor = Color.Red;

			// Account Liste mit neuem Eintrag ergänzen
			_systemparameter.SystemCertificate[listviewid] = new Dictionary<string, string>();
			_systemparameter.SystemCertificate[listviewid].Add(ResourceText.keyMode, ResourceText.AuthModeCERT);
			_systemparameter.SystemCertificate[listviewid].Add(ResourceText.keyCertificate, textBoxCertificateName.Text);
			_systemparameter.SystemCertificate[listviewid].Add(ResourceText.keyCertificateName, Path.GetFileName(_certificate));
			_systemparameter.SystemCertificate[listviewid].Add(ResourceText.keyPassphrase, Chiper.Encrypt(textBoxCertificatePassphrase.Text, ResourceText.Passphrase));
			_systemparameter.SystemCertificate[listviewid].Add(ResourceText.keyServer, textBoxCertificateServer.Text);
			_systemparameter.SystemCertificate[listviewid].Add(ResourceText.keyPort, textBoxCertificatePort.Text);

			// TextBoxen mit Standardparameteren belegen
			textboxinit();

			_certificate = null;
		}

		private void buttonCertificateDelete_Click(object sender, EventArgs e)
		{
			if (listViewCertificate.SelectedItems.Count < 1 || listViewCertificate.Items.Count < 2)
				return;

			int listviewid = Convert.ToInt16(listViewCertificate.SelectedItems[0].SubItems[0].Text);

			_systemparameter.SystemCertificate.Remove(listviewid);

			listViewCertificate.SelectedItems[0].Remove();

			listViewCertificate.Items[0].Focused = true;
			listViewCertificate.Items[0].Selected = true;
		}

		private void textBoxCertificateName_Enter(object sender, EventArgs e)
		{
			if (textBoxCertificateName.Text == ResourceText.ValueCertificate)
				textBoxCertificateName.Text = ResourceText.EMPTY;

			textBoxCertificateName.ForeColor = Color.Black;
		}

		private void textBoxCertificateName_Leave(object sender, EventArgs e)
		{
			if (textBoxCertificateName.Text == ResourceText.EMPTY)
				textBoxCertificateName.Text = ResourceText.ValueUsername;
		}

		private void textBoxCertificatePassphrase_Enter(object sender, EventArgs e)
		{
			if (textBoxCertificatePassphrase.Text == ResourceText.ValuePassword)
				textBoxCertificatePassphrase.Text = ResourceText.EMPTY;
			textBoxCertificatePassphrase.ForeColor = Color.Black;
		}

		private void textBoxCertificatePassphrase_Leave(object sender, EventArgs e)
		{
			if (textBoxCertificatePassphrase.Text == ResourceText.EMPTY)
				textBoxCertificatePassphrase.Text = ResourceText.ValuePassword;
		}

		private void textBoxCertificateServer_Enter(object sender, EventArgs e)
		{
			if (textBoxCertificateServer.Text == ResourceText.ValueServer)
				textBoxCertificateServer.Text = ResourceText.EMPTY;
			textBoxCertificateServer.ForeColor = Color.Black;
		}

		private void textBoxCertificateServer_Leave(object sender, EventArgs e)
		{
			if (textBoxCertificateServer.Text == ResourceText.EMPTY)
				textBoxCertificateServer.Text = ResourceText.ValueServer;
		}

		private void textBoxCertificatePort_Enter(object sender, EventArgs e)
		{
			if (textBoxCertificatePort.Text == ResourceText.ValuePort)
				textBoxCertificatePort.Text = ResourceText.EMPTY;
			textBoxCertificatePort.ForeColor = Color.Black;
		}

		private void textBoxCertificatePort_Leave(object sender, EventArgs e)
		{
			if (textBoxCertificatePort.Text == ResourceText.EMPTY)
				textBoxCertificatePort.Text = ResourceText.ValuePort;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Funktionen
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Start						+++|
		//	+--------------------------------------------------+

		private void textboxinit()
		{
				textBoxAccountUsername.Text = ResourceText.ValueUsername;
				textBoxAccountPassword.Text = ResourceText.ValuePassword;
				textBoxAccountServer.Text = ResourceText.ValueServer;
				textBoxAccountPort.Text = ResourceText.ValuePort;

				textBoxAccountUsername.ForeColor = Color.LightGray;
				textBoxAccountPassword.ForeColor = Color.LightGray;
				textBoxAccountServer.ForeColor = Color.LightGray;
				textBoxAccountPort.ForeColor = Color.LightGray;

				textBoxCertificateName.Text = ResourceText.ValueCertificate;
				textBoxCertificatePassphrase.Text = ResourceText.ValuePassword;
				textBoxCertificateServer.Text = ResourceText.ValueServer;
				textBoxCertificatePort.Text = ResourceText.ValuePort;

				textBoxCertificateName.ForeColor = Color.LightGray;
				textBoxCertificatePassphrase.ForeColor = Color.LightGray;
				textBoxCertificateServer.ForeColor = Color.LightGray;
				textBoxCertificatePort.ForeColor = Color.LightGray;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Properties
		//	+--------------------------------------------------+
		//	|+++	System -> Properties					+++|
		//	+--------------------------------------------------+

		public bool GetAuthentification
		{
			get
			{
				return _authentification;
			}
		}
		
		public int GetAccountId
		{
			get
			{
				return _accountid;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
}
