using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using NetworkLib.Language;
using ToolboxLib;
using Renci.SshNet;

namespace NetworkLib
{
	#region Klasse_SSH
	//	+--------------------------------------------------+
	//	|+++	SSH Klasse								+++|
	//	+--------------------------------------------------+
	public class SSH
	{
		// Systemkonstanten
		private const string _version = "V1.0B";
		private const int _maxport = 65535;

		// Klassenvariablen
		private ConnectionInfo _connection;
		private SshClient _ssh;
		private SftpClient _sftp;

		private string _ipaddress = ResourceText.sshIP;
		private string _username = ResourceText.sshUSERNAME;
		private string _password = ResourceText.sshPASSWORD;
		private string _port = ResourceText.sshPORT;
		private string _certificate = ResourceText.sshCERTIFICATE;
		private string _passphrase = ResourceText.sshPASSPHRASE;

		#region Konstruktoren
		//	+--------------------------------------------------+
		//	|+++	Konstruktoren							+++|
		//	+--------------------------------------------------+

		// Leerkonstruktor benötigt für Versionskontrolle
		public SSH()
		{
			_connection = null;
			_ssh = null;
			_sftp = null;
		}

		// Konstruktor zur Verbindungseinstellung mittels Benutzer und Passwort
		public SSH(string ipadress, string port, string username, string password = null)
		{
			// Variablen überprüfen
			if (ipadress == ResourceText.EMPTY)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionIP));
			if (username == ResourceText.EMPTY)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionUser));
			if (Tool.String2Int(port, 22) > _maxport)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionPort));

			// Klassenvariablen beschreiben
			_ipaddress = ipadress;
			_username = username;
			_port = port;
			_password = password;

			// Passwort basierte Verbindung erstellen
			_connection = new ConnectionInfo(ipadress, Tool.String2Int(port, 22), username, new AuthenticationMethod[] { new PasswordAuthenticationMethod(username, password) });
		}

		// Konstruktor zur Verbindungseinstellung mittels Zertifikat
		public SSH(string ipadress, string port, string username, string certificate, string passphrase)
		{
			// Variablen überprüfen
			if (ipadress == ResourceText.EMPTY)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionIP));
			if (username == ResourceText.EMPTY)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionUser));
			if (Tool.String2Int(port, 22) > _maxport)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionPort));
			if (certificate == ResourceText.EMPTY)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionCertificate));

			// Klassenvariablen beschreiben
			_ipaddress = ipadress;
			_port = port;
			_username = username;
			_certificate = certificate;
			_passphrase = passphrase;

			// Zertifikat basierte Verbindung erstellen
			_connection = new ConnectionInfo(ipadress, Tool.String2Int(port, 22), username, new PrivateKeyAuthenticationMethod(username, new PrivateKeyFile[] { new PrivateKeyFile(@certificate, passphrase) }));
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region SSHconnect
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> SSHconnect				+++|
		//	+--------------------------------------------------+

		// SSH Verbindungsaufbau
		public bool SSHconnect()
		{
			if (_connection == null)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionConnectionFailed));

			try
			{
				_ssh = new SshClient(_connection);
			}
			catch
			{
				_connection = null;
				_ssh = null;
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHclient));
			}

			try
			{
				_ssh.Connect();
			}
			catch
			{
				_connection = null;
				_ssh = null;
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));
			}
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region SFTPconnect
		//	+--------------------------------------------------+
		//	|+++	Funktion -> SFTPconnect					+++|
		//	+--------------------------------------------------+

		// SFTP Verbindungsaufbau
		public bool SFTPconnect()
		{
			if (_connection == null)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionConnectionFailed));

			try
			{
				_sftp = new SftpClient(_connection);
			}
			catch
			{
				_connection = null;
				_sftp = null;
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSFTPclient));
			}

			try
			{
				_sftp.Connect();
			}
			catch
			{
				_connection = null;
				_sftp = null;
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSFTPconnect));
			}

			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region SSHexec
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> SSHexec					+++|
		//	+--------------------------------------------------+

		// SSH Befehl ausführen
		public string SSHexec(string command)
		{
			if (_ssh == null)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));

			if (!_ssh.IsConnected)
				return ResourceText.sshFaultNoConnection;

			return _ssh.CreateCommand(command).Execute();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region SFTPupload
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> SFTPupload				+++|
		//	+--------------------------------------------------+

		// SFTP Datei hochladen
		public void SFTPupload(string localdir, string filename, string uploaddir)
		{
			if (_sftp == null)
				throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSFTPclient));

			if (!_sftp.IsConnected)
				return;

			_sftp.ChangeDirectory(uploaddir);
			_sftp.UploadFile(File.OpenRead(localdir + filename), filename, true);

			_sftp.Disconnect();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region UploadBashTool
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> UploadBashTool			+++|
		//	+--------------------------------------------------+

		// Bash Tool hochladen wenn nicht vorhanden
		public bool UploadBashTool(SSH ssh, SSH sftp, string bashuser, string startuppath)
		{
			//if (startuppath[startuppath.Length - 1].ToString() != ResourceText.Slash)
			//	startuppath = startuppath + ResourceText.Slash;

			if ((startuppath = Handler.CheckDirectory(startuppath, true)) == false.ToString())
			{
				return false;
			}

			//if (File.Exists(startuppath + ResourceText.ServerBashToolname))
			if (Handler.CheckFile(startuppath + ResourceText.ServerBashToolname))
			{
				try
				{
					// Lokale Toolbox auf den Server laden
					sftp.SFTPupload(startuppath, ResourceText.ServerBashToolname, ResourceText.ServerBashHome + bashuser);

					// Berechtigung zum ausführen der Toolbox auf dem Server setzten
					if (ssh.SSHexec(ResourceText.BashChmod + ResourceText._0744 + ResourceText.ServerBashHome + bashuser + ResourceText.Slash + ResourceText.ServerBashToolname) == ResourceText.EMPTY)
						return true;
					return false;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region SSHdisconnect
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> SSHdisconnect				+++|
		//	+--------------------------------------------------+

		// SSH Verbindung auflösen
		public void SSHdisconnect()
		{
			if (_ssh.IsConnected)
				_ssh.Disconnect();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region SFTPdisconnect
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> SFTPdisconnect			+++|
		//	+--------------------------------------------------+

		// SFTP Verbindung auflösen
		public void SFTPdisconnect()
		{
			if (_sftp.IsConnected)
				_sftp.Disconnect();
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Properties
		//	+--------------------------------------------------+
		//	|+++	Properties								+++|
		//	+--------------------------------------------------+

		// Gibt zurück ob eine Verbindung mit dem Server besteht		
		public bool CheckSSHConnnection
		{
			get
			{
				try
				{
					return _ssh.IsConnected;
				}
				catch
				{
					return false;
				}
			}
		}

		// Gibt zurück ob eine Verbindung mit dem SFTP server besteht
		public bool CheckSFTPConnnection
		{
			get
			{
				try
				{
					return _sftp.IsConnected;
				}
				catch
				{
					return false;
				}
			}
		}

		// Gibt die eingetragene IP Adresse zurück
		public string IPaddress
		{
			get
			{
				return _ipaddress;
			}
		}

		// Gibt den eingetragenen Port zurück
		public int Port
		{
			get
			{
				return Tool.String2Int(_port, -1);
			}
		}

		// Gibt den eingetragenen Benutzernamen zurück
		public string Username
		{
			get
			{
				return _username;
			}
		}

		// Gibt den eingetragenen Zertifikatnamen zurück
		public string Certificate
		{
			get
			{
				return _certificate;
			}
		}

		// Gibt zurück ob das Bashtool auf dem Server vorhanden ist
		public bool GetBashTool
		{
			get
			{
				if (_ssh == null)
					throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));

				if (_ssh.IsConnected)
				{
					string username = Tool.ReplaceLinebreak(SSHexec(ResourceText.BashgetUser));

					if (Tool.ReplaceLinebreak(SSHexec(ResourceText.BashHome + username + ResourceText.BashApp + " " + ResourceText.BashAppTest)) == ResourceText.TRUE)
						if(Tool.ReplaceLinebreak(SSHexec(ResourceText.BashgetFilePremission + ResourceText.BashHome + username + ResourceText.BashApp)) == "744")
							return true;
					return false;
				}
				return false;
			}
		}

		// Gibt die Version des Bashtools auf dem Server zurück
		public string GetBashToolVersion
		{
			get
			{
				if (_ssh == null)
					throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));

				if (_ssh.IsConnected)
				{
					string username = Tool.ReplaceLinebreak(SSHexec(ResourceText.BashgetUser));

					if (GetBashTool == true)
						return SSHexec(ResourceText.BashHome + username + ResourceText.BashApp + " " + ResourceText.BashAppVersion);
				}
				return ResourceText.NotAvileable;
			}
		}

		// Gibt die Klassenversion Zurück
		public string GetSSHClassVersion
		{
			get
			{
				return _version;
			}
		}

		// Gibt den Benutzernamen zurück
		public string GetBashUser
		{
			get
			{
				if (_ssh == null)
					throw new Exception(Handler.CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionBashUserQuery));

				if (_ssh.IsConnected)
				{
					return Tool.ReplaceLinebreak(SSHexec(ResourceText.BashgetUser));
				}
				return ResourceText.NotAvileable;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
	//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#endregion
}
