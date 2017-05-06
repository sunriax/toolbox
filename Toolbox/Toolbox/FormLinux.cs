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
using System.Configuration;
using System.IO;
using Toolbox.Language;
using Toolbox.UART;
using NetworkLib;
using VersionLib;

namespace Toolbox
{
	public partial class FormLinux : Form
	{
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklaration					+++|
		//	+--------------------------------------------------+

		// Wird nur Initialisiert wenn DEBUG definiert, ansonsten wird
		// die standard IP-Adresse übernommen die in den jeweiligen
		// Textboxen hinterlegt sind.
		private int _IPByte1 = 192;			// IP-Adresse 1. Byte (192)
		private int _IPByte2 = 168;         // IP-Adresse 2. Byte (168)
		private int _IPByte3 = 132;         // IP-Adresse 3. Byte (0)
		private int _IPByte4 = 130;         // IP-Adresse 4. Byte (1)

		private int _IPport = 22;			// Standard IP Port für SSH Verbindungen
		private int _accountid = -1;        // Variable zum anzeigen welcher Account ausgewählt wurde
		private bool _authentification= false;

		private Parameter _systemparameter; // Lokale Systemparameter Variable
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Initialisierung
		//	+--------------------------------------------------+
		//	|+++	Form/Komponenteninitialisierung			+++|
		//	+--------------------------------------------------+

		public FormLinux(Parameter SystemParameter)
		{
			InitializeComponent();
			_systemparameter = SystemParameter;

			_authentification = _systemparameter.AccountType;
			_accountid = _systemparameter.AccountId;

			// Überprüfen ob SSH Verbindung vorhanden
			if(_systemparameter.SystemSSH != null)
				makelabel(labelConnection, Color.Green, ResourceText.ConnectionEstablished);

#if (DEBUG)
			// IP Adresse (Textbox) mit internen Werten beschreiben
			textBoxIPByte1.Text = _IPByte1.ToString();
			textBoxIPByte2.Text = _IPByte2.ToString();
			textBoxIPByte3.Text = _IPByte3.ToString();
			textBoxIPByte4.Text = _IPByte4.ToString();

			// Port (Textbox) mit internen Werten beschreiben
			textBoxPort.Text = _IPport.ToString();
#endif

			// Überprüfen ob Passwort-Authentifizierung eingestellt
			if (_authentification == false && _systemparameter.SystemAccount[_accountid][ResourceText.keyMode] == ResourceText.AuthModePWD)
			{
				labelAuthMethod.Visible = true;
				makelabel(labelAuthMethod, Color.Empty, ResourceText.AuthPWD);
				_authentification = false;
			}
			// Überprüfen ob Zertifikat-Authentifizierung eingestellt
			else if (_authentification == true && _systemparameter.SystemCertificate[_accountid][ResourceText.keyMode] == ResourceText.AuthModeCERT)
			{
				labelAuthMethod.Visible = true;
				makelabel(labelAuthMethod, Color.Empty, ResourceText.AuthCERT);
				_authentification = true;
			}
			// Wenn kein Authentifizierungsmodus gewählt Groupbox deaktivieren
			else
			{
				makelabel(labelAuthMethod, Color.Red, ResourceText.ConnectionNoAuthMode);
				buttonConnect.Enabled = false;		// Verbindungstest Button deaktivieren
				groupBoxSetting.Enabled = false;    // Authentifizierungsgroupbox deaktivieren
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

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
			DialogResult result = DialogResult.OK;

			// Abfragen ob Dialog wirklich geschlossen werden soll wenn keine Verbindung hergestellt
			if (_systemparameter.SystemSSH == null)
				result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				return;

			// Programm beenden
			Close();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Einstellungen
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Einstellungen				+++|
		//	+--------------------------------------------------+

		private void accountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> Account
			// PORT Konfiguration Fenster öffnen
			FormAuthMethod FormPointer = new FormAuthMethod(_systemparameter);
			DialogResult Form = FormPointer.ShowDialog();

			_accountid = FormPointer.GetAccountId;
			_authentification = FormPointer.GetAuthentification;

			_systemparameter.AccountId = _accountid;
			_systemparameter.AccountType = _authentification;

			// Rücksprung aus Account Fenster behandeln
			// if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
			//	return;

			// Überprüfen ob Passwort-Authentifizierung eingestellt
			if(_accountid >= 0)
			{
				if (_authentification == false && _systemparameter.SystemAccount[_accountid][ResourceText.keyMode] == ResourceText.AuthModePWD)
				{
					labelAuthMethod.Visible = true;
					makelabel(labelAuthMethod, Color.Empty, ResourceText.AuthPWD);
				}
				// Überprüfen ob Zertifikat-Authentifizierung eingestellt
				else if (_authentification == true && _systemparameter.SystemCertificate[_accountid][ResourceText.keyMode] == ResourceText.AuthModeCERT)
				{
					labelAuthMethod.Visible = true;
					makelabel(labelAuthMethod, Color.Empty, ResourceText.AuthCERT);

				}
				// Wenn kein Authentifizierungsmodus gewählt Groupbox deaktivieren
				else
				{
					makelabel(labelAuthMethod, Color.Red, ResourceText.ConnectionNoAuthMode);
					buttonConnect.Enabled = false;      // Verbindungstest Button deaktivieren
					groupBoxSetting.Enabled = false;    // Authentifizierungsgroupbox deaktivieren
				}
			}
			else
			{
				makelabel(labelAuthMethod, Color.Red, ResourceText.ConnectionNoAuthMode);
				buttonConnect.Enabled = false;      // Verbindungstest Button deaktivieren
				groupBoxSetting.Enabled = false;    // Authentifizierungsgroupbox deaktivieren
			}
		}

		private void certToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> Authetifizierung -> Zertifikat
			_authentification = true;

			if (_accountid < 0)
			{
				for(int i=0; i < _systemparameter.SystemCertificate.Count; i++)
				{
					if(_systemparameter.SystemAccount[i][ResourceText.keyMode] == ResourceText.AuthCERT)
					{
						_accountid = i;
						break;
					}
					else
					{
						_accountid = -1;
					}
				}
			}

			// Überprüfen ob Account gefunden
			if(_accountid >= 0 && _systemparameter.SystemCertificate[_accountid][ResourceText.keyMode] == ResourceText.AuthModeCERT)
			{
				buttonConnect.Enabled = true;
				groupBoxSetting.Enabled = true;
				labelAuthMethod.Visible = true;
				makelabel(labelAuthMethod, Color.Empty, ResourceText.AuthCERT);
			}
			else
			{
				buttonConnect.Enabled = false;
				groupBoxSetting.Enabled = false;
				makelabel(labelAuthMethod, Color.Red, ResourceText.ConnectionNoAccount);
			}
		}

