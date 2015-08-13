/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 */
namespace Todomoo
{
	partial class OptionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabGui = new System.Windows.Forms.TabPage();
			this.boxBehaviour = new System.Windows.Forms.GroupBox();
			this.optClosingMinimize = new System.Windows.Forms.RadioButton();
			this.optClosingClose = new System.Windows.Forms.RadioButton();
			this.lblClosing = new System.Windows.Forms.Label();
			this.boxLanguage = new System.Windows.Forms.GroupBox();
			this.lblCurrency = new System.Windows.Forms.Label();
			this.cmbCurrency = new System.Windows.Forms.ComboBox();
			this.cmbLanguage = new System.Windows.Forms.ComboBox();
			this.boxAppearance = new System.Windows.Forms.GroupBox();
			this.cmbCategoriesStyle = new System.Windows.Forms.ComboBox();
			this.lblCategoriesStyle = new System.Windows.Forms.Label();
			this.cmbToolbarStyle = new System.Windows.Forms.ComboBox();
			this.lblToolbarStyle = new System.Windows.Forms.Label();
			this.cmbMenuStyle = new System.Windows.Forms.ComboBox();
			this.lblMenuStyle = new System.Windows.Forms.Label();
			this.tabBackup = new System.Windows.Forms.TabPage();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblBackupSize = new System.Windows.Forms.Label();
			this.cmdBackupDirectory = new System.Windows.Forms.Button();
			this.lblBackupTip = new System.Windows.Forms.Label();
			this.boxAutomaticBackup = new System.Windows.Forms.GroupBox();
			this.chkAutomaticBackup = new System.Windows.Forms.CheckBox();
			this.imgsTab = new System.Windows.Forms.ImageList(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabs.SuspendLayout();
			this.tabGui.SuspendLayout();
			this.boxBehaviour.SuspendLayout();
			this.boxLanguage.SuspendLayout();
			this.boxAppearance.SuspendLayout();
			this.tabBackup.SuspendLayout();
			this.panel2.SuspendLayout();
			this.boxAutomaticBackup.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabGui);
			this.tabs.Controls.Add(this.tabBackup);
			this.tabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabs.ImageList = this.imgsTab;
			this.tabs.ItemSize = new System.Drawing.Size(88, 26);
			this.tabs.Location = new System.Drawing.Point(8, 8);
			this.tabs.Name = "tabs";
			this.tabs.Padding = new System.Drawing.Point(10, 4);
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(336, 392);
			this.tabs.TabIndex = 0;
			// 
			// tabGui
			// 
			this.tabGui.Controls.Add(this.boxBehaviour);
			this.tabGui.Controls.Add(this.boxLanguage);
			this.tabGui.Controls.Add(this.boxAppearance);
			this.tabGui.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabGui.ImageKey = "gui";
			this.tabGui.Location = new System.Drawing.Point(4, 30);
			this.tabGui.Name = "tabGui";
			this.tabGui.Padding = new System.Windows.Forms.Padding(3);
			this.tabGui.Size = new System.Drawing.Size(328, 358);
			this.tabGui.TabIndex = 0;
			this.tabGui.Text = "Interface (GUI)";
			this.tabGui.UseVisualStyleBackColor = true;
			// 
			// boxBehaviour
			// 
			this.boxBehaviour.Controls.Add(this.optClosingMinimize);
			this.boxBehaviour.Controls.Add(this.optClosingClose);
			this.boxBehaviour.Controls.Add(this.lblClosing);
			this.boxBehaviour.Location = new System.Drawing.Point(16, 248);
			this.boxBehaviour.Name = "boxBehaviour";
			this.boxBehaviour.Size = new System.Drawing.Size(296, 88);
			this.boxBehaviour.TabIndex = 7;
			this.boxBehaviour.TabStop = false;
			this.boxBehaviour.Text = "Behaviour";
			// 
			// optClosingMinimize
			// 
			this.optClosingMinimize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optClosingMinimize.Location = new System.Drawing.Point(32, 56);
			this.optClosingMinimize.Name = "optClosingMinimize";
			this.optClosingMinimize.Size = new System.Drawing.Size(232, 20);
			this.optClosingMinimize.TabIndex = 2;
			this.optClosingMinimize.TabStop = true;
			this.optClosingMinimize.Text = "Minimize to tray";
			this.optClosingMinimize.UseVisualStyleBackColor = true;
			// 
			// optClosingClose
			// 
			this.optClosingClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optClosingClose.Location = new System.Drawing.Point(32, 38);
			this.optClosingClose.Name = "optClosingClose";
			this.optClosingClose.Size = new System.Drawing.Size(216, 22);
			this.optClosingClose.TabIndex = 1;
			this.optClosingClose.TabStop = true;
			this.optClosingClose.Text = "Close Todomoo";
			this.optClosingClose.UseVisualStyleBackColor = true;
			// 
			// lblClosing
			// 
			this.lblClosing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClosing.Location = new System.Drawing.Point(16, 24);
			this.lblClosing.Name = "lblClosing";
			this.lblClosing.Size = new System.Drawing.Size(272, 16);
			this.lblClosing.TabIndex = 0;
			this.lblClosing.Text = "When the main window is closed:";
			// 
			// boxLanguage
			// 
			this.boxLanguage.Controls.Add(this.lblCurrency);
			this.boxLanguage.Controls.Add(this.cmbCurrency);
			this.boxLanguage.Controls.Add(this.cmbLanguage);
			this.boxLanguage.Location = new System.Drawing.Point(16, 144);
			this.boxLanguage.Name = "boxLanguage";
			this.boxLanguage.Size = new System.Drawing.Size(296, 88);
			this.boxLanguage.TabIndex = 6;
			this.boxLanguage.TabStop = false;
			this.boxLanguage.Text = "Language";
			// 
			// lblCurrency
			// 
			this.lblCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrency.Location = new System.Drawing.Point(56, 48);
			this.lblCurrency.Name = "lblCurrency";
			this.lblCurrency.Size = new System.Drawing.Size(120, 16);
			this.lblCurrency.TabIndex = 6;
			this.lblCurrency.Text = "Currency:";
			this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbCurrency
			// 
			this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbCurrency.FormattingEnabled = true;
			this.cmbCurrency.Items.AddRange(new object[] {
									"€ - Euro",
									"$ - Dollar",
									"£ - Pound",
									"¥ - Renminbi",
									"R$ - Real",
									"฿ - Thai Baht"});
			this.cmbCurrency.Location = new System.Drawing.Point(184, 48);
			this.cmbCurrency.Name = "cmbCurrency";
			this.cmbCurrency.Size = new System.Drawing.Size(96, 21);
			this.cmbCurrency.TabIndex = 5;
			// 
			// cmbLanguage
			// 
			this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLanguage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbLanguage.FormattingEnabled = true;
			this.cmbLanguage.Location = new System.Drawing.Point(16, 24);
			this.cmbLanguage.Name = "cmbLanguage";
			this.cmbLanguage.Size = new System.Drawing.Size(264, 21);
			this.cmbLanguage.TabIndex = 4;
			// 
			// boxAppearance
			// 
			this.boxAppearance.Controls.Add(this.cmbCategoriesStyle);
			this.boxAppearance.Controls.Add(this.lblCategoriesStyle);
			this.boxAppearance.Controls.Add(this.cmbToolbarStyle);
			this.boxAppearance.Controls.Add(this.lblToolbarStyle);
			this.boxAppearance.Controls.Add(this.cmbMenuStyle);
			this.boxAppearance.Controls.Add(this.lblMenuStyle);
			this.boxAppearance.Location = new System.Drawing.Point(16, 16);
			this.boxAppearance.Name = "boxAppearance";
			this.boxAppearance.Size = new System.Drawing.Size(296, 112);
			this.boxAppearance.TabIndex = 0;
			this.boxAppearance.TabStop = false;
			this.boxAppearance.Text = "Appearance";
			// 
			// cmbCategoriesStyle
			// 
			this.cmbCategoriesStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategoriesStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbCategoriesStyle.FormattingEnabled = true;
			this.cmbCategoriesStyle.Items.AddRange(new object[] {
									"Standard",
									"Flat"});
			this.cmbCategoriesStyle.Location = new System.Drawing.Point(144, 72);
			this.cmbCategoriesStyle.Name = "cmbCategoriesStyle";
			this.cmbCategoriesStyle.Size = new System.Drawing.Size(136, 21);
			this.cmbCategoriesStyle.TabIndex = 3;
			// 
			// lblCategoriesStyle
			// 
			this.lblCategoriesStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCategoriesStyle.Location = new System.Drawing.Point(16, 72);
			this.lblCategoriesStyle.Name = "lblCategoriesStyle";
			this.lblCategoriesStyle.Size = new System.Drawing.Size(120, 16);
			this.lblCategoriesStyle.TabIndex = 4;
			this.lblCategoriesStyle.Text = "Categories bar:";
			this.lblCategoriesStyle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbToolbarStyle
			// 
			this.cmbToolbarStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbToolbarStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbToolbarStyle.FormattingEnabled = true;
			this.cmbToolbarStyle.Items.AddRange(new object[] {
									"Standard",
									"Flat"});
			this.cmbToolbarStyle.Location = new System.Drawing.Point(144, 48);
			this.cmbToolbarStyle.Name = "cmbToolbarStyle";
			this.cmbToolbarStyle.Size = new System.Drawing.Size(136, 21);
			this.cmbToolbarStyle.TabIndex = 2;
			// 
			// lblToolbarStyle
			// 
			this.lblToolbarStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblToolbarStyle.Location = new System.Drawing.Point(16, 48);
			this.lblToolbarStyle.Name = "lblToolbarStyle";
			this.lblToolbarStyle.Size = new System.Drawing.Size(120, 16);
			this.lblToolbarStyle.TabIndex = 2;
			this.lblToolbarStyle.Text = "Toolbar:";
			this.lblToolbarStyle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbMenuStyle
			// 
			this.cmbMenuStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMenuStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbMenuStyle.FormattingEnabled = true;
			this.cmbMenuStyle.Items.AddRange(new object[] {
									"Standard",
									"Flat"});
			this.cmbMenuStyle.Location = new System.Drawing.Point(144, 24);
			this.cmbMenuStyle.Name = "cmbMenuStyle";
			this.cmbMenuStyle.Size = new System.Drawing.Size(136, 21);
			this.cmbMenuStyle.TabIndex = 1;
			// 
			// lblMenuStyle
			// 
			this.lblMenuStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMenuStyle.Location = new System.Drawing.Point(16, 24);
			this.lblMenuStyle.Name = "lblMenuStyle";
			this.lblMenuStyle.Size = new System.Drawing.Size(120, 16);
			this.lblMenuStyle.TabIndex = 0;
			this.lblMenuStyle.Text = "Menu:";
			this.lblMenuStyle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// tabBackup
			// 
			this.tabBackup.Controls.Add(this.panel6);
			this.tabBackup.Controls.Add(this.panel5);
			this.tabBackup.Controls.Add(this.panel4);
			this.tabBackup.Controls.Add(this.panel2);
			this.tabBackup.Controls.Add(this.lblBackupSize);
			this.tabBackup.Controls.Add(this.cmdBackupDirectory);
			this.tabBackup.Controls.Add(this.lblBackupTip);
			this.tabBackup.Controls.Add(this.boxAutomaticBackup);
			this.tabBackup.ImageKey = "backup";
			this.tabBackup.Location = new System.Drawing.Point(4, 30);
			this.tabBackup.Name = "tabBackup";
			this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
			this.tabBackup.Size = new System.Drawing.Size(328, 358);
			this.tabBackup.TabIndex = 1;
			this.tabBackup.Text = "Backups";
			this.tabBackup.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel6.Location = new System.Drawing.Point(312, 56);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(1, 64);
			this.panel6.TabIndex = 14;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel5.Location = new System.Drawing.Point(16, 56);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(1, 64);
			this.panel5.TabIndex = 13;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel4.Location = new System.Drawing.Point(16, 120);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(296, 1);
			this.panel4.TabIndex = 12;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Location = new System.Drawing.Point(16, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(296, 1);
			this.panel2.TabIndex = 11;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel3.Location = new System.Drawing.Point(0, 64);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(296, 1);
			this.panel3.TabIndex = 12;
			// 
			// lblBackupSize
			// 
			this.lblBackupSize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBackupSize.Location = new System.Drawing.Point(248, 16);
			this.lblBackupSize.Name = "lblBackupSize";
			this.lblBackupSize.Size = new System.Drawing.Size(72, 24);
			this.lblBackupSize.TabIndex = 10;
			this.lblBackupSize.Text = "0 MB";
			this.lblBackupSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmdBackupDirectory
			// 
			this.cmdBackupDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdBackupDirectory.Image = ((System.Drawing.Image)(resources.GetObject("cmdBackupDirectory.Image")));
			this.cmdBackupDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdBackupDirectory.Location = new System.Drawing.Point(16, 16);
			this.cmdBackupDirectory.Name = "cmdBackupDirectory";
			this.cmdBackupDirectory.Size = new System.Drawing.Size(224, 24);
			this.cmdBackupDirectory.TabIndex = 5;
			this.cmdBackupDirectory.Text = " Open backup directory";
			this.cmdBackupDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdBackupDirectory.UseVisualStyleBackColor = true;
			this.cmdBackupDirectory.Click += new System.EventHandler(this.CmdBackupDirectoryClick);
			// 
			// lblBackupTip
			// 
			this.lblBackupTip.BackColor = System.Drawing.SystemColors.Info;
			this.lblBackupTip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBackupTip.Location = new System.Drawing.Point(16, 56);
			this.lblBackupTip.Name = "lblBackupTip";
			this.lblBackupTip.Padding = new System.Windows.Forms.Padding(3);
			this.lblBackupTip.Size = new System.Drawing.Size(296, 64);
			this.lblBackupTip.TabIndex = 8;
			this.lblBackupTip.Text = "If you want to restore a backup, open the backup direcory, close Todomoo and then" +
			" replace the \"db.sqlite\" file (that is in the Todomoo executable directory) with" +
			" a backupped one. ";
			this.lblBackupTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// boxAutomaticBackup
			// 
			this.boxAutomaticBackup.Controls.Add(this.chkAutomaticBackup);
			this.boxAutomaticBackup.Location = new System.Drawing.Point(16, 136);
			this.boxAutomaticBackup.Name = "boxAutomaticBackup";
			this.boxAutomaticBackup.Size = new System.Drawing.Size(296, 64);
			this.boxAutomaticBackup.TabIndex = 7;
			this.boxAutomaticBackup.TabStop = false;
			this.boxAutomaticBackup.Text = "Automatic backups";
			// 
			// chkAutomaticBackup
			// 
			this.chkAutomaticBackup.Checked = true;
			this.chkAutomaticBackup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutomaticBackup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAutomaticBackup.Location = new System.Drawing.Point(16, 16);
			this.chkAutomaticBackup.Name = "chkAutomaticBackup";
			this.chkAutomaticBackup.Size = new System.Drawing.Size(264, 40);
			this.chkAutomaticBackup.TabIndex = 6;
			this.chkAutomaticBackup.Text = "Backup database when Todomoo is closed";
			this.chkAutomaticBackup.UseVisualStyleBackColor = true;
			// 
			// imgsTab
			// 
			this.imgsTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgsTab.ImageStream")));
			this.imgsTab.TransparentColor = System.Drawing.Color.Transparent;
			this.imgsTab.Images.SetKeyName(0, "gui");
			this.imgsTab.Images.SetKeyName(1, "backup");
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(248, 416);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 24);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOk
			// 
			this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOk.Location = new System.Drawing.Point(104, 416);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(136, 24);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = " Ok";
			this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Location = new System.Drawing.Point(12, 408);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(324, 1);
			this.panel1.TabIndex = 7;
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(353, 448);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tabs);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.tabs.ResumeLayout(false);
			this.tabGui.ResumeLayout(false);
			this.boxBehaviour.ResumeLayout(false);
			this.boxLanguage.ResumeLayout(false);
			this.boxAppearance.ResumeLayout(false);
			this.tabBackup.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.boxAutomaticBackup.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox boxBehaviour;
		private System.Windows.Forms.Label lblClosing;
		private System.Windows.Forms.RadioButton optClosingMinimize;
		private System.Windows.Forms.RadioButton optClosingClose;
		private System.Windows.Forms.ComboBox cmbCurrency;
		private System.Windows.Forms.Label lblCurrency;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lblBackupSize;
		private System.Windows.Forms.Button cmdBackupDirectory;
		private System.Windows.Forms.GroupBox boxAutomaticBackup;
		private System.Windows.Forms.CheckBox chkAutomaticBackup;
		private System.Windows.Forms.Label lblBackupTip;
		private System.Windows.Forms.TabPage tabBackup;
		private System.Windows.Forms.Label lblMenuStyle;
		private System.Windows.Forms.ComboBox cmbMenuStyle;
		private System.Windows.Forms.Label lblToolbarStyle;
		private System.Windows.Forms.ComboBox cmbToolbarStyle;
		private System.Windows.Forms.Label lblCategoriesStyle;
		private System.Windows.Forms.ComboBox cmbCategoriesStyle;
		private System.Windows.Forms.ComboBox cmbLanguage;
		private System.Windows.Forms.GroupBox boxLanguage;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ImageList imgsTab;
		private System.Windows.Forms.GroupBox boxAppearance;
		private System.Windows.Forms.TabPage tabGui;
		private System.Windows.Forms.TabControl tabs;
	}
}
