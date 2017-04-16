using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using NetworkLib.Language;
using Renci.SshNet;

namespace NetworkLib
{

	#region Klasse_NETWORK
	//	+--------------------------------------------------+
	//	|+++	NETWORK Klasse							+++|
	//	+--------------------------------------------------+

	public class Network
    {
		private int[] _ipaddress;
		private string _data = ResourceText.pingDATA;

		#region checkip
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> checkip					+++|
		//	+--------------------------------------------------+

		// Prüft eine IP-Adresse auf ihre Richtigkeit
		public bool checkip(string ipaddress)
		{
			char[] delimeter = new char[] { Convert.ToChar(ResourceText.IPdelimiter) };	// IP-Adresse Trennzeichen in Array ablegen
			string[] ipbuffer = new string[4];											// Interner Funktionspuffer für IP-Adresse
			int[] ipbytes = new int[4];													// Interner Funktionsbuffer für IP-Bytes

			// IP-Adressen Bytes in Buffer ablegen
			ipbuffer = ipaddress.Split(delimeter, 4);

			// Überprüfen ob Array mehr als 4 Elemente enthält
			// (wird schon durch Split begrenzt)
			if (ipbuffer.Length > 4)
				return false;

			// Buffer Schleifendurchlauf
			for(int i=0; i < ipbuffer.Length; i++)
			{
				// Überprüfen ob IP-String in IP-Int umgewandlet werden kann
				if (!int.TryParse(ipbuffer[i], out ipbytes[i]))
					return false;
			}

			// Überprüfen ob IP-Bytes gültig sind
			if (!checknumber(ipbytes[0], 1, 254))
				return false;
			if (!checknumber(ipbytes[1], 0, 254))
				return false;
			if (!checknumber(ipbytes[2], 0, 254))
				return false;
			if (!checknumber(ipbytes[3], 1, 254))
				return false;

			// Rückgabe wenn alle Bedingungne erfüllt sind
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region pinghost
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> pinghost					+++|
		//	+--------------------------------------------------+

		// Versucht einen hostnamen begrenzt durch einen Timeout anzupingen
		public bool pinghost(string hostname, int timeout)
		{
			Ping ping = new Ping();

			// Buffer mit 2 Bytes erzeugen
			byte[] buffer = Encoding.ASCII.GetBytes(_data);

			PingReply reply = ping.Send(hostname, timeout, buffer);

			if (reply.Status == IPStatus.Success)
			{
				if (checkip(reply.Address.ToString()))
					return true;
				return false;
			}
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region pingip
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> pingip					+++|
		//	+--------------------------------------------------+

		// Versucht eine IP-Adresse begrenzt durch einen Timeout anzupingen
		public bool pingip(string ipaddress, int timeout)
		{
			Ping ping = new Ping();
			IPAddress address = IPAddress.Parse(ipaddress);

			// Buffer mit 2 Bytes erzeugen
			byte[] buffer = Encoding.ASCII.GetBytes(_data);

			PingReply reply = ping.Send(address, timeout, buffer);

			if (reply.Status == IPStatus.Success)
			{
				if (checkip(reply.Address.ToString()))
					return true;
				return false;
			}
			return true;
		}

		public bool pingip(byte[] ipaddress, int timeout)
		{
			Ping ping = new Ping();
			IPAddress address = IPAddress.Parse(ipaddress[0].ToString() + ResourceText.IPdelimiter + ipaddress[1].ToString() + ResourceText.IPdelimiter + ipaddress[2].ToString() + ResourceText.IPdelimiter + ipaddress[3].ToString());

			// Buffer mit 2 Bytes erzeugen
			string data = ResourceText.pingDATA;
			byte[] buffer = Encoding.ASCII.GetBytes(data);

			PingReply reply = ping.Send(address, timeout, buffer);

			if (reply.Status == IPStatus.Success)
			{
				if (checkip(reply.Address.ToString()))
					return true;
				return false;
			}
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region resolvehost
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> resolvehost				+++|
		//	+--------------------------------------------------+

		// Versucht einen Namen in eine IP-Adresse aufzulösen
		public IPAddress[] resolvehost(string hostname)
		{
			IPHostEntry hostentry = Dns.GetHostEntry(hostname);
			IPAddress[] iparray = new IPAddress[hostentry.AddressList.Length];

			int count = 0;

			for (int i = 0; i < hostentry.AddressList.Length; i++)
			{
				iparray[count] = hostentry.AddressList[i];
			}

			return iparray;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Properties
		//	+--------------------------------------------------+
		//	|+++	Properties								+++|
		//	+--------------------------------------------------+

		// Gibt die eingetragene IP-Adresse zurück
		public int[] GetIP
		{
			// IP Adresse zurückgeben
			get
			{
				return _ipaddress;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Private
		//	+--------------------------------------------------+
		//	|+++	System -> Interne Funktionen			+++|
		//	+--------------------------------------------------+

		// Überprüft ob eine Zahl einen bestimmten min/max Grenzwert überschreitet
		private bool checknumber(int number, int MIN, int MAX)
		{
			if (number <= MAX && number >= MIN)
				return true;
			return false;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

	}
	//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#endregion

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
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionIP));
			if (username == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionUser));
			if (String2Int(port, 22) > _maxport)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionPort));

			// Klassenvariablen beschreiben
			_ipaddress = ipadress;
			_username = username;
			_port = port;
			_password = password;

			// Passwort basierte Verbindung erstellen
			_connection = new ConnectionInfo(ipadress, String2Int(port, 22), username, new AuthenticationMethod[] { new PasswordAuthenticationMethod(username, password) });
		}

