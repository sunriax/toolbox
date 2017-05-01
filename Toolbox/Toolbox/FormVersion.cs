#define DEBUG
//#undef DEBUG

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
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklaration					+++|
		//	+--------------------------------------------------+

		Parameter _systemparameter;
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Initialisierung
		//	+--------------------------------------------------+
		//	|+++	Komponenteninitialisierung				+++|
		//	+--------------------------------------------------+

		public FormVersion(Parameter SystemParameter)
		{
			InitializeComponent();
			_systemparameter = SystemParameter;

			// Program Versionen aus Hauptprogramm entnehmen
			labelTitle.Text = ResourceText.ProgramName;
			labelToolboxVer.Text = ResourceText.ProgramVersion;
			labelBuildVer.Text = ResourceText.ProgramBuild;

			// Klassen Versionen aus Hauptprogramm entnehmen
			labelClassSSHVer.Text = Library.ClassSSH;
			labelClassUartVer.Text = Library.ClassUART;
			labelClassFifoVer.Text = Library.ClassFIFO;
			labelClassJtagVer.Text = Library.ClassJTAG;
			labelClassImageVer.Text = Library.ClassIMAGE;
			labelBashLinuxVer.Text = Library.BashTool;

			// Weiteres aus Hauptprogramm entnehmen
			linkLabelGithub.Text = ResourceText.LinkGithub;
			labelCopyright.Text = ResourceText.Copyright;
			labelRenciSSH.Text = ResourceText.RenciSSHText;
			linkLabelRenciSSH.Text = ResourceText.RenciSSHLink;
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
	}
}
