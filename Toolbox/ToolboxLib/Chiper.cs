using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using ToolboxLib.Language;

namespace ToolboxLib
{
	public static class Chiper
	{
		#region Deklaration
		//	+--------------------------------------------------+
		//	|+++	Variablendeklaration					+++|
		//	+--------------------------------------------------+

		private const int _keylength = 256;		// Länge des Schlüssels (gültig: 128/192/256)
		private const int _repeat = 2048;		// Wiederholungen der Verschlüsselung
		private const int _blocksize = 256;     // Blocklänge des Schlüssels (gültig: 128/192/256)
												//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! INFORMATION !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		// Nachstehende Funktionen kopiert von http://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
		// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

		#region Encrypt
		//	+--------------------------------------------------+
		//	|+++	Encrypt									+++|
		//	+--------------------------------------------------+

		// Funktion zum Verschlüsseln von Plaintext
		public static string Encrypt(string plaintext, string passphrase)
		{
			// Versuchen Verschlüsselung durchzuführen
			try
			{
				byte[] saltbytes = Generate256BitsOfRandomEntropy();		// Random Bitfolge erzeugen (Salz)
				byte[] ivbytes = Generate256BitsOfRandomEntropy();			// Random Bitfolge erzeugen (Salz)
				byte[] plainbytes = Encoding.UTF8.GetBytes(plaintext);		// Bytes aus Eingabetext erzeugen

				// Generation der Schlüsselableitungsfunktion (PBKDF2) mithilfe des HMACSHA1 Generator (SHA1 Broken (unsicher)!!!)
				Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passphrase, saltbytes, _repeat);

				byte[] keybytes = password.GetBytes(_keylength / 8);	// Erzeugen eines Byte Array aus dem Passwort

				// Erzeugen der Algorithmus Basisklasse
				Rijndael keysymmetric = new RijndaelManaged();

				// Einstellen spezifischer Verschlüsselungseinstellungen
				keysymmetric.BlockSize = _blocksize;		// Einstellen der Blockgröße
				keysymmetric.Mode = CipherMode.CBC;			// 
				keysymmetric.Padding = PaddingMode.PKCS7;
			
				ICryptoTransform encryptor = keysymmetric.CreateEncryptor(keybytes, ivbytes);

				MemoryStream memstream = new MemoryStream();
				CryptoStream cryptstream = new CryptoStream(memstream, encryptor, CryptoStreamMode.Write);

				cryptstream.Write(plainbytes, 0, plainbytes.Length);
				cryptstream.FlushFinalBlock();

				byte[] chiperbytes = saltbytes;

				chiperbytes = chiperbytes.Concat(ivbytes).ToArray();
				chiperbytes = chiperbytes.Concat(memstream.ToArray()).ToArray();
				memstream.Close();
				cryptstream.Close();

				return Convert.ToBase64String(chiperbytes);
			}
			catch
			{
				return null;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion

		#region Decrypt
		//	+--------------------------------------------------+
		//	|+++	Decrypt									+++|
		//	+--------------------------------------------------+

		// Funktion zum Entschlüsseln von Plaintext
		public static string Decrypt(string chiperstring, string passphrase)
		{
			try
			{
				byte[] chiperbytessaltiv = Convert.FromBase64String(chiperstring);
				byte[] saltbytes = chiperbytessaltiv.Take(_keylength / 8).ToArray();
				byte[] ivbytes = chiperbytessaltiv.Skip(_keylength / 8).Take(_keylength / 8).ToArray();
				byte[] textbytes = chiperbytessaltiv.Skip((_keylength / 8) * 2).Take(chiperbytessaltiv.Length - ((_keylength / 8) * 2)).ToArray();

				Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passphrase, saltbytes, _repeat);

				byte[] keybytes = password.GetBytes(_keylength / 8);
				Rijndael keysymmetric = new RijndaelManaged();

				keysymmetric.BlockSize = _blocksize;
				keysymmetric.Mode = CipherMode.CBC;
				keysymmetric.Padding = PaddingMode.PKCS7;

				ICryptoTransform decryptor = keysymmetric.CreateDecryptor(keybytes, ivbytes);

				MemoryStream memstream = new MemoryStream(textbytes);
				CryptoStream cryptstream = new CryptoStream(memstream, decryptor, CryptoStreamMode.Read);

				byte[] plainbytes = new byte[textbytes.Length];
				int decryptbytes = cryptstream.Read(plainbytes, 0, plainbytes.Length);

				memstream.Close();
				cryptstream.Close();

				return Encoding.UTF8.GetString(plainbytes, 0, decryptbytes);
			}
			catch
			{
				return null;
			}
		}
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		#endregion
		
		
		// Zu Testzwecken
		public static int CalcPolynom(double a, double b, double c, double d, int x, bool direction)
		{
			double polynom_0 = (a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d);
			double polynom_1 = (3 * a * Math.Pow(x ,2) + 2 * b * x + c);
			double polynom_2 = (6 * a * x + 2 * b);

			return (int)(polynom_0 + polynom_1 + polynom_2);
		}


		#region Lokal
		//	+--------------------------------------------------+
		//	|+++	Lokale Funktionen						+++|
		//	+--------------------------------------------------+

		// Zufallsbits generieren
		private static byte[] Generate256BitsOfRandomEntropy()
		{
			byte[] randomBytes = new byte[32];

			RNGCryptoServiceProvider rngcrytoservice = new RNGCryptoServiceProvider();

			rngcrytoservice.GetBytes(randomBytes);

			return randomBytes;
		}

		// Funktion zum erzeugen von Exception Texten
		private static string CreateException(string ExceptionClass, string ExceptionFunction, string ExceptionFault)
		{
			string create = ExceptionClass + "->" + ExceptionFunction + "(" + ResourceText.Message + ": " + ExceptionFault + ")";
			return create;
		}
		#endregion
	}
}
