using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ToolboxLib.Language;

namespace ToolboxLib
{
	public static class Handler
	{

		static public bool CheckFile(string file)
		{
			if (File.Exists(file))
				return true;
			return false;
		}

		static public bool CheckDirectory(string path)
		{
			if (Directory.Exists(path))
				return true;
			return false;
		}

		static public string CheckDirectory(string path, bool delimeter)
		{
			if (Directory.Exists(path))
			{
				if (delimeter == true)
				{
					if (path[path.Length - 1].ToString() != ResourceText.Slash)
						path = path + ResourceText.Slash;
				}
				return path;
			}
			return false.ToString();
		}
	}
}
