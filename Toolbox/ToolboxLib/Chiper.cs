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
	public class Chiper
	{
		private const int _maxkeylength = 2048;
		private const int _maxrepeat = 4096;

		private int _keylength;
		private int _repeat;
		private int _blocksize;
		
		public Chiper()
		{
			_keylength = 256;	// Schlüssellänge
			_repeat = 2048;		// Wiederholungen
			_blocksize = 8;		// 2^_blocksize = 256
		}

		// Nachstehende funktionen gefunden auf http://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
		public string Encrypt(string plaintext, string passphrase)
		{
			byte[] saltbytes = Generate256BitsOfRandomEntropy();
			byte[] ivbytes = Generate256BitsOfRandomEntropy();
			byte[] plainbytes = Encoding.UTF8.GetBytes(plaintext);

			Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passphrase, saltbytes, _repeat);

			byte[] keybytes = password.GetBytes(_keylength / 8);

			Rijndael keysymmetric = new RijndaelManaged();

			keysymmetric.BlockSize = (int)(Math.Pow(2, _blocksize));
			keysymmetric.Mode = CipherMode.CBC;
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

		public string Decrypt(string chiperstring, string passphrase)
		{
			byte[] chiperbytessaltiv = Convert.FromBase64String(chiperstring);
			byte[] saltbytes = chiperbytessaltiv.Take(_keylength / 8).ToArray();
			byte[] ivbytes = chiperbytessaltiv.Skip(_keylength / 8).Take(_keylength / 8).ToArray();
			byte[] textbytes = chiperbytessaltiv.Skip((_keylength / 8) * 2).Take(chiperbytessaltiv.Length - ((_keylength / 8) * 2)).ToArray();

			Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passphrase, saltbytes, _repeat);

			byte[] keybytes = password.GetBytes(_keylength / 8);
			Rijndael keysymmetric = new RijndaelManaged();

			keysymmetric.BlockSize = (int)(Math.Pow(2, _blocksize));
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

		private static byte[] Generate256BitsOfRandomEntropy()
		{
			byte[] randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.

			RNGCryptoServiceProvider rngcrytoservice = new RNGCryptoServiceProvider();

			rngcrytoservice.GetBytes(randomBytes);

			return randomBytes;
		}

		#region Lokal
		//	+--------------------------------------------------+
		//	|+++	Lokale Funktionen						+++|
		//	+--------------------------------------------------+

		// Funktion zum erzeugen von Exception Texten
		private string CreateException(string ExceptionClass, string ExceptionFunction, string ExceptionFault)
		{
			string create = ExceptionClass + "->" + ExceptionFunction + "(" + ResourceText.Message + ": " + ExceptionFault + ")";
			return create;
		}
		#endregion
	}
}
