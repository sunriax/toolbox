using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkLib;
using VersionLib.Language;

namespace VersionLib
{
	public static class Library
	{
		private static string _ClassUART = ResourceText.NotAvileable;
		private static string _ClassFIFO = ResourceText.NotAvileable;
		private static string _ClassJTAG = ResourceText.NotAvileable;
		private static string _ClassSSH = ResourceText.NotAvileable;
		private static string _ClassIMAGE = ResourceText.NotAvileable;
		private static string _BashTool = ResourceText.NotAvileable;

		// Klassen mit leeren Konstruktoren erzeugen
		private static SSH _ssh = new SSH();

		public static string ClassSSH
		{
			get
			{
				try
				{
					_ClassSSH = _ssh.GetSSHClassVersion;
				}
				catch
				{
					_ClassSSH = ResourceText.NotAvileable;
				}

				return _ClassSSH;
			}
		}

		public static string ClassUART
		{
			get
			{
				return _ClassUART;
			}
		}

		public static string ClassFIFO
		{
			get
			{
				return _ClassFIFO;
			}
		}

		public static string ClassJTAG
		{
			get
			{
				return _ClassJTAG;
			}
		}

		public static string ClassIMAGE
		{
			get
			{
				return _ClassIMAGE;
			}
		}

		public static string BashTool
		{
			get
			{
				return _BashTool;
			}
			set
			{
				_BashTool = value;
			}
		}
	}
}
