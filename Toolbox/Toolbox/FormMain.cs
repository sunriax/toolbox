#define DEBUG
//#undef DEBUG

using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Toolbox.Language;
using ToolboxLib;
using NetworkLib;
using VersionLib;

namespace Toolbox
{
	#region Datensruktur
	//	+--------------------------------------------------+
	//	|+++	Menüband - > Start						+++|
	//	+--------------------------------------------------+

	// Datenstruktur für Fensterübergabeparameter
	public struct Parameter
	{
		public int AccountId;
		public bool AccountType;

		public Ressource SystemApp;
		public SSH SystemSSH;
		public SSH SystemSFTP;
		public List<string[]> SystemPorts;
		public Dictionary<int, Dictionary<string, string>> SystemAccount;
		public Dictionary<int, Dictionary<string, string>> SystemCertificate;
	}
	//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#endregion

	public partial class FormMain : Form
	{
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklaration					+++|
		//	+--------------------------------------------------+

		Parameter _SystemParameter = new Parameter();   // Systemparameter Struktur erzeugen
		private bool _restart = false;                  // Systemvariablen
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Initialisierung
		//	+--------------------------------------------------+
		//	|+++	Komponenteninitialisierung				+++|
		//	+--------------------------------------------------+

		public FormMain()
		{
			// Sprache Initialisieren
			try
			{
				// Überprüfen ob Systemsprache verwendet werden soll
				if (ConfigurationManager.AppSettings[ResourceText.keyLanguage] == ResourceText.keyNone)
				{
					// Sprache von System ermitteln
					Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureInfo.InstalledUICulture.ToString());
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureInfo.InstalledUICulture.ToString());
				}
				else
				{
					// Sprache aus App.config laden
					Thread.CurrentThread.CurrentCulture = new CultureInfo(_SystemParameter.SystemApp.GetValue(ResourceText.keyLanguage));
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(_SystemParameter.SystemApp.GetValue(ResourceText.keyLanguage));
				}
			}
			catch
			{
				MessageBox.Show(ResourceText.MsgLanguageNotFound, ResourceText.Information, MessageBoxButtons.OK ,MessageBoxIcon.Information);
			}

			InitializeComponent();

			// Systemparameter Initialisieren
			_SystemParameter.SystemApp = new Ressource(Application.ExecutablePath);					// Toolboxressource erzeugen
			_SystemParameter.SystemSSH = null;														// SSH Verindungsvariable
			_SystemParameter.SystemPorts = new List<string[]>();									// Array Liste zum Speichern der UART Porteinstellungen erzeugen
			_SystemParameter.SystemAccount = new Dictionary<int, Dictionary<string, string>>();		// SSH Account Dictionary
			_SystemParameter.SystemCertificate = new Dictionary<int, Dictionary<string, string>>(); // SSH Account Dictionary
			_SystemParameter.AccountId = 0;															// Primär verwendete AccountId
			_SystemParameter.AccountType = false;													// Primär verwendeter Account Type

			// Standardbenutzeraccount aus Appconfig laden
			_SystemParameter.SystemAccount[0] = new Dictionary<string, string>();
			_SystemParameter.SystemAccount[0].Add(ResourceText.keyMode,		_SystemParameter.SystemApp.GetValue(ResourceText.keyMode));
			_SystemParameter.SystemAccount[0].Add(ResourceText.keyUsername,	_SystemParameter.SystemApp.GetValue(ResourceText.keyUsername));
			_SystemParameter.SystemAccount[0].Add(ResourceText.keyPassword,	_SystemParameter.SystemApp.GetValue(ResourceText.keyPassword));
			_SystemParameter.SystemAccount[0].Add(ResourceText.keyServer,	_SystemParameter.SystemApp.GetValue(ResourceText.keyServer));
			_SystemParameter.SystemAccount[0].Add(ResourceText.keyPort,		_SystemParameter.SystemApp.GetValue(ResourceText.keyPort));
			_SystemParameter.SystemAccount[0].Add(ResourceText.keyEmpty,	ResourceText.EMPTY);

#if (DEBUG)
			MessageBox.Show(ResourceText.MsgDebugMode, ResourceText.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);

			// Debug Modus aktiviert in Main Frame anzeigen
			groupBoxDebug.Visible = true;
#endif

