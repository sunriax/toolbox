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

		public static void Account2Dict(string[][] data, Dictionary<int, Dictionary<string, string>> dictionary, ListView listview = null, bool clear = false)
		{
			if (listview != null && clear == true)
				listview.Items.Clear();

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i][0] == ResourceText.AuthModePWD)
				{
					int position = dictionary.Count;

					dictionary[position] = new Dictionary<string, string>();
					dictionary[position].Add(ResourceText.keyMode, data[i][0]);
					dictionary[position].Add(ResourceText.keyUsername, data[i][1]);
					dictionary[position].Add(ResourceText.keyPassword, data[i][2]);
					dictionary[position].Add(ResourceText.keyServer, data[i][3]);
					dictionary[position].Add(ResourceText.keyPort, data[i][4]);
					dictionary[position].Add(ResourceText.keyEmpty, data[i][5]);

					if(listview != null)
					{
						string[] listviewitem = { data[i][1], ResourceText.SpacerPassword, data[i][3], data[i][4] };
						Items2Listview(listview, listviewitem);
					}
				}
			}
		}

		public static void Certificate2Dict(string[][] data, Dictionary<int, Dictionary<string, string>> dictionary, ListView listview = null, bool clear = false)
		{
			if (listview != null && clear == true)
				listview.Items.Clear();

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i][0] == ResourceText.AuthModeCERT)
				{
					int position = dictionary.Count;

					dictionary[position] = new Dictionary<string, string>();
					dictionary[position].Add(ResourceText.keyMode, data[i][0]);
					dictionary[position].Add(ResourceText.keyCertificate, data[i][1]);
					dictionary[position].Add(ResourceText.keyCertificateName, data[i][2]);
					dictionary[position].Add(ResourceText.keyPassphrase, data[i][3]);
					dictionary[position].Add(ResourceText.keyServer, data[i][4]);
					dictionary[position].Add(ResourceText.keyPort, data[i][5]);

					if (listview != null)
					{
						string[] listviewitem = { data[i][1], ResourceText.SpacerPassword, data[i][4], data[i][5] };
						Items2Listview(listview, listviewitem);
					}
				}
			}
		}

		public static void ListviewInit(ListView listview, Dictionary<int, Dictionary<string, string>> dictionary)
		{
			// Listview mit bestehenden Elementen füllen
			for (int i = 0; i < dictionary.Count; i++)
			{
				string[] listviewitem = new string[dictionary[i].Count];

				if (dictionary[i][ResourceText.keyMode] == ResourceText.AuthModePWD)
				{
					listviewitem[0] = dictionary[i][ResourceText.keyUsername];
					listviewitem[1] = ResourceText.SpacerPassword;
					listviewitem[2] = dictionary[i][ResourceText.keyServer];
					listviewitem[3] = dictionary[i][ResourceText.keyPort];
				}
				else if (dictionary[i][ResourceText.keyMode] == ResourceText.AuthModeCERT)
				{
					listviewitem[0] = dictionary[i][ResourceText.keyCertificate];
					listviewitem[1] = ResourceText.SpacerPassword;
					listviewitem[2] = dictionary[i][ResourceText.keyServer];
					listviewitem[3] = dictionary[i][ResourceText.keyPort];
				}
				else
					listviewitem = null;

				if(listviewitem != null)
					Items2Listview(listview, listviewitem);
			}
		}


		public static bool Items2Listview(ListView listview, string[] items)
		{
			//	if(items.Length < 1)
			//		Handler.CreateException()

			string[] listviewitem = new string[items.Length];

			for (int i = 0; i < items.Length; i++)
			{
				if (i == 0)
					listviewitem[i] = listview.Items.Count.ToString();
				else
					listviewitem[i] = items[i - 1];
			}

			ListViewItem item = new ListViewItem(listviewitem);
			
			try
			{
				listview.Items.Add(item);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Funktion zum ersezten von Zeilenumbrüchen und Wagenrücklauf
		public static string ReplaceLinebreak(string InputString)
		{
			return InputString.Replace(('\r' + '\n').ToString(), null).Replace('\r'.ToString(), null).Replace('\n'.ToString(), null);
		}
	}
}
