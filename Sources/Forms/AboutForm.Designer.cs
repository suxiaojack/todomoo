/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 */
namespace Todomoo
{
	partial class AboutForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblGpl = new System.Windows.Forms.Label();
			this.lblWebsite = new System.Windows.Forms.Label();
			this.lblProjectPage = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblBuild = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.webCredits = new System.Windows.Forms.WebBrowser();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(88, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Todomoo";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(104, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "A project by";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Location = new System.Drawing.Point(72, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1, 416);
			this.panel1.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Location = new System.Drawing.Point(104, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Version number: ";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(88, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(264, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Copyright (C) 2007-2011 Lorenzo Stanco";
			// 
			// lblGpl
			// 
			this.lblGpl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblGpl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGpl.ForeColor = System.Drawing.Color.Blue;
			this.lblGpl.Location = new System.Drawing.Point(88, 104);
			this.lblGpl.Name = "lblGpl";
			this.lblGpl.Size = new System.Drawing.Size(216, 16);
			this.lblGpl.TabIndex = 6;
			this.lblGpl.Text = "GNU General Public License (GNU GPL)";
			this.lblGpl.Click += new System.EventHandler(this.LblGplClick);
			// 
			// lblWebsite
			// 
			this.lblWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWebsite.ForeColor = System.Drawing.Color.Blue;
			this.lblWebsite.Location = new System.Drawing.Point(88, 136);
			this.lblWebsite.Name = "lblWebsite";
			this.lblWebsite.Size = new System.Drawing.Size(216, 16);
			this.lblWebsite.TabIndex = 7;
			this.lblWebsite.Text = "Visit Todomoo website";
			this.lblWebsite.Click += new System.EventHandler(this.LblWebsiteClick);
			// 
			// lblProjectPage
			// 
			this.lblProjectPage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblProjectPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProjectPage.ForeColor = System.Drawing.Color.Blue;
			this.lblProjectPage.Location = new System.Drawing.Point(88, 152);
			this.lblProjectPage.Name = "lblProjectPage";
			this.lblProjectPage.Size = new System.Drawing.Size(216, 16);
			this.lblProjectPage.TabIndex = 8;
			this.lblProjectPage.Text = "Visit project page on SourceForge.net";
			this.lblProjectPage.Click += new System.EventHandler(this.LblProjectPageClick);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(167, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "Lorenzo Stanco";
			// 
			// lblBuild
			// 
			this.lblBuild.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBuild.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblBuild.Location = new System.Drawing.Point(186, 56);
			this.lblBuild.Name = "lblBuild";
			this.lblBuild.Size = new System.Drawing.Size(88, 16);
			this.lblBuild.TabIndex = 11;
			this.lblBuild.Text = "0.0";
			// 
			// lblEmail
			// 
			this.lblEmail.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEmail.ForeColor = System.Drawing.Color.Blue;
			this.lblEmail.Location = new System.Drawing.Point(134, 376);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(160, 16);
			this.lblEmail.TabIndex = 13;
			this.lblEmail.Text = "lorenzo.stanco@gmail.com";
			this.lblEmail.Click += new System.EventHandler(this.LblEmailClick);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(88, 376);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 14;
			this.label12.Text = "Mail me:";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClose.Location = new System.Drawing.Point(88, 408);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(304, 24);
			this.btnClose.TabIndex = 15;
			this.btnClose.Text = " Close";
			this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// webCredits
			// 
			this.webCredits.AllowWebBrowserDrop = false;
			this.webCredits.IsWebBrowserContextMenuEnabled = false;
			this.webCredits.Location = new System.Drawing.Point(88, 184);
			this.webCredits.MinimumSize = new System.Drawing.Size(20, 20);
			this.webCredits.Name = "webCredits";
			this.webCredits.Size = new System.Drawing.Size(304, 176);
			this.webCredits.TabIndex = 36;
			this.webCredits.TabStop = false;
			this.webCredits.WebBrowserShortcutsEnabled = false;
			// 
			// AboutForm
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(409, 449);
			this.Controls.Add(this.webCredits);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.lblEmail);
			this.Controls.Add(this.lblBuild);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lblProjectPage);
			this.Controls.Add(this.lblWebsite);
			this.Controls.Add(this.lblGpl);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About Todomoo";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.WebBrowser webCredits;
		private System.Windows.Forms.Label lblGpl;
		private System.Windows.Forms.Label lblWebsite;
		private System.Windows.Forms.Label lblProjectPage;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblBuild;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
