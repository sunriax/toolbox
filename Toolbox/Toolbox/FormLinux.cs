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
using Toolbox.Language;
using Toolbox.UART;
using NetworkLib;
using VersionLib;

namespace Toolbox
{
	public partial class FormLinux : Form
	{
		private int _IPByte1 = 192;
		private int _IPByte2 = 168;
		private int _IPByte3 = 132;
		private int _IPByte4 = 130;

		private int _IPport = 22;

		private bool _AuthCERT = false;
		private bool _AuthPWD = false;

		private Library _version;

		Dictionary<int, Dictionary<string, string>> _account = new Dictionary<int, Dictionary<string, string>>();
		SSH _sshopen;

		public FormLinux(Dictionary<int, Dictionary<string, string>> account, Library version, SSH sshopen)
		{
			InitializeComponent();

			// Versionsvariablen übergeben
			_version = version;

			// SSHvariablen übergeben
			_account = account;

			// Falls bereits bestehnde Verbindung vorhanden, übernhemen
			_sshopen = sshopen;

			if(_sshopen != null)
			{
				makelabel(labelConnection, Color.Green, ResourceText.ConnectionEstablished);
			}

			// IP Adresse Initialisieren
			textBoxIPByte1.Text = _IPByte1.ToString();
			textBoxIPByte2.Text = _IPByte2.ToString();
			textBoxIPByte3.Text = _IPByte3.ToString();
			textBoxIPByte4.Text = _IPByte4.ToString();
			textBoxPort.Text = _IPport.ToString();

			// Überprüfen ob Authentifizierung eingestellt
			if (_account[0][ResourceText.keyMode] == ResourceText.AuthModeCERT)
			{
				_AuthCERT = true;
				labelAuthMethod.Visible = true;
				labelAuthMethod.Text = ResourceText.AuthCERT;

			}
			else if (_account[0][ResourceText.keyMode] == ResourceText.AuthModePWD)
			{
				_AuthPWD = true;
				labelAuthMethod.Visible = true;
				labelAuthMethod.Text = ResourceText.AuthPWD;
			}
			else
				groupBoxSetting.Enabled = false;
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
			DialogResult result = DialogResult.OK;

			// Abfragen ob Dialog wirklich geschlossen werden soll wenn keine Verbindung hergestellt
			if (_sshopen == null)
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
			FormLinuxAccount FormPointer = new FormLinuxAccount(_account);
			DialogResult Form = FormPointer.ShowDialog();

			MessageBox.Show(FormPointer.GetId.ToString());

			// Rücksprung aus Account Fenster behandeln
			if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
				return;
		}

		private void certToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> Authetifizierung -> Zertifikat
			groupBoxSetting.Enabled = true;
			labelAuthMethod.Visible = true;
			labelAuthMethod.Text = ResourceText.AuthCERT;
			_AuthCERT = true;
			_AuthPWD = false;
		}

		private void usernamePasswortToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> Authentifizierung -> Benutzer/Passwort
			groupBoxSetting.Enabled = true;
			labelAuthMethod.Visible = true;
			labelAuthMethod.Text = ResourceText.AuthPWD;
			_AuthPWD = true;
			_AuthCERT = false;
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
			FormVersion FormPointer = new FormVersion(_version);
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
		private void buttonConnect_Click(object sender, EventArgs e)
		{
			if (!checkipaddress(textBoxIPByte1, textBoxIPByte2, textBoxIPByte3, textBoxIPByte4, textBoxPort))
				return;

			string ip = textBoxIPByte1.Text + "." + textBoxIPByte2.Text + "." + textBoxIPByte3.Text + "." + textBoxIPByte4.Text;
			string port = textBoxPort.Text;

			makelabel(labelConnection, Color.Empty, ResourceText.ConnectionRun);
			_sshopen = new SSH(ip, port, _account[0][ResourceText.keyUsername], _account[0][ResourceText.keyPassword]);

			try
			{
				_sshopen.SSHconnect();
				makelabel(labelConnection, Color.Green, ResourceText.ConnectionEstablished);

				// Überprüfen ob Toolbox bereits auf Server vorhanden
				//MessageBox.Show(_sshopen.SSHexec("/home/" + _ssh[0] + "/toolbox check"));

				if (_sshopen.GetBashTool)
				{
					// ***** Zusatzfunktion einbauen die prüft ob sich eine neuer version im aktuellen Programm
					// ***** befindet, da sich das Programm via Update erneuern lässt!!!

					labelVersion.Text = _sshopen.GetBashToolVersion;
				}
				else
				{
					labelVersion.Text = ResourceText.NotAvileable;
					// Toolbox File (toolbox) hochladen falls nicht vorhanden
					//_sshopen.SFTPupload("toolbox.sh", "/home/local/");
					//_sshopen.SFTPdisconnect();
				}
				
			}
			catch
			{
				_sshopen = null;

				makelabel(labelConnection, Color.Red, ResourceText.ConnectionFailed);
				MessageBox.Show(ResourceText.ConnectionFault, ResourceText.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}
		}

		private void FormLinux_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = DialogResult.OK;

			// Abfragen ob Dialog wirklich geschlossen werden soll wenn keine Verbindung hergestellt
			if (_sshopen == null)
				result = MessageBox.Show(ResourceText.MsgDialogExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen unterbrechen
			if (result == DialogResult.Cancel)
				e.Cancel = true;
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
		public SSH GetConnection
		{
			get
			{
				return _sshopen;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

	}
}
