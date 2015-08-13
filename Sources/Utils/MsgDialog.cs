/*
 * ===============================================================
 * UTILS namespace
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * MSGDIALOG CLASS (MsgDialog.cs)
 * Static method to display message dialogs.
 * ===============================================================
 */
 
using System;
using System.Windows.Forms;

namespace Utils {
	
	public class MsgDialog {
		
		public static void Info(string text, string title) {
			MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		public static void Warning(string text, string title) {
			MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		
		public static void Error(string text, string title) {
			MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		public static bool Question(string text, string title) {
			DialogResult r = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return (r == DialogResult.Yes);
		}
		
		public static bool Confirm(string text, string title) {
			DialogResult r = MessageBox.Show(text, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			return (r == DialogResult.OK);
		}
		
	}
	
}
