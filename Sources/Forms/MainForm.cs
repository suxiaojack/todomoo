/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * MAIN FORM (MainForm.cs)
 * Application main form.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Resources;
using System.Windows.Forms;

namespace Todomoo {
	
	// MainForm.
	public partial class MainForm : Form {
		
		// Configuration and language
		public Utils.AppSettings Settings;
		public Languages.Language Lang;
		
		// Selected category
		private Category selected_category;
		
		// Application paths
		public static string ApplicationDirectory;
		public static string DatabasePath;
		public static string ConfigurationPath;
		public static string LanguageDirectory;
		public static string BackupDirectory;
		
		// Sorting column
		private BrightIdeasSoftware.OLVColumn sortColumn = null;
		private SortOrder sortOrder = SortOrder.Descending;
		
		// View
		private bool hideCompleted = false;
		private bool flatView = false;
		
		// Tray icon
		private NotifyIcon tray = null;
		private bool boolForceExit = false;
		
		// Auto updates
		Timer timerUpdates;
		UpdatesCheck u;
		
		// Task move
		private List<Task> moving = new List<Task>();
		
		// Constructor
		public MainForm() {
			
			// Required for Windows Forms designer support.
			InitializeComponent();
			
			// Create a reference of this in Todomoo engine.
			Todomoo.mainForm = this;
			
		}
		
		// Loading operations
		private void MainFormLoad(object sender, EventArgs e) {
            treeTasks.MultiSelect = true;
			// Hide move panel
			HideMovePanel();
			
			// Set up application pahs
			DirectoryInfo appdir = new DirectoryInfo(Application.ExecutablePath);
			appdir = new DirectoryInfo(appdir.Parent.FullName);
			ApplicationDirectory = appdir.FullName.TrimEnd(new char[] {'\\'}) + "\\";
			DatabasePath = ApplicationDirectory + "db.sqlite";
			ConfigurationPath = ApplicationDirectory + "todomoo.conf";
			BackupDirectory = ApplicationDirectory + "backups\\";
			LanguageDirectory = ApplicationDirectory + "lang\\";
			
			// Create the main engine from the database file
			try { Todomoo.OpenDatabase(DatabasePath); }
			catch (Exception ex) { ExitWithError("Unable to load main database (db.sqlite)!\n" + ex.Message); return; }
			
			// Create the default configuration, then load user settings
			Settings = new Utils.AppSettings(ConfigurationPath);
			ApplyDefaultSettings();
			Settings.Load();
			
			// Language inizialization
			Lang = new Languages.Language(LanguageDirectory);
			Lang.LoadLanguage(Settings.Get("lang").ToString());
			ApplyLanguage();
			
			// Form aspect
			WindowState = (Settings.Get("window_maximized").ToString() == "1") ? FormWindowState.Maximized : FormWindowState.Normal;
			if (Settings.Get("window_maximized").ToString() != "1") {
				Rectangle screen = Screen.PrimaryScreen.Bounds;
				int w = Math.Max(100, Math.Min(screen.Width  - 50, (int)Settings.Get("window_width" )));
				int h = Math.Max(100, Math.Min(screen.Height - 50, (int)Settings.Get("window_height")));
				int x = Math.Max(0,   Math.Min(screen.Width  - w,  (int)Settings.Get("window_xpos" )));
				int y = Math.Max(0,   Math.Min(screen.Height - h,  (int)Settings.Get("window_ypos" )));
				SetBounds(x, y, w, h); }
			UpdateFormAspect();
			UpdateColumnsAspect();
			treeTasks.Refresh();
			
			// Icons initialization
			btnCategoryAll.Image = IconColoured.GetSquared(Color.Gray);
			
			// Setup task tree and load categories. 
			// SelectedCategory set method automatically fill in the tree.
			SetupTaskTree();
			LoadCategories();
			int category_to_load_id = Utils.Conversion.ToInt(Settings.Get("selected_category").ToString());
			foreach (Category category in Todomoo.Categories) if (category.Id == category_to_load_id) SelectedCategory = category;
		
			// Updates auto check
			if (Settings.Get("updates_auto").ToString() == "1") {
				
				 // Wait 5secs and start to check for updates
				timerUpdates = new Timer();
				timerUpdates.Interval = 5000;
				timerUpdates.Tick += delegate {
					timerUpdates.Stop();
					u = new UpdatesCheck();
					u.Error += delegate(string message) {
						try { Utils.Debug.Write("Updates check error: " + message); } catch { } };
					u.NewVersionAvailable += delegate(string version, string url_setup, int size_setup, string url_portable, int size_portable) {
						try { this.Invoke((MethodInvoker)delegate { UpdatesForm.CreateWithNewVersion(Lang, Settings, version, url_setup, size_setup, url_portable, size_portable).ShowDialog(this); }); } catch { } };
					u.Check();
				};
				timerUpdates.Start();
				
			}
			
		}
		
		// Load categories in the toolbar
		private void LoadCategories() {
			
			toolCategories.SuspendLayout();
			
			// Load categories from the database
			Todomoo.LoadCategories();
			RedrawCategoriesBar();
			CountTasks();
			
			toolCategories.ResumeLayout();
			
			// Now selected a category
			SelectedCategory = selected_category;
			
		}
		
		// Load tasks in the tree list
		private void LoadTasks(bool NotInHackMoving = false) {
			
			treeTasks.SuspendLayout();
			
			// Cancel moving
            if (NotInHackMoving == false)
            {
                TaskMoveCancel();
            }
			
			// Load tasks.
			Todomoo.LoadTasks(SelectedCategory);
			treeTasks.SetObjects(flatView ? Todomoo.GetAllTasks() : Todomoo.GetRootTasks());
			if (treeTasks.GetItemCount() == 1) treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
			
			treeTasks.ResumeLayout();
			
			CountTasks();
			
			// Update selection
			TreeTasksSelectionChanged(this, null);
			
		}
		
		// Setup the object task tree
		private void SetupTaskTree() {
			
			treeTasks.SuspendLayout();
			
			// Completed status
			treeTasks.BooleanCheckStateGetter = delegate(object o) { 
				try { DateTime d = ((Task)o).Completed; return true; }
				catch { return false; } };
			
			// Set completed with checkbox
			treeTasks.BooleanCheckStatePutter = delegate(object o, bool completed) { 
				bool returned = true;
				try { if (completed) ((Task)o).Completed = DateTime.Now; else ((Task)o).RemoveCompleted(); ((Task)o).Update(); } catch { }
				try { DateTime d = ((Task)o).Completed; } catch { returned = false; }
				treeTasks.RefreshObject((Task)o);
				treeTasks.RefreshObject(Todomoo.GetRoot((Task)o));
				TreeTasksSelectionChanged();
				return returned;
			};
			
			// Name
			colName.AspectGetter = delegate(object o) { return ((Task)o).Name; };
			
			// Category
			colCategory.AspectGetter = delegate(object o) { return Todomoo.GetCategoryFromId(((Task)o).CategoryId).Name; };
			
			// Icon
			colName.ImageGetter = delegate(object o) { return IconColoured.GetSquared(((Task)o).Colour); };
			
			// Priority column
			colPriority.AspectGetter = delegate(object o) {
				return ((Task)o).Priority; };
			colPriority.ImageGetter = delegate(object o) {
				try { return imgPriority.Images[((Task)o).Priority]; }
				catch { return imgPriority.Images[0]; } };
			colPriority.AspectToStringConverter = delegate(object o) { 
				return ""; };
			
			// Dates
			colCreationDate.AspectGetter = delegate(object o) { 
				return ((Task)o).CreationDate; };
			colDueDate.AspectGetter = delegate(object o) { 
				try { return ((Task)o).DueDate;  }
				catch { return DateTime.MaxValue; } };
			colCompleted.AspectGetter = delegate(object o) { 
				try { return ((Task)o).Completed;  }
				catch { return DateTime.MaxValue; } };
			
			// Dates aspect converter
			colCreationDate.AspectToStringConverter = 
			colDueDate.AspectToStringConverter = 
			colCompleted.AspectToStringConverter = 
				delegate(object o) {
					if ((DateTime)o == DateTime.MaxValue) return ""; 
					if ((DateTime)o == DateTime.Today) return Lang.Get("today");
					if ((DateTime)o == DateTime.Today.AddDays(1)) return Lang.Get("tomorrow");
					if ((DateTime)o == DateTime.Today.AddDays(-1)) return Lang.Get("yesterday");
					return ((DateTime)o).ToShortDateString(); };
			
			// Timer
			colTimer.AspectGetter = delegate(object o) {
				try { return ((Task)o).Timer; } 
				catch { return 0; } };
			colTimer.ImageGetter = delegate(object o) {
				try { if (((Task)o).IsTimerRunning()) return imgTimer.Images["running"]; 
					  else if (((Task)o).Timer >= 0) return imgTimer.Images["paused"];
					  return null; }
				catch { return null; } };
			colTimer.AspectToStringConverter = delegate(object o) {
				return Task.TimerToString((int)o); };
			
			// Payment
			colPrice.AspectGetter = delegate(object o) {
				try { return ((Task)o).Price;  }
				catch { return 0F; } };
			colPrice.ImageGetter = delegate(object o) {
				try { DateTime d = ((Task)o).Paid; return imgTick.Images["tick"]; }
				catch { return null; } };
			colPrice.AspectToStringConverter = delegate(object o) {
				if ((float)o == 0F) return "";
				return ((float)o).ToString("0.00") + " " + Settings.Get("currency").ToString(); };
			
			// Notes
			colNotes.AspectGetter = delegate(object o) {
				try { return ((Task)o).NotesCount; }
				catch { return 0; } };
			colNotes.ImageGetter = delegate(object o) {
				try { return (((Task)o).NotesCount > 0) ? imgNote.Images["note"] : null; }
				catch { return null; } };
			colNotes.AspectToStringConverter = delegate(object o) {
				if ((int)o == 0) return "";
				return ((int)o).ToString(); };
			
			// Childern tasks
			treeTasks.CanExpandGetter = delegate(object o) {
				if (flatView) return false;
				return (Todomoo.GetChildrenTasks(((Task)o)).Count > 0); };
			treeTasks.ChildrenGetter = delegate(object o) { 
				if (flatView) return null;
				return Todomoo.GetChildrenTasks(((Task)o)); };
			
			treeTasks.ResumeLayout();
			
		}
		