		private void usernamePasswortToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> Authentifizierung -> Benutzer/Passwort
			_authentification = false;

			if (_accountid < 0)
			{
				for (int i = 0; i < _systemparameter.SystemAccount.Count; i++)
				{
					if (_systemparameter.SystemAccount[i][ResourceText.keyMode] == ResourceText.AuthPWD)
					{
						_accountid = i;
						break;
					}
					else
					{
						_accountid = -1;
					}
				}
			}

			// Überprüfen ob Account gefunden
			if (_accountid >= 0 && _systemparameter.SystemAccount[_accountid][ResourceText.keyMode] == ResourceText.AuthModePWD)
			{
				buttonConnect.Enabled = true;
				groupBoxSetting.Enabled = true;
				labelAuthMethod.Visible = true;
				makelabel(labelAuthMethod, Color.Empty, ResourceText.AuthPWD);
			}
			else
			{
				buttonConnect.Enabled = false;
				groupBoxSetting.Enabled = false;
				makelabel(labelAuthMethod, Color.Red, ResourceText.ConnectionNoAccount);
			}
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
			// Menüband -> Hilfe -> Hilfe/Support
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Form
		//	+--------------------------------------------------+
		//	|+++	Form -> Funktionen						+++|
		//	+--------------------------------------------------+

		private void FormLinux_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = DialogResult.OK;

			// Abfragen ob Dialog wirklich geschlossen werden soll wenn keine Verbindung hergestellt
			if (_systemparameter.SystemSSH == null)
				result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			if (!checkipaddress(textBoxIPByte1, textBoxIPByte2, textBoxIPByte3, textBoxIPByte4, textBoxPort))
				return;

