/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 */
namespace Todomoo
{
	partial class TaskForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.lblPriority = new System.Windows.Forms.Label();
			this.cmbPriority = new System.Windows.Forms.ImageCombo();
			this.imgPriority = new System.Windows.Forms.ImageList(this.components);
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnChooseColour = new System.Windows.Forms.Button();
			this.lblColour = new System.Windows.Forms.Label();
			this.cmbColour = new System.Windows.Forms.ImageCombo();
			this.btnAddCategory = new System.Windows.Forms.Button();
			this.lblCategory = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblSubTaskOf = new System.Windows.Forms.Label();
			this.cmbCategory = new System.Windows.Forms.ImageCombo();
			this.panParent = new System.Windows.Forms.Panel();
			this.lblParentName = new System.Windows.Forms.Label();
			this.boxParentIcon = new System.Windows.Forms.PictureBox();
			this.tabDatesTime = new System.Windows.Forms.TabPage();
			this.chkUseTimer = new System.Windows.Forms.CheckBox();
			this.boxUseTimer = new System.Windows.Forms.GroupBox();
			this.btnSumTimers = new System.Windows.Forms.Button();
			this.numTimerS = new System.Windows.Forms.NumericUpDown();
			this.lblTimerS = new System.Windows.Forms.Label();
			this.numTimerH = new System.Windows.Forms.NumericUpDown();
			this.numTimerM = new System.Windows.Forms.NumericUpDown();
			this.btnTimerReset = new System.Windows.Forms.Button();
			this.lblTimerM = new System.Windows.Forms.Label();
			this.lblTimerH = new System.Windows.Forms.Label();
			this.lblTimer = new System.Windows.Forms.Label();
			this.panCannotEditTimer = new System.Windows.Forms.Panel();
			this.lblCannotEditTimer = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.chkCompletedNot = new System.Windows.Forms.CheckBox();
			this.dtCompleted = new System.Windows.Forms.DateTimePicker();
			this.lblCompleted = new System.Windows.Forms.Label();
			this.chkDueDateNot = new System.Windows.Forms.CheckBox();
			this.dtDueDate = new System.Windows.Forms.DateTimePicker();
			this.dtCreationDate = new System.Windows.Forms.DateTimePicker();
			this.lblCreationDate = new System.Windows.Forms.Label();
			this.lblDueDate = new System.Windows.Forms.Label();
			this.tabPayment = new System.Windows.Forms.TabPage();
			this.chkPerHour = new System.Windows.Forms.CheckBox();
			this.btnSumPrice = new System.Windows.Forms.Button();
			this.txtPaymentNote = new System.Windows.Forms.TextBox();
			this.lblPaymentNote = new System.Windows.Forms.Label();
			this.lblPayment = new System.Windows.Forms.Label();
			this.cmbPaymentType = new System.Windows.Forms.ComboBox();
			this.chkPaidNot = new System.Windows.Forms.CheckBox();
			this.dtPaid = new System.Windows.Forms.DateTimePicker();
			this.lblPaid = new System.Windows.Forms.Label();
			this.chkPriceNot = new System.Windows.Forms.CheckBox();
			this.lblCurrency = new System.Windows.Forms.Label();
			this.lblPrice = new System.Windows.Forms.Label();
			this.numPrice = new System.Windows.Forms.NumericUpDown();
			this.tabNotes = new System.Windows.Forms.TabPage();
			this.btnNewNote = new System.Windows.Forms.Button();
			this.chkWordWrap = new System.Windows.Forms.CheckBox();
			this.panAccordion = new System.Windows.Forms.Panel();
			this.scrollAccordion = new System.Windows.Forms.VScrollBar();
			this.shapeAccordionRight = new System.Windows.Forms.Panel();
			this.shapeAccordionLeft = new System.Windows.Forms.Panel();
			this.shapeAccordionBottom = new System.Windows.Forms.Panel();
			this.shapeAccordionTop = new System.Windows.Forms.Panel();
			this.btnDeleteNote = new System.Windows.Forms.Button();
			this.chkMonospace = new System.Windows.Forms.CheckBox();
			this.imgsTab = new System.Windows.Forms.ImageList(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.shapeLine = new System.Windows.Forms.Panel();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.imgNote = new System.Windows.Forms.ImageList(this.components);
			this.tabs.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.panParent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.boxParentIcon)).BeginInit();
			this.tabDatesTime.SuspendLayout();
			this.boxUseTimer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTimerS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTimerH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTimerM)).BeginInit();
			this.panCannotEditTimer.SuspendLayout();
			this.tabPayment.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
			this.tabNotes.SuspendLayout();
			this.panAccordion.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabGeneral);
			this.tabs.Controls.Add(this.tabDatesTime);
			this.tabs.Controls.Add(this.tabPayment);
			this.tabs.Controls.Add(this.tabNotes);
			this.tabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabs.ImageList = this.imgsTab;
			this.tabs.ItemSize = new System.Drawing.Size(88, 26);
			this.tabs.Location = new System.Drawing.Point(8, 8);
			this.tabs.Multiline = true;
			this.tabs.Name = "tabs";
			this.tabs.Padding = new System.Drawing.Point(8, 4);
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(552, 336);
			this.tabs.TabIndex = 1;
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.TabsSelectedIndexChanged);
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.lblPriority);
			this.tabGeneral.Controls.Add(this.cmbPriority);
			this.tabGeneral.Controls.Add(this.txtDescription);
			this.tabGeneral.Controls.Add(this.txtName);
			this.tabGeneral.Controls.Add(this.btnChooseColour);
			this.tabGeneral.Controls.Add(this.lblColour);
			this.tabGeneral.Controls.Add(this.cmbColour);
			this.tabGeneral.Controls.Add(this.btnAddCategory);
			this.tabGeneral.Controls.Add(this.lblCategory);
			this.tabGeneral.Controls.Add(this.lblName);
			this.tabGeneral.Controls.Add(this.lblDescription);
			this.tabGeneral.Controls.Add(this.lblSubTaskOf);
			this.tabGeneral.Controls.Add(this.cmbCategory);
			this.tabGeneral.Controls.Add(this.panParent);
			this.tabGeneral.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabGeneral.ImageKey = "task";
			this.tabGeneral.Location = new System.Drawing.Point(4, 30);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(544, 302);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "Task";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// lblPriority
			// 
			this.lblPriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPriority.Location = new System.Drawing.Point(24, 264);
			this.lblPriority.Name = "lblPriority";
			this.lblPriority.Size = new System.Drawing.Size(104, 16);
			this.lblPriority.TabIndex = 14;
			this.lblPriority.Text = "Priority:";
			this.lblPriority.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbPriority
			// 
			this.cmbPriority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbPriority.FormattingEnabled = true;
			this.cmbPriority.ImageList = this.imgPriority;
			this.cmbPriority.Location = new System.Drawing.Point(136, 264);
			this.cmbPriority.Name = "cmbPriority";
			this.cmbPriority.Size = new System.Drawing.Size(224, 22);
			this.cmbPriority.TabIndex = 8;
			this.cmbPriority.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.cmbPriority.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// imgPriority
			// 
			this.imgPriority.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPriority.ImageStream")));
			this.imgPriority.TransparentColor = System.Drawing.Color.Transparent;
			this.imgPriority.Images.SetKeyName(0, "Priority 1b.png");
			this.imgPriority.Images.SetKeyName(1, "Priority 2b.png");
			this.imgPriority.Images.SetKeyName(2, "Priority 3b.png");
			// 
			// txtDescription
			// 
			this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescription.Location = new System.Drawing.Point(136, 80);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescription.Size = new System.Drawing.Size(392, 142);
			this.txtDescription.TabIndex = 5;
			// 
			// txtName
			// 
			this.txtName.AcceptsReturn = true;
			this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(136, 48);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(320, 21);
			this.txtName.TabIndex = 4;
			this.txtName.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.txtName.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// btnChooseColour
			// 
			this.btnChooseColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChooseColour.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseColour.Image")));
			this.btnChooseColour.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChooseColour.Location = new System.Drawing.Point(368, 231);
			this.btnChooseColour.Name = "btnChooseColour";
			this.btnChooseColour.Size = new System.Drawing.Size(88, 24);
			this.btnChooseColour.TabIndex = 7;
			this.btnChooseColour.Text = " More";
			this.btnChooseColour.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnChooseColour.UseVisualStyleBackColor = true;
			this.btnChooseColour.Click += new System.EventHandler(this.BtnChooseColourClick);
			// 
			// lblColour
			// 
			this.lblColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblColour.Location = new System.Drawing.Point(24, 232);
			this.lblColour.Name = "lblColour";
			this.lblColour.Size = new System.Drawing.Size(104, 16);
			this.lblColour.TabIndex = 9;
			this.lblColour.Text = "Colour:";
			this.lblColour.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbColour
			// 
			this.cmbColour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbColour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbColour.FormattingEnabled = true;
			this.cmbColour.Location = new System.Drawing.Point(136, 232);
			this.cmbColour.Name = "cmbColour";
			this.cmbColour.Size = new System.Drawing.Size(224, 22);
			this.cmbColour.TabIndex = 6;
			this.cmbColour.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.cmbColour.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// btnAddCategory
			// 
			this.btnAddCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCategory.Image")));
			this.btnAddCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAddCategory.Location = new System.Drawing.Point(368, 15);
			this.btnAddCategory.Name = "btnAddCategory";
			this.btnAddCategory.Size = new System.Drawing.Size(88, 24);
			this.btnAddCategory.TabIndex = 3;
			this.btnAddCategory.Text = " New";
			this.btnAddCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAddCategory.UseVisualStyleBackColor = true;
			this.btnAddCategory.Click += new System.EventHandler(this.BtnAddCategoryClick);
			// 
			// lblCategory
			// 
			this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCategory.Location = new System.Drawing.Point(16, 16);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(112, 16);
			this.lblCategory.TabIndex = 6;
			this.lblCategory.Text = "Category:";
			this.lblCategory.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblName
			// 
			this.lblName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(16, 48);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(112, 16);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name:";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblDescription
			// 
			this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription.Location = new System.Drawing.Point(16, 80);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(112, 16);
			this.lblDescription.TabIndex = 0;
			this.lblDescription.Text = "Description:";
			this.lblDescription.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblSubTaskOf
			// 
			this.lblSubTaskOf.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSubTaskOf.Location = new System.Drawing.Point(16, 16);
			this.lblSubTaskOf.Name = "lblSubTaskOf";
			this.lblSubTaskOf.Size = new System.Drawing.Size(112, 16);
			this.lblSubTaskOf.TabIndex = 16;
			this.lblSubTaskOf.Text = "Sub-task of:";
			this.lblSubTaskOf.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.lblSubTaskOf.Visible = false;
			// 
			// cmbCategory
			// 
			this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new System.Drawing.Point(136, 16);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(224, 22);
			this.cmbCategory.TabIndex = 2;
			this.cmbCategory.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.cmbCategory.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// panParent
			// 
			this.panParent.Controls.Add(this.lblParentName);
			this.panParent.Controls.Add(this.boxParentIcon);
			this.panParent.Location = new System.Drawing.Point(136, 13);
			this.panParent.Name = "panParent";
			this.panParent.Size = new System.Drawing.Size(320, 24);
			this.panParent.TabIndex = 17;
			// 
			// lblParentName
			// 
			this.lblParentName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblParentName.Location = new System.Drawing.Point(20, 4);
			this.lblParentName.Name = "lblParentName";
			this.lblParentName.Size = new System.Drawing.Size(292, 16);
			this.lblParentName.TabIndex = 1;
			this.lblParentName.Text = "Parent name";
			this.lblParentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// boxParentIcon
			// 
			this.boxParentIcon.Location = new System.Drawing.Point(2, 4);
			this.boxParentIcon.Name = "boxParentIcon";
			this.boxParentIcon.Size = new System.Drawing.Size(16, 16);
			this.boxParentIcon.TabIndex = 0;
			this.boxParentIcon.TabStop = false;
			// 
			// tabDatesTime
			// 
			this.tabDatesTime.Controls.Add(this.chkUseTimer);
			this.tabDatesTime.Controls.Add(this.boxUseTimer);
			this.tabDatesTime.Controls.Add(this.panel2);
			this.tabDatesTime.Controls.Add(this.chkCompletedNot);
			this.tabDatesTime.Controls.Add(this.dtCompleted);
			this.tabDatesTime.Controls.Add(this.lblCompleted);
			this.tabDatesTime.Controls.Add(this.chkDueDateNot);
			this.tabDatesTime.Controls.Add(this.dtDueDate);
			this.tabDatesTime.Controls.Add(this.dtCreationDate);
			this.tabDatesTime.Controls.Add(this.lblCreationDate);
			this.tabDatesTime.Controls.Add(this.lblDueDate);
			this.tabDatesTime.ImageKey = "datestime";
			this.tabDatesTime.Location = new System.Drawing.Point(4, 30);
			this.tabDatesTime.Name = "tabDatesTime";
			this.tabDatesTime.Padding = new System.Windows.Forms.Padding(3);
			this.tabDatesTime.Size = new System.Drawing.Size(544, 302);
			this.tabDatesTime.TabIndex = 1;
			this.tabDatesTime.Text = "Dates and time";
			this.tabDatesTime.UseVisualStyleBackColor = true;
			// 
			// chkUseTimer
			// 
			this.chkUseTimer.AutoSize = true;
			this.chkUseTimer.Location = new System.Drawing.Point(24, 152);
			this.chkUseTimer.Name = "chkUseTimer";
			this.chkUseTimer.Size = new System.Drawing.Size(162, 17);
			this.chkUseTimer.TabIndex = 14;
			this.chkUseTimer.Text = "Use a timer for this task";
			this.chkUseTimer.UseVisualStyleBackColor = true;
			this.chkUseTimer.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.chkUseTimer.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			this.chkUseTimer.CheckedChanged += new System.EventHandler(this.ChkUseTimerCheckedChanged);
			// 
			// boxUseTimer
			// 
			this.boxUseTimer.Controls.Add(this.btnSumTimers);
			this.boxUseTimer.Controls.Add(this.numTimerS);
			this.boxUseTimer.Controls.Add(this.lblTimerS);
			this.boxUseTimer.Controls.Add(this.numTimerH);
			this.boxUseTimer.Controls.Add(this.numTimerM);
			this.boxUseTimer.Controls.Add(this.btnTimerReset);
			this.boxUseTimer.Controls.Add(this.lblTimerM);
			this.boxUseTimer.Controls.Add(this.lblTimerH);
			this.boxUseTimer.Controls.Add(this.lblTimer);
			this.boxUseTimer.Controls.Add(this.panCannotEditTimer);
			this.boxUseTimer.Location = new System.Drawing.Point(16, 152);
			this.boxUseTimer.Name = "boxUseTimer";
			this.boxUseTimer.Size = new System.Drawing.Size(512, 104);
			this.boxUseTimer.TabIndex = 24;
			this.boxUseTimer.TabStop = false;
			// 
			// btnSumTimers
			// 
			this.btnSumTimers.Enabled = false;
			this.btnSumTimers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSumTimers.Image = ((System.Drawing.Image)(resources.GetObject("btnSumTimers.Image")));
			this.btnSumTimers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSumTimers.Location = new System.Drawing.Point(232, 64);
			this.btnSumTimers.Name = "btnSumTimers";
			this.btnSumTimers.Size = new System.Drawing.Size(176, 24);
			this.btnSumTimers.TabIndex = 43;
			this.btnSumTimers.Text = "Sum subtasks";
			this.btnSumTimers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSumTimers.UseVisualStyleBackColor = true;
			this.btnSumTimers.Click += new System.EventHandler(this.BtnSumTimersClick);
			// 
			// numTimerS
			// 
			this.numTimerS.Enabled = false;
			this.numTimerS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTimerS.Location = new System.Drawing.Point(264, 32);
			this.numTimerS.Maximum = new decimal(new int[] {
									59,
									0,
									0,
									0});
			this.numTimerS.Name = "numTimerS";
			this.numTimerS.Size = new System.Drawing.Size(40, 21);
			this.numTimerS.TabIndex = 29;
			this.numTimerS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTimerS.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.numTimerS.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// lblTimerS
			// 
			this.lblTimerS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimerS.Location = new System.Drawing.Point(304, 30);
			this.lblTimerS.Name = "lblTimerS";
			this.lblTimerS.Size = new System.Drawing.Size(16, 17);
			this.lblTimerS.TabIndex = 30;
			this.lblTimerS.Text = "s";
			this.lblTimerS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// numTimerH
			// 
			this.numTimerH.Enabled = false;
			this.numTimerH.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTimerH.Location = new System.Drawing.Point(120, 32);
			this.numTimerH.Maximum = new decimal(new int[] {
									99999,
									0,
									0,
									0});
			this.numTimerH.Name = "numTimerH";
			this.numTimerH.Size = new System.Drawing.Size(56, 21);
			this.numTimerH.TabIndex = 15;
			this.numTimerH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTimerH.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.numTimerH.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// numTimerM
			// 
			this.numTimerM.Enabled = false;
			this.numTimerM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numTimerM.Location = new System.Drawing.Point(200, 32);
			this.numTimerM.Maximum = new decimal(new int[] {
									59,
									0,
									0,
									0});
			this.numTimerM.Name = "numTimerM";
			this.numTimerM.Size = new System.Drawing.Size(40, 21);
			this.numTimerM.TabIndex = 16;
			this.numTimerM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numTimerM.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.numTimerM.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// btnTimerReset
			// 
			this.btnTimerReset.Enabled = false;
			this.btnTimerReset.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTimerReset.Image = ((System.Drawing.Image)(resources.GetObject("btnTimerReset.Image")));
			this.btnTimerReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTimerReset.Location = new System.Drawing.Point(120, 64);
			this.btnTimerReset.Name = "btnTimerReset";
			this.btnTimerReset.Size = new System.Drawing.Size(104, 24);
			this.btnTimerReset.TabIndex = 17;
			this.btnTimerReset.Text = " Reset";
			this.btnTimerReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnTimerReset.UseVisualStyleBackColor = true;
			this.btnTimerReset.Click += new System.EventHandler(this.BtnTimerResetClick);
			// 
			// lblTimerM
			// 
			this.lblTimerM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimerM.Location = new System.Drawing.Point(240, 30);
			this.lblTimerM.Name = "lblTimerM";
			this.lblTimerM.Size = new System.Drawing.Size(16, 17);
			this.lblTimerM.TabIndex = 28;
			this.lblTimerM.Text = "m";
			this.lblTimerM.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblTimerH
			// 
			this.lblTimerH.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimerH.Location = new System.Drawing.Point(176, 31);
			this.lblTimerH.Name = "lblTimerH";
			this.lblTimerH.Size = new System.Drawing.Size(16, 16);
			this.lblTimerH.TabIndex = 27;
			this.lblTimerH.Text = "h";
			this.lblTimerH.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblTimer
			// 
			this.lblTimer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimer.Location = new System.Drawing.Point(16, 31);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new System.Drawing.Size(96, 16);
			this.lblTimer.TabIndex = 24;
			this.lblTimer.Text = "Timer:";
			this.lblTimer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panCannotEditTimer
			// 
			this.panCannotEditTimer.BackColor = System.Drawing.SystemColors.Info;
			this.panCannotEditTimer.Controls.Add(this.lblCannotEditTimer);
			this.panCannotEditTimer.Controls.Add(this.panel11);
			this.panCannotEditTimer.Controls.Add(this.panel10);
			this.panCannotEditTimer.Controls.Add(this.panel9);
			this.panCannotEditTimer.Controls.Add(this.panel8);
			this.panCannotEditTimer.Location = new System.Drawing.Point(16, 32);
			this.panCannotEditTimer.Name = "panCannotEditTimer";
			this.panCannotEditTimer.Size = new System.Drawing.Size(480, 24);
			this.panCannotEditTimer.TabIndex = 25;
			this.panCannotEditTimer.Visible = false;
			// 
			// lblCannotEditTimer
			// 
			this.lblCannotEditTimer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCannotEditTimer.Location = new System.Drawing.Point(8, 5);
			this.lblCannotEditTimer.Name = "lblCannotEditTimer";
			this.lblCannotEditTimer.Size = new System.Drawing.Size(460, 16);
			this.lblCannotEditTimer.TabIndex = 4;
			this.lblCannotEditTimer.Text = "Cannot edit timer now";
			// 
			// panel11
			// 
			this.panel11.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel11.Location = new System.Drawing.Point(479, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(8, 24);
			this.panel11.TabIndex = 3;
			// 
			// panel10
			// 
			this.panel10.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel10.Location = new System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(1, 24);
			this.panel10.TabIndex = 2;
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel9.Location = new System.Drawing.Point(0, 23);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(480, 8);
			this.panel9.TabIndex = 1;
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(480, 1);
			this.panel8.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Location = new System.Drawing.Point(16, 128);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(512, 1);
			this.panel2.TabIndex = 15;
			// 
			// chkCompletedNot
			// 
			this.chkCompletedNot.Checked = true;
			this.chkCompletedNot.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCompletedNot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkCompletedNot.Location = new System.Drawing.Point(328, 80);
			this.chkCompletedNot.Name = "chkCompletedNot";
			this.chkCompletedNot.Size = new System.Drawing.Size(152, 24);
			this.chkCompletedNot.TabIndex = 13;
			this.chkCompletedNot.Text = "Not completed";
			this.chkCompletedNot.UseVisualStyleBackColor = true;
			this.chkCompletedNot.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.chkCompletedNot.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			this.chkCompletedNot.CheckedChanged += new System.EventHandler(this.ChkCompletedNotCheckedChanged);
			// 
			// dtCompleted
			// 
			this.dtCompleted.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtCompleted.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dtCompleted.CalendarTitleForeColor = System.Drawing.Color.Black;
			this.dtCompleted.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtCompleted.Enabled = false;
			this.dtCompleted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtCompleted.Location = new System.Drawing.Point(136, 80);
			this.dtCompleted.Name = "dtCompleted";
			this.dtCompleted.Size = new System.Drawing.Size(184, 21);
			this.dtCompleted.TabIndex = 12;
			this.dtCompleted.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.dtCompleted.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// lblCompleted
			// 
			this.lblCompleted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCompleted.Location = new System.Drawing.Point(16, 80);
			this.lblCompleted.Name = "lblCompleted";
			this.lblCompleted.Size = new System.Drawing.Size(112, 16);
			this.lblCompleted.TabIndex = 12;
			this.lblCompleted.Text = "Completed:";
			this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// chkDueDateNot
			// 
			this.chkDueDateNot.Checked = true;
			this.chkDueDateNot.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDueDateNot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkDueDateNot.Location = new System.Drawing.Point(328, 48);
			this.chkDueDateNot.Name = "chkDueDateNot";
			this.chkDueDateNot.Size = new System.Drawing.Size(160, 24);
			this.chkDueDateNot.TabIndex = 11;
			this.chkDueDateNot.Text = "None";
			this.chkDueDateNot.UseVisualStyleBackColor = true;
			this.chkDueDateNot.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.chkDueDateNot.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			this.chkDueDateNot.CheckedChanged += new System.EventHandler(this.ChkDueDateNotCheckedChanged);
			// 
			// dtDueDate
			// 
			this.dtDueDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtDueDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dtDueDate.CalendarTitleForeColor = System.Drawing.Color.Black;
			this.dtDueDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtDueDate.Enabled = false;
			this.dtDueDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtDueDate.Location = new System.Drawing.Point(136, 48);
			this.dtDueDate.Name = "dtDueDate";
			this.dtDueDate.Size = new System.Drawing.Size(184, 21);
			this.dtDueDate.TabIndex = 10;
			this.dtDueDate.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.dtDueDate.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// dtCreationDate
			// 
			this.dtCreationDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtCreationDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dtCreationDate.CalendarTitleForeColor = System.Drawing.Color.Black;
			this.dtCreationDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtCreationDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtCreationDate.Location = new System.Drawing.Point(136, 16);
			this.dtCreationDate.Name = "dtCreationDate";
			this.dtCreationDate.Size = new System.Drawing.Size(184, 21);
			this.dtCreationDate.TabIndex = 9;
			this.dtCreationDate.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.dtCreationDate.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// lblCreationDate
			// 
			this.lblCreationDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCreationDate.Location = new System.Drawing.Point(16, 16);
			this.lblCreationDate.Name = "lblCreationDate";
			this.lblCreationDate.Size = new System.Drawing.Size(112, 16);
			this.lblCreationDate.TabIndex = 8;
			this.lblCreationDate.Text = "Creation date:";
			this.lblCreationDate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblDueDate
			// 
			this.lblDueDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDueDate.Location = new System.Drawing.Point(16, 48);
			this.lblDueDate.Name = "lblDueDate";
			this.lblDueDate.Size = new System.Drawing.Size(112, 16);
			this.lblDueDate.TabIndex = 7;
			this.lblDueDate.Text = "Due date:";
			this.lblDueDate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// tabPayment
			// 
			this.tabPayment.Controls.Add(this.chkPerHour);
			this.tabPayment.Controls.Add(this.btnSumPrice);
			this.tabPayment.Controls.Add(this.txtPaymentNote);
			this.tabPayment.Controls.Add(this.lblPaymentNote);
			this.tabPayment.Controls.Add(this.lblPayment);
			this.tabPayment.Controls.Add(this.cmbPaymentType);
			this.tabPayment.Controls.Add(this.chkPaidNot);
			this.tabPayment.Controls.Add(this.dtPaid);
			this.tabPayment.Controls.Add(this.lblPaid);
			this.tabPayment.Controls.Add(this.chkPriceNot);
			this.tabPayment.Controls.Add(this.lblCurrency);
			this.tabPayment.Controls.Add(this.lblPrice);
			this.tabPayment.Controls.Add(this.numPrice);
			this.tabPayment.ImageKey = "payment";
			this.tabPayment.Location = new System.Drawing.Point(4, 30);
			this.tabPayment.Name = "tabPayment";
			this.tabPayment.Padding = new System.Windows.Forms.Padding(3);
			this.tabPayment.Size = new System.Drawing.Size(544, 302);
			this.tabPayment.TabIndex = 2;
			this.tabPayment.Text = "Payment";
			this.tabPayment.UseVisualStyleBackColor = true;
			// 
			// chkPerHour
			// 
			this.chkPerHour.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPerHour.Location = new System.Drawing.Point(240, 16);
			this.chkPerHour.Name = "chkPerHour";
			this.chkPerHour.Size = new System.Drawing.Size(80, 24);
			this.chkPerHour.TabIndex = 43;
			this.chkPerHour.Text = "per hour";
			this.chkPerHour.UseVisualStyleBackColor = true;
			this.chkPerHour.CheckedChanged += new System.EventHandler(this.ChkPerHourCheckedChanged);
			// 
			// btnSumPrice
			// 
			this.btnSumPrice.Enabled = false;
			this.btnSumPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSumPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnSumPrice.Image")));
			this.btnSumPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSumPrice.Location = new System.Drawing.Point(392, 16);
			this.btnSumPrice.Name = "btnSumPrice";
			this.btnSumPrice.Size = new System.Drawing.Size(136, 23);
			this.btnSumPrice.TabIndex = 42;
			this.btnSumPrice.Text = "Sum subtasks";
			this.btnSumPrice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSumPrice.UseVisualStyleBackColor = true;
			this.btnSumPrice.Click += new System.EventHandler(this.BtnSumPriceClick);
			// 
			// txtPaymentNote
			// 
			this.txtPaymentNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPaymentNote.Location = new System.Drawing.Point(136, 112);
			this.txtPaymentNote.Multiline = true;
			this.txtPaymentNote.Name = "txtPaymentNote";
			this.txtPaymentNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtPaymentNote.Size = new System.Drawing.Size(392, 142);
			this.txtPaymentNote.TabIndex = 23;
			// 
			// lblPaymentNote
			// 
			this.lblPaymentNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPaymentNote.Location = new System.Drawing.Point(0, 112);
			this.lblPaymentNote.Name = "lblPaymentNote";
			this.lblPaymentNote.Size = new System.Drawing.Size(128, 16);
			this.lblPaymentNote.TabIndex = 41;
			this.lblPaymentNote.Text = "Payment note:";
			this.lblPaymentNote.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblPayment
			// 
			this.lblPayment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPayment.Location = new System.Drawing.Point(0, 80);
			this.lblPayment.Name = "lblPayment";
			this.lblPayment.Size = new System.Drawing.Size(128, 16);
			this.lblPayment.TabIndex = 40;
			this.lblPayment.Text = "Payment type:";
			this.lblPayment.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cmbPaymentType
			// 
			this.cmbPaymentType.Enabled = false;
			this.cmbPaymentType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbPaymentType.FormattingEnabled = true;
			this.cmbPaymentType.Location = new System.Drawing.Point(136, 80);
			this.cmbPaymentType.Name = "cmbPaymentType";
			this.cmbPaymentType.Size = new System.Drawing.Size(176, 21);
			this.cmbPaymentType.TabIndex = 22;
			this.cmbPaymentType.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.cmbPaymentType.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// chkPaidNot
			// 
			this.chkPaidNot.Checked = true;
			this.chkPaidNot.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPaidNot.Enabled = false;
			this.chkPaidNot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPaidNot.Location = new System.Drawing.Point(320, 48);
			this.chkPaidNot.Name = "chkPaidNot";
			this.chkPaidNot.Size = new System.Drawing.Size(160, 24);
			this.chkPaidNot.TabIndex = 21;
			this.chkPaidNot.Text = "Not paid";
			this.chkPaidNot.UseVisualStyleBackColor = true;
			this.chkPaidNot.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.chkPaidNot.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			this.chkPaidNot.CheckedChanged += new System.EventHandler(this.ChkPaidNotCheckedChanged);
			// 
			// dtPaid
			// 
			this.dtPaid.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtPaid.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dtPaid.CalendarTitleForeColor = System.Drawing.Color.Black;
			this.dtPaid.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtPaid.Enabled = false;
			this.dtPaid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtPaid.Location = new System.Drawing.Point(136, 48);
			this.dtPaid.Name = "dtPaid";
			this.dtPaid.Size = new System.Drawing.Size(176, 21);
			this.dtPaid.TabIndex = 20;
			this.dtPaid.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.dtPaid.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// lblPaid
			// 
			this.lblPaid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPaid.Location = new System.Drawing.Point(16, 48);
			this.lblPaid.Name = "lblPaid";
			this.lblPaid.Size = new System.Drawing.Size(112, 16);
			this.lblPaid.TabIndex = 36;
			this.lblPaid.Text = "Paid:";
			this.lblPaid.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// chkPriceNot
			// 
			this.chkPriceNot.Checked = true;
			this.chkPriceNot.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPriceNot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPriceNot.Location = new System.Drawing.Point(320, 16);
			this.chkPriceNot.Name = "chkPriceNot";
			this.chkPriceNot.Size = new System.Drawing.Size(72, 24);
			this.chkPriceNot.TabIndex = 19;
			this.chkPriceNot.Text = "None";
			this.chkPriceNot.UseVisualStyleBackColor = true;
			this.chkPriceNot.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.chkPriceNot.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			this.chkPriceNot.CheckedChanged += new System.EventHandler(this.ChkPriceNotCheckedChanged);
			// 
			// lblCurrency
			// 
			this.lblCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrency.Location = new System.Drawing.Point(216, 16);
			this.lblCurrency.Name = "lblCurrency";
			this.lblCurrency.Size = new System.Drawing.Size(32, 16);
			this.lblCurrency.TabIndex = 34;
			this.lblCurrency.Text = "€";
			this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblPrice
			// 
			this.lblPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrice.Location = new System.Drawing.Point(16, 16);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(112, 16);
			this.lblPrice.TabIndex = 32;
			this.lblPrice.Text = "Price:";
			this.lblPrice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// numPrice
			// 
			this.numPrice.DecimalPlaces = 2;
			this.numPrice.Enabled = false;
			this.numPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numPrice.Location = new System.Drawing.Point(136, 16);
			this.numPrice.Maximum = new decimal(new int[] {
									99999,
									0,
									0,
									0});
			this.numPrice.Name = "numPrice";
			this.numPrice.Size = new System.Drawing.Size(80, 21);
			this.numPrice.TabIndex = 18;
			this.numPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numPrice.Leave += new System.EventHandler(this.TxtSimpleFieldLeave);
			this.numPrice.Enter += new System.EventHandler(this.TxtSimpleFieldEnter);
			// 
			// tabNotes
			// 
			this.tabNotes.Controls.Add(this.btnNewNote);
			this.tabNotes.Controls.Add(this.chkWordWrap);
			this.tabNotes.Controls.Add(this.panAccordion);
			this.tabNotes.Controls.Add(this.shapeAccordionRight);
			this.tabNotes.Controls.Add(this.shapeAccordionLeft);
			this.tabNotes.Controls.Add(this.shapeAccordionBottom);
			this.tabNotes.Controls.Add(this.shapeAccordionTop);
			this.tabNotes.Controls.Add(this.btnDeleteNote);
			this.tabNotes.Controls.Add(this.chkMonospace);
			this.tabNotes.ImageKey = "notes";
			this.tabNotes.Location = new System.Drawing.Point(4, 30);
			this.tabNotes.Name = "tabNotes";
			this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
			this.tabNotes.Size = new System.Drawing.Size(544, 302);
			this.tabNotes.TabIndex = 3;
			this.tabNotes.Text = "Notes";
			this.tabNotes.UseVisualStyleBackColor = true;
			// 
			// btnNewNote
			// 
			this.btnNewNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNewNote.Image = ((System.Drawing.Image)(resources.GetObject("btnNewNote.Image")));
			this.btnNewNote.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNewNote.Location = new System.Drawing.Point(224, 264);
			this.btnNewNote.Name = "btnNewNote";
			this.btnNewNote.Size = new System.Drawing.Size(112, 24);
			this.btnNewNote.TabIndex = 27;
			this.btnNewNote.Text = " New note";
			this.btnNewNote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnNewNote.UseVisualStyleBackColor = true;
			this.btnNewNote.Click += new System.EventHandler(this.AddNewNoteAccordionItem);
			// 
			// chkWordWrap
			// 
			this.chkWordWrap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkWordWrap.Location = new System.Drawing.Point(112, 264);
			this.chkWordWrap.Name = "chkWordWrap";
			this.chkWordWrap.Size = new System.Drawing.Size(128, 24);
			this.chkWordWrap.TabIndex = 26;
			this.chkWordWrap.Text = "Word wrap";
			this.chkWordWrap.UseVisualStyleBackColor = true;
			this.chkWordWrap.CheckedChanged += new System.EventHandler(this.ChkWordWrapCheckedChanged);
			// 
			// panAccordion
			// 
			this.panAccordion.Controls.Add(this.scrollAccordion);
			this.panAccordion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panAccordion.Location = new System.Drawing.Point(18, 18);
			this.panAccordion.Name = "panAccordion";
			this.panAccordion.Size = new System.Drawing.Size(509, 237);
			this.panAccordion.TabIndex = 24;
			// 
			// scrollAccordion
			// 
			this.scrollAccordion.LargeChange = 50;
			this.scrollAccordion.Location = new System.Drawing.Point(492, 0);
			this.scrollAccordion.Name = "scrollAccordion";
			this.scrollAccordion.Size = new System.Drawing.Size(17, 237);
			this.scrollAccordion.SmallChange = 25;
			this.scrollAccordion.TabIndex = 0;
			this.scrollAccordion.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollAccordionScroll);
			// 
			// shapeAccordionRight
			// 
			this.shapeAccordionRight.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shapeAccordionRight.Location = new System.Drawing.Point(528, 16);
			this.shapeAccordionRight.Name = "shapeAccordionRight";
			this.shapeAccordionRight.Size = new System.Drawing.Size(1, 241);
			this.shapeAccordionRight.TabIndex = 9;
			// 
			// shapeAccordionLeft
			// 
			this.shapeAccordionLeft.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shapeAccordionLeft.Location = new System.Drawing.Point(16, 16);
			this.shapeAccordionLeft.Name = "shapeAccordionLeft";
			this.shapeAccordionLeft.Size = new System.Drawing.Size(1, 240);
			this.shapeAccordionLeft.TabIndex = 8;
			// 
			// shapeAccordionBottom
			// 
			this.shapeAccordionBottom.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shapeAccordionBottom.Location = new System.Drawing.Point(16, 256);
			this.shapeAccordionBottom.Name = "shapeAccordionBottom";
			this.shapeAccordionBottom.Size = new System.Drawing.Size(512, 1);
			this.shapeAccordionBottom.TabIndex = 7;
			// 
			// shapeAccordionTop
			// 
			this.shapeAccordionTop.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shapeAccordionTop.Location = new System.Drawing.Point(16, 16);
			this.shapeAccordionTop.Name = "shapeAccordionTop";
			this.shapeAccordionTop.Size = new System.Drawing.Size(512, 1);
			this.shapeAccordionTop.TabIndex = 6;
			// 
			// btnDeleteNote
			// 
			this.btnDeleteNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteNote.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteNote.Image")));
			this.btnDeleteNote.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnDeleteNote.Location = new System.Drawing.Point(344, 264);
			this.btnDeleteNote.Name = "btnDeleteNote";
			this.btnDeleteNote.Size = new System.Drawing.Size(184, 24);
			this.btnDeleteNote.TabIndex = 28;
			this.btnDeleteNote.Text = " Delete selected note";
			this.btnDeleteNote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDeleteNote.UseVisualStyleBackColor = true;
			this.btnDeleteNote.Click += new System.EventHandler(this.DeleteSelectedNoteAccordionItem);
			// 
			// chkMonospace
			// 
			this.chkMonospace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkMonospace.Location = new System.Drawing.Point(16, 264);
			this.chkMonospace.Name = "chkMonospace";
			this.chkMonospace.Size = new System.Drawing.Size(104, 24);
			this.chkMonospace.TabIndex = 25;
			this.chkMonospace.Text = "Monospace";
			this.chkMonospace.UseVisualStyleBackColor = true;
			this.chkMonospace.CheckedChanged += new System.EventHandler(this.ChkMonospaceCheckedChanged);
			// 
			// imgsTab
			// 
			this.imgsTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgsTab.ImageStream")));
			this.imgsTab.TransparentColor = System.Drawing.Color.Transparent;
			this.imgsTab.Images.SetKeyName(0, "task");
			this.imgsTab.Images.SetKeyName(1, "datestime");
			this.imgsTab.Images.SetKeyName(2, "payment");
			this.imgsTab.Images.SetKeyName(3, "notes");
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(472, 360);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 24);
			this.btnCancel.TabIndex = 30;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOk
			// 
			this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOk.Location = new System.Drawing.Point(328, 360);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(136, 24);
			this.btnOk.TabIndex = 29;
			this.btnOk.Text = " Ok";
			this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// shapeLine
			// 
			this.shapeLine.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shapeLine.Location = new System.Drawing.Point(8, 352);
			this.shapeLine.Name = "shapeLine";
			this.shapeLine.Size = new System.Drawing.Size(552, 1);
			this.shapeLine.TabIndex = 11;
			// 
			// colorDialog
			// 
			this.colorDialog.Color = System.Drawing.Color.Gray;
			// 
			// imgNote
			// 
			this.imgNote.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgNote.ImageStream")));
			this.imgNote.TransparentColor = System.Drawing.Color.Transparent;
			this.imgNote.Images.SetKeyName(0, "note");
			this.imgNote.Images.SetKeyName(1, "note_green.png");
			// 
			// TaskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(569, 393);
			this.Controls.Add(this.shapeLine);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tabs);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(577, 427);
			this.Name = "TaskForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Task";
			this.Shown += new System.EventHandler(this.TaskFormShown);
			this.Resize += new System.EventHandler(this.TaskFormResize);
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.panParent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.boxParentIcon)).EndInit();
			this.tabDatesTime.ResumeLayout(false);
			this.tabDatesTime.PerformLayout();
			this.boxUseTimer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numTimerS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTimerH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTimerM)).EndInit();
			this.panCannotEditTimer.ResumeLayout(false);
			this.tabPayment.ResumeLayout(false);
			this.tabPayment.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
			this.tabNotes.ResumeLayout(false);
			this.panAccordion.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblCurrency;
		private System.Windows.Forms.CheckBox chkPerHour;
		private System.Windows.Forms.Button btnSumTimers;
		private System.Windows.Forms.Button btnSumPrice;
		private System.Windows.Forms.Panel shapeAccordionRight;
		private System.Windows.Forms.Panel shapeAccordionLeft;
		private System.Windows.Forms.Panel shapeAccordionBottom;
		private System.Windows.Forms.Panel shapeAccordionTop;
		private System.Windows.Forms.Panel shapeLine;
		private System.Windows.Forms.Label lblTimerH;
		private System.Windows.Forms.Label lblTimerM;
		private System.Windows.Forms.Label lblTimerS;
		private System.Windows.Forms.Panel panCannotEditTimer;
		private System.Windows.Forms.Label lblCannotEditTimer;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.NumericUpDown numTimerS;
		private System.Windows.Forms.Button btnDeleteNote;
		private System.Windows.Forms.Button btnNewNote;
		private System.Windows.Forms.CheckBox chkMonospace;
		private System.Windows.Forms.CheckBox chkWordWrap;
		private System.Windows.Forms.ImageList imgNote;
		private System.Windows.Forms.VScrollBar scrollAccordion;
		private System.Windows.Forms.Panel panAccordion;
		private System.Windows.Forms.PictureBox boxParentIcon;
		private System.Windows.Forms.Label lblParentName;
		private System.Windows.Forms.Panel panParent;
		private System.Windows.Forms.Label lblSubTaskOf;
		private System.Windows.Forms.CheckBox chkPaidNot;
		private System.Windows.Forms.DateTimePicker dtPaid;
		private System.Windows.Forms.CheckBox chkPriceNot;
		private System.Windows.Forms.Label lblPaymentNote;
		private System.Windows.Forms.TextBox txtPaymentNote;
		private System.Windows.Forms.ComboBox cmbPaymentType;
		private System.Windows.Forms.Label lblPayment;
		private System.Windows.Forms.Label lblPaid;
		private System.Windows.Forms.NumericUpDown numPrice;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.NumericUpDown numTimerH;
		private System.Windows.Forms.NumericUpDown numTimerM;
		private System.Windows.Forms.GroupBox boxUseTimer;
		private System.Windows.Forms.CheckBox chkDueDateNot;
		private System.Windows.Forms.CheckBox chkCompletedNot;
		private System.Windows.Forms.DateTimePicker dtCreationDate;
		private System.Windows.Forms.Label lblCreationDate;
		private System.Windows.Forms.DateTimePicker dtDueDate;
		private System.Windows.Forms.DateTimePicker dtCompleted;
		private System.Windows.Forms.Label lblDueDate;
		private System.Windows.Forms.Label lblCompleted;
		private System.Windows.Forms.Label lblTimer;
		private System.Windows.Forms.Button btnTimerReset;
		private System.Windows.Forms.CheckBox chkUseTimer;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ImageList imgPriority;
		private System.Windows.Forms.Button btnChooseColour;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ImageCombo cmbColour;
		private System.Windows.Forms.ImageCombo cmbCategory;
		private System.Windows.Forms.ImageCombo cmbPriority;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblPriority;
		private System.Windows.Forms.Label lblColour;
		private System.Windows.Forms.Button btnAddCategory;
		private System.Windows.Forms.TabPage tabNotes;
		private System.Windows.Forms.TabPage tabDatesTime;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabPayment;
		private System.Windows.Forms.ImageList imgsTab;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabControl tabs;
	}
}