		/// Selected category property get/set
		public Category SelectedCategory {
			get { return selected_category; }
			set {
				
				toolCategories.SuspendLayout();
				
				// Default value
				selected_category = null;
				ToolStripButton select = ((ToolStripButton)btnCategoryAll);
				
				// Loop on category button searching the selected one
				foreach (ToolStripItem item in toolCategories.Items) {
					if (!(item.Tag is Category)) continue;
					if (item.Tag != value) continue;
					selected_category = (Category)item.Tag;
					select = (ToolStripButton)item;
				}
				
				// Higlight selected item
				foreach (ToolStripItem item in toolCategories.Items) try {
					((ToolStripButton)item).Checked = (select == item);
				} catch {}
				
				// Enable and disable menu items
				mnDeleteCategory.Enabled = (selected_category != null);
				mnEditCategory.Enabled = (selected_category != null);
				
				toolCategories.ResumeLayout();
				
				// Load tasks
				LoadTasks();
				
			}
		}
		
		#region Editing methods - Tasks
		
		// Create a new root task
		private void TaskNewRoot(object sender, EventArgs e) { TaskNewRoot(); }
		private void TaskNewRoot() {
			try {
				
				// Create a new Task in this category
				Task new_task = new Task();
				new_task.CategoryId = (SelectedCategory == null) ? 0 : SelectedCategory.Id; 
				
				// Edit the new task in a Task form.
				TaskForm form = new TaskForm(Lang, Settings, new_task);
				if (!this.Visible) { // From tray...
					form.MinimizeBox = true;
					form.ShowInTaskbar = true;
					form.StartPosition = FormStartPosition.CenterScreen; }
				DialogResult res = form.ShowDialog();
				
				// If the task has been modified, save it to the DB.
				if (res != DialogResult.OK) return;
				new_task.Update(); // Save task in DB
				CountTasks();
				
				// Save pending notes
				ArrayList pending_notes = new_task.GetUnsavedNotes();
				foreach (Note note in pending_notes) { note.TaskId = new_task.Id; note.Save(); }
				if (pending_notes.Count > 0) { new_task.Reload(); new_task.ClearUnsavedNotes(); }
				
				// If the task is in the selected category, update the tree
				if (SelectedCategory != null) if (new_task.CategoryId != SelectedCategory.Id) return;
				Todomoo.Tasks.Add(new_task); // Add to tasks
				treeTasks.AddObject(new_task); // Add to tree (this is always a root task)
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
				
				// Select created task
				treeTasks.SelectedObject = new_task;
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_save_error"), Lang.Get("error")); return;
			}
		}
		
		// Create a new child task (parent is the selected task)
		private void TaskNewChild(object sender, EventArgs e) { TaskNewChild(); }
		private void TaskNewChild() {
			try {
				
				// Create a new Task with selected parent
				Task new_task = new Task();
				Task parent_task = (Task)treeTasks.GetSelectedObject();
				new_task.CategoryId = parent_task.CategoryId;
				new_task.ParentId = parent_task.Id;
				
				// Edit the new task in a Task form.
				TaskForm form = new TaskForm(Lang, Settings, new_task);
				if (!this.Visible) { // From tray...
					form.MinimizeBox = true;
					form.ShowInTaskbar = true;
					form.StartPosition = FormStartPosition.CenterScreen; }
				DialogResult res = form.ShowDialog();
				
				// If the task has been modified, save it to the DB.
				if (res != DialogResult.OK) return;
				new_task.Update(); // Save task in DB
				CountTasks();
				
				// Save pending notes
				ArrayList pending_notes = new_task.GetUnsavedNotes();
				foreach (Note note in pending_notes) { note.TaskId = new_task.Id; note.Save(); }
				if (pending_notes.Count > 0) { new_task.Reload(); new_task.ClearUnsavedNotes(); }
				
				// If the task is in the selected category, update the tree
				if (SelectedCategory != null) if (new_task.CategoryId != SelectedCategory.Id) return;
				Todomoo.Tasks.Add(new_task); // Add to tasks
				if (flatView) { /* Flat view? Add task and select it */
					treeTasks.AddObject(new_task);
					treeTasks.SelectedObject = new_task;
				} else { /* Tree view, update and expand parent */
					treeTasks.RefreshObject(Todomoo.GetParent(new_task)); // Refresh parent task  (this will add the created child), thanks to Dege
					treeTasks.Expand(parent_task); /* Expand parent task to view new task */ }
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_save_error"), Lang.Get("error")); return;
			}
		}
		
		// Edit the selected task
		private void TaskEditSelected(object sender, EventArgs e) { TaskEditSelected(); }
		private void TaskEditSelected() { TaskEditSelected(TaskForm.StartingTab.General); }
		private void TaskEditSelected(TaskForm.StartingTab starting_tab) {
			try {
				
				// Edit the selected task in a Task form.
				Task edit_task = (Task)treeTasks.GetSelectedObject();
				int oldCategory = edit_task.CategoryId;
				TaskForm form = new TaskForm(Lang, Settings, edit_task, starting_tab);
				DialogResult res = form.ShowDialog();
				
				// If the task has been modified, save it to the DB.
				if (res != DialogResult.OK) return;
				edit_task.Update(); // Save task in DB
				
				// Save pending notes
				ArrayList current_notes = edit_task.GetNotes();
				ArrayList pending_notes = edit_task.GetUnsavedNotes();
				foreach (Note note in current_notes) { bool d = true; foreach (Note p in pending_notes) if (note.Id == p.Id) d = false; if (d) Todomoo.RemoveNote(note); }
				foreach (Note note in pending_notes) { note.TaskId = edit_task.Id; note.Save(); }
				if ((pending_notes.Count > 0) || (current_notes.Count > 0)) { edit_task.Reload(); edit_task.ClearUnsavedNotes(); }
				
				// If the task is in the selected category, update the tree
				if ((oldCategory != edit_task.CategoryId) && (SelectedCategory != null)) LoadTasks();
				else {
					if (SelectedCategory != null) if (edit_task.CategoryId != SelectedCategory.Id) return;
					if (flatView) treeTasks.RefreshObject(edit_task);
					else treeTasks.RefreshObject(Todomoo.GetRoot(edit_task)); // Refresh root task (whis will refresh the edited child or itself)
					treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
					treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
				}
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_edit_error"), Lang.Get("error")); return;
			}
		}
		