			string ip = textBoxIPByte1.Text + "." + textBoxIPByte2.Text + "." + textBoxIPByte3.Text + "." + textBoxIPByte4.Text;
			string port = textBoxPort.Text;

			makelabel(labelConnection, Color.Empty, ResourceText.ConnectionRun);
			_systemparameter.SystemSSH = new SSH(ip, port, _systemparameter.SystemAccount[0][ResourceText.keyUsername], _systemparameter.SystemAccount[0][ResourceText.keyPassword]);
			_systemparameter.SystemSFTP = new SSH(ip, port, _systemparameter.SystemAccount[0][ResourceText.keyUsername], _systemparameter.SystemAccount[0][ResourceText.keyPassword]);

			try
			{
				_systemparameter.SystemSSH.SSHconnect();
				_systemparameter.SystemSFTP.SFTPconnect();
				makelabel(labelConnection, Color.Green, ResourceText.ConnectionEstablished);

				// Überprüfen ob Toolbox bereits auf Server vorhanden
				if (_systemparameter.SystemSSH.GetBashTool)
				{
					labelVersion.Text = _systemparameter.SystemSSH.GetBashToolVersion;
					Library.BashTool = _systemparameter.SystemSSH.GetBashToolVersion;
				}
				else
				{

					// Toolbox File (toolbox) hochladen falls nicht vorhanden
					try
					{
						if (_systemparameter.SystemSSH.UploadBashTool(_systemparameter.SystemSSH, _systemparameter.SystemSFTP, _systemparameter.SystemSSH.GetBashUser, Application.StartupPath))
						{
							labelVersion.Text = _systemparameter.SystemSSH.GetBashToolVersion;
						}
						else
						{
							labelVersion.Text = ResourceText.NotAvileable;
							makelabel(labelConnection, Color.Red, ResourceText.ConnectionBashTool);
							MessageBox.Show(ResourceText.ConnectionBashFail, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

							return;
						}
					}
					catch
					{
						labelVersion.Text = ResourceText.NotAvileable;
						makelabel(labelConnection, Color.Red, ResourceText.ConnectionBashTool);
						MessageBox.Show(ResourceText.ConnectionBashFail, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

						return;
					}
				}
			}
			catch
			{
				_systemparameter.SystemSSH = null;

				makelabel(labelConnection, Color.Red, ResourceText.ConnectionFailed);
				MessageBox.Show(ResourceText.ConnectionFault, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Funktionen
		//	+--------------------------------------------------+
		//	|+++	System -> Funktionen					+++|
		//	+--------------------------------------------------+
		private bool checkipaddress(TextBox IPString1, TextBox IPString2, TextBox IPString3, TextBox IPString4, TextBox IPport)
		{
			if (!checkipfield(IPString1, 1, 254)) return false;
			if (!checkipfield(IPString2, 0, 254)) return false;
			if (!checkipfield(IPString3, 0, 254)) return false;
			if (!checkipfield(IPString4, 1, 254)) return false;
			if (!checkipfield(IPport, 1, 65535)) return false;

			return true;
		}

		private bool checkipfield(TextBox inputTextBox, int MIN, int MAX)
		{
			int IPByte = 0;
			inputTextBox.BackColor = Color.Empty;

			if (int.TryParse(inputTextBox.Text, out IPByte))
			{
				if (IPByte <= MAX && IPByte >= MIN)
					return true;
			}

			inputTextBox.BackColor = Color.Red;
			inputTextBox.SelectAll();

			MessageBox.Show(ResourceText.MsgIPFault, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		private void makelabel(Label inputLabel, Color TextColor, string Text)
		{
			inputLabel.Visible = true;
			inputLabel.ForeColor = TextColor;
			inputLabel.Text = Text;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Properties
		//	+--------------------------------------------------+
		//	|+++	System -> Properties					+++|
		//	+--------------------------------------------------+

		// Rückgabe der aufgebauten SSH Verbindung
		public SSH GetConnection
		{
			get
			{
				return _systemparameter.SystemSSH;
			}
		}

		// Rückgabe welcher Account verwendet
		public int GetAccountId
		{
			get
			{
				return _accountid;
			}
		}

		public bool GetAccountType
		{
			get
			{
				return _authentification;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
}
