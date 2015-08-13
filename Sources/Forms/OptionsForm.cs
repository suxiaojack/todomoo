/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * OPTIONS FORM (OptionsForm.cs)
 * Options form class.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Todomoo {
	
	/// <summary>
	/// Todomoo options form.
	/// </summary>
	public partial class OptionsForm : Form {
		
		// Language and settings
		private Languages.Language Lang;
		private Utils.AppSettings Settings;
		
		// Constructor
		public OptionsForm(Languages.Language language, Utils.AppSettings settings) {
			
			// Windows Forms designer support.
			InitializeComponent();
			
			// Setup settings reference
			Settings = settings;
			
			// Setup language for the form
			Lang = language;
			Text = Lang.Get("options");
			btnOk.Text = Lang.Get("ok");
			btnCancel.Text = Lang.Get("cancel");
			
			// Setup language for GUI
			tabGui.Text = Lang.Get("options_gui");
			boxAppearance.Text = Lang.Get("options_appearance");
			lblMenuStyle.Text = Lang.Get("options_menu") + ":";
			lblToolbarStyle.Text = Lang.Get("options_toolbar") + ":";
			lblCategoriesStyle.Text = Lang.Get("options_categories_bar") + ":";
			cmbMenuStyle.Items[0] = Lang.Get("options_style_standard");
			cmbMenuStyle.Items[1] = Lang.Get("options_style_flat");
			cmbToolbarStyle.Items[0] = Lang.Get("options_style_standard");
			cmbToolbarStyle.Items[1] = Lang.Get("options_style_flat");
			cmbCategoriesStyle.Items[0] = Lang.Get("options_style_standard");
			cmbCategoriesStyle.Items[1] = Lang.Get("options_style_flat");
			boxLanguage.Text = Lang.Get("options_language");
			lblCurrency.Text = Lang.Get("options_currency") + ":";
			
			// Setup language for backup
			tabBackup.Text = Lang.Get("options_backups");
			cmdBackupDirectory.Text = Lang.Get("options_backup_dir");
			lblBackupTip.Text = Lang.Get("options_backup_tip");
			boxAutomaticBackup.Text = Lang.Get("options_automatic_backup");
			chkAutomaticBackup.Text = Lang.Get("options_automatic_backup_text");
			
			// Setup language for minimize to tray
			boxBehaviour.Text = Lang.Get("options_behaviour");
			lblClosing.Text = Lang.Get("options_closing") + ":";
			optClosingMinimize.Text = Lang.Get("minimize_to_tray");
			optClosingClose.Text = Lang.Get("close_program");
			
			// Fill in fields for the GUI
			cmbMenuStyle.SelectedIndex = (Settings.Get("style_menu").ToString() == "0" ? 0 : 1);
			cmbToolbarStyle.SelectedIndex = (Settings.Get("style_toolbar").ToString() == "0" ? 0 : 1);
			cmbCategoriesStyle.SelectedIndex = (Settings.Get("style_categories").ToString() == "0" ? 0 : 1);
			cmbCurrency.SelectedIndex = 0;
			if (Settings.Get("currency").ToString() == "€" ) cmbCurrency.SelectedIndex = 0;
			if (Settings.Get("currency").ToString() == "$" ) cmbCurrency.SelectedIndex = 1;
			if (Settings.Get("currency").ToString() == "£" ) cmbCurrency.SelectedIndex = 2;
			if (Settings.Get("currency").ToString() == "¥" ) cmbCurrency.SelectedIndex = 3;
			if (Settings.Get("currency").ToString() == "R$") cmbCurrency.SelectedIndex = 4;
			if (Settings.Get("currency").ToString() == "฿" ) cmbCurrency.SelectedIndex = 5;
			
			// Fill in languages combo
			cmbLanguage.Items.Clear();
			foreach (Languages.AvailableLanguage l in Languages.AvailableLanguage.GetAll()) {
				cmbLanguage.Items.Add(l);
				if (Settings.Get("lang").ToString() == l.Code) cmbLanguage.SelectedItem = l;
			}
			
			// Fill in minimize radio
			if (Settings.Get("window_minimize_when_closing").ToString() == "0") optClosingClose.Checked = true;
			else optClosingMinimize.Checked = true;
			
			// Fill in fields for the backup
			chkAutomaticBackup.Checked = (Settings.Get("backup_automatic").ToString() == "1");
			try {
				long sum = 0;
				DirectoryInfo backup_dir = new DirectoryInfo(MainForm.BackupDirectory);
				if (!backup_dir.Exists) backup_dir.Create();
				FileInfo[] files = backup_dir.GetFiles("*.sqlite");
				foreach (FileInfo file in files) sum += file.Length;
				lblBackupSize.Text = ((float)sum / (1024F * 1024F)).ToString("0.00").Replace(',', '.') + " MB";
			} catch {
				lblBackupSize.Text = "? MB";
			}
			
		}
		
		/// <summary>
		/// Save settings
		/// </summary>
		/// <returns></returns>
		public bool Save() {
			
			// Change GUI settings
			Settings.Set("style_menu", cmbMenuStyle.SelectedIndex);
			Settings.Set("style_toolbar", cmbToolbarStyle.SelectedIndex);
			Settings.Set("style_categories", cmbCategoriesStyle.SelectedIndex);
			if (cmbCurrency.SelectedIndex == 0) Settings.Set("currency", "€");
			if (cmbCurrency.SelectedIndex == 1) Settings.Set("currency", "$");
			if (cmbCurrency.SelectedIndex == 2) Settings.Set("currency", "£");
			if (cmbCurrency.SelectedIndex == 3) Settings.Set("currency", "¥");
			if (cmbCurrency.SelectedIndex == 4) Settings.Set("currency", "R$");
			if (cmbCurrency.SelectedIndex == 5) Settings.Set("currency", "฿");
			
			// Change language
			foreach (Languages.AvailableLanguage l in Languages.AvailableLanguage.GetAll()) {
				if (((Languages.AvailableLanguage)cmbLanguage.SelectedItem).Code == l.Code) {
					Settings.Set("lang", l.Code);
				}
			}
			
			// Change backup settings
			Settings.Set("backup_automatic", (chkAutomaticBackup.Checked ? 1 : 0));
			
			// Change minimize settings
			Settings.Set("window_minimize_when_closing", (optClosingMinimize.Checked ? 1 : 0));
			
			// Return TRUE
			return true;
			
		}
		
		#region GUI events
		
		void BtnOkClick(object sender, EventArgs e) {
			if (Save()) { this.DialogResult = DialogResult.OK; Close(); }
		}
		
		void BtnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel; Close();
		}
		
		void CmdBackupDirectoryClick(object sender, EventArgs e) {
			DirectoryInfo backup_dir = new DirectoryInfo(MainForm.BackupDirectory);
			if (!backup_dir.Exists) backup_dir.Create();
			System.Diagnostics.Process.Start(backup_dir.FullName);
		}
		
		#endregion
		
	}
	
}