		// Delete the selected task
		private void TaskDeleteSelected(object sender, EventArgs e) { TaskDeleteSelected(); }
		private void TaskDeleteSelected() {
			try {
				
				// Get task to delete
				Task to_delete = (Task)treeTasks.SelectedObject;
				bool confirm = false;
				
				// Show confirm message
				if (Todomoo.GetChildrenTasks(to_delete).Count > 0)
					 confirm = Utils.MsgDialog.Confirm(Lang.Get("task_delete_confirm_with_children"), Lang.Get("task_delete"));
				else confirm = Utils.MsgDialog.Confirm(Lang.Get("task_delete_confirm"), Lang.Get("task_delete"));
				
				// Delete task
				if (confirm) {
					Todomoo.RemoveTask(to_delete);
					Todomoo.LostTimers.Remove(to_delete.Id);
					treeTasks.RemoveObject(to_delete);
					if (flatView) LoadTasks(); /* Heavy, but stress avoiding :) */
					else treeTasks.RefreshObject(Todomoo.GetParent(to_delete));
					CountTasks();
				}
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_delete_error"), Lang.Get("error"));
			}
		}
		
		// Mark task (un)completed
		private void TaskToggleCompleted(object sender, EventArgs e) { TaskToggleCompleted(); }
		private void TaskToggleCompleted() {
			try {
				Task task = (Task)treeTasks.GetSelectedObject();
				bool now = false;
				try { DateTime d = task.Completed; now = true; } catch { now = false; }
				if (now) task.RemoveCompleted(); else task.Completed = DateTime.Now;
				task.Update(); // Save and reload task
				treeTasks.RefreshObject(task);
				treeTasks.RefreshObject(Todomoo.GetRoot(task));
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_edit_error"), Lang.Get("error"));
			}
		}
		
		// Change the priority of selected task
		private void TaskChangeSelectedPriority(object sender, EventArgs e) { TaskChangeSelectedPriority(); }
		private void TaskChangeSelectedPriority() {
			return; // One-click priority change disabled. I don't like it.
			#pragma warning disable 162
			try {
				Task task = (Task)treeTasks.GetSelectedObject();
				task.Priority = (task.Priority + 1) % 3; // Set priority
				task.Update(); // Save and reload task
				treeTasks.RefreshObject(task);
				treeTasks.RefreshObject(Todomoo.GetRoot(task));
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
			} catch {
				Utils.MsgDialog.Error(Lang.Get("priority_set_error"), Lang.Get("error"));
			}
			#pragma warning restore 162
		}
		
		// Start the task timer
		private void TaskTimerStart(object sender, EventArgs e) { TaskTimerStart(); }
		private void TaskTimerStart() {
			try {
				
				// Start the selected task timer
				Task edit_task = (Task)treeTasks.GetSelectedObject();
				edit_task.StartTimer();
				
				// If the task is in the selected category, update the tree
				if (SelectedCategory != null) if (edit_task.CategoryId != SelectedCategory.Id) return;
				if (flatView) treeTasks.RefreshObject(edit_task);
				else treeTasks.RefreshObject(Todomoo.GetRoot(edit_task)); // Refresh root task (whis will refresh the edited child or itself)
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_timer_error"), Lang.Get("error")); return;
			}
		}
		
		// Pause the task timer
		private void TaskTimerPause(object sender, EventArgs e) { TaskTimerPause(); }
		private void TaskTimerPause() {
			try {
				
				// Stop the selected task timer
				Task edit_task = (Task)treeTasks.GetSelectedObject();
				edit_task.StopTimer();
				
				// Remove task from the lost timers, if it's in...
				Todomoo.LostTimers.Remove(edit_task.Id);
				
				// Update task
				edit_task.Update(); // Save task in DB (because timer has been modified)
				
				// If the task is in the selected category, update the tree
				if (SelectedCategory != null) if (edit_task.CategoryId != SelectedCategory.Id) return;
				if (flatView) treeTasks.RefreshObject(edit_task);
				else treeTasks.RefreshObject(Todomoo.GetRoot(edit_task)); // Refresh root task (whis will refresh the editid child or itself)
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_timer_error"), Lang.Get("error")); return;
			}
		}
		
		// Edit task payment details
		private void TaskEditPayment(object sender, EventArgs e) { TaskEditPayment(); }
		private void TaskEditPayment() {
			TaskEditSelected(TaskForm.StartingTab.Payment);
		}
		
		// View task notes
		private void TaskNotesView(object sender, EventArgs e) { TaskNotesView(); }
		private void TaskNotesView() {
			TaskEditSelected(TaskForm.StartingTab.Notes);
		}
		
		// Add a task note
		private void TaskNoteAdd(object sender, EventArgs e) { TaskNoteAdd(); }
		private void TaskNoteAdd() {
			try {
				
				// Edit the selected task in a Task form, showing notes.
				Task edit_task = (Task)treeTasks.GetSelectedObject();
				TaskForm form = new TaskForm(Lang, Settings, edit_task, TaskForm.StartingTab.Notes);
				form.AddNewNoteAccordionItem(); // Add a new note
				form.giveFocusToNewNote = true;
				DialogResult res = form.ShowDialog();
				
				// If the task has been modified, save it to the DB.
				if (res != DialogResult.OK) return;
				edit_task.Update(); // Save task in DB
				
				// Save pending notes
				ArrayList current_notes = edit_task.GetNotes();
				ArrayList pending_notes = edit_task.GetUnsavedNotes();
				foreach (Note note in current_notes) { bool d = true; foreach (Note p in pending_notes) if (note.Id == p.Id) d = false; if (d) Todomoo.RemoveNote(note); }
				foreach (Note note in pending_notes) { note.TaskId = edit_task.Id; note.Save(); }
				if ((pending_notes.Count > 0) || (current_notes.Count > 0)) { edit_task.Reload(); edit_task.ClearUnsavedNotes(); }
				
				// If the task is in the selected category, update the tree
				if (SelectedCategory != null) if (edit_task.CategoryId != SelectedCategory.Id) return;
				if (flatView) treeTasks.RefreshObject(edit_task);
				else treeTasks.RefreshObject(Todomoo.GetRoot(edit_task)); // Refresh root task (whis will refresh the editid child or itself)
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_edit_error"), Lang.Get("error")); return;
			}
		}
		
		// Do a backup of the tasks
		private void TaskBackup(object sender, EventArgs e) { TaskBackup(false); }
		private void TaskBackup(bool auto) {
			DirectoryInfo backup_dir = new DirectoryInfo(MainForm.BackupDirectory);
			if (!backup_dir.Exists) backup_dir.Create();
			try {
				string backup_file = "db-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sqlite";
				File.Copy(DatabasePath, BackupDirectory + backup_file);
				if (!auto) Utils.MsgDialog.Info(Lang.Get("backup_done") + ": " + backup_file, Lang.Get("info"));
			} catch {
				Utils.MsgDialog.Error(Lang.Get("backup_error"), Lang.Get("error"));
			}
		}
		
		// Do a backup of the tasks in...
		private void TaskBackupIn(object sender, EventArgs e) { TaskBackupIn(); }
		private void TaskBackupIn() {
			if (dlgBackup.ShowDialog() != DialogResult.OK) return;
			try {
				File.Copy(DatabasePath, dlgBackup.FileName, true);
				Utils.MsgDialog.Info(Lang.Get("backup_done") + ":\n" + dlgBackup.FileName, Lang.Get("info"));
			} catch {
				Utils.MsgDialog.Error(Lang.Get("backup_error"), Lang.Get("error"));
			}
		}
		
		#endregion
		
		#region Editings method - Task move
		
		// Move the selected task
		private void TaskMoveSelected(object sender, EventArgs e) { 
			if (moving.Count>0) TaskMoveCancel();
			else TaskMoveSelected(); }
		private void TaskMoveSelected() {
			try {
				
				// Get task to move
                moving.Clear();
                foreach (Task t in treeTasks.SelectedObjects)
                {
                    moving.Add(t);
                }
				if (moving.Count == 0) return;
				btnMove.Checked = mnMove.Checked = true;
				
				// Show move panel
				ShowMovePanel();
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_moving_error") + ".", Lang.Get("error"));
			}
		}
		
