/*
 * ===============================================================
 * UTILS namespace
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * APPSETTINGS CLASS (AppSettings.cs)
 * Useful to store application settings (strings, integers and 
 * booleans) in a simple text file.
 * ===============================================================
 */

using System;
using System.Collections;
using System.IO;

namespace Utils {
	
	public class AppSettings {
		
		// Class properties
		private Hashtable settings;
		private string filepath;
		
		// Constructors
		public AppSettings() : this(".settings") {}
		public AppSettings(string filename) {
			filepath = filename;
			settings = new Hashtable();
		}
		
		// Set methods
		public  void Set(string name, string val) { Set(name, (object)val); }
		public  void Set(string name, int val)    { Set(name, (object)val); }
		public  void Set(string name, bool val)   { Set(name, (object)val); }
		private void Set(string name, object val) {
			if (settings.ContainsKey(name)) settings.Remove(name);
			settings.Add(name, val);
		}
		
		// Get method
		public object Get(string name) {
			if (!settings.ContainsKey(name)) return new object();
			return settings[name];
		}
		
		// Load settings from file
		public void Load() { Load(filepath); }
		public void Load(string filename) {
			
			// Open settings file
			StreamReader f;
			try { f = File.OpenText(filename); }
			catch { return; }
			
			// Load settings
			try {
				string line;
				while (!f.EndOfStream) if ((line = f.ReadLine()).Length > 0) {
					string[] data = line.Split(new char[] {'.', '='}, 3);
					if (data.Length != 3) continue;
					switch (data[0].Trim().ToLower()) {
						
						// Strings
						case "string":
							Set(data[1].Trim(), data[2].Trim());
							break;
						
						// Integers
						case "int":
							try { Set(data[1].Trim(), Convert.ToInt32(data[2].Trim())); } catch { continue; }
							break;
						
						// Booleans
						case "bool":
							Set(data[1].Trim(), (data[2].Trim() == "true") ? true : false);
							break;
						
						// Others
						default: continue;
						
					}
				}
				
			// On exceptions, close file
			} catch {
				f.Close();
				return;
			}
			
			// Close file
			f.Close();
			
		}
		
		// Save settings to file
		public void Save() { Save(filepath); }
		public void Save(string filename) {
			
			// Create a new text file
			StreamWriter f;
			try { f = File.CreateText(filename); }
			catch { return; }
			
			// Save settings
			try {
				ArrayList keys = new ArrayList(settings.Keys);
				keys.Sort();
				foreach (string key in keys) {
					DictionaryEntry data = new DictionaryEntry(key, settings[key]);
					string line = "";
					switch (data.Value.GetType().ToString()) {
						
						// Strings
						case "String": case "System.String":
							line += "string.";
							line += data.Key.ToString() + " = "; 
							line += data.Value.ToString();
							break;
							
						// Integers
						case "Int": case "Int32": case "System.Int32":
							line += "int.";
							line += data.Key.ToString() + " = "; 
							line += data.Value.ToString();
							break;
							
						// Booleans
						case "Bool": case "Boolean": case "System.Boolean":
							line += "bool.";
							line += data.Key.ToString() + " = "; 
							line += ((bool)data.Value) ? "true" : "false";
							break;
						
						// Other (not to save)
						default: continue;
						
					}
					
					// Write line to file
					f.WriteLine(line);
					
				}
				
			// On exceptions, close file
			} catch {
				f.Close();
				return;
			}
			
			// Close file
			f.Close();
			
		}
		
	}
	
}
