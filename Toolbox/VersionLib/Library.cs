using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkLib;
using VersionLib.Language;

namespace VersionLib
{
	static public class Library
	{
		static private string _ClassUART = ResourceText.NotAvileable;
		static private string _ClassFIFO = ResourceText.NotAvileable;
		static private string _ClassJTAG = ResourceText.NotAvileable;
		static private string _ClassSSH = ResourceText.NotAvileable;
		static private string _ClassIMAGE = ResourceText.NotAvileable;
		static private string _BashTool = ResourceText.NotAvileable;

		// Klassen mit leeren Konstruktoren erzeugen
		static private SSH _ssh = new SSH();

		static public string ClassSSH
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

		static public string ClassUART
		{
			get
			{
				return _ClassUART;
			}
		}

		static public string ClassFIFO
		{
			get
			{
				return _ClassFIFO;
			}
		}

		static public string ClassJTAG
		{
			get
			{
				return _ClassJTAG;
			}
		}

		static public string ClassIMAGE
		{
			get
			{
				return _ClassIMAGE;
			}
		}

		static public string BashTool
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