		// Moving
		void TreeTasksMouseMove(object sender, MouseEventArgs e) {
			if (moving.Count == 0) return;
			try {
				
				// Get target task
				Task target = null;
				BrightIdeasSoftware.OLVListItem item = treeTasks.GetItemAt(e.X, e.Y);
				if (item != null) target = (Task)item.RowObject;
				
				// Change tip
				treeTasks.Cursor = Cursors.Hand;
				if (target != null) ShowMovePanel(target);
				else ShowMovePanel(SelectedCategory);
				
			} catch { }
		}
		
		// Confirm moving as sub task
		private void TaskMoveConfirm(Task target) {
			if (moving.Count == 0) return;
            foreach (Task tmoving in moving)
            {
                // A sub task
                if (target != null)
                {
                    if (!Todomoo.IsContained(tmoving, target))
                    {

                        // Update
                        tmoving.ParentId = target.Id;
                        tmoving.Update();
                        LoadTasks(true);

                        // Expand to view moved task
                        Task tl;
                        Stack<Task> s = new Stack<Task>();
                        foreach (Task t in Todomoo.Tasks) if (t.Id == target.Id)
                            {
                                s.Push(tl = t);
                                while (tl.ParentId > 0) s.Push(tl = Todomoo.GetParent(tl));
                                break;
                            }
                        while (s.Count > 0) treeTasks.Expand(s.Pop());

                    }
                    else if (tmoving != target)
                    {
                        Utils.MsgDialog.Error(Lang.Get("task_moving_error") + ".", Lang.Get("error"));
                    }
                }

                // As root
                if ((target == null) && (SelectedCategory != null))
                {

                    // Update
                    tmoving.ParentId = 0;
                    tmoving.Update();
                    LoadTasks(true);

                }
            }
			// Done
			TaskMoveCancel();
			
		}
		
		// Confirm moving in a category
		private void TaskMoveConfirm(Category target) {
			if (moving.Count == 0 ) return;
            foreach (Task tmoving in moving)
            {
                // In category
                if (target != null)
                {

                    // Update
                    tmoving.ParentId = 0; // No more child
                    Todomoo.ChangeCategoryToHierarchy(tmoving, target.Id);
                    tmoving.Update();
                    LoadTasks(true);
                }
            }
			// Done
			TaskMoveCancel();
			
		}
		
		// Cancel task moving
		private void TaskMoveCancel(object sender, EventArgs e) { TaskMoveCancel(); }
		private void TaskMoveCancel() {
			moving.Clear();
			btnMove.Checked = mnMove.Checked = false;
			treeTasks.Cursor = Cursors.Default;
			toolCategories.Cursor = Cursors.Default;
			HideMovePanel();
		}
		
		// Show the "task move" tip
		private void ShowMovePanel() { ShowMovePanel(null); }
		private void ShowMovePanel(object target) {
			if (moving.Count == 0 ) { HideMovePanel(); return; }
			
			// Show panel if not visible
			if (!panMove.Visible) {
				panMove.Visible = true;
				treeTasks.Height -= panMove.Height;
			}
			
			// Show tip
			if ((target != null) && (target is Category)) 	lblMove.Text = Lang.Get("task_move_in") + ": " + ((Category)target).Name;
			else if ((target != null) && (target is Task)) 	lblMove.Text = Lang.Get("task_move_as_sub_of") + ": " + ((Task)target).Name;
			else lblMove.Text = Lang.Get("task_move_in") + "...";
			
		}
		
		// Hide the "task move" tip
		private void HideMovePanel() {
			if (moving.Count > 0 ) { ShowMovePanel(); return; }
			
			// Hide the panel
			if (panMove.Visible) {
				treeTasks.Height += panMove.Height;
				panMove.Visible = false;
			}
			
		}
		
		#endregion
		
		#region Editing methods - Categories
		
		private void CategoryNew(object sender, EventArgs e) { CategoryNew(); }
		private void CategoryNew() {
			try {
				
				// Edit a new category in a Category form.
				Category new_category = new Category();
				CategoryForm form = new CategoryForm(Lang, new_category);
				DialogResult res = form.ShowDialog();
				
				// If the category has been modified, save it to the DB.
				if (res != DialogResult.OK) return;
				new_category.Update(); // Save task in DB
				
				// Add category and update the category bar
				Todomoo.Categories.Add(new_category);
				RedrawCategoriesBar();
				SelectedCategory = new_category;
				CountTasks();
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_save_error"), Lang.Get("error")); return;
			}
		}
		
		private void CategoryEditSelected(object sender, EventArgs e) { CategoryEditSelected(); }
		private void CategoryEditSelected() {
			if (SelectedCategory == null) return;
			try {
				
				// Edit the selected category in a Category form.
				Category edit_category = SelectedCategory;
				CategoryForm form = new CategoryForm(Lang, edit_category);
				DialogResult res = form.ShowDialog();
				
				// If the category has been modified, save it to the DB.
				if (res != DialogResult.OK) return;
				edit_category.Update(); // Save task in DB
				
				// Update the category bar
				RedrawCategoriesBar();
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_save_error"), Lang.Get("error")); return;
			}
		}
		
		private void CategoryDeleteSelected(object sender, EventArgs e) { CategoryDeleteSelected(); }
		private void CategoryDeleteSelected() {
			if (SelectedCategory == null) return;
			try { 
				
				// Ask if not empty
				if (SelectedCategory.GetTasksCount() > 0) {
					if (!Utils.MsgDialog.Question(Lang.Get("category_delete_confirm"), Lang.Get("warning"))) return;
				}
				
				// Remove category and update bar
				Todomoo.RemoveCategory(SelectedCategory);
				RedrawCategoriesBar();
				SelectedCategory = null;
				
			} catch (Exception ex) {
				if (ex.Message == "NOT EMPTY") Utils.MsgDialog.Warning(Lang.Get("category_delete_not_empty") + ".", Lang.Get("warning"));
				else Utils.MsgDialog.Error(Lang.Get("category_delete_error"), Lang.Get("error"));
			}
		}
		
		#endregion
		
		#region GUI methods
		
		public void CountTasks() {
			
			// Total tasks, in this category, hidden
			int total = Todomoo.CountTasks();
			int this_cat = (SelectedCategory != null) ? SelectedCategory.GetTasksCount() : total;
			int completed = Todomoo.CountCompletedTasks();
			lblStatus.Text  = total + " " + Lang.Get(total == 1 ? "status_total_task" : "status_total_tasks") + ", ";
			if (SelectedCategory != null) lblStatus.Text += this_cat + " " + Lang.Get(this_cat == 1 ? "status_cat_task"   : "status_cat_tasks")    + ", ";
			lblStatus.Text += completed + " " + Lang.Get(completed == 1 ? "status_completed_task": "status_completed_tasks") + ". ";
			
			// For each item in the category bar
			toolCategories.SuspendLayout();
			foreach (ToolStripItem item in toolCategories.Items) try {
				int count = ((Category)item.Tag).GetTasksCount();
				((ToolStripButton)item).ToolTipText = "(" + count + " " + Lang.Get(count == 1 ? "task" : "tasks") + ")";
			} catch {}
			toolCategories.ResumeLayout();
			
		}
		
		public void RedrawCategoriesBar() {
			
			toolCategories.SuspendLayout();
			
			// Clear buttons
			for (int i = 0; i < toolCategories.Items.Count; i++) 
				if (toolCategories.Items[i].Tag is Category)
					toolCategories.Items.Remove(toolCategories.Items[i--]);
			
			// Create buttons
			Todomoo.Categories.Sort(new CategoryComparer());
			foreach (Category category in Todomoo.Categories) {
				ToolStripButton item = new ToolStripButton();
				item.Name = "cat" + category.Id;
				item.Tag = category;
				item.Text = category.Name;
				item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
				item.Image = IconColoured.GetSquared(category.Colour);
				item.MouseEnter += ToolCategoriesItemMouseEnter;
				item.MouseLeave += ToolCategoriesItemMouseLeave;
				toolCategories.Items.Add(item);
			}
			
			// Selected category
			foreach (ToolStripItem item in toolCategories.Items) try {
				((ToolStripButton)item).Checked = (SelectedCategory == (Category)item.Tag);
			} catch {}
			
			toolCategories.ResumeLayout();
			
		}
		
