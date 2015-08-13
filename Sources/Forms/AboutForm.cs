/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * ABOUT FORM (AboutForm.cs)
 * About form class.
 * ===============================================================
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Todomoo {
	
	/// <summary>
	/// About form.
	/// </summary>
	public partial class AboutForm : Form {
		
		public AboutForm(Languages.Language language) {
			
			// Windows Forms designer support.
			InitializeComponent();
			
			// Version no
			Version v = new Version(Application.ProductVersion);
			lblBuild.Text = v.Major + "." + v.Minor;
			
			// Language
			btnClose.Text = language.Get("close");
			Text = language.Get("help_about");
			
			// Credits
			string htmlCredits = @"
				<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" ""http://www.w3.org/TR/html4/loose.dtd"">
				<html lang=""en"">
				<head>
					<style type=""text/css"">
						body {
							font-size: 11px;
							font-family: Tahoma, sans-serif;
							margin: 0;
							padding: 10px 10px;
							background-color: #f6f6f6;
							color: #000000;
						}
						p {
							padding: 0;
							margin: 0 0 10px;
						}
					</style>
				</head>
				<body>
					<p>
						Best beta tester ever: <b>Davide &quot;Gege&quot; De Gennaro</b><br>
						Cutest beta tester ever: <b>Serena Mantovani</b>
					</p>
					<p>
						French translation: <b>MML67</b><br>
						Portuguese translation: <b>Edson Braga Zampieri</b><br>
						Spanish translation: <b>Ian</b><br>
						Chinese translation: <b>Chunhui Zhao</b><br>
						Dutch translation: <b>Rick Spaan</b><br>
						Thai translation: <b>Prakrit Dungsutha</b><br>
						Polish translation: <b>Eugeniusz Wieczorek</b><br>
						Greek translation: <b>geogeo.gr</b><br>
						Romanian translation: <b>Oprea Nicolae</b><br>
						German translation: <b>Wolfgang Gaida</b><br>
						Russian translation: <b>Василий Павлов</b>
					</p>
					<p>
						<a href=""http://www.famfamfam.com/lab/icons/silk/"">Silk icons</a> by FamFamFam.<br>
						<a href=""http://www.codeproject.com/KB/list/ObjectListView.aspx"">Object list view</a> by Phillip Piper (GNU GPL).
					</p>
				</body>
				</html>
			";
			
			webCredits.DocumentText = htmlCredits.Trim(new char[] { '\n', '\r', '\t', ' '}).Trim();
			webCredits.Navigating += delegate(object sender, WebBrowserNavigatingEventArgs e) { 
				System.Diagnostics.Process.Start(e.Url.ToString());
				e.Cancel = true;
			};
			
		}
		
		#region GUI events
		
		void BtnCloseClick(object sender, EventArgs e) {
			Close();
		}
		
		void LblGplClick(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://www.gnu.org/licenses/gpl.html");
		}
		
		void LblWebsiteClick(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://todomoo.sourceforge.net/");
		}
		
		void LblProjectPageClick(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://sourceforge.net/projects/todomoo/");
		}
		
		void LblSilkIconsClick(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://www.famfamfam.com/lab/icons/silk/");
		}
		
		void LblEmailClick(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("mailto:lorenzo.stanco@gmail.com");
		}
		
		void LblOLVClick(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://www.codeproject.com/KB/list/ObjectListView.aspx");
		}
		
		#endregion
		
	}
	
}
