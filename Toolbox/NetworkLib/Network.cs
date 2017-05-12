using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using ToolboxLib;
using NetworkLib.Language;
using Renci.SshNet;

namespace NetworkLib
{
	#region Klasse_NETWORK
	//	+--------------------------------------------------+
	//	|+++	NETWORK Klasse							+++|
	//	+--------------------------------------------------+

	public static class Network
    {
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklaration					+++|
		//	+--------------------------------------------------+

		private static string _data = ResourceText.pingDATA;
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
		
		#region CheckIP
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> CheckIp					+++|
		//	+--------------------------------------------------+

		// Prüft eine IP-Adresse auf ihre Richtigkeit
		public static bool CheckIP(string ipstring)
		{
			IPAddress ipaddress = null;     // Variable für IP-Adresse

			// Überprüfen ob eingegebene IP-Adresse gültig
			if (!IPAddress.TryParse(ipstring, out ipaddress))
				return false;

			// Rückgabe wenn alle Bedingungne erfüllt sind
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region CheckIP
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> CheckHost					+++|
		//	+--------------------------------------------------+

		// Prüft einen Hostnamen auf Richtigkeit
		public static bool CheckHost(string hostname)
		{
			// Überprüfen ob Hostname bekannt
			if (Uri.CheckHostName(hostname) == UriHostNameType.Unknown)
				return false;
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region PingHost
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> PingHost					+++|
		//	+--------------------------------------------------+

		// Versucht einen hostnamen begrenzt durch einen Timeout anzupingen
		public static bool PingHost(string hostname, int timeout, string data = null)
		{
			byte[] buffer;			// Byte Buffer anlegen

			Ping ping = new Ping(); // Neue Ping Instanz erzeugen
			PingReply reply;        // Ping Antwortvariable

			// Überprüfen ob externe Daten vorhanden
			if (data == null)
				buffer = Encoding.ASCII.GetBytes(_data);	// Buffer erzeugen
			else
				buffer = Encoding.ASCII.GetBytes(data);     // Buffer erzeugen

			try
			{
				// Ping ausführen und Antwort speichern
				reply = ping.Send(hostname, timeout, buffer);
			}
			catch
			{
				return false;
			}

			// Überprüfen ob Ping Abfrage erfolgreich
			if (reply.Status == IPStatus.Success)
			{
				// Überprüfen ob Antwortadresse gültig
				if (CheckIP(reply.Address.ToString()))
					return true;
			}
			return false;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
		
		#region PingIP
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> PingIP					+++|
		//	+--------------------------------------------------+

		// Versucht eine IP-Adresse (String) begrenzt durch einen Timeout anzupingen
		public static bool PingIP(string ipaddress, int timeout, string data)
		{
			byte[] buffer;          // Byte Buffer anlegen

			Ping ping = new Ping();		// Neue Ping Instanz erzeugen
			PingReply reply;			// Ping Antwortvariable
			IPAddress address = null;	// Variable für IP-Adresse

			// Überprüfen ob eingegebene IP-Adresse gültig
			if (!IPAddress.TryParse(ipaddress, out address))
				return false;

			// Überprüfen ob externe Daten vorhanden
			if (data == null)
				buffer = Encoding.ASCII.GetBytes(_data);    // Buffer erzeugen
			else
				buffer = Encoding.ASCII.GetBytes(data);     // Buffer erzeugen

			try
			{
				// Ping ausführen und Antwort speichern
				reply = ping.Send(address, timeout, buffer);
			}
			catch
			{
				return false;
			}

			// Überprüfen ob Ping Abfrage erfolgreich
			if (reply.Status == IPStatus.Success)
			{
				// Überprüfen ob Antwortadresse gültig
				if (CheckIP(reply.Address.ToString()))
					return true;
			}
			return false;
		}

		// Versucht eine IP-Adresse (Byte Array) begrenzt durch einen Timeout anzupingen
		public static bool PingIP(byte[] ipaddress, int timeout, string data = null)
		{
			// Eingabe IP-Addresse (Byte Array) in string ablegen
			string ipstring = ipaddress[0].ToString() + ResourceText.IPdelimiter + ipaddress[1].ToString() + ResourceText.IPdelimiter + ipaddress[2].ToString() + ResourceText.IPdelimiter + ipaddress[3].ToString();
			byte[] buffer;				// Byte Buffer anlegen

			Ping ping = new Ping();     // Neue Ping Instanz erzeugen
			PingReply reply;            // Ping Antwortvariable
			IPAddress address = null;   // Variable für IP-Adresse

			// Überprüfen ob eingegebene IP-Adresse gültig
			if (!IPAddress.TryParse(ipstring, out address))
				return false;

			// Überprüfen ob externe Daten vorhanden
			if (data == null)
				buffer = Encoding.ASCII.GetBytes(_data);    // Buffer erzeugen
			else
				buffer = Encoding.ASCII.GetBytes(data);     // Buffer erzeugen

			try
			{
				// Ping ausführen und Antwort speichern
				reply = ping.Send(address, timeout, buffer);
			}
			catch
			{
				return false;
			}

			// Überprüfen ob Ping Abfrage erfolgreich
			if (reply.Status == IPStatus.Success)
			{
				// Überprüfen ob Antwortadresse gültig
				if (CheckIP(reply.Address.ToString()))
					return true;
			}
			return false;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region ResolveHost
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> ResolveHost				+++|
		//	+--------------------------------------------------+

		// Versucht einen Namen in eine IP-Adresse aufzulösen
		public static IPAddress[] ResolveHost(string hostname)
		{
			IPHostEntry hostentry = Dns.GetHostEntry(hostname);					// Variable für Hosteintrag
			IPAddress[] iparray = new IPAddress[hostentry.AddressList.Length];	// Array für IP-Adressen

			// Ermittelte IP-Adressen in Array speichern
			for (int i = 0; i < hostentry.AddressList.Length; i++)
			{
				iparray[i] = hostentry.AddressList[i];
			}

			return iparray;	// Array zurückgeben
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
	//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#endregion
}