		private void UpdateFormAspect() {
			
			SuspendLayout();
			
			// Reselect current category. Needed for keeping sorting.
			SelectedCategory = SelectedCategory;
			
			// Interface
			mnMenu.RenderMode = mnContextCategory.RenderMode = mnContextTask.RenderMode = (Settings.Get("style_menu").ToString() == "0" ? ToolStripRenderMode.System : ToolStripRenderMode.Professional);
			toolToolbar.RenderMode = (Settings.Get("style_toolbar").ToString() == "0" ? ToolStripRenderMode.System : ToolStripRenderMode.Professional);
			toolCategories.RenderMode = (Settings.Get("style_categories").ToString() == "0" ? ToolStripRenderMode.System : ToolStripRenderMode.Professional);
			
			ResumeLayout();
			
		}
		
		private void UpdateColumnsAspect() {
			
			treeTasks.SuspendLayout();
			
			try {
				
				// Width
				colName.Width         = Utils.Conversion.ToInt(Settings.Get("col_name"));
				colCategory.Width     = Utils.Conversion.ToInt(Settings.Get("col_category"));
				colPriority.Width     = Utils.Conversion.ToInt(Settings.Get("col_priority"));
				colCreationDate.Width = Utils.Conversion.ToInt(Settings.Get("col_creation_date"));
				colDueDate.Width      = Utils.Conversion.ToInt(Settings.Get("col_due_date"));
				colCompleted.Width    = Utils.Conversion.ToInt(Settings.Get("col_completed"));
				colTimer.Width        = Utils.Conversion.ToInt(Settings.Get("col_timer"));
				colPrice.Width        = Utils.Conversion.ToInt(Settings.Get("col_price"));
				colNotes.Width        = Utils.Conversion.ToInt(Settings.Get("col_notes"));
				
				// Visibility
				colCategory.IsVisible     = (Settings.Get("col_category_v").ToString()      != "0");
				colPriority.IsVisible     = (Settings.Get("col_priority_v").ToString()      != "0");
				colCreationDate.IsVisible = (Settings.Get("col_creation_date_v").ToString() != "0");
				colDueDate.IsVisible      = (Settings.Get("col_due_date_v").ToString()      != "0");
				colCompleted.IsVisible    = (Settings.Get("col_completed_v").ToString()     != "0");
				colTimer.IsVisible        = (Settings.Get("col_timer_v").ToString()         != "0");
				colPrice.IsVisible        = (Settings.Get("col_price_v").ToString()         != "0");
				colNotes.IsVisible        = (Settings.Get("col_notes_v").ToString()         != "0");
				
				// Sorting
				string sort_o = "0";
				BrightIdeasSoftware.OLVColumn sort_c = null;
				if (Settings.Get("col_name_s").ToString() != "0"         ) { sort_c = colName;         sort_o = Settings.Get("col_name_s").ToString();          }
				if (Settings.Get("col_category_s").ToString() != "0"     ) { sort_c = colCategory;     sort_o = Settings.Get("col_category_s").ToString();      }
				if (Settings.Get("col_priority_s").ToString() != "0"     ) { sort_c = colPriority;     sort_o = Settings.Get("col_priority_s").ToString();      }
				if (Settings.Get("col_creation_date_s").ToString() != "0") { sort_c = colCreationDate; sort_o = Settings.Get("col_creation_date_s").ToString(); }
				if (Settings.Get("col_due_date_s").ToString() != "0"     ) { sort_c = colDueDate;      sort_o = Settings.Get("col_due_date_s").ToString();      }
				if (Settings.Get("col_completed_s").ToString() != "0"    ) { sort_c = colCompleted;    sort_o = Settings.Get("col_completed_s").ToString();     }
				if (Settings.Get("col_timer_s").ToString() != "0"        ) { sort_c = colTimer;        sort_o = Settings.Get("col_timer_s").ToString();         }
				if (Settings.Get("col_price_s").ToString() != "0"        ) { sort_c = colPrice;        sort_o = Settings.Get("col_price_s").ToString();         }
				if (Settings.Get("col_notes_s").ToString() != "0"        ) { sort_c = colNotes;        sort_o = Settings.Get("col_notes_s").ToString();         }
				if (sort_c != null) treeTasks.Sort(sort_c, (sort_o == "1") ? SortOrder.Ascending : SortOrder.Descending);
				
				// Position
				colName.DisplayIndex = 0;
				colCategory.DisplayIndex     = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_category_o")),      treeTasks.ColumnsInDisplayOrder.Count - 1);
				colPriority.DisplayIndex     = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_priority_o")),      treeTasks.ColumnsInDisplayOrder.Count - 1);
				colCreationDate.DisplayIndex = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_creation_date_o")), treeTasks.ColumnsInDisplayOrder.Count - 1);
				colDueDate.DisplayIndex      = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_due_date_o")),      treeTasks.ColumnsInDisplayOrder.Count - 1);
				colCompleted.DisplayIndex    = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_completed_o")),     treeTasks.ColumnsInDisplayOrder.Count - 1);
				colTimer.DisplayIndex        = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_timer_o")),         treeTasks.ColumnsInDisplayOrder.Count - 1);
				colPrice.DisplayIndex        = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_price_o")),         treeTasks.ColumnsInDisplayOrder.Count - 1);
				colNotes.DisplayIndex        = Math.Min(Utils.Conversion.ToInt(Settings.Get("col_notes_o")),         treeTasks.ColumnsInDisplayOrder.Count - 1);
				
				// Recreate columns in right position
				foreach (BrightIdeasSoftware.OLVColumn col in treeTasks.ColumnsInDisplayOrder) {
					if (col.DisplayIndex == 0) continue;
					treeTasks.AllColumns.Remove(col);
					treeTasks.AllColumns.Add(col);
				}
				
			} catch { }
			
			// Rebuild columns
			treeTasks.RebuildColumns();
			
			treeTasks.ResumeLayout();
			
		}
		
		private int GetSortingNumberFor(BrightIdeasSoftware.OLVColumn col) {
			if (sortColumn == null) return 0;
			if (sortColumn != col) return 0;
			if (sortOrder == SortOrder.None) return 0;
			if (sortOrder == SortOrder.Ascending) return 1;
			if (sortOrder == SortOrder.Descending) return 2;
			return 0;
		}
		
		private void RefreshTimers(object sender, EventArgs e) { RefreshTimers(); }
		private void RefreshTimers() {
			
			// Refresh running tasks
			bool running_timers = false;
			foreach (Task t in Todomoo.Tasks) if (t.IsTimerRunning()) {
				running_timers = true;
				if (flatView) treeTasks.RefreshObject(t);
				else treeTasks.RefreshObject(Todomoo.GetRoot(t)); 
			}
			
			// First and last item refreshing bug
			if (running_timers) {
				treeTasks.RefreshItem(treeTasks.GetItem(0)); // Refresh first item. Bug?
				treeTasks.RefreshItem(treeTasks.GetItem(treeTasks.GetItemCount() - 1)); // Refresh last item. Bug?
			}
			
		}
		
		private void PersistTimers(object sender, EventArgs e) { PersistTimers(); }
		private void PersistTimers() {
			
			// Save running timers to DB (avoid losing them on crashes!)
			SuspendLayout();
			foreach (Task t in Todomoo.Tasks) if (t.IsTimerRunning()) {
				t.StopTimer();
				t.Save();
				t.StartTimer();
			}
			ResumeLayout();
			
		}
		
		private void MinimizeToTray(object sender, EventArgs e) { MinimizeToTray(); }
		private void MinimizeToTray() {
			
			// Tray icon already created
			if (tray != null) {
				tray.Visible = true;
				this.Hide();
				return;
			}
			
			// Setup tray icon
			tray = new NotifyIcon();
			tray.Icon = this.Icon;
			Version v = new Version(Application.ProductVersion);
			tray.Text = "Todomoo "+ v.Major + "." + v.Minor;
			
			// Create menu
			tray.ContextMenuStrip = mnContextTray;
			
			// Double click opens Todomoo
			tray.DoubleClick += ShowMainForm;
			
			// Hide form and show tray icon
			tray.Visible = true;
			this.Hide();
			
		}
		
		private void ShowOptionForm(object sender, EventArgs e) { ShowOptionForm(); }
		private void ShowOptionForm() {
			OptionsForm form = new OptionsForm(Lang, Settings);
			if (form.ShowDialog(this) == DialogResult.Cancel) return;
			Lang.LoadLanguage(Settings.Get("lang").ToString());
			UpdateFormAspect();
			CountTasks();
			ApplyLanguage();
		}
		
