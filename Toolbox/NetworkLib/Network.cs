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
}