		// Konstruktor zur Verbindungseinstellung mittels Zertifikat
		public SSH(string ipadress, string port, string username, string certificate, string passphrase)
		{
			// Variablen überprüfen
			if (ipadress == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionIP));
			if (username == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionUser));
			if (String2Int(port, 22) > _maxport)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionPort));
			if (certificate == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionCertificate));

			// Klassenvariablen beschreiben
			_ipaddress = ipadress;
			_port = port;
			_username = username;
			_certificate = certificate;
			_passphrase = passphrase;

			// Zertifikat basierte Verbindung erstellen
			_connection = new ConnectionInfo(ipadress, String2Int(port, 22), username, new PrivateKeyAuthenticationMethod(username, new PrivateKeyFile[] { new PrivateKeyFile(@certificate, passphrase) }));
		}

		// Konstruktor zur Verbindungseinstellung mittels bereits bestehender Verbindung
		public SSH(ConnectionInfo connection)
		{
			// Übeprüfen ob Verbindung vorhanden
			if (connection == null)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionConnection));

			// Externe Verbindung auf interne Klasse legen
			_connection = connection;
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
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionConnectionFailed));

			try
			{
				_ssh = new SshClient(_connection);
			}
			catch
			{
				_connection = null;
				_ssh = null;
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHclient));
			}

			try
			{
				_ssh.Connect();
			}
			catch
			{
				_connection = null;
				_ssh = null;
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));
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
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionConnectionFailed));

			try
			{
				_sftp = new SftpClient(_connection);
			}
			catch
			{
				_connection = null;
				_sftp = null;
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSFTPclient));
			}

			try
			{
				_sftp.Connect();
			}
			catch
			{
				_connection = null;
				_sftp = null;
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSFTPconnect));
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
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));

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
		public void SFTPupload(string filename, string uploaddir)
		{
			if (_sftp == null)
				throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSFTPclient));

			if (!_sftp.IsConnected)
				return;

			_sftp.ChangeDirectory(uploaddir);
			_sftp.UploadFile(File.OpenRead(filename), filename, true);

			_sftp.Disconnect();
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
				return String2Int(_port, -1);
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
					throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));

				if (_ssh.IsConnected)
				{
					string username = ReplaceLinebreak(SSHexec(ResourceText.bashUser));

					if (ReplaceLinebreak(SSHexec(ResourceText.bashHome + username + ResourceText.bashApp + " " + ResourceText.bashAppTest)) == ResourceText.TRUE)
						return true;
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
					throw new Exception(CreateException(ResourceText.ExceptionClass, ResourceText.ExceptionSSH, ResourceText.ExceptionSSHconnect));

				if (_ssh.IsConnected)
				{
					string username = ReplaceLinebreak(SSHexec(ResourceText.bashUser));

					if (GetBashTool == true)
						return SSHexec(ResourceText.bashHome + username + ResourceText.bashApp + " " + ResourceText.bashAppVersion);
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
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Lokal
		//	+--------------------------------------------------+
		//	|+++	Lokale Funktionen						+++|
		//	+--------------------------------------------------+

		// Funktion zum erzeugen von Exception Texten
		private string CreateException(string ExceptionClass, string ExceptionFunction, string ExceptionFault)
		{
			string create = ExceptionClass + "->" + ExceptionFunction + "(" + ResourceText.Message + ": " + ExceptionFault + ")";
			return create;
		}

		// Funktion zum umwandeln von String 2 Int
		private int String2Int(string text, int convert)
		{
			// Überprüfen ob Variable konvertierbar ist
			if (int.TryParse(text, out convert))
				if (convert < int.MaxValue && convert > int.MinValue)
					return convert;

			return convert;
		}

		// Funktion zum ersezten von Zeilenumbrüchen und Wagenrücklauf
		private string ReplaceLinebreak(string InputString)
		{
			return InputString.Replace("\r\n", null).Replace("\r", null).Replace("\n", null);
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
	//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#endregion

}
