/*
 * ===============================================================
 * PROJECT NAME
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * FILE TITLE (filename)
 * File description.
 * ===============================================================
 */
namespace Todomoo
{
	partial class UpdatesForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatesForm));
			this.panChecking = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.picLoading = new System.Windows.Forms.PictureBox();
			this.lblChecking = new System.Windows.Forms.Label();
			this.tmrLoading = new System.Windows.Forms.Timer(this.components);
			this.panUpdated = new System.Windows.Forms.Panel();
			this.lblUpdated = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.panNewVersion = new System.Windows.Forms.Panel();
			this.btnDownloadPortable = new System.Windows.Forms.Button();
			this.btnDownloadSetup = new System.Windows.Forms.Button();
			this.lblNewVersion = new System.Windows.Forms.Label();
			this.panError = new System.Windows.Forms.Panel();
			this.lblError = new System.Windows.Forms.Label();
			this.chkAuto = new System.Windows.Forms.CheckBox();
			this.panChecking.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
			this.panUpdated.SuspendLayout();
			this.panNewVersion.SuspendLayout();
			this.panError.SuspendLayout();
			this.SuspendLayout();
			// 
			// panChecking
			// 
			this.panChecking.Controls.Add(this.panel3);
			this.panChecking.Controls.Add(this.lblChecking);
			this.panChecking.Enabled = false;
			this.panChecking.Location = new System.Drawing.Point(8, 8);
			this.panChecking.Name = "panChecking";
			this.panChecking.Size = new System.Drawing.Size(368, 96);
			this.panChecking.TabIndex = 9;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.picLoading);
			this.panel3.Location = new System.Drawing.Point(160, 24);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(32, 32);
			this.panel3.TabIndex = 3;
			// 
			// picLoading
			// 
			this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
			this.picLoading.Location = new System.Drawing.Point(8, 8);
			this.picLoading.Name = "picLoading";
			this.picLoading.Size = new System.Drawing.Size(264, 136);
			this.picLoading.TabIndex = 0;
			this.picLoading.TabStop = false;
			// 
			// lblChecking
			// 
			this.lblChecking.Location = new System.Drawing.Point(8, 64);
			this.lblChecking.Name = "lblChecking";
			this.lblChecking.Size = new System.Drawing.Size(352, 16);
			this.lblChecking.TabIndex = 3;
			this.lblChecking.Text = "Checking for updates...";
			this.lblChecking.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tmrLoading
			// 
			this.tmrLoading.Enabled = true;
			this.tmrLoading.Interval = 25;
			this.tmrLoading.Tick += new System.EventHandler(this.StepLoading);
			// 
			// panUpdated
			// 
			this.panUpdated.Controls.Add(this.lblUpdated);
			this.panUpdated.Enabled = false;
			this.panUpdated.Location = new System.Drawing.Point(8, 168);
			this.panUpdated.Name = "panUpdated";
			this.panUpdated.Size = new System.Drawing.Size(368, 96);
			this.panUpdated.TabIndex = 10;
			this.panUpdated.Visible = false;
			// 
			// lblUpdated
			// 
			this.lblUpdated.Location = new System.Drawing.Point(8, 8);
			this.lblUpdated.Name = "lblUpdated";
			this.lblUpdated.Size = new System.Drawing.Size(352, 80);
			this.lblUpdated.TabIndex = 0;
			this.lblUpdated.Text = "No updates available. You are using the latest Todomoo version.";
			this.lblUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Location = new System.Drawing.Point(8, 112);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(368, 1);
			this.panel2.TabIndex = 12;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(288, 120);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(88, 24);
			this.btnClose.TabIndex = 13;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// panNewVersion
			// 
			this.panNewVersion.Controls.Add(this.btnDownloadPortable);
			this.panNewVersion.Controls.Add(this.btnDownloadSetup);
			this.panNewVersion.Controls.Add(this.lblNewVersion);
			this.panNewVersion.Enabled = false;
			this.panNewVersion.Location = new System.Drawing.Point(8, 376);
			this.panNewVersion.Name = "panNewVersion";
			this.panNewVersion.Size = new System.Drawing.Size(368, 96);
			this.panNewVersion.TabIndex = 14;
			this.panNewVersion.Visible = false;
			// 
			// btnDownloadPortable
			// 
			this.btnDownloadPortable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDownloadPortable.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadPortable.Image")));
			this.btnDownloadPortable.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDownloadPortable.Location = new System.Drawing.Point(8, 64);
			this.btnDownloadPortable.Name = "btnDownloadPortable";
			this.btnDownloadPortable.Size = new System.Drawing.Size(352, 24);
			this.btnDownloadPortable.TabIndex = 2;
			this.btnDownloadPortable.Text = " Download Todomoo 0.0 portable (000 KB)";
			this.btnDownloadPortable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDownloadPortable.UseVisualStyleBackColor = true;
			// 
			// btnDownloadSetup
			// 
			this.btnDownloadSetup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDownloadSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadSetup.Image")));
			this.btnDownloadSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDownloadSetup.Location = new System.Drawing.Point(8, 32);
			this.btnDownloadSetup.Name = "btnDownloadSetup";
			this.btnDownloadSetup.Size = new System.Drawing.Size(352, 24);
			this.btnDownloadSetup.TabIndex = 1;
			this.btnDownloadSetup.Text = " Download Todomoo 0.0 setup (000 KB)";
			this.btnDownloadSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDownloadSetup.UseVisualStyleBackColor = true;
			// 
			// lblNewVersion
			// 
			this.lblNewVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNewVersion.Location = new System.Drawing.Point(8, 8);
			this.lblNewVersion.Name = "lblNewVersion";
			this.lblNewVersion.Size = new System.Drawing.Size(328, 16);
			this.lblNewVersion.TabIndex = 1;
			this.lblNewVersion.Text = "A new version, 0.0 is available to download!";
			// 
			// panError
			// 
			this.panError.Controls.Add(this.lblError);
			this.panError.Enabled = false;
			this.panError.Location = new System.Drawing.Point(8, 272);
			this.panError.Name = "panError";
			this.panError.Size = new System.Drawing.Size(368, 96);
			this.panError.TabIndex = 11;
			this.panError.Visible = false;
			// 
			// lblError
			// 
			this.lblError.Location = new System.Drawing.Point(8, 8);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(352, 80);
			this.lblError.TabIndex = 0;
			this.lblError.Text = "Can\'t connect to Todomoo website. Retry later.";
			this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chkAuto
			// 
			this.chkAuto.Location = new System.Drawing.Point(8, 120);
			this.chkAuto.Name = "chkAuto";
			this.chkAuto.Size = new System.Drawing.Size(272, 24);
			this.chkAuto.TabIndex = 15;
			this.chkAuto.Text = "Automatically checks for updates";
			this.chkAuto.UseVisualStyleBackColor = true;
			// 
			// UpdatesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(385, 153);
			this.Controls.Add(this.chkAuto);
			this.Controls.Add(this.panError);
			this.Controls.Add(this.panNewVersion);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.panUpdated);
			this.Controls.Add(this.panChecking);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdatesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Updates";
			this.Shown += new System.EventHandler(this.UpdatesFormShown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdatesFormFormClosing);
			this.panChecking.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
			this.panUpdated.ResumeLayout(false);
			this.panNewVersion.ResumeLayout(false);
			this.panError.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox chkAuto;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.Panel panError;
		private System.Windows.Forms.Button btnDownloadPortable;
		private System.Windows.Forms.Button btnDownloadSetup;
		private System.Windows.Forms.Label lblNewVersion;
		private System.Windows.Forms.Panel panChecking;
		private System.Windows.Forms.Panel panUpdated;
		private System.Windows.Forms.Panel panNewVersion;
		private System.Windows.Forms.Label lblUpdated;
		private System.Windows.Forms.Label lblChecking;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Timer tmrLoading;
		private System.Windows.Forms.PictureBox picLoading;
		private System.Windows.Forms.Panel panel3;
	}
}
