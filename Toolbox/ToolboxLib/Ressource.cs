using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ToolboxLib.Language;

namespace ToolboxLib
{
	public class Ressource
	{
		private Configuration _appconfig;
		private string _dicrectory;

		// Konstruktor
		public Ressource(string directory)
		{
			_appconfig = ConfigurationManager.OpenExeConfiguration(directory);
			_dicrectory = directory;    // Pfadangabe speichern
		}

		// Key aus App.config löschen
		public bool Remove(string key)
		{
			string value = ConfigurationManager.AppSettings[key];

			// Prüfen ob String Null oder Leer oder Appconfig nicht gefunden
			if (String.IsNullOrEmpty(value) || _appconfig == null)
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}

			try
			{
				// Daten in App.config löschen
				_appconfig.AppSettings.Settings.Remove(key);
				_appconfig.Save(ConfigurationSaveMode.Modified);
			}
			catch
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}
			return true;        // Funktionsaufruf erfolgreich
		}

		// Key in App.config speichern
		public bool Create(string key, string value)
		{
			string getkey = ConfigurationManager.AppSettings[key];

			// Prüfen ob String Null oder Leer oder Appconfig nicht gefunden
			if (!String.IsNullOrEmpty(value) || _appconfig == null)
			{
				if(!Update(key, value))
					return false;   // Funktionsaufruf fehlgeschlagen
				return true;        // Funktionsaufruf erfolgreich
			}

			try
			{
				// Daten in App.config speichern
				_appconfig.AppSettings.Settings.Add(key, value);
				_appconfig.Save(ConfigurationSaveMode.Modified);
			}
			catch
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}
			return true;        // Funktionsaufruf erfolgreich
		}

		// Key aus App.config updaten
		public bool Update(string key, string value)
		{
			string getkey = ConfigurationManager.AppSettings[key];

			// Prüfen ob String Null oder Leer oder Appconfig nicht gefunden
			if (String.IsNullOrEmpty(value) || _appconfig == null)
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}

			try
			{
				// Daten in App.config updaten
				_appconfig.AppSettings.Settings[key].Value = value;
				_appconfig.Save(ConfigurationSaveMode.Modified);
			}
			catch
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}
			return true;        // Funktionsaufruf erfolgreich
		}

		// Key aus App.config updaten
		public bool Save()
		{
			// Prüfen ob Appconfig vorhanden
			if (_appconfig == null)
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}

			try
			{
				// App.config
				_appconfig.Save(ConfigurationSaveMode.Modified);
			}
			catch
			{
				return false;   // Funktionsaufruf fehlgeschlagen
			}
			return true;        // Funktionsaufruf erfolgreich
		}

		// Key aus App.config lesen
		public string GetValue(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

	}
}
