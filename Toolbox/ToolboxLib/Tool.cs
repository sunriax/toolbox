using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ToolboxLib.Language;

namespace ToolboxLib
{
	public static class Tool
	{
		public static bool CheckNumeric(int number, int MIN, int MAX)
		{
			if (number <= MAX && number >= MIN)
				return true;
			return false;
		}

		public static bool CheckNumeric(string number, int MIN, int MAX)
		{
			int variable = 0;

			if (int.TryParse(number, out variable))
				if (variable <= MAX && variable >= MIN)
					return true;
			return false;
		}

		public static bool CheckString(TextBox inputTextBox, int MIN, int MAX)
		{
			inputTextBox.BackColor = Color.Empty;
			int variable = 0;

			if (inputTextBox.Text != ResourceText.EMPTY)
				if (int.TryParse(inputTextBox.Text, out variable))
					if (variable <= MAX && variable >= MIN)
						return true;
			
			inputTextBox.BackColor = Color.Red;
			inputTextBox.SelectAll();

			return false;
		}

		public static bool CheckString(TextBox inputTextBox, string compare = null)
		{
			inputTextBox.BackColor = Color.Empty;

			if (compare == null)
			{
				if (inputTextBox.Text != ResourceText.EMPTY)
					return true;
			}
			else
			{
				if (inputTextBox.Text == compare)
					return true;
			}
			inputTextBox.BackColor = Color.Red;
			inputTextBox.SelectAll();

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