		private void ShowAboutForm(object sender, EventArgs e) { ShowAboutForm(); }
		private void ShowAboutForm() {
			AboutForm form = new AboutForm(Lang);
			form.ShowDialog(this);
		}
		
		private void LaunchWebsite(object sender, EventArgs e) { LaunchWebsite(); }
		private void LaunchWebsite() {
			System.Diagnostics.Process.Start("http://todomoo.sourceforge.net/");
		}
		
		private void LaunchProjectPage(object sender, EventArgs e) { LaunchProjectPage(); }
		private void LaunchProjectPage() {
			System.Diagnostics.Process.Start("http://sourceforge.net/projects/todomoo/");
		}
		
		private void ShowMainForm(object sender, EventArgs e) { ShowMainForm(); }
		private void ShowMainForm() {
			this.Show();
			if (tray != null) tray.Visible = false;
		}
		
		void BtnHideCompletedClick(object sender, EventArgs e) {
			hideCompleted = !hideCompleted;
			btnHideCompleted.Checked = mnHideCompleted.Checked = hideCompleted;
			Todomoo.LoadCompletedTasks = !hideCompleted;
			LoadTasks();
		}
		
		void BtnFlatViewClick(object sender, EventArgs e) {
			flatView = !flatView;
			btnFlatView.Checked = mnFlatView.Checked = flatView;
			LoadTasks();
		}
		
		void BtnExpandAllClick(object sender, EventArgs e) {
			if (flatView) {
				flatView = false;
				btnFlatView.Checked = mnFlatView.Checked = flatView;
				LoadTasks(); }
			treeTasks.ExpandAll();
		}
		
		void BtnCollapseAllClick(object sender, EventArgs e) {
			if (flatView) {
				flatView = false;
				btnFlatView.Checked = mnFlatView.Checked = flatView;
				LoadTasks(); }
			treeTasks.CollapseAll();
			
		}
		
		void MnExportClick(object sender, EventArgs e) {
			if (dlgSave.ShowDialog() != DialogResult.OK) return;
			try {
				Todomoo.ExportToCSV(dlgSave.FileName);
				Utils.MsgDialog.Info(Lang.Get("export_csv_ok") + ":\n" + dlgSave.FileName, Lang.Get("export_csv"));
			} catch {
				Utils.MsgDialog.Error(Lang.Get("export_csv_error"), Lang.Get("export_csv"));
			}
		}
		
		void MnUpdatesClick(object sender, EventArgs e) {
			if (u != null) u.Stop();
			if (timerUpdates != null) timerUpdates.Stop();
			UpdatesForm form = new UpdatesForm(Lang, Settings);
			form.ShowDialog(this);
		}
		
		#endregion
		
		#region GUI events - Task tree
		
		// Tree cell click (generated using CellEditing event).
		// This works only on editable cells.
		void TreeTasksCellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e) {
			e.Cancel = true;
			
			// Am I moving a task?
			if (moving.Count > 0) {
                //TODO:确认入口2
				TaskMoveConfirm((Task)e.RowObject);
			
			// View notes
			} else if (e.Column == colNotes) {
				TaskEditSelected(TaskForm.StartingTab.Notes);
			
			// Change task priority
			} else if (e.Column == colPriority) {
				TaskChangeSelectedPriority();
			}
			
		}
		
		// Tree item double click (generated using the tree double click).
		// This works on the full row of every item.
		// Simply unfolds the selected item, or edit if it has no subtasks.
		void TreeTasksDoubleClick(object sender, EventArgs e) {
			object o = treeTasks.GetSelectedObject();
			if (o == null) return;
			if (treeTasks.IsExpanded(o)) treeTasks.Collapse(o);
			else {
				treeTasks.Expand(o);
				
				// If now is not expanded, then it has no children. Go edit...
				if (!treeTasks.IsExpanded(o)) TaskEditSelected();
				
			}
		}
		
		// Tree item middle click (generated using the mouse up event).
		// This works on the full row of every item.
		void TreeTasksMouseUp(object sender, MouseEventArgs e){
			
			// Am I moving?
			if ((e.Button == MouseButtons.Left) && (moving.Count>0)) {
				Task target = null;
				BrightIdeasSoftware.OLVListItem item = treeTasks.GetItemAt(e.X, e.Y);
				if (item != null) target = (Task)item.RowObject;
                //TODO:确认入口
				TaskMoveConfirm(target);
			}
			
			// Simple middle click
			if (e.Button != MouseButtons.Middle) return;
			try {
				BrightIdeasSoftware.OLVListItem item = treeTasks.GetItemAt(e.X, e.Y);
				item.Selected = true;
				TaskEditSelected();
			} catch { }
			
		}
		
		// This store the current sorting method.
		void TreeTasksAfterSorting(object sender, BrightIdeasSoftware.AfterSortingEventArgs e) {
			sortColumn = e.ColumnToSort;
			sortOrder = e.SortOrder;
		}
		
		// Disable and enable buttons depending on task selection
		void TreeTasksSelectionChanged(object sender, EventArgs e) { TreeTasksSelectionChanged(); }
		void TreeTasksSelectionChanged() {
			
			// Based on selection yes/no (toolbar and menu)
			Task selected =treeTasks.SelectedObjects.Count > 0 ? (Task)treeTasks.SelectedObjects[0]:null;
			mnNewSubTask.Enabled = btnNewSubTask.Enabled = mnTrayNewSubTask.Enabled = (selected != null);
			mnEditTask.Enabled = mnDeleteTask.Enabled = (selected != null);
			mnSetCompleted.Enabled = btnSetCompleted.Enabled = (selected != null);
			mnTimerStart.Enabled = btnTimerStart.Enabled = false;
			mnTimerPause.Enabled = btnTimerPause.Enabled = false;
			mnEditPayment.Enabled = btnEditPayment.Enabled = (selected != null);
			mnNoteAdd.Enabled = btnNoteAdd.Enabled = (selected != null);
			mnNotesView.Enabled = btnNotesView.Enabled = false;
			mnMove.Enabled = btnMove.Enabled = (selected != null);
			
			// Based on selection yes/no (context menu)
			mnContextNewSubTask.Enabled = (selected != null);
			mnContextEditTask.Enabled = mnContextDeleteTask.Enabled = (selected != null);
			mnContextMoveTask.Enabled = (selected != null);
			mnContextSetCompleted.Enabled = (selected != null);
			mnContextTimerStart.Enabled = (selected != null);
			mnContextTimerPause.Enabled = (selected != null);
			mnContextEditPayment.Enabled = (selected != null);
			mnContextNoteAdd.Enabled = (selected != null);
			mnContextNotesView.Enabled =  (selected != null);
			
			// Context menu visibility
			mnContextNewTask.Visible = (selected == null);
			mnContextNewSubTask.Visible = (selected != null);
			mnContextEditTask.Visible = (selected != null);
			mnContextMoveTask.Visible = (selected != null);
			mnContextDeleteTask.Visible = (selected != null);
			mnContextSeparator.Visible = (selected != null);
			mnContextSetCompleted.Visible = (selected != null);
			mnContextTimerStart.Visible = (selected != null);
			mnContextTimerPause.Visible = (selected != null);
			mnContextEditPayment.Visible = (selected != null);
			mnContextNoteAdd.Visible = (selected != null);
			mnContextNotesView.Visible = (selected != null);
			
			// Tray "new sub task" text
			if (selected != null) mnTrayNewSubTask.Text = Lang.Get("task_sub_new_tray") + " " + selected.Name + "...";
			else mnTrayNewSubTask.Text = Lang.Get("task_sub_new") + "...";
			
			// Specific for task properties
			if (selected == null) return;
			try { DateTime d = selected.Completed; btnSetCompleted.Checked = true; } catch { btnSetCompleted.Checked = false; }
			mnSetCompleted.Text = btnSetCompleted.Text = mnContextSetCompleted.Text = (btnSetCompleted.Checked ? Lang.Get("task_set_uncompleted") : Lang.Get("task_set_completed"));
			mnTimerStart.Enabled = btnTimerStart.Enabled = mnContextTimerStart.Enabled = (!selected.IsTimerRunning());
			mnTimerPause.Enabled = btnTimerPause.Enabled = mnContextTimerPause.Enabled = (selected.IsTimerRunning());
			mnNotesView.Enabled = btnNotesView.Enabled = mnContextNotesView.Enabled = (selected.NotesCount > 0);
			
		}
		
