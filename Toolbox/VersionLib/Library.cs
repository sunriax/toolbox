using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkLib;
using VersionLib.Language;

namespace VersionLib
{
	public class Library
	{
		private string _ClassUART = null;
		private string _ClassFIFO = null;
		private string _ClassJTAG = null;
		private string _ClassSSH = null;
		private string _ClassIMAGE = null;

		private string _BashTool = null;
		private SSH _ssh = new SSH();

		public Library()
		{
			_ClassUART = ResourceText.NotAvileable;
			_ClassFIFO = ResourceText.NotAvileable;
			_ClassJTAG = ResourceText.NotAvileable;
			_ClassIMAGE = ResourceText.NotAvileable;
			_BashTool = ResourceText.NotAvileable;

			try
			{
				_ClassSSH = _ssh.GetSSHClassVersion;
			}
			catch
			{
				_ClassSSH = ResourceText.NotAvileable;
			}
		}

		public string ClassSSH
		{
			get
			{
				return _ClassSSH;
			}
		}

		public string ClassUART
		{
			get
			{
				return _ClassUART;
			}
		}

		public string ClassFIFO
		{
			get
			{
				return _ClassFIFO;
			}
		}

		public string ClassJTAG
		{
			get
			{
				return _ClassJTAG;
			}
		}

		public string ClassIMAGE
		{
			get
			{
				return _ClassIMAGE;
			}
		}

		public string BashTool
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