			//	string encrypt = _SystemSecure.Encrypt("Blablabla12345", "asasdkewez2i371o3fdhx");
			//	string decrypt = Chiper.Decrypt("t5mfxj4Cyb5tWP8oUZlobtdGhPQZPTwm9UTeyxvf+NvROIHrmSSuS3p722zlpdVXAPuuUGmp+xY67rwIb8hycd13ophxL8lm4fToCahxOLv0rHHcBc6qIp9giXcaGKys", ResourceText.Passphrase);

			// Version auf Mainframe einstellen
			labelVersionNr.Text = ResourceText.ProgramVersion;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Start
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Start						+++|
		//	+--------------------------------------------------+
		private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Start -> Datei speichern
		}

		private void FileLoadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Start -> Datei öffnen
		}

		private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Start -> Beenden
			// Abfragen ob Programm wirklich geschlossen werden soll
			DialogResult result = MessageBox.Show(ResourceText.MsgProgramExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen beenden
			if (result == DialogResult.Cancel)
				return;

			// Programm beenden
			Close();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Toolbox
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Toolbox - > UART			+++|
		//	+--------------------------------------------------+

		private void eepromToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> UART -> E²PROM
		}

		private void ds1307ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> UART -> DS1307
		}

		private void debugToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> UART -> Debug
		}

		//	+--------------------------------------------------+
		//	|+++	Menüband - > Toolbox - > JTAG			+++|
		//	+--------------------------------------------------+

		private void xilinxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> JTAG -> Xilinx
		}

		//	+--------------------------------------------------+
		//	|+++	Menüband - > Toolbox - > Network		+++|
		//	+--------------------------------------------------+
		private void controlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> Network -> Control
			// Versionsfenster öffnen
			FormControl FormPointer = new FormControl(_SystemParameter);
			DialogResult Form = FormPointer.ShowDialog();

			// Rücksprung aus Versionsfenster behandeln
			if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
				return;
		}

		private void interfaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> Network -> Web
			// Verlinkung auf Seite (Github)
			System.Diagnostics.Process.Start(ResourceText.Linkhttp + _SystemParameter.SystemAccount[0][ResourceText.keyIPAddress]);
		}

		private void sshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> Network -> SSH
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Funktionen
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Funktionen - > Bild		+++|
		//	+--------------------------------------------------+
		private void image2RawToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Funktion -> Bild -> Image2Raw
		}

		private void raw2ImageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Funktion -> Bild -> Raw2Image
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Einstellungen
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Einstellungen				+++|
		//	+--------------------------------------------------+

		private void AriettaG25ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> Arietta G25
			// SSH/Telnet Fenster öffnen
			FormLinux FormPointer = new FormLinux(_SystemParameter);
			DialogResult Form = FormPointer.ShowDialog();

			// Verbindungen an Haupprogramm übergeben
			_SystemParameter.SystemSSH = FormPointer.GetConnection;
			_SystemParameter.AccountId = FormPointer.GetAccountId;
			_SystemParameter.AccountType = FormPointer.GetAccountType;

			// Überprüfen ob Verbindungen vorhanden
			if (_SystemParameter.SystemSSH == null)
			{
				interfaceToolStripMenuItem.Enabled = false;
				controlToolStripMenuItem.Enabled = false;
				sshToolStripMenuItem.Enabled = false;
				return;
			}

			// Erneute Überprüfung ob Verbindung auch in Unterklasse Renci vorhanden
			if (!_SystemParameter.SystemSSH.CheckSSHConnnection)
				return;

			// Überprüfen ob IP Addresse vorhanden
			if (_SystemParameter.SystemSSH.IPaddress != ResourceText.EMPTY)
			{
				_SystemParameter.SystemAccount[0].Remove(ResourceText.keyIPAddress);									// Falls Key schon existiert entfernen
				_SystemParameter.SystemAccount[0].Add(ResourceText.keyIPAddress, _SystemParameter.SystemSSH.IPaddress);	// Neuen Key,Value hinzufügen	

				// Menüband -> Toolbox -> Network -> Web Freigeben
				interfaceToolStripMenuItem.Enabled = true;
			}

			// SSH Funktionen in Toolstrip aktivieren
			controlToolStripMenuItem.Enabled = true;    // Menüband -> Toolbox -> Network -> Control Freigeben
			sshToolStripMenuItem.Enabled = true;        // Menüband -> Toolbox -> Network -> SSH Freigeben
		}

		private void PortToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> PORT Konfiguration
			// PORT Konfiguration Fenster öffnen
			FormPort FormPointer = new FormPort(_SystemParameter);
			DialogResult Form = FormPointer.ShowDialog();

			// Rücksprung aus SSH/Telnet Fenster behandeln
			if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
				if(FormPointer.GetPorts == null)
					return;

			_SystemParameter.SystemPorts = FormPointer.GetPorts;

			MessageBox.Show(_SystemParameter.SystemPorts.Count().ToString());

		}

		#region Einstellungen_Sprache
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Einstellungen -> Sprache	+++|
		//	+--------------------------------------------------+

		private void deutschAustriaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellung -> Sprache -> Deutsch/Österreich
			// Eingestellte Sprache in der App.config abspeichern
			_SystemParameter.SystemApp.Create(ResourceText.keyLanguage, ResourceText.SpeakdeAT);

			// Ausgabe das Daten erfolgreich gespeichert
			DialogResult Message = MessageBox.Show(ResourceText.MsgLanguageSetup, ResourceText.Information, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			// Überprüfen ob Neustart OK
			if(Message == DialogResult.OK)
			{
				_restart = true;        // Restart abfrage deaktivieren
				Application.Restart();  // Applikation neu starten
			}
		}

		private void englishGreatBritanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellung -> Sprache -> English
			// Eingestellte Sprache in der App.config abspeichern
			_SystemParameter.SystemApp.Create(ResourceText.keyLanguage, ResourceText.SpeakenGB);

			// Ausgabe das Daten erfolgreich gespeichert
			DialogResult Message = MessageBox.Show(ResourceText.MsgLanguageSetup, ResourceText.Information, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			// Überprüfen ob Neustart OK
			if (Message == DialogResult.OK)
			{
				_restart = true;        // Restart abfrage deaktivieren
				Application.Restart();  // Applikation neu starten
			}
		}

		private void espanolSpainToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellung -> Sprache -> Espanol
			// Eingestellte Sprache in der App.config abspeichern
			_SystemParameter.SystemApp.Create(ResourceText.keyLanguage, ResourceText.SpeakesES);

			// Ausgabe das Daten erfolgreich gespeichert
			DialogResult Message = MessageBox.Show(ResourceText.MsgLanguageSetup, ResourceText.Information, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			// Überprüfen ob Neustart OK
			if (Message == DialogResult.OK)
			{
				_restart = true;        // Restart abfrage deaktivieren
				Application.Restart();  // Applikation neu starten
			}
		}

		private void SystemSpeakToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellung -> Sprache -> Systemsprache
			// System Sprache in der App.config abspeichern
			_SystemParameter.SystemApp.Create(ResourceText.keyLanguage, ResourceText.keyNone);

			// Ausgabe das Daten erfolgreich gespeichert
			DialogResult Message = MessageBox.Show(ResourceText.MsgLanguageSetup, ResourceText.Information, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

			// Überprüfen ob Neustart OK
			if (Message == DialogResult.OK)
			{
				_restart = true;		// Restart abfrage deaktivieren
				Application.Restart();  // Applikation neu starten
			}
				
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
			#endregion
			#endregion

		#region Hilfe
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Hilfe						+++|
		//	+--------------------------------------------------+

		private void GithubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Hilfe -> Github
			// Verlinkung auf Projektseite (Github)
			System.Diagnostics.Process.Start(ResourceText.LinkGithub);
		}

		private void HelpSupportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Hilfe -> Hilfe/Support
		}

		private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Hilfe -> Aktualisieren
		}

		private void VersionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Hilfe -> Version
			// Versionsfenster öffnen
			FormVersion FormPointer = new FormVersion(_SystemParameter);
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

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_restart == true)
				return;

			// Abfragen ob Programm wirklich geschlossen werden soll
			DialogResult result = MessageBox.Show(ResourceText.MsgProgramExit, ResourceText.Hint, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			// Wenn Abbrechen dann Schließen beenden
			if (result == DialogResult.Cancel)
				e.Cancel = true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

	}
}