		#endregion
		
		#region GUI events - Categories bar
		
		// Categories toolbar left click
		void ToolCategoriesItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			
			// New category button
			if (e.ClickedItem == btnCategoryNew) {
				CategoryNew();
			
			// All category button
			} else if (e.ClickedItem == btnCategoryAll) {
				SelectedCategory = null;
				
			// Am I moving?
			} else if ((moving.Count>0) && (e.ClickedItem.Tag is Category)) {
				TaskMoveConfirm((Category)e.ClickedItem.Tag);
			
			// Single category switch
			} else if (e.ClickedItem.Tag is Category) {
				SelectedCategory = (Category)e.ClickedItem.Tag;
			}
			
		}
		
		// Item mouse hover, used for task moving
		void ToolCategoriesItemMouseEnter(object sender, EventArgs e) {
			if (moving.Count==0) return;
			try {
				
				// Get target category
				Category target = (Category)((ToolStripItem)sender).Tag;
				
				// Change tip
				toolCategories.Cursor = ((target != null) ? Cursors.Hand : Cursors.Default);
				ShowMovePanel(target);
				
			} catch { }
		}
		void ToolCategoriesItemMouseLeave(object sender, EventArgs e) {
			toolCategories.Cursor = Cursors.Default;
		}
		
		// Categories toolbar right click
		void ToolCategoriesMouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				
				// Select clicked item, show context menu
				try {
					ToolStripItem item = toolCategories.GetItemAt(e.Location);
					if (!(item.Tag is Category)) return;
					if (SelectedCategory != null) if (SelectedCategory != (Category)item.Tag) 
						SelectedCategory = (Category)item.Tag;
					if (SelectedCategory == null)
						SelectedCategory = (Category)item.Tag;
					mnContextCategory.Show(toolCategories, e.Location);
				} catch {}
				
			}
		}
		
		#endregion
		
		#region Language and default settings loading
		
		// Definition of default settings
		private void ApplyDefaultSettings() {
			
			SuspendLayout();
			
			// Language and window parameters
			Settings.Set("lang", "en");
			Settings.Set("currency", "�");
			Settings.Set("window_maximized", 0);
			Settings.Set("window_xpos", 100);
			Settings.Set("window_ypos", 100);
			Settings.Set("window_width", 900);
			Settings.Set("window_height", 420);
			Settings.Set("window_minimize_when_closing", 0);
			
			// Selected category
			Settings.Set("selected_category", 0);
			
			// Interface settings
			Settings.Set("style_menu", 0);
			Settings.Set("style_toolbar", 0);
			Settings.Set("style_categories", 0);
			
			// Backup settings
			Settings.Set("backup_automatic", 1);
			
			// Tree columns
			Settings.Set("col_name", 260);
			Settings.Set("col_category", 100);
			Settings.Set("col_priority", 65);
			Settings.Set("col_creation_date", 110);
			Settings.Set("col_due_date", 110);
			Settings.Set("col_completed", 110);
			Settings.Set("col_timer", 70);
			Settings.Set("col_price", 70);
			Settings.Set("col_notes", 65);
			Settings.Set("col_category_v", 1);
			Settings.Set("col_priority_v", 1);
			Settings.Set("col_creation_date_v", 1);
			Settings.Set("col_due_date_v", 1);
			Settings.Set("col_completed_v", 1);
			Settings.Set("col_timer_v", 1);
			Settings.Set("col_price_v", 1);
			Settings.Set("col_notes_v", 1);
			Settings.Set("col_name_s", 0);
			Settings.Set("col_category_s", 0);
			Settings.Set("col_priority_s", 0);
			Settings.Set("col_creation_date_s", 2);
			Settings.Set("col_due_date_s", 0);
			Settings.Set("col_completed_s", 0);
			Settings.Set("col_timer_s", 0);
			Settings.Set("col_price_s", 0);
			Settings.Set("col_notes_s", 0);
			Settings.Set("col_category_o", 1);
			Settings.Set("col_priority_o", 2);
			Settings.Set("col_creation_date_o", 3);
			Settings.Set("col_due_date_o", 4);
			Settings.Set("col_completed_o", 5);
			Settings.Set("col_timer_o", 6);
			Settings.Set("col_price_o", 7);
			Settings.Set("col_notes_o", 8);
			
			// Notes
			Settings.Set("note_monospace", 0);
			Settings.Set("note_word_wrap", 0);
			Settings.Set("note_form_width", 577);
			Settings.Set("note_form_height", 427);
			
			// Updates
			Settings.Set("updates_auto", 1);
			
			ResumeLayout();
			
		}
		
		// Apply language to form
		private void ApplyLanguage() {
			
			SuspendLayout();
			
			// Menu
			mnTask.Text = Lang.Get("task").Substring(0, 1).ToUpper() + Lang.Get("task").Substring(1);
			mnCategory.Text = Lang.Get("category");
			mnNewCategory.Text = Lang.Get("category_new") + "...";
			mnEditCategory.Text = Lang.Get("category_edit_current");
			mnDeleteCategory.Text = Lang.Get("category_delete_current");
			mnNewTask.Text = Lang.Get("task_new") + "...";
			mnTrayNewTask.Text = Lang.Get("task_new") + "...";
			mnNewSubTask.Text = Lang.Get("task_sub_new") + "...";
			mnTrayNewSubTask.Text = Lang.Get("task_sub_new") + "...";
			mnEditTask.Text = Lang.Get("task_edit") + "...";
			mnMove.Text = Lang.Get("task_move") + "...";
			mnDeleteTask.Text = Lang.Get("task_delete");
			mnSetCompleted.Text = Lang.Get("task_set_completed");
			mnTimerStart.Text = Lang.Get("task_timer_start");
			mnTimerPause.Text = Lang.Get("task_timer_pause");
			mnEditPayment.Text = Lang.Get("task_payment_edit") + "...";
			mnNoteAdd.Text = Lang.Get("note_new") + "...";
			mnNotesView.Text = Lang.Get("task_notes_view") + "...";
			mnTools.Text = Lang.Get("tools");
			mnOptions.Text = Lang.Get("options") + "...";			
			mnDoBackup.Text = Lang.Get("backup_do");
			mnExport.Text = dlgSave.Title = Lang.Get("export_csv_title") + "...";
			mnDoBackupIn.Text = dlgBackup.Title = Lang.Get("backup_in") + "...";
			mnMinimizeToTray.Text = Lang.Get("minimize_to_tray");
			mnWebsite.Text = Lang.Get("help_website");
			mnProjectPage.Text = Lang.Get("help_project_page");
			mnAbout.Text = Lang.Get("help_about") + "...";
			mnHideCompleted.Text = Lang.Get("hide_completed_tasks");
			mnFlatView.Text = Lang.Get("flat_view");
			mnExpandAll.Text = Lang.Get("expand_all");
			mnCollapseAll.Text = Lang.Get("collapse_all");
			mnUpdates.Text = Lang.Get("updates_check") + "...";
			
			// Context menus
			mnContextEditCategory.Text = Lang.Get("category_edit");
			mnContextDeleteCategory.Text = Lang.Get("category_delete");
			mnContextNewTask.Text = Lang.Get("task_new") + "...";
			mnContextNewSubTask.Text = Lang.Get("task_sub_new_short") + "...";
			mnContextEditTask.Text = Lang.Get("task_edit") + "...";
			mnContextMoveTask.Text = Lang.Get("task_move") + "...";
			mnContextDeleteTask.Text = Lang.Get("task_delete");
			mnContextSetCompleted.Text = Lang.Get("task_set_completed");
			mnContextTimerStart.Text = Lang.Get("task_timer_start");
			mnContextTimerPause.Text = Lang.Get("task_timer_pause");
			mnContextEditPayment.Text = Lang.Get("task_payment_edit") + "...";
			mnContextNoteAdd.Text = Lang.Get("note_new") + "...";
			mnContextNotesView.Text = Lang.Get("task_notes_view") + "...";
			mnOpenTodomoo.Text = Lang.Get("open");
			mnExit.Text = Lang.Get("exit");
			mnExitTodomoo.Text = Lang.Get("exit");
			
			// Toolbar
			btnNewTask.Text = Lang.Get("task_new") + "...";
			btnNewSubTask.Text = Lang.Get("task_sub_new") + "...";
			btnMove.Text = Lang.Get("task_move") + "...";
			btnSetCompleted.Text = Lang.Get("task_set_completed");
			btnTimerStart.Text = Lang.Get("task_timer_start");
			btnTimerPause.Text = Lang.Get("task_timer_pause");
			btnEditPayment.Text = Lang.Get("task_payment_edit") + "...";
			btnNoteAdd.Text = Lang.Get("note_new") + "...";;
			btnNotesView.Text = Lang.Get("task_notes_view") + "...";
			btnOptions.Text = Lang.Get("options") + "...";
			btnMinimizeToTray.Text = Lang.Get("minimize_to_tray");
			btnAbout.Text = Lang.Get("help_about") + "...";
			btnHideCompleted.Text = Lang.Get("hide_completed_tasks");
			btnFlatView.Text = Lang.Get("flat_view");
			btnExpandAll.Text = Lang.Get("expand_all");
			btnCollapseAll.Text = Lang.Get("collapse_all");
			
			// Category toolbar
			btnCategoryNew.Text = Lang.Get("category_new") + "...";
			btnCategoryAll.Text = Lang.Get("category_all");
			foreach (ToolStripItem item in toolCategories.Items) try { btnCategoryAll.ToolTipText = ""; } catch { }
			
			// Task tree
			colName.Text = Lang.Get("task_name");
			colCategory.Text = Lang.Get("category");
			colPriority.Text = Lang.Get("task_priority");
			colCreationDate.Text = Lang.Get("task_creation_date");
			colDueDate.Text = Lang.Get("task_due_date");
			colCompleted.Text = Lang.Get("task_completed");
			colTimer.Text = Lang.Get("task_timer");
			colPrice.Text = Lang.Get("task_price");
			colNotes.Text = Lang.Get("task_notes");
			
			// Moving
			btnMoveCancel.Text = Lang.Get("cancel");
			
			ResumeLayout();
			
		}
		
		#endregion
		
		#region Exit methods
		
		// Normal termination
		private void Exit(object sender, EventArgs e) { boolForceExit = true; this.Close(); boolForceExit = false; }
		public void Exit(object sender, FormClosingEventArgs e) {
			
			// Minize to tray if option
			if (!boolForceExit) if (Settings.Get("window_minimize_when_closing").ToString() == "1") {
				e.Cancel = true;
				MinimizeToTray();
				return;
			}	
			
			// Save stuffs if DB is open
			if (Todomoo.isDbOpen) {
			
				// Ask for running timers
				bool running_timers = (Todomoo.LostTimers.Count > 0);
				if (!running_timers) foreach (Task t in Todomoo.Tasks) if (t.IsTimerRunning()) running_timers = true;
				if (running_timers) if (!Utils.MsgDialog.Confirm(Lang.Get("running_timers_confirm"), Lang.Get("warning"))) {
					e.Cancel = true;
					return;
				}
				
				// Save running timers
				foreach (Task t in Todomoo.Tasks) if (t.IsTimerRunning()) try {
					t.StopTimer(); // Stop timer
					t.Save(); // Save task
				} catch { Utils.MsgDialog.Error(Lang.Get("task_timer_error"), Lang.Get("error")); }
				
				// Save lost running timers
				foreach (int key in Todomoo.LostTimers.Keys) try {
					Task t = new Task(key); // Load the task with the unsaved timer
					int stopped_at = (int)((object[])Todomoo.LostTimers[t.Id])[0]; // Timer was stopper at second
					DateTime stopped_dt = (DateTime)((object[])Todomoo.LostTimers[t.Id])[1]; // Timer was stopped at time
					t.Timer = stopped_at + (int)(DateTime.Now.Subtract(stopped_dt).TotalSeconds); // Restore timer
					t.Save(); // Save task with correct timer
				} catch { Utils.MsgDialog.Error(Lang.Get("task_timer_error"), Lang.Get("error")); }
				
				// Close database
				Todomoo.CloseDatabase();
				
			}
			
			// If settings are loaded...
			if (Settings != null) {
				
				// Backup the database
				if (Settings.Get("backup_automatic").ToString() == "1") TaskBackup(true);
				
				// Save window bounds
				Settings.Set("window_xpos", Bounds.X);
				Settings.Set("window_ypos", Bounds.Y);
				Settings.Set("window_maximized", (WindowState == FormWindowState.Maximized ? 1 : 0));
				if (WindowState == FormWindowState.Normal) {
					Settings.Set("window_width", Bounds.Width);
					Settings.Set("window_height", Bounds.Height);
				}
				
				// Save columns width
				Settings.Set("col_name", colName.Width);
				Settings.Set("col_category", colCategory.Width);
				Settings.Set("col_priority", colPriority.Width);
				Settings.Set("col_creation_date", colCreationDate.Width);
				Settings.Set("col_due_date", colDueDate.Width);
				Settings.Set("col_completed", colCompleted.Width);
				Settings.Set("col_timer", colTimer.Width);
				Settings.Set("col_price", colPrice.Width);
				Settings.Set("col_notes", colNotes.Width);
				
				// Save columns visibility
				Settings.Set("col_category_v", (colCategory.IsVisible ? 1 : 0));
				Settings.Set("col_priority_v", (colPriority.IsVisible ? 1 : 0));
				Settings.Set("col_creation_date_v", (colCreationDate.IsVisible ? 1 : 0));
				Settings.Set("col_due_date_v", (colDueDate.IsVisible ? 1 : 0));
				Settings.Set("col_completed_v", (colCompleted.IsVisible ? 1 : 0));
				Settings.Set("col_timer_v", (colTimer.IsVisible ? 1 : 0));
				Settings.Set("col_price_v", (colPrice.IsVisible ? 1 : 0));
				Settings.Set("col_notes_v", (colNotes.IsVisible ? 1 : 0));
				
				// Save columns position
				Settings.Set("col_category_o", Math.Max(colCategory.DisplayIndex, 1));
				Settings.Set("col_priority_o", Math.Max(colPriority.DisplayIndex, 1));
				Settings.Set("col_creation_date_o", Math.Max(colCreationDate.DisplayIndex, 1));
				Settings.Set("col_due_date_o", Math.Max(colDueDate.DisplayIndex, 1));
				Settings.Set("col_completed_o", Math.Max(colCompleted.DisplayIndex, 1));
				Settings.Set("col_timer_o", Math.Max(colTimer.DisplayIndex, 1));
				Settings.Set("col_price_o", Math.Max(colPrice.DisplayIndex, 1));
				Settings.Set("col_notes_o", Math.Max(colNotes.DisplayIndex, 1));
				
				// Save columns sorting
				Settings.Set("col_name_s", GetSortingNumberFor(colName));
				Settings.Set("col_category_s", GetSortingNumberFor(colCategory));
				Settings.Set("col_priority_s", GetSortingNumberFor(colPriority));
				Settings.Set("col_creation_date_s", GetSortingNumberFor(colCreationDate));
				Settings.Set("col_due_date_s", GetSortingNumberFor(colDueDate));
				Settings.Set("col_completed_s", GetSortingNumberFor(colCompleted));
				Settings.Set("col_timer_s", GetSortingNumberFor(colTimer));
				Settings.Set("col_price_s", GetSortingNumberFor(colPrice));
				Settings.Set("col_notes_s", GetSortingNumberFor(colNotes));
				
				// Save settings
				Settings.Set("selected_category", (SelectedCategory == null) ? 0 : SelectedCategory.Id);
				Settings.Save();
				
			}
			
			// Delete tray icon if one
			if (tray != null) tray.Visible = false;
			
			// Undo updates
			if (u != null) try { u.Stop(); } catch { }
			
		}
		
		// Abnormal termination
		public void ExitWithError(string message) {
			try { Utils.MsgDialog.Error(message, Lang.Get("critical")); }
			catch { Utils.MsgDialog.Error(message, "Critical error!"); }
			try {
				Todomoo.CloseDatabase();
				boolForceExit = true; 
				Close();
				Application.Exit();
			} catch {}
		}
		
		#endregion
		
		#region ProcMessages
		
		protected override void WndProc(ref Message m) {
			if(m.Msg == NativeMethods.WM_SHOWME) {
				ShowMainForm();
				if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;
				NativeMethods.SetForegroundWindow(this.Handle);
				bool top = TopMost;
				TopMost = true;
				TopMost = top; }
			base.WndProc(ref m);
		}

		#endregion

	}
	
}
