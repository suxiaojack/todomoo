/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * UPDATES FORM (UpdatesForm.cs)
 * About form class.
 * ===============================================================
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Todomoo {
	
	/// <summary>
	/// Updates form.
	/// </summary>
	public partial class UpdatesForm : Form {
		
		// Language and settings
		private Languages.Language Lang;
		private Utils.AppSettings Settings;
		
		// Already checked
		private bool already_checked = false;
		
		// Loading animation
		private int loading_step = 0;
		
		// Updates check
		UpdatesCheck u;
		
		public static UpdatesForm CreateWithNewVersion(
			Languages.Language language, Utils.AppSettings settings, 
			string version, string url_setup, int size_setup, string url_portable, int size_portable
		) {
			
			// Create the form
			UpdatesForm u = new UpdatesForm(language, settings);
			u.already_checked = true;
			u.ShowAvailableUpdate(version, url_setup, size_setup, url_portable, size_portable);
			return u;
			
		}
		
		public UpdatesForm(Languages.Language language, Utils.AppSettings settings) {
			
			// Windows Forms designer support.
			InitializeComponent();
			
			// Show first panel
			ShowPanel(panChecking);
			
			// Setup settings reference
			Settings = settings;
			
			// Setup language for the form
			Lang = language;
			Text = Lang.Get("updates");
			btnClose.Text = Lang.Get("close");
			
			// Language setup
			lblChecking.Text = Lang.Get("updates_checking") + "...";
			lblUpdated.Text = Lang.Get("updates_updated");
			lblError.Text = Lang.Get("updates_error");
			chkAuto.Text = Lang.Get("updates_auto");
			
			// Auto check
			chkAuto.Checked = (Settings.Get("updates_auto").ToString() == "1");
			chkAuto.CheckedChanged += delegate { Settings.Set("updates_auto", chkAuto.Checked ? 1 : 0); };
			
		}
		
		void UpdatesFormShown(object sender, EventArgs e) {
			
			// If already checked, do nothing
			if (already_checked) return;
			
			// Check for updates
			u = new UpdatesCheck();
			u.Error += delegate   { try { this.Invoke((MethodInvoker)delegate { ShowPanel(panError);   }); } catch { Utils.Debug.Write("CEZ"); } };
			u.Updated += delegate { try { this.Invoke((MethodInvoker)delegate { ShowPanel(panUpdated); }); } catch { Utils.Debug.Write("CEZ"); } };
			u.NewVersionAvailable += delegate(string version, string url_setup, int size_setup, string url_portable, int size_portable) {
				try { this.Invoke((MethodInvoker)delegate { ShowAvailableUpdate(version, url_setup, size_setup, url_portable, size_portable); }); } catch { Utils.Debug.Write("CEZ"); } };
			u.Check();
			
		}
		
		private void ShowAvailableUpdate(string version, string url_setup, int size_setup, string url_portable, int size_portable) {
			lblNewVersion.Text = string.Format(Lang.Get("updates_new_version"), version);
			btnDownloadSetup.Text = " " + string.Format(Lang.Get("updates_download_setup"), version, size_setup);
			btnDownloadPortable.Text = " " + string.Format(Lang.Get("updates_download_portable"), version, size_portable);
			btnDownloadSetup.Click += delegate { System.Diagnostics.Process.Start(url_setup); };
			btnDownloadPortable.Click += delegate { System.Diagnostics.Process.Start(url_portable); };
			ShowPanel(panNewVersion);
		}
		
		private void StepLoading(object sender, EventArgs e) { StepLoading(); }
		private void StepLoading() {
			loading_step = loading_step % 32;
			if (loading_step == 0) loading_step = 1;
			int x = loading_step % 8;
			int y = loading_step / 8;
			panChecking.SuspendLayout();
			picLoading.Location = new Point( - x * 32, - y * 32);
			panChecking.ResumeLayout();
			loading_step++;
		}
		
		private void ShowPanel(Panel panel) {
			panChecking.Enabled   = panChecking.Visible   = false;
			panError.Enabled      = panError.Visible      = false;
			panNewVersion.Enabled = panNewVersion.Visible = false;
			panUpdated.Enabled    = panUpdated.Visible    = false;
			panel.Enabled         = panel.Visible         = true;
			panel.Top = 8;
		}
		
		void UpdatesFormFormClosing(object sender, FormClosingEventArgs e) {
			if (u != null) u.Stop();
		}
		
	}
	
}
