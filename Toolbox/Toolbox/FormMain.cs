#define DEBUG

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
	public partial class FormMain : Form
	{
		// Array Liste zum Speichern der UART Porteinstellungen erzeugen
		List<string[]> _SystemPorts = new List<string[]>();

		// Toolboxressource erzeugen
		private Ressource _SystemApp = new Ressource(Application.ExecutablePath);

		// Versionskontrolle erzeugen
		private Library _SystemVersion = new Library();

		// Verschlüsselungstool erzeugen
		private Chiper _SystemSecure = new Chiper();

		// SSH Array und Verindungsvariable
		Dictionary<int, Dictionary<string, string>> _Account = new Dictionary<int, Dictionary<string, string>>();
		private SSH _SSHToolbox = null;

		// Systemvariablen
		private bool _restart = false;

		// Programmstart (Fensteraufruf)
		public FormMain()
		{
			#region Language
			//	+--------------------------------------------------+
			//	|+++	Sprache Initialisieren					+++|
			//	+--------------------------------------------------+
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
					Thread.CurrentThread.CurrentCulture = new CultureInfo(_SystemApp.GetValue(ResourceText.keyLanguage));
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(_SystemApp.GetValue(ResourceText.keyLanguage));
				}
			}
			catch
			{
				MessageBox.Show(ResourceText.MsgLanguageNotFound, ResourceText.Information, MessageBoxButtons.OK ,MessageBoxIcon.Information);
			}
			//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
			#endregion

			#region Language
			//	+--------------------------------------------------+
			//	|+++	Standard accountdaten laden				+++|
			//	+--------------------------------------------------+
			_Account[0] = new Dictionary<string, string>();

			// Standardbenutzeraccount aus Appconfig Initialiseren
			_Account[0].Add(ResourceText.keyMode,		_SystemApp.GetValue(ResourceText.keyMode));
			_Account[0].Add(ResourceText.keyUsername,	_SystemApp.GetValue(ResourceText.keyUsername));
			_Account[0].Add(ResourceText.keyPassword,	_SystemApp.GetValue(ResourceText.keyPassword));
			_Account[0].Add(ResourceText.keyServer,		_SystemApp.GetValue(ResourceText.keyServer));
			_Account[0].Add(ResourceText.keyPort,		_SystemApp.GetValue(ResourceText.keyPort));
			//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
			#endregion

			InitializeComponent();

			string encrypt = _SystemSecure.Encrypt("Blablabla12345", "asasdkewez2i371o3fdhx");
			string decrypt = _SystemSecure.Decrypt(encrypt ,"asasdkewez2i371o3fdhx");


			// Prüfen ob Debugmodus aktiven
#if (DEBUG)
			MessageBox.Show(ResourceText.MsgDebugMode, ResourceText.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);

			// Debug Modus aktiviert in Main Frame anzeigen
			groupBoxDebug.Visible = true;
#endif

			// Version auf Mainframe einstellen
			labelVersionNr.Text = ResourceText.ProgramVersion;
		}

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
			FormControl FormPointer = new FormControl(_SSHToolbox, _SystemVersion);
			DialogResult Form = FormPointer.ShowDialog();

			// Rücksprung aus Versionsfenster behandeln
			if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
				return;
		}

		private void interfaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Toolbox -> Network -> Web
			// Verlinkung auf Seite (Github)
			System.Diagnostics.Process.Start(ResourceText.Linkhttp + _Account[0][ResourceText.keyIPAddress]);
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
			FormLinux FormPointer = new FormLinux(_Account,_SystemVersion, _SSHToolbox);
			DialogResult Form = FormPointer.ShowDialog();

			// Verbindungen an Haupprogramm übergeben
			_SSHToolbox = FormPointer.GetConnection;

			// Überprüfen ob Verbindungen vorhanden
			if (_SSHToolbox == null)
			{
				interfaceToolStripMenuItem.Enabled = false;
				controlToolStripMenuItem.Enabled = false;
				sshToolStripMenuItem.Enabled = false;
				return;
			}

			// Erneute Überprüfung ob Verbindung auch in Unterklasse Renci vorhanden
			if (!_SSHToolbox.CheckSSHConnnection)
				return;

			// Überprüfen ob IP Addresse vorhanden
			if (_SSHToolbox.IPaddress != ResourceText.EMPTY)
			{
				_Account[0].Remove(ResourceText.keyIPAddress);							// Falls Key schon existiert entfernen
				_Account[0].Add(ResourceText.keyIPAddress, _SSHToolbox.IPaddress);		// Neuen Key,Value hinzufügen

				// Menüband -> Toolbox -> Network -> Web Freigeben
				interfaceToolStripMenuItem.Enabled = true;
			}

			// Versionsverweis aktualisieren
			_SystemVersion.BashTool = _SSHToolbox.GetBashToolVersion;

			// SSH Funktionen in Toolstrip aktivieren
			controlToolStripMenuItem.Enabled = true;    // Menüband -> Toolbox -> Network -> Control Freigeben
			sshToolStripMenuItem.Enabled = true;        // Menüband -> Toolbox -> Network -> SSH Freigeben
		}

		private void PortToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellungen -> PORT Konfiguration
			// PORT Konfiguration Fenster öffnen
			FormPort FormPointer = new FormPort(_SystemVersion, _SystemPorts);
			DialogResult Form = FormPointer.ShowDialog();

			// Rücksprung aus SSH/Telnet Fenster behandeln
			if (Form == DialogResult.Cancel || Form == DialogResult.Abort)
				if(FormPointer.GetPorts == null)
					return;

			_SystemPorts = FormPointer.GetPorts;

			MessageBox.Show(_SystemPorts.Count().ToString());

		}

		#region Einstellungen_Sprache
		//	+--------------------------------------------------+
		//	|+++	Menüband - > Einstellungen -> Sprache	+++|
		//	+--------------------------------------------------+

		private void deutschAustriaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Menüband -> Einstellung -> Sprache -> Deutsch/Österreich
			// Eingestellte Sprache in der App.config abspeichern
			_SystemApp.Create(ResourceText.keyLanguage, ResourceText.SpeakdeAT);

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
			_SystemApp.Create(ResourceText.keyLanguage, ResourceText.SpeakenGB);

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
			_SystemApp.Create(ResourceText.keyLanguage, ResourceText.SpeakesES);

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
			_SystemApp.Create(ResourceText.keyLanguage, ResourceText.keyNone);

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
			FormVersion FormPointer = new FormVersion(_SystemVersion);
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
