using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
		private static int[] _ipaddress;
		private static string _data = ResourceText.pingDATA;

		#region CheckIP
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> checkip					+++|
		//	+--------------------------------------------------+

		// Prüft eine IP-Adresse auf ihre Richtigkeit
		public static bool CheckIP(string ipaddress)
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
			if (!Tool.checknumber(ipbytes[0], 1, 254))
				return false;
			if (!Tool.checknumber(ipbytes[1], 0, 254))
				return false;
			if (!Tool.checknumber(ipbytes[2], 0, 254))
				return false;
			if (!Tool.checknumber(ipbytes[3], 1, 254))
				return false;

			// Rückgabe wenn alle Bedingungne erfüllt sind
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region PingHost
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> pinghost					+++|
		//	+--------------------------------------------------+

		// Versucht einen hostnamen begrenzt durch einen Timeout anzupingen
		public static bool PingHost(string hostname, int timeout)
		{
			Ping ping = new Ping();

			// Buffer mit 2 Bytes erzeugen
			byte[] buffer = Encoding.ASCII.GetBytes(_data);

			PingReply reply = ping.Send(hostname, timeout, buffer);

			if (reply.Status == IPStatus.Success)
			{
				if (CheckIP(reply.Address.ToString()))
					return true;
				return false;
			}
			return true;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region PingIP
		//	+--------------------------------------------------+
		//	|+++	Funktionen -> pingip					+++|
		//	+--------------------------------------------------+

		// Versucht eine IP-Adresse begrenzt durch einen Timeout anzupingen
		public static bool PingIP(string ipaddress, int timeout)
		{
			Ping ping = new Ping();
			IPAddress address = IPAddress.Parse(ipaddress);

			// Buffer mit 2 Bytes erzeugen
			byte[] buffer = Encoding.ASCII.GetBytes(_data);

			PingReply reply = ping.Send(address, timeout, buffer);

			if (reply.Status == IPStatus.Success)
			{
				if (CheckIP(reply.Address.ToString()))
					return true;
				return false;
			}
			return true;
		}

		public static bool PingIP(byte[] ipaddress, int timeout)
		{
			Ping ping = new Ping();
			IPAddress address = IPAddress.Parse(ipaddress[0].ToString() + ResourceText.IPdelimiter + ipaddress[1].ToString() + ResourceText.IPdelimiter + ipaddress[2].ToString() + ResourceText.IPdelimiter + ipaddress[3].ToString());

			// Buffer mit 2 Bytes erzeugen
			string data = ResourceText.pingDATA;
			byte[] buffer = Encoding.ASCII.GetBytes(data);

			PingReply reply = ping.Send(address, timeout, buffer);

			if (reply.Status == IPStatus.Success)
			{
				if (CheckIP(reply.Address.ToString()))
					return true;
				return false;
			}
			return true;
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
		public static int[] GetIP
		{
			// IP Adresse zurückgeben
			get
			{
				return _ipaddress;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
	//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#endregion
}
