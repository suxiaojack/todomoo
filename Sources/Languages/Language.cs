/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * LANGUAGE CLASS (Language.cs)
 * File description.
 * ===============================================================
 */

using System;
using System.Collections.Generic;

namespace Todomoo.Languages {
	
	/// <summary>
	/// Define an available language (name and code).
	/// </summary>
	public class AvailableLanguage {
		
		public string Code;
		public string Name;
		
		public AvailableLanguage(string code, string name) {
			this.Code = code;
			this.Name = name;
		}
		
		public override string ToString() {
			return this.Name;
		}
		
		/// <summary>
		/// Gets the list of available languages.
		/// Used to populate ComboBoxes, etc...
		/// </summary>
		/// <returns>The list of available languages</returns>
		public static List<AvailableLanguage> GetAll() {
			List<AvailableLanguage> l = new List<AvailableLanguage>();
			l.Add(new AvailableLanguage("de", "Deutsch"));
			l.Add(new AvailableLanguage("nl", "Dutch"));
			l.Add(new AvailableLanguage("el", "ελληνικά"));
			l.Add(new AvailableLanguage("en", "English"));
			l.Add(new AvailableLanguage("es", "Español"));
			l.Add(new AvailableLanguage("fr", "Français"));
			l.Add(new AvailableLanguage("it", "Italiano"));
			l.Add(new AvailableLanguage("pl", "Język polski"));
			l.Add(new AvailableLanguage("pt", "Português"));
			l.Add(new AvailableLanguage("ro", "Română"));
			l.Add(new AvailableLanguage("ru", "Русский"));
			l.Add(new AvailableLanguage("zh-cn", "Simplified Chinese"));
			l.Add(new AvailableLanguage("th", "Thai"));
			return l;
		}
		
	}
	
	/// <summary>
	/// Language class. Load a language file and provides get methods for strings.
	/// </summary>
	public class Language {
		
		// Language file directory
		string directory;
		
		// Language class use a configuration file from Utils namespace
		Utils.AppSettings definitions;
		
		/// <summary>
		/// Constructor for the class.
		/// </summary>
		/// <param name="language_directory">The folder that contains language files</param>
		public Language(string language_directory) {
			directory = language_directory.Trim(new char[] {'\\'});
		}
		
		/// <summary>
		/// Load a language file.
		/// </summary>
		/// <param name="language_code">Language code, for example "en"</param>
		public void LoadLanguage(string language_code) {
			definitions = new Utils.AppSettings(directory + "\\" + language_code + ".lang");
			definitions.Load();
		}
		
		/// <summary>
		/// Get a string from current language file.
		/// </summary>
		/// <param name="key">Key of the string</param>
		/// <returns></returns>
		public string Get(string key) {
			string val = definitions.Get(key).ToString();
			if (val == "System.Object") return "!ERR.LANG!";
			return val;
		}
		
	}
	
}
