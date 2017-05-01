using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolboxLib
{
	public static class Tool
	{
		public static bool checknumber(int number, int MIN, int MAX)
		{
			if (number <= MAX && number >= MIN)
				return true;
			return false;
		}

		public static int String2Int(string text, int convert)
		{
			// Überprüfen ob Variable konvertierbar ist
			if (int.TryParse(text, out convert))
				if (convert < int.MaxValue && convert > int.MinValue)
					return convert;

			return convert;
		}

		// Funktion zum ersezten von Zeilenumbrüchen und Wagenrücklauf
		public static string ReplaceLinebreak(string InputString)
		{
			return InputString.Replace(('\r' + '\n').ToString(), null).Replace('\r'.ToString(), null).Replace('\n'.ToString(), null);
		}
	}
}
