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

		public static bool CheckFile(string file)
		{
			if (File.Exists(file))
				return true;
			return false;
		}

		public static bool CheckDirectory(string path)
		{
			if (Directory.Exists(path))
				return true;
			return false;
		}

		public static string CheckDirectory(string path, bool delimeter)
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

		public static bool WriteCSV(string path, string filename, char delimeter, List<string[]> data, bool append = false)
		{
			if(filename == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionFileNameEmpty));

			if(!CheckDirectory(path))
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionDirectoryNotExist));

			// Weitere Prüfungen nichtnotwendig da später über Filedialog alles bereits abgeprüft

			StreamWriter datastream = new StreamWriter(path + filename, append);

			// Zeile Eingabedaten + Seperator (ASCII)

			if(data.Count >= int.MaxValue)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionFileSize));

			for (int i = 0; i < data.Count; i++)
			{
				if(data[i].Length > int.MaxValue)
					throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionDataLength));

				for (int j = 0; j < data[0].Length; j++)
				{
					datastream.Write(data[i][j] + delimeter);
				}
				datastream.WriteLine();
			}
			datastream.Close();

			return true;
		}

		public static bool ReadCSV(string path, string filename, char delimeter, List<string[]> data)
		{
			string linedata;

			if (filename == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionReadCSV, ResourceText.ExceptionFileNameEmpty));

			if (!CheckDirectory(path) || !CheckFile(path + filename))
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionReadCSV, ResourceText.ExceptionFileNotFound));

			// Weitere Prüfungen nichtnotwendig da später über Filedialog alles bereits abgeprüft

			StreamReader datastream = new StreamReader(path + filename);

			while((linedata = datastream.ReadLine()) != null)
			{
				string[] seperateddata = linedata.Split(delimeter);

				for(int i=0; i < seperateddata.Length; i++)
				{
					data[data.Count][i] = seperateddata[i];
				}
			}
			datastream.Close();

			return true;
		}

		#region Lokal
		//	+--------------------------------------------------+
		//	|+++	Lokale Funktionen						+++|
		//	+--------------------------------------------------+

		// Funktion zum erzeugen von Exception Texten
		public static string CreateException(string ExceptionMessage, string ExceptionClass, string ExceptionFunction, string ExceptionFault)
		{
			string create = ExceptionClass + "->" + ExceptionFunction + "(" + ExceptionMessage + ": " + ExceptionFault + ")";
			return create;
		}
		#endregion
	}
}
