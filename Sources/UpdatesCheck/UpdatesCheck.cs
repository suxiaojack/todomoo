/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * UPDATES CHECK (UpdatesCheck.cs)
 * Checks if Todomoo updates are available.
 * ===============================================================
 */

using System;
using System.Net;
using System.Windows.Forms;
using System.Text;

namespace Todomoo {
	
	public class UpdatesCheck {
		
		// Events
		public delegate void NewVersionAvailableHandler(string version, string url_setup, int size_setup, string url_portable, int size_portable);
		public event NewVersionAvailableHandler NewVersionAvailable;
		public delegate void UpdatedHandler();
		public event UpdatedHandler Updated;
		public delegate void ErrorHandler(string message);
		public event ErrorHandler Error;
		
		// Web request
		private PostRequestHelper p;
		
		public UpdatesCheck() { }
		
		public void Check() {
			
			// Prepare request
			p = new PostRequestHelper("http://todomoo.sourceforge.net/updatescheck.php", 30000);
			Version v = new Version(Application.ProductVersion);
			p.UserAgent = "Todomoo " + v.Major + "." + v.Minor;
			p.Accept = "text/plain,text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			
			// Add POST data (current version, user date and time, machine hashed ID)
			//   NB: Machine ID is hashed due to privacy guarantee, needed only for updates statistics
			//   NB: Local language is for statistics about localizations and translations
			p.AddPostData("current", v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision);
			p.AddPostData("user_time", DateTime.Now.ToString("R"));
			p.AddPostData("machine_id", MD5.Compute(UniqueMachineID.Get()));
			p.AddPostData("local_lang", System.Globalization.CultureInfo.CurrentUICulture.ToString());
			//p.AddPostData("force_new_version", "1"); // DEBUG
			
			// Get response
			try {
				
				p.BeginGetResponse();
				
				// Process response when it's ready
				p.ResponseReady += delegate(System.Net.PostRequestHelper s, string response) {
					ProcessResponse(response);
				};
				
				// Error in HTTP response
				p.Error += delegate(System.Net.PostRequestHelper s, Exception exception) {
					if (Error != null) Error(exception.Message);
				};
			
			// Error on HTTP request initialization
			} catch (Exception ex) {
				if (Error != null) Error(ex.Message);
			}
			
		}
		
		private void ProcessResponse(string response) {
			
			// Updated
			if (response.Trim().StartsWith("Updated")) {
				if (Updated != null) Updated();
			
			// Not updated
			} else if (NewVersionAvailable != null) {
				
				// Process response
				string[] data = response.Split(new char[] {'\n'});
				if (data.Length < 6) { if (Error != null) Error("Bad response.");
				
				// Throw event
				} else NewVersionAvailable(data[1],
					data[2], Utils.Conversion.ToInt(data[3]),
					data[4], Utils.Conversion.ToInt(data[5])
				);
				
			}
		}
		
		public void Stop() {
			if (p != null) p.StopRequest();
			Utils.Debug.Write("Updates check stopped.");
			NewVersionAvailable = null;
			Updated = null;
			Error = null;
		}
		
	}
	
}
