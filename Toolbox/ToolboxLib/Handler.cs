using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
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

		public static bool WriteCSV(string path, string filename, char delimeter, string[][] data, bool encrypt = false, string passphrase = null, bool append = false)
		{
			if (filename == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionFileNameEmpty));

			if (!CheckDirectory(path))
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionDirectoryNotExist));

			// Weitere Prüfungen nichtnotwendig da später über Filedialog alles bereits abgeprüft
			path = CheckDirectory(path, true);

			string stream = null;
			StreamWriter datastream = new StreamWriter(path + filename, append);

			// Zeile Eingabedaten + Seperator (ASCII)

			if (data.Length >= int.MaxValue)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionFileSize));

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].Length > int.MaxValue)
					throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionDataLength));

				for (int j = 0; j < data[i].Length; j++)
				{
					stream += (data[i][j] + delimeter);
					// datastream.Write(data[i][j] + delimeter);
				}
				stream += '\n'.ToString();
				// datastream.WriteLine();
			}

			if(encrypt == true)
				if (passphrase == null)
					return false;
				else
					stream = Chiper.Encrypt(stream, passphrase);

			datastream.Write(stream);
			datastream.Close();

			return true;
		}

		public static bool WriteCSV(string path, string filename, char delimeter, List<string[]> data, bool encrypt = false, string passphrase = null, bool append = false)
		{
			if(filename == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionFileNameEmpty));

			if(!CheckDirectory(path))
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionDirectoryNotExist));

			// Weitere Prüfungen nichtnotwendig da später über Filedialog alles bereits abgeprüft
			path = CheckDirectory(path, true);

			string stream = null;
			StreamWriter datastream = new StreamWriter(path + filename, append);

			// Zeile Eingabedaten + Seperator (ASCII)

			if(data.Count >= int.MaxValue)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionFileSize));

			for (int i = 0; i < data.Count; i++)
			{
				if(data[i].Length > int.MaxValue)
					throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionWriteCSV, ResourceText.ExceptionDataLength));

				for (int j = 0; j < data[i].Length; j++)
				{
					datastream.Write(data[i][j] + delimeter);
				}
				datastream.WriteLine();
			}

			if (encrypt == true)
				if (passphrase == null)
					return false;
				else
					stream = Chiper.Encrypt(stream, passphrase);

			datastream.Write(stream);
			datastream.Close();

			return true;
		}

		public static string[][] ReadCSV(string path, string filename, char delimeter, bool decrypt = false, string passphrase = null)
		{
			List<string[]> data = new List<string[]>();
			string linedata = null;

			path = CheckDirectory(path, true);

			if (filename == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionReadCSV, ResourceText.ExceptionFileNameEmpty));

			if (!CheckDirectory(path) || !CheckFile(path + filename))
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionReadCSV, ResourceText.ExceptionFileNotFound));

			// Weitere Prüfungen nichtnotwendig da später über Filedialog alles bereits abgeprüft

			StreamReader datastream;

			// Wenn Entschlüsseln erforderlich
			if (decrypt == true)
			{
				if (passphrase == null)
					return null;

				StreamReader cryptostream = new StreamReader(path + filename);
				byte[] decryptarray = Encoding.UTF8.GetBytes(Chiper.Decrypt(cryptostream.ReadToEnd(), passphrase));

				MemoryStream stream = new MemoryStream(decryptarray);

				datastream = new StreamReader(stream);
			}
			else
			{
				datastream = new StreamReader(path + filename);
			}

			while ((linedata = datastream.ReadLine()) != null)
			{
				string[] seperateddata = linedata.Split(delimeter);
				data.Add(seperateddata);
			}
			datastream.Close();

			return data.ToArray();
		}

		public static bool ReadCSV(string path, string filename, char delimeter, List<string[]> data, bool decrypt = false, string passphrase = null)
		{
			string linedata;

			path = CheckDirectory(path, true);

			if (filename == ResourceText.EMPTY)
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionReadCSV, ResourceText.ExceptionFileNameEmpty));

			if (!CheckDirectory(path) || !CheckFile(path + filename))
				throw new Exception(CreateException(ResourceText.Message, ResourceText.ExceptionClass, ResourceText.ExceptionReadCSV, ResourceText.ExceptionFileNotFound));

			// Weitere Prüfungen nichtnotwendig da später über Filedialog alles bereits abgeprüft

			StreamReader datastream;

			// Wenn Entschlüsseln erforderlich
			if (decrypt == true)
			{
				if (passphrase == null)
					return false;

				StreamReader cryptostream = new StreamReader(path + filename);
				byte[] decryptarray = Encoding.UTF8.GetBytes(Chiper.Decrypt(cryptostream.ReadToEnd(), passphrase));

				MemoryStream stream = new MemoryStream(decryptarray);

				datastream = new StreamReader(stream);
			}
			else
			{
				datastream = new StreamReader(path + filename);
			}

			while ((linedata = datastream.ReadLine()) != null)
			{
				string[] seperateddata = linedata.Split(delimeter);
				data.Add(seperateddata);
			}
			datastream.Close();

			return true;
		}

		public static bool FileCopy(string filename, string topath, bool delete = false)
		{
			if (!CheckDirectory(topath))
				return false;

			string filecopy = Path.GetFileName(filename);

			if (delete == true)
				File.Delete(topath + filecopy);
			File.Copy(filename, topath + filecopy);

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
