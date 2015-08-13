/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 */
namespace Todomoo
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolToolbar = new System.Windows.Forms.ToolStrip();
			this.btnNewTask = new System.Windows.Forms.ToolStripButton();
			this.btnNewSubTask = new System.Windows.Forms.ToolStripButton();
			this.btnMove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSetCompleted = new System.Windows.Forms.ToolStripButton();
			this.btnTimerStart = new System.Windows.Forms.ToolStripButton();
			this.btnTimerPause = new System.Windows.Forms.ToolStripButton();
			this.btnEditPayment = new System.Windows.Forms.ToolStripButton();
			this.btnNoteAdd = new System.Windows.Forms.ToolStripButton();
			this.btnNotesView = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.btnHideCompleted = new System.Windows.Forms.ToolStripButton();
			this.btnFlatView = new System.Windows.Forms.ToolStripButton();
			this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
			this.btnCollapseAll = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnMinimizeToTray = new System.Windows.Forms.ToolStripButton();
			this.btnOptions = new System.Windows.Forms.ToolStripButton();
			this.btnAbout = new System.Windows.Forms.ToolStripButton();
			this.mnMenu = new System.Windows.Forms.MenuStrip();
			this.todomooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnHideCompleted = new System.Windows.Forms.ToolStripMenuItem();
			this.mnFlatView = new System.Windows.Forms.ToolStripMenuItem();
			this.mnExpandAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mnCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.mnMinimizeToTray = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnExitTodomoo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnNewCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnEditCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnNewTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnNewSubTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnEditTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnMove = new System.Windows.Forms.ToolStripMenuItem();
			this.mnDeleteTask = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnSetCompleted = new System.Windows.Forms.ToolStripMenuItem();
			this.mnTimerStart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnTimerPause = new System.Windows.Forms.ToolStripMenuItem();
			this.mnEditPayment = new System.Windows.Forms.ToolStripMenuItem();
			this.mnNoteAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.mnNotesView = new System.Windows.Forms.ToolStripMenuItem();
			this.mnTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnExport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnDoBackup = new System.Windows.Forms.ToolStripMenuItem();
			this.mnDoBackupIn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.mnOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnUpdates = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.mnWebsite = new System.Windows.Forms.ToolStripMenuItem();
			this.mnProjectPage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolCategories = new System.Windows.Forms.ToolStrip();
			this.btnCategoryNew = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnCategoryAll = new System.Windows.Forms.ToolStripButton();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.mnContextCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnContextEditCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.treeTasks = new BrightIdeasSoftware.TreeListView();
			this.colName = new BrightIdeasSoftware.OLVColumn();
			this.colCategory = new BrightIdeasSoftware.OLVColumn();
			this.colPriority = new BrightIdeasSoftware.OLVColumn();
			this.colCreationDate = new BrightIdeasSoftware.OLVColumn();
			this.colDueDate = new BrightIdeasSoftware.OLVColumn();
			this.colCompleted = new BrightIdeasSoftware.OLVColumn();
			this.colTimer = new BrightIdeasSoftware.OLVColumn();
			this.colPrice = new BrightIdeasSoftware.OLVColumn();
			this.colNotes = new BrightIdeasSoftware.OLVColumn();
			this.mnContextTask = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnContextNewTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextNewSubTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextEditTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextMoveTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextDeleteTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.mnContextSetCompleted = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextTimerStart = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextTimerPause = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextEditPayment = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextNoteAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.mnContextNotesView = new System.Windows.Forms.ToolStripMenuItem();
			this.imgPriority = new System.Windows.Forms.ImageList(this.components);
			this.imgTick = new System.Windows.Forms.ImageList(this.components);
			this.imgNote = new System.Windows.Forms.ImageList(this.components);
			this.imgTimer = new System.Windows.Forms.ImageList(this.components);
			this.tmrTimerRefresh = new System.Windows.Forms.Timer(this.components);
			this.mnContextTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnOpenTodomoo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnTrayNewTask = new System.Windows.Forms.ToolStripMenuItem();
			this.mnTrayNewSubTask = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			this.dlgBackup = new System.Windows.Forms.SaveFileDialog();
			this.panMove = new System.Windows.Forms.Panel();
			this.lblMove = new System.Windows.Forms.Label();
			this.btnMoveCancel = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tmrPersistTimers = new System.Windows.Forms.Timer(this.components);
			this.toolToolbar.SuspendLayout();
			this.mnMenu.SuspendLayout();
			this.toolCategories.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.mnContextCategory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeTasks)).BeginInit();
			this.mnContextTask.SuspendLayout();
			this.mnContextTray.SuspendLayout();
			this.panMove.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolToolbar
			// 
			this.toolToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnNewTask,
									this.btnNewSubTask,
									this.btnMove,
									this.toolStripSeparator14,
									this.btnSetCompleted,
									this.btnTimerStart,
									this.btnTimerPause,
									this.btnEditPayment,
									this.btnNoteAdd,
									this.btnNotesView,
									this.toolStripSeparator9,
									this.btnHideCompleted,
									this.btnFlatView,
									this.btnExpandAll,
									this.btnCollapseAll,
									this.toolStripSeparator3,
									this.btnMinimizeToTray,
									this.btnOptions,
									this.btnAbout});
			this.toolToolbar.Location = new System.Drawing.Point(0, 24);
			this.toolToolbar.Name = "toolToolbar";
			this.toolToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolToolbar.Size = new System.Drawing.Size(892, 25);
			this.toolToolbar.TabIndex = 0;
			this.toolToolbar.Text = "toolStrip1";
			// 
			// btnNewTask
			// 
			this.btnNewTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTask.Image")));
			this.btnNewTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNewTask.Name = "btnNewTask";
			this.btnNewTask.Size = new System.Drawing.Size(23, 22);
			this.btnNewTask.Text = "New task...";
			this.btnNewTask.Click += new System.EventHandler(this.TaskNewRoot);
			// 
			// btnNewSubTask
			// 
			this.btnNewSubTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNewSubTask.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSubTask.Image")));
			this.btnNewSubTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNewSubTask.Name = "btnNewSubTask";
			this.btnNewSubTask.Size = new System.Drawing.Size(23, 22);
			this.btnNewSubTask.Text = "New sub-task of selected task...";
			this.btnNewSubTask.Click += new System.EventHandler(this.TaskNewChild);
			// 
			// btnMove
			// 
			this.btnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
			this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(23, 22);
			this.btnMove.Text = "Move task...";
			this.btnMove.Click += new System.EventHandler(this.TaskMoveSelected);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
			// 
			// btnSetCompleted
			// 
			this.btnSetCompleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSetCompleted.Image = ((System.Drawing.Image)(resources.GetObject("btnSetCompleted.Image")));
			this.btnSetCompleted.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSetCompleted.Name = "btnSetCompleted";
			this.btnSetCompleted.Size = new System.Drawing.Size(23, 22);
			this.btnSetCompleted.Text = "Mark task completed";
			this.btnSetCompleted.Click += new System.EventHandler(this.TaskToggleCompleted);
			// 
			// btnTimerStart
			// 
			this.btnTimerStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimerStart.Image = ((System.Drawing.Image)(resources.GetObject("btnTimerStart.Image")));
			this.btnTimerStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimerStart.Name = "btnTimerStart";
			this.btnTimerStart.Size = new System.Drawing.Size(23, 22);
			this.btnTimerStart.Text = "Start task timer";
			this.btnTimerStart.Click += new System.EventHandler(this.TaskTimerStart);
			// 
			// btnTimerPause
			// 
			this.btnTimerPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnTimerPause.Image = ((System.Drawing.Image)(resources.GetObject("btnTimerPause.Image")));
			this.btnTimerPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTimerPause.Name = "btnTimerPause";
			this.btnTimerPause.Size = new System.Drawing.Size(23, 22);
			this.btnTimerPause.Text = "Pause task timer";
			this.btnTimerPause.Click += new System.EventHandler(this.TaskTimerPause);
			// 
			// btnEditPayment
			// 
			this.btnEditPayment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEditPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPayment.Image")));
			this.btnEditPayment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditPayment.Name = "btnEditPayment";
			this.btnEditPayment.Size = new System.Drawing.Size(23, 22);
			this.btnEditPayment.Text = "Edit payment details...";
			this.btnEditPayment.Click += new System.EventHandler(this.TaskEditPayment);
			// 
			// btnNoteAdd
			// 
			this.btnNoteAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNoteAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnNoteAdd.Image")));
			this.btnNoteAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNoteAdd.Name = "btnNoteAdd";
			this.btnNoteAdd.Size = new System.Drawing.Size(23, 22);
			this.btnNoteAdd.Text = "Add a note...";
			this.btnNoteAdd.Click += new System.EventHandler(this.TaskNoteAdd);
			// 
			// btnNotesView
			// 
			this.btnNotesView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNotesView.Image = ((System.Drawing.Image)(resources.GetObject("btnNotesView.Image")));
			this.btnNotesView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNotesView.Name = "btnNotesView";
			this.btnNotesView.Size = new System.Drawing.Size(23, 22);
			this.btnNotesView.Text = "View notes...";
			this.btnNotesView.Click += new System.EventHandler(this.TaskNotesView);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// btnHideCompleted
			// 
			this.btnHideCompleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnHideCompleted.Image = ((System.Drawing.Image)(resources.GetObject("btnHideCompleted.Image")));
			this.btnHideCompleted.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHideCompleted.Name = "btnHideCompleted";
			this.btnHideCompleted.Size = new System.Drawing.Size(23, 22);
			this.btnHideCompleted.Text = "Flat view";
			this.btnHideCompleted.Click += new System.EventHandler(this.BtnHideCompletedClick);
			// 
			// btnFlatView
			// 
			this.btnFlatView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFlatView.Image = ((System.Drawing.Image)(resources.GetObject("btnFlatView.Image")));
			this.btnFlatView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFlatView.Name = "btnFlatView";
			this.btnFlatView.Size = new System.Drawing.Size(23, 22);
			this.btnFlatView.Text = "Flat view";
			this.btnFlatView.Click += new System.EventHandler(this.BtnFlatViewClick);
			// 
			// btnExpandAll
			// 
			this.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
			this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExpandAll.Name = "btnExpandAll";
			this.btnExpandAll.Size = new System.Drawing.Size(23, 22);
			this.btnExpandAll.Text = "Expand all";
			this.btnExpandAll.Click += new System.EventHandler(this.BtnExpandAllClick);
			// 
			// btnCollapseAll
			// 
			this.btnCollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
			this.btnCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCollapseAll.Name = "btnCollapseAll";
			this.btnCollapseAll.Size = new System.Drawing.Size(23, 22);
			this.btnCollapseAll.Text = "Collapse all";
			this.btnCollapseAll.Click += new System.EventHandler(this.BtnCollapseAllClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// btnMinimizeToTray
			// 
			this.btnMinimizeToTray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnMinimizeToTray.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizeToTray.Image")));
			this.btnMinimizeToTray.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMinimizeToTray.Name = "btnMinimizeToTray";
			this.btnMinimizeToTray.Size = new System.Drawing.Size(23, 22);
			this.btnMinimizeToTray.Text = "Minimize to tray";
			this.btnMinimizeToTray.Click += new System.EventHandler(this.MinimizeToTray);
			// 
			// btnOptions
			// 
			this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
			this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(23, 22);
			this.btnOptions.Text = "Options...";
			this.btnOptions.Click += new System.EventHandler(this.ShowOptionForm);
			// 
			// btnAbout
			// 
			this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
			this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(23, 22);
			this.btnAbout.Text = "About...";
			this.btnAbout.Click += new System.EventHandler(this.ShowAboutForm);
			// 
			// mnMenu
			// 
			this.mnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.todomooToolStripMenuItem,
									this.mnCategory,
									this.mnTask,
									this.mnTools,
									this.mnHelp});
			this.mnMenu.Location = new System.Drawing.Point(0, 0);
			this.mnMenu.Name = "mnMenu";
			this.mnMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.mnMenu.Size = new System.Drawing.Size(892, 24);
			this.mnMenu.TabIndex = 1;
			this.mnMenu.Text = "New category";
			// 
			// todomooToolStripMenuItem
			// 
			this.todomooToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnHideCompleted,
									this.mnFlatView,
									this.mnExpandAll,
									this.mnCollapseAll,
									this.toolStripSeparator10,
									this.mnMinimizeToTray,
									this.toolStripSeparator6,
									this.mnExitTodomoo});
			this.todomooToolStripMenuItem.Name = "todomooToolStripMenuItem";
			this.todomooToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.todomooToolStripMenuItem.Text = "Todomoo";
			// 
			// mnHideCompleted
			// 
			this.mnHideCompleted.Name = "mnHideCompleted";
			this.mnHideCompleted.Size = new System.Drawing.Size(186, 22);
			this.mnHideCompleted.Text = "Hide completed tasks";
			this.mnHideCompleted.Click += new System.EventHandler(this.BtnHideCompletedClick);
			// 
			// mnFlatView
			// 
			this.mnFlatView.Name = "mnFlatView";
			this.mnFlatView.Size = new System.Drawing.Size(186, 22);
			this.mnFlatView.Text = "Flat view";
			this.mnFlatView.Click += new System.EventHandler(this.BtnFlatViewClick);
			// 
			// mnExpandAll
			// 
			this.mnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("mnExpandAll.Image")));
			this.mnExpandAll.Name = "mnExpandAll";
			this.mnExpandAll.Size = new System.Drawing.Size(186, 22);
			this.mnExpandAll.Text = "Expand all";
			this.mnExpandAll.Click += new System.EventHandler(this.BtnExpandAllClick);
			// 
			// mnCollapseAll
			// 
			this.mnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("mnCollapseAll.Image")));
			this.mnCollapseAll.Name = "mnCollapseAll";
			this.mnCollapseAll.Size = new System.Drawing.Size(186, 22);
			this.mnCollapseAll.Text = "Collapse all";
			this.mnCollapseAll.Click += new System.EventHandler(this.BtnCollapseAllClick);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(183, 6);
			// 
			// mnMinimizeToTray
			// 
			this.mnMinimizeToTray.Image = ((System.Drawing.Image)(resources.GetObject("mnMinimizeToTray.Image")));
			this.mnMinimizeToTray.Name = "mnMinimizeToTray";
			this.mnMinimizeToTray.ShortcutKeys = System.Windows.Forms.Keys.F9;
			this.mnMinimizeToTray.Size = new System.Drawing.Size(186, 22);
			this.mnMinimizeToTray.Text = "Minimize to tray";
			this.mnMinimizeToTray.Click += new System.EventHandler(this.MinimizeToTray);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(183, 6);
			// 
			// mnExitTodomoo
			// 
			this.mnExitTodomoo.Name = "mnExitTodomoo";
			this.mnExitTodomoo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.mnExitTodomoo.Size = new System.Drawing.Size(186, 22);
			this.mnExitTodomoo.Text = "Exit";
			this.mnExitTodomoo.Click += new System.EventHandler(this.Exit);
			// 
			// mnCategory
			// 
			this.mnCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnNewCategory,
									this.mnEditCategory,
									this.mnDeleteCategory});
			this.mnCategory.Name = "mnCategory";
			this.mnCategory.Size = new System.Drawing.Size(64, 20);
			this.mnCategory.Text = "Category";
			// 
			// mnNewCategory
			// 
			this.mnNewCategory.Image = ((System.Drawing.Image)(resources.GetObject("mnNewCategory.Image")));
			this.mnNewCategory.Name = "mnNewCategory";
			this.mnNewCategory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
			this.mnNewCategory.Size = new System.Drawing.Size(212, 22);
			this.mnNewCategory.Text = "New category...";
			this.mnNewCategory.Click += new System.EventHandler(this.CategoryNew);
			// 
			// mnEditCategory
			// 
			this.mnEditCategory.Name = "mnEditCategory";
			this.mnEditCategory.Size = new System.Drawing.Size(212, 22);
			this.mnEditCategory.Text = "Edit current category";
			this.mnEditCategory.Click += new System.EventHandler(this.CategoryEditSelected);
			// 
			// mnDeleteCategory
			// 
			this.mnDeleteCategory.Name = "mnDeleteCategory";
			this.mnDeleteCategory.Size = new System.Drawing.Size(212, 22);
			this.mnDeleteCategory.Text = "Delete current category";
			this.mnDeleteCategory.Click += new System.EventHandler(this.CategoryDeleteSelected);
			// 
			// mnTask
			// 
			this.mnTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnNewTask,
									this.mnNewSubTask,
									this.mnEditTask,
									this.mnMove,
									this.mnDeleteTask,
									this.toolStripSeparator4,
									this.mnSetCompleted,
									this.mnTimerStart,
									this.mnTimerPause,
									this.mnEditPayment,
									this.mnNoteAdd,
									this.mnNotesView});
			this.mnTask.Name = "mnTask";
			this.mnTask.Size = new System.Drawing.Size(41, 20);
			this.mnTask.Text = "Task";
			// 
			// mnNewTask
			// 
			this.mnNewTask.Image = ((System.Drawing.Image)(resources.GetObject("mnNewTask.Image")));
			this.mnNewTask.Name = "mnNewTask";
			this.mnNewTask.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.mnNewTask.Size = new System.Drawing.Size(287, 22);
			this.mnNewTask.Text = "New task...";
			this.mnNewTask.Click += new System.EventHandler(this.TaskNewRoot);
			// 
			// mnNewSubTask
			// 
			this.mnNewSubTask.Image = ((System.Drawing.Image)(resources.GetObject("mnNewSubTask.Image")));
			this.mnNewSubTask.Name = "mnNewSubTask";
			this.mnNewSubTask.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mnNewSubTask.Size = new System.Drawing.Size(287, 22);
			this.mnNewSubTask.Text = "New sub-task of selected task...";
			this.mnNewSubTask.Click += new System.EventHandler(this.TaskNewChild);
			// 
			// mnEditTask
			// 
			this.mnEditTask.Name = "mnEditTask";
			this.mnEditTask.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.mnEditTask.Size = new System.Drawing.Size(287, 22);
			this.mnEditTask.Text = "Edit task...";
			this.mnEditTask.Click += new System.EventHandler(this.TaskEditSelected);
			// 
			// mnMove
			// 
			this.mnMove.Image = ((System.Drawing.Image)(resources.GetObject("mnMove.Image")));
			this.mnMove.Name = "mnMove";
			this.mnMove.Size = new System.Drawing.Size(287, 22);
			this.mnMove.Text = "Move task...";
			this.mnMove.Click += new System.EventHandler(this.TaskMoveSelected);
			// 
			// mnDeleteTask
			// 
			this.mnDeleteTask.Name = "mnDeleteTask";
			this.mnDeleteTask.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.mnDeleteTask.Size = new System.Drawing.Size(287, 22);
			this.mnDeleteTask.Text = "Delete task";
			this.mnDeleteTask.Click += new System.EventHandler(this.TaskDeleteSelected);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(284, 6);
			// 
			// mnSetCompleted
			// 
			this.mnSetCompleted.Image = ((System.Drawing.Image)(resources.GetObject("mnSetCompleted.Image")));
			this.mnSetCompleted.Name = "mnSetCompleted";
			this.mnSetCompleted.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
			this.mnSetCompleted.Size = new System.Drawing.Size(287, 22);
			this.mnSetCompleted.Text = "Mark task completed";
			this.mnSetCompleted.Click += new System.EventHandler(this.TaskToggleCompleted);
			// 
			// mnTimerStart
			// 
			this.mnTimerStart.Image = ((System.Drawing.Image)(resources.GetObject("mnTimerStart.Image")));
			this.mnTimerStart.Name = "mnTimerStart";
			this.mnTimerStart.Size = new System.Drawing.Size(287, 22);
			this.mnTimerStart.Text = "Start task timer";
			this.mnTimerStart.Click += new System.EventHandler(this.TaskTimerStart);
			// 
			// mnTimerPause
			// 
			this.mnTimerPause.Image = ((System.Drawing.Image)(resources.GetObject("mnTimerPause.Image")));
			this.mnTimerPause.Name = "mnTimerPause";
			this.mnTimerPause.Size = new System.Drawing.Size(287, 22);
			this.mnTimerPause.Text = "Pause task timer";
			this.mnTimerPause.Click += new System.EventHandler(this.TaskTimerPause);
			// 
			// mnEditPayment
			// 
			this.mnEditPayment.Image = ((System.Drawing.Image)(resources.GetObject("mnEditPayment.Image")));
			this.mnEditPayment.Name = "mnEditPayment";
			this.mnEditPayment.Size = new System.Drawing.Size(287, 22);
			this.mnEditPayment.Text = "Edit payment details...";
			this.mnEditPayment.Click += new System.EventHandler(this.TaskEditPayment);
			// 
			// mnNoteAdd
			// 
			this.mnNoteAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnNoteAdd.Image")));
			this.mnNoteAdd.Name = "mnNoteAdd";
			this.mnNoteAdd.Size = new System.Drawing.Size(287, 22);
			this.mnNoteAdd.Text = "Add a note...";
			this.mnNoteAdd.Click += new System.EventHandler(this.TaskNoteAdd);
			// 
			// mnNotesView
			// 
			this.mnNotesView.Image = ((System.Drawing.Image)(resources.GetObject("mnNotesView.Image")));
			this.mnNotesView.Name = "mnNotesView";
			this.mnNotesView.Size = new System.Drawing.Size(287, 22);
			this.mnNotesView.Text = "View notes...";
			this.mnNotesView.Click += new System.EventHandler(this.TaskNotesView);
			// 
			// mnTools
			// 
			this.mnTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnExport,
									this.mnDoBackup,
									this.mnDoBackupIn,
									this.toolStripSeparator11,
									this.mnOptions});
			this.mnTools.Name = "mnTools";
			this.mnTools.Size = new System.Drawing.Size(44, 20);
			this.mnTools.Text = "Tools";
			// 
			// mnExport
			// 
			this.mnExport.Name = "mnExport";
			this.mnExport.Size = new System.Drawing.Size(193, 22);
			this.mnExport.Text = "Export all tasks to CSV";
			this.mnExport.Click += new System.EventHandler(this.MnExportClick);
			// 
			// mnDoBackup
			// 
			this.mnDoBackup.Name = "mnDoBackup";
			this.mnDoBackup.Size = new System.Drawing.Size(193, 22);
			this.mnDoBackup.Text = "Do a backup";
			this.mnDoBackup.Click += new System.EventHandler(this.TaskBackup);
			// 
			// mnDoBackupIn
			// 
			this.mnDoBackupIn.Name = "mnDoBackupIn";
			this.mnDoBackupIn.Size = new System.Drawing.Size(193, 22);
			this.mnDoBackupIn.Text = "Do a backup in...";
			this.mnDoBackupIn.Click += new System.EventHandler(this.TaskBackupIn);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(190, 6);
			// 
			// mnOptions
			// 
			this.mnOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnOptions.Image")));
			this.mnOptions.Name = "mnOptions";
			this.mnOptions.Size = new System.Drawing.Size(193, 22);
			this.mnOptions.Text = "Options...";
			this.mnOptions.Click += new System.EventHandler(this.ShowOptionForm);
			// 
			// mnHelp
			// 
			this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnUpdates,
									this.toolStripSeparator12,
									this.mnWebsite,
									this.mnProjectPage,
									this.toolStripSeparator2,
									this.mnAbout});
			this.mnHelp.Name = "mnHelp";
			this.mnHelp.Size = new System.Drawing.Size(24, 20);
			this.mnHelp.Text = "?";
			// 
			// mnUpdates
			// 
			this.mnUpdates.Image = ((System.Drawing.Image)(resources.GetObject("mnUpdates.Image")));
			this.mnUpdates.Name = "mnUpdates";
			this.mnUpdates.Size = new System.Drawing.Size(281, 22);
			this.mnUpdates.Text = "Check for updates...";
			this.mnUpdates.Click += new System.EventHandler(this.MnUpdatesClick);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(278, 6);
			// 
			// mnWebsite
			// 
			this.mnWebsite.Name = "mnWebsite";
			this.mnWebsite.Size = new System.Drawing.Size(281, 22);
			this.mnWebsite.Text = "Visit Todomoo website...";
			this.mnWebsite.Click += new System.EventHandler(this.LaunchWebsite);
			// 
			// mnProjectPage
			// 
			this.mnProjectPage.Name = "mnProjectPage";
			this.mnProjectPage.Size = new System.Drawing.Size(281, 22);
			this.mnProjectPage.Text = "Visiti project page on SourceForge.net...";
			this.mnProjectPage.Click += new System.EventHandler(this.LaunchProjectPage);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(278, 6);
			// 
			// mnAbout
			// 
			this.mnAbout.Image = ((System.Drawing.Image)(resources.GetObject("mnAbout.Image")));
			this.mnAbout.Name = "mnAbout";
			this.mnAbout.Size = new System.Drawing.Size(281, 22);
			this.mnAbout.Text = "About Todomoo...";
			this.mnAbout.Click += new System.EventHandler(this.ShowAboutForm);
			// 
			// toolCategories
			// 
			this.toolCategories.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.toolCategories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.btnCategoryNew,
									this.toolStripSeparator1,
									this.btnCategoryAll});
			this.toolCategories.Location = new System.Drawing.Point(0, 49);
			this.toolCategories.Name = "toolCategories";
			this.toolCategories.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolCategories.Size = new System.Drawing.Size(892, 25);
			this.toolCategories.TabIndex = 2;
			this.toolCategories.Text = "toolStrip2";
			this.toolCategories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ToolCategoriesMouseClick);
			this.toolCategories.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolCategoriesItemClicked);
			// 
			// btnCategoryNew
			// 
			this.btnCategoryNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCategoryNew.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryNew.Image")));
			this.btnCategoryNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCategoryNew.Name = "btnCategoryNew";
			this.btnCategoryNew.Size = new System.Drawing.Size(23, 22);
			this.btnCategoryNew.Text = "New category...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnCategoryAll
			// 
			this.btnCategoryAll.Checked = true;
			this.btnCategoryAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnCategoryAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryAll.Image")));
			this.btnCategoryAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCategoryAll.Name = "btnCategoryAll";
			this.btnCategoryAll.Size = new System.Drawing.Size(38, 22);
			this.btnCategoryAll.Text = "All";
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.lblStatus});
			this.statusBar.Location = new System.Drawing.Point(0, 364);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(892, 22);
			this.statusBar.TabIndex = 3;
			this.statusBar.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(19, 17);
			this.lblStatus.Text = "...";
			// 
			// mnContextCategory
			// 
			this.mnContextCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnContextEditCategory,
									this.mnContextDeleteCategory});
			this.mnContextCategory.Name = "mnCategoryContext";
			this.mnContextCategory.Size = new System.Drawing.Size(117, 48);
			// 
			// mnContextEditCategory
			// 
			this.mnContextEditCategory.Name = "mnContextEditCategory";
			this.mnContextEditCategory.Size = new System.Drawing.Size(116, 22);
			this.mnContextEditCategory.Text = "Edit";
			this.mnContextEditCategory.Click += new System.EventHandler(this.CategoryEditSelected);
			// 
			// mnContextDeleteCategory
			// 
			this.mnContextDeleteCategory.Name = "mnContextDeleteCategory";
			this.mnContextDeleteCategory.Size = new System.Drawing.Size(116, 22);
			this.mnContextDeleteCategory.Text = "Delete";
			this.mnContextDeleteCategory.Click += new System.EventHandler(this.CategoryDeleteSelected);
			// 
			// treeTasks
			// 
			this.treeTasks.AllColumns.Add(this.colName);
			this.treeTasks.AllColumns.Add(this.colCategory);
			this.treeTasks.AllColumns.Add(this.colPriority);
			this.treeTasks.AllColumns.Add(this.colCreationDate);
			this.treeTasks.AllColumns.Add(this.colDueDate);
			this.treeTasks.AllColumns.Add(this.colCompleted);
			this.treeTasks.AllColumns.Add(this.colTimer);
			this.treeTasks.AllColumns.Add(this.colPrice);
			this.treeTasks.AllColumns.Add(this.colNotes);
			this.treeTasks.AllowColumnReorder = true;
			this.treeTasks.AllowDrop = true;
			this.treeTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeTasks.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
			this.treeTasks.CheckBoxes = true;
			this.treeTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colName,
									this.colCategory,
									this.colPriority,
									this.colCreationDate,
									this.colDueDate,
									this.colCompleted,
									this.colTimer,
									this.colPrice,
									this.colNotes});
			this.treeTasks.ContextMenuStrip = this.mnContextTask;
			this.treeTasks.FullRowSelect = true;
			this.treeTasks.HideSelection = false;
			this.treeTasks.Location = new System.Drawing.Point(0, 74);
			this.treeTasks.MultiSelect = false;
			this.treeTasks.Name = "treeTasks";
			this.treeTasks.OwnerDraw = true;
			this.treeTasks.RowHeight = 16;
			this.treeTasks.ShowGroups = false;
			this.treeTasks.ShowImagesOnSubItems = true;
			this.treeTasks.Size = new System.Drawing.Size(896, 254);
			this.treeTasks.TabIndex = 4;
			this.treeTasks.TintSortColumn = true;
			this.treeTasks.UseCompatibleStateImageBehavior = false;
			this.treeTasks.UseHotItem = true;
			this.treeTasks.UseSubItemCheckBoxes = true;
			this.treeTasks.View = System.Windows.Forms.View.Details;
			this.treeTasks.VirtualMode = true;
			this.treeTasks.DoubleClick += new System.EventHandler(this.TreeTasksDoubleClick);
			this.treeTasks.AfterSorting += new System.EventHandler<BrightIdeasSoftware.AfterSortingEventArgs>(this.TreeTasksAfterSorting);
			this.treeTasks.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.TreeTasksCellEditStarting);
			this.treeTasks.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TreeTasksMouseMove);
			this.treeTasks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeTasksMouseUp);
			this.treeTasks.SelectionChanged += new System.EventHandler(this.TreeTasksSelectionChanged);
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 260;
			// 
			// colCategory
			// 
			this.colCategory.Text = "Category";
			this.colCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colCategory.Width = 100;
			// 
			// colPriority
			// 
			this.colPriority.Text = "Priority";
			this.colPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colPriority.ToolTipText = "";
			this.colPriority.Width = 65;
			// 
			// colCreationDate
			// 
			this.colCreationDate.IsEditable = false;
			this.colCreationDate.Text = "Creation Date";
			this.colCreationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colCreationDate.Width = 110;
			// 
			// colDueDate
			// 
			this.colDueDate.IsEditable = false;
			this.colDueDate.Text = "Due date";
			this.colDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colDueDate.Width = 110;
			// 
			// colCompleted
			// 
			this.colCompleted.IsEditable = false;
			this.colCompleted.Text = "Completed";
			this.colCompleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colCompleted.Width = 110;
			// 
			// colTimer
			// 
			this.colTimer.IsEditable = false;
			this.colTimer.Text = "Timer";
			this.colTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colTimer.Width = 70;
			// 
			// colPrice
			// 
			this.colPrice.IsEditable = false;
			this.colPrice.Text = "Price";
			this.colPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colPrice.Width = 70;
			// 
			// colNotes
			// 
			this.colNotes.Text = "Notes";
			this.colNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colNotes.Width = 65;
			// 
			// mnContextTask
			// 
			this.mnContextTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnContextNewTask,
									this.mnContextNewSubTask,
									this.mnContextEditTask,
									this.mnContextMoveTask,
									this.mnContextDeleteTask,
									this.mnContextSeparator,
									this.mnContextSetCompleted,
									this.mnContextTimerStart,
									this.mnContextTimerPause,
									this.mnContextEditPayment,
									this.mnContextNoteAdd,
									this.mnContextNotesView});
			this.mnContextTask.Name = "mnContextTask";
			this.mnContextTask.Size = new System.Drawing.Size(195, 252);
			// 
			// mnContextNewTask
			// 
			this.mnContextNewTask.Image = ((System.Drawing.Image)(resources.GetObject("mnContextNewTask.Image")));
			this.mnContextNewTask.Name = "mnContextNewTask";
			this.mnContextNewTask.Size = new System.Drawing.Size(194, 22);
			this.mnContextNewTask.Text = "New task...";
			this.mnContextNewTask.Click += new System.EventHandler(this.TaskNewRoot);
			// 
			// mnContextNewSubTask
			// 
			this.mnContextNewSubTask.Image = ((System.Drawing.Image)(resources.GetObject("mnContextNewSubTask.Image")));
			this.mnContextNewSubTask.Name = "mnContextNewSubTask";
			this.mnContextNewSubTask.Size = new System.Drawing.Size(194, 22);
			this.mnContextNewSubTask.Text = "New sub-task...";
			this.mnContextNewSubTask.Click += new System.EventHandler(this.TaskNewChild);
			// 
			// mnContextEditTask
			// 
			this.mnContextEditTask.Name = "mnContextEditTask";
			this.mnContextEditTask.Size = new System.Drawing.Size(194, 22);
			this.mnContextEditTask.Text = "Edit task...";
			this.mnContextEditTask.Click += new System.EventHandler(this.TaskEditSelected);
			// 
			// mnContextMoveTask
			// 
			this.mnContextMoveTask.Image = ((System.Drawing.Image)(resources.GetObject("mnContextMoveTask.Image")));
			this.mnContextMoveTask.Name = "mnContextMoveTask";
			this.mnContextMoveTask.Size = new System.Drawing.Size(194, 22);
			this.mnContextMoveTask.Text = "Move task...";
			this.mnContextMoveTask.Click += new System.EventHandler(this.TaskMoveSelected);
			// 
			// mnContextDeleteTask
			// 
			this.mnContextDeleteTask.Name = "mnContextDeleteTask";
			this.mnContextDeleteTask.Size = new System.Drawing.Size(194, 22);
			this.mnContextDeleteTask.Text = "Delete task";
			this.mnContextDeleteTask.Click += new System.EventHandler(this.TaskDeleteSelected);
			// 
			// mnContextSeparator
			// 
			this.mnContextSeparator.Name = "mnContextSeparator";
			this.mnContextSeparator.Size = new System.Drawing.Size(191, 6);
			// 
			// mnContextSetCompleted
			// 
			this.mnContextSetCompleted.Image = ((System.Drawing.Image)(resources.GetObject("mnContextSetCompleted.Image")));
			this.mnContextSetCompleted.Name = "mnContextSetCompleted";
			this.mnContextSetCompleted.Size = new System.Drawing.Size(194, 22);
			this.mnContextSetCompleted.Text = "Mark task completed";
			this.mnContextSetCompleted.Click += new System.EventHandler(this.TaskToggleCompleted);
			// 
			// mnContextTimerStart
			// 
			this.mnContextTimerStart.Image = ((System.Drawing.Image)(resources.GetObject("mnContextTimerStart.Image")));
			this.mnContextTimerStart.Name = "mnContextTimerStart";
			this.mnContextTimerStart.Size = new System.Drawing.Size(194, 22);
			this.mnContextTimerStart.Text = "Start task timer";
			this.mnContextTimerStart.Click += new System.EventHandler(this.TaskTimerStart);
			// 
			// mnContextTimerPause
			// 
			this.mnContextTimerPause.Image = ((System.Drawing.Image)(resources.GetObject("mnContextTimerPause.Image")));
			this.mnContextTimerPause.Name = "mnContextTimerPause";
			this.mnContextTimerPause.Size = new System.Drawing.Size(194, 22);
			this.mnContextTimerPause.Text = "Pause task timer";
			this.mnContextTimerPause.Click += new System.EventHandler(this.TaskTimerPause);
			// 
			// mnContextEditPayment
			// 
			this.mnContextEditPayment.Image = ((System.Drawing.Image)(resources.GetObject("mnContextEditPayment.Image")));
			this.mnContextEditPayment.Name = "mnContextEditPayment";
			this.mnContextEditPayment.Size = new System.Drawing.Size(194, 22);
			this.mnContextEditPayment.Text = "Edit payment details...";
			this.mnContextEditPayment.Click += new System.EventHandler(this.TaskEditPayment);
			// 
			// mnContextNoteAdd
			// 
			this.mnContextNoteAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnContextNoteAdd.Image")));
			this.mnContextNoteAdd.Name = "mnContextNoteAdd";
			this.mnContextNoteAdd.Size = new System.Drawing.Size(194, 22);
			this.mnContextNoteAdd.Text = "Add a note...";
			this.mnContextNoteAdd.Click += new System.EventHandler(this.TaskNoteAdd);
			// 
			// mnContextNotesView
			// 
			this.mnContextNotesView.Image = ((System.Drawing.Image)(resources.GetObject("mnContextNotesView.Image")));
			this.mnContextNotesView.Name = "mnContextNotesView";
			this.mnContextNotesView.Size = new System.Drawing.Size(194, 22);
			this.mnContextNotesView.Text = "View notes...";
			this.mnContextNotesView.Click += new System.EventHandler(this.TaskNotesView);
			// 
			// imgPriority
			// 
			this.imgPriority.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPriority.ImageStream")));
			this.imgPriority.TransparentColor = System.Drawing.Color.Transparent;
			this.imgPriority.Images.SetKeyName(0, "Priority 1.png");
			this.imgPriority.Images.SetKeyName(1, "Priority 2.png");
			this.imgPriority.Images.SetKeyName(2, "Priority 3.png");
			// 
			// imgTick
			// 
			this.imgTick.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTick.ImageStream")));
			this.imgTick.TransparentColor = System.Drawing.Color.Transparent;
			this.imgTick.Images.SetKeyName(0, "tick");
			// 
			// imgNote
			// 
			this.imgNote.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgNote.ImageStream")));
			this.imgNote.TransparentColor = System.Drawing.Color.Transparent;
			this.imgNote.Images.SetKeyName(0, "note");
			// 
			// imgTimer
			// 
			this.imgTimer.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTimer.ImageStream")));
			this.imgTimer.TransparentColor = System.Drawing.Color.Transparent;
			this.imgTimer.Images.SetKeyName(0, "paused");
			this.imgTimer.Images.SetKeyName(1, "running");
			// 
			// tmrTimerRefresh
			// 
			this.tmrTimerRefresh.Enabled = true;
			this.tmrTimerRefresh.Interval = 1000;
			this.tmrTimerRefresh.Tick += new System.EventHandler(this.RefreshTimers);
			// 
			// mnContextTray
			// 
			this.mnContextTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mnOpenTodomoo,
									this.toolStripSeparator7,
									this.mnTrayNewTask,
									this.mnTrayNewSubTask,
									this.toolStripSeparator8,
									this.mnExit});
			this.mnContextTray.Name = "mnContextTray";
			this.mnContextTray.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.mnContextTray.Size = new System.Drawing.Size(242, 104);
			// 
			// mnOpenTodomoo
			// 
			this.mnOpenTodomoo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.mnOpenTodomoo.Name = "mnOpenTodomoo";
			this.mnOpenTodomoo.Size = new System.Drawing.Size(241, 22);
			this.mnOpenTodomoo.Text = "Open Todomoo...";
			this.mnOpenTodomoo.Click += new System.EventHandler(this.ShowMainForm);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(238, 6);
			// 
			// mnTrayNewTask
			// 
			this.mnTrayNewTask.Image = ((System.Drawing.Image)(resources.GetObject("mnTrayNewTask.Image")));
			this.mnTrayNewTask.Name = "mnTrayNewTask";
			this.mnTrayNewTask.Size = new System.Drawing.Size(241, 22);
			this.mnTrayNewTask.Text = "New task...";
			this.mnTrayNewTask.Click += new System.EventHandler(this.TaskNewRoot);
			// 
			// mnTrayNewSubTask
			// 
			this.mnTrayNewSubTask.Image = ((System.Drawing.Image)(resources.GetObject("mnTrayNewSubTask.Image")));
			this.mnTrayNewSubTask.Name = "mnTrayNewSubTask";
			this.mnTrayNewSubTask.Size = new System.Drawing.Size(241, 22);
			this.mnTrayNewSubTask.Text = "New sub-task of selected task...";
			this.mnTrayNewSubTask.Click += new System.EventHandler(this.TaskNewChild);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(238, 6);
			// 
			// mnExit
			// 
			this.mnExit.Name = "mnExit";
			this.mnExit.Size = new System.Drawing.Size(241, 22);
			this.mnExit.Text = "Exit";
			this.mnExit.Click += new System.EventHandler(this.Exit);
			// 
			// dlgSave
			// 
			this.dlgSave.DefaultExt = "csv";
			this.dlgSave.Filter = "CSV files|*.csv|All files|*.*";
			this.dlgSave.Title = "Export to CSV...";
			// 
			// dlgBackup
			// 
			this.dlgBackup.DefaultExt = "sqlite";
			this.dlgBackup.Filter = "SQLite files|*.sqlite|All files|*.*";
			this.dlgBackup.Title = "Do a backup in...";
			// 
			// panMove
			// 
			this.panMove.BackColor = System.Drawing.SystemColors.Info;
			this.panMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panMove.Controls.Add(this.lblMove);
			this.panMove.Controls.Add(this.btnMoveCancel);
			this.panMove.Controls.Add(this.pictureBox1);
			this.panMove.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panMove.Location = new System.Drawing.Point(0, 328);
			this.panMove.Name = "panMove";
			this.panMove.Padding = new System.Windows.Forms.Padding(5);
			this.panMove.Size = new System.Drawing.Size(892, 36);
			this.panMove.TabIndex = 7;
			// 
			// lblMove
			// 
			this.lblMove.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMove.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMove.Location = new System.Drawing.Point(21, 5);
			this.lblMove.Name = "lblMove";
			this.lblMove.Padding = new System.Windows.Forms.Padding(5);
			this.lblMove.Size = new System.Drawing.Size(755, 24);
			this.lblMove.TabIndex = 2;
			this.lblMove.Text = "Move to...";
			// 
			// btnMoveCancel
			// 
			this.btnMoveCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnMoveCancel.Location = new System.Drawing.Point(776, 5);
			this.btnMoveCancel.Name = "btnMoveCancel";
			this.btnMoveCancel.Size = new System.Drawing.Size(109, 24);
			this.btnMoveCancel.TabIndex = 1;
			this.btnMoveCancel.Text = "Cancel";
			this.btnMoveCancel.UseVisualStyleBackColor = true;
			this.btnMoveCancel.Click += new System.EventHandler(this.TaskMoveCancel);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(5, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// tmrPersistTimers
			// 
			this.tmrPersistTimers.Enabled = true;
			this.tmrPersistTimers.Interval = 30000;
			this.tmrPersistTimers.Tick += new System.EventHandler(this.PersistTimers);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(892, 386);
			this.Controls.Add(this.panMove);
			this.Controls.Add(this.treeTasks);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolCategories);
			this.Controls.Add(this.toolToolbar);
			this.Controls.Add(this.mnMenu);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnMenu;
			this.Name = "MainForm";
			this.Text = "Todomoo";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit);
			this.toolToolbar.ResumeLayout(false);
			this.toolToolbar.PerformLayout();
			this.mnMenu.ResumeLayout(false);
			this.mnMenu.PerformLayout();
			this.toolCategories.ResumeLayout(false);
			this.toolCategories.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.mnContextCategory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeTasks)).EndInit();
			this.mnContextTask.ResumeLayout(false);
			this.mnContextTray.ResumeLayout(false);
			this.panMove.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem mnHideCompleted;
		private System.Windows.Forms.ToolStripButton btnHideCompleted;
		private System.Windows.Forms.Timer tmrPersistTimers;
		private System.Windows.Forms.ToolStripMenuItem mnContextMoveTask;
		private System.Windows.Forms.ToolStripButton btnMove;
		private System.Windows.Forms.ToolStripMenuItem mnMove;
		private System.Windows.Forms.Button btnMoveCancel;
		private System.Windows.Forms.Label lblMove;
		private System.Windows.Forms.Panel panMove;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.SaveFileDialog dlgBackup;
		private System.Windows.Forms.ToolStripMenuItem mnDoBackupIn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem mnUpdates;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem mnExport;
		private System.Windows.Forms.ToolStripMenuItem mnFlatView;
		private System.Windows.Forms.ToolStripButton btnFlatView;
		private System.Windows.Forms.ToolStripMenuItem mnExpandAll;
		private System.Windows.Forms.ToolStripMenuItem mnCollapseAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripButton btnCollapseAll;
		private System.Windows.Forms.ToolStripButton btnExpandAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem mnTrayNewTask;
		private System.Windows.Forms.ToolStripMenuItem mnTrayNewSubTask;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem mnExitTodomoo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem todomooToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton btnMinimizeToTray;
		private System.Windows.Forms.ToolStripMenuItem mnExit;
		private System.Windows.Forms.ToolStripMenuItem mnOpenTodomoo;
		private System.Windows.Forms.ContextMenuStrip mnContextTray;
		private System.Windows.Forms.ToolStripMenuItem mnMinimizeToTray;
		private System.Windows.Forms.ToolStripSeparator mnContextSeparator;
		private System.Windows.Forms.ToolStripMenuItem mnContextEditTask;
		private System.Windows.Forms.ToolStripMenuItem mnContextNewSubTask;
		private System.Windows.Forms.ToolStripMenuItem mnContextNewTask;
		private System.Windows.Forms.ToolStripMenuItem mnContextNotesView;
		private System.Windows.Forms.ToolStripMenuItem mnContextNoteAdd;
		private System.Windows.Forms.ToolStripMenuItem mnContextEditPayment;
		private System.Windows.Forms.ToolStripMenuItem mnContextTimerPause;
		private System.Windows.Forms.ToolStripMenuItem mnContextTimerStart;
		private System.Windows.Forms.ToolStripMenuItem mnContextSetCompleted;
		private System.Windows.Forms.ToolStripMenuItem mnContextDeleteTask;
		private System.Windows.Forms.ContextMenuStrip mnContextTask;
		private System.Windows.Forms.Timer tmrTimerRefresh;
		private System.Windows.Forms.ImageList imgTimer;
		private System.Windows.Forms.ToolStripButton btnTimerStart;
		private System.Windows.Forms.ToolStripMenuItem mnSetCompleted;
		private System.Windows.Forms.ToolStripMenuItem mnTimerStart;
		private System.Windows.Forms.ToolStripMenuItem mnEditPayment;
		private System.Windows.Forms.ToolStripMenuItem mnNoteAdd;
		private System.Windows.Forms.ToolStripMenuItem mnNotesView;
		private System.Windows.Forms.ToolStripButton btnEditPayment;
		private System.Windows.Forms.ToolStripButton btnNoteAdd;
		private System.Windows.Forms.ToolStripButton btnNotesView;
		private System.Windows.Forms.ToolStripMenuItem mnTimerPause;
		private System.Windows.Forms.ToolStripButton btnTimerPause;
		private System.Windows.Forms.ToolStripButton btnSetCompleted;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ImageList imgNote;
		private System.Windows.Forms.ToolStripMenuItem mnDeleteTask;
		private System.Windows.Forms.ToolStripMenuItem mnEditTask;
		private System.Windows.Forms.ImageList imgTick;
		private System.Windows.Forms.ToolStripMenuItem mnNewSubTask;
		private System.Windows.Forms.ToolStripButton btnNewSubTask;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnNewTask;
		private System.Windows.Forms.ToolStripMenuItem mnNewTask;
		private System.Windows.Forms.ToolStripButton btnCategoryAll;
		private System.Windows.Forms.ImageList imgPriority;
		private BrightIdeasSoftware.OLVColumn colNotes;
		private BrightIdeasSoftware.OLVColumn colPrice;
		private BrightIdeasSoftware.OLVColumn colTimer;
		private BrightIdeasSoftware.OLVColumn colCompleted;
		private BrightIdeasSoftware.OLVColumn colDueDate;
		private BrightIdeasSoftware.OLVColumn colCreationDate;
		private BrightIdeasSoftware.OLVColumn colName;
		private BrightIdeasSoftware.OLVColumn colPriority;
		private BrightIdeasSoftware.OLVColumn colCategory;
		private System.Windows.Forms.ToolStripMenuItem mnTask;
		private System.Windows.Forms.ToolStripMenuItem mnHelp;
		private System.Windows.Forms.ToolStripButton btnAbout;
		private System.Windows.Forms.ToolStripMenuItem mnAbout;
		private System.Windows.Forms.ToolStripMenuItem mnProjectPage;
		private System.Windows.Forms.ToolStripMenuItem mnWebsite;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private BrightIdeasSoftware.TreeListView treeTasks;
		private System.Windows.Forms.ToolStripMenuItem mnDoBackup;
		private System.Windows.Forms.ToolStripButton btnOptions;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripMenuItem mnOptions;
		private System.Windows.Forms.ToolStripMenuItem mnTools;
		private System.Windows.Forms.ToolStrip toolToolbar;
		private System.Windows.Forms.ToolStripMenuItem mnContextDeleteCategory;
		private System.Windows.Forms.ContextMenuStrip mnContextCategory;
		private System.Windows.Forms.ToolStripMenuItem mnContextEditCategory;
		private System.Windows.Forms.ToolStripMenuItem mnDeleteCategory;
		private System.Windows.Forms.ToolStripMenuItem mnEditCategory;
		private System.Windows.Forms.ToolStripMenuItem mnNewCategory;
		private System.Windows.Forms.MenuStrip mnMenu;
		private System.Windows.Forms.ToolStripMenuItem mnCategory;
		private System.Windows.Forms.ToolStripButton btnCategoryNew;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolCategories;
		
	}
}
