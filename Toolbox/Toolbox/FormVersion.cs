using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionLib;
using Toolbox.Language;

namespace Toolbox
{
	public partial class FormVersion : Form
	{
		private Library _version;

		public FormVersion(Library version)
		{
			InitializeComponent();

			_version = version;

			// Program Versionen aus Hauptprogramm entnehmen
			labelTitle.Text = ResourceText.ProgramName;
			labelToolboxVer.Text = ResourceText.ProgramVersion;
			labelBuildVer.Text = ResourceText.ProgramBuild;

			// Klassen Versionen aus Hauptprogramm entnehmen
			labelClassSSHVer.Text = _version.ClassSSH;
			labelClassUartVer.Text = _version.ClassUART;
			labelClassFifoVer.Text = _version.ClassFIFO;
			labelClassJtagVer.Text = _version.ClassJTAG;
			labelClassImageVer.Text = _version.ClassIMAGE;
			labelBashLinuxVer.Text = _version.BashTool;

			// Weiteres aus Hauptprogramm entnehmen
			linkLabelGithub.Text = ResourceText.LinkGithub;
			labelCopyright.Text = ResourceText.Copyright;
			labelRenciSSH.Text = ResourceText.RenciSSHText;
			linkLabelRenciSSH.Text = ResourceText.RenciSSHLink;
		}
	}
}
