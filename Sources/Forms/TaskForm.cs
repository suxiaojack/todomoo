/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * TASK FORM (filename)
 * Form for create and edit tasks and notes.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Todomoo {
	
	/// <summary>
	/// Task form.
	/// </summary>
	public partial class TaskForm : Form {
		
		// Task to create or edit
		Task task;
		
		// Language and settings
		private Languages.Language Lang;
		private Utils.AppSettings Settings;
		
		// Enum of starting tabs
		public enum StartingTab {
			General,
			DatesTime,
			Payment,
			Notes
		};
		
		// Notes accordion
		private Accordion accordion = new Accordion();
		private FontFamily notes_monospace_font = FontFamily.GenericMonospace;
		
		// New note focus
		public bool giveFocusToNewNote = false;
		
		/// <summary>
		/// Edit a Task object.
		/// </summary>
		/// <param name="task">Task to edit</param>
		public TaskForm(Languages.Language language, Utils.AppSettings settings, Task task) : this(language, settings, task, StartingTab.General) { }
		
		/// <summary>
		/// Edit a Task object showing a specific section.
		/// </summary>
		/// <param name="task">Task to edit</param>
		/// <param name="start_tab">The forst section to show</param>
		public TaskForm(Languages.Language language, Utils.AppSettings settings, Task task, StartingTab start_tab) {
			
			// Windows Forms designer support.
			InitializeComponent();
			
			// Setup task
			this.task = task;
			
			// Form icon
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
			Icon = (task.Id == 0) ? ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))) : ((System.Drawing.Icon)(resources.GetObject("$this.Icon2")));
			
			// Language
			Lang = language;
			Text = Lang.Get((task.Id == 0) ? "task_add" : "task_edit");
			btnOk.Text = " " + Lang.Get((task.Id == 0) ? "add" : "edit");
			btnCancel.Text = Lang.Get("cancel");
			ApplyLanguage();
			
			// Settings
			Settings = settings;
			lblCurrency.Text = Settings.Get("currency").ToString();
			
			// Starting tab
			switch (start_tab) {
				case StartingTab.DatesTime:   tabs.SelectedTab = tabDatesTime; break;
				case StartingTab.Payment:     tabs.SelectedTab = tabPayment;   break;
				case StartingTab.Notes:       tabs.SelectedTab = tabNotes;     break;
			}
			
			// Populate combos
			PopulateColourCombo();
			PopulatePriorityCombo();
			PopulatePaymentCombo();
			if (task.IsRoot()) PopulateCategoryCombo(task.CategoryId); // Category combo also for root tasks
			
			// Fill in GUI fields (general)
			txtName.Text = task.Name;
			try { txtDescription.Text = task.Description; } catch { txtDescription.Text = ""; }
			foreach (ImageComboItem item in cmbColour.Items) if (item.Text == Lang.Get("colour_as") + " " + task.Name) cmbColour.SelectedItem = item;
			cmbPriority.SelectedIndex = task.Priority % 3;
			
			// Fill in GUI fields (dates and time)
			dtCreationDate.Value = task.CreationDate;
			try { dtDueDate.Value = task.DueDate; chkDueDateNot.Checked = false; } catch { chkDueDateNot.Checked = true; }
			try { dtCompleted.Value = task.Completed; chkCompletedNot.Checked = false; } catch { chkCompletedNot.Checked = true; }
			try { int t = task.Timer; chkUseTimer.Checked = true; } catch { chkUseTimer.Checked = false; }
			try { numTimerS.Value = task.Timer % 60; 
				  numTimerM.Value = ((task.Timer - numTimerS.Value) / 60) % 60;
				  numTimerH.Value = (task.Timer - numTimerS.Value - numTimerM.Value * 60) / (60 * 60); } catch { }
			
			// If the timer is running, disable timer fields.
			if (task.IsTimerRunning()) {
				chkUseTimer.Enabled = false;
				lblTimer.Visible = btnTimerReset.Visible = btnSumTimers.Visible = false;
				numTimerS.Visible = numTimerM.Visible = numTimerH.Visible = false;
				lblTimerS.Visible = lblTimerM.Visible = lblTimerH.Visible = false;
				panCannotEditTimer.Visible = true;
				lblCannotEditTimer.Text = Lang.Get("task_timer_is_running"); }
			
			// Fill in GUI fields (payment)
			try {
				chkPerHour.Checked = task.PricingByHour;
				if (task.PricingByHour) numPrice.Value = (Decimal)task.PriceByHour;
				else numPrice.Value = (Decimal)task.Price;
				chkPriceNot.Checked = false;
			} catch { chkPriceNot.Checked = true; }
			try { dtPaid.Value = task.Paid; chkPaidNot.Checked = false; }  catch { chkPaidNot.Checked = true; }
			try { cmbPaymentType.Text = task.Payment; } catch { }
			try { txtPaymentNote.Text = task.PaymentNote; } catch { txtPaymentNote.Text = ""; }
			chkPerHour.Enabled = !chkPriceNot.Checked ; 
			
			// Show/hide task parent
			if (task.ParentId != 0) cmbCategory.Hide();
			lblCategory.Visible = btnAddCategory.Visible = (task.ParentId == 0);
			btnAddCategory.Enabled = (task.ParentId == 0);
			lblSubTaskOf.Visible = panParent.Visible = (task.ParentId != 0);
			
			// Setup task parent
			if (!task.IsRoot()) {
				try {
					Task parent = new Task(task.ParentId);
					lblParentName.Text = parent.Name;
					boxParentIcon.Image = IconColoured.GetSquared(parent.Colour);
					task.CategoryId = parent.CategoryId; // Same category of the parent!
					if (task.Id == 0) foreach (ImageComboItem item in cmbColour.Items) 
						if (item.Text == Lang.Get("colour_as") + " " + parent.Name) cmbColour.SelectedItem = item;
				} catch {
					lblParentName.Text = Lang.Get("task_loading_error");
					boxParentIcon.Image = IconColoured.GetSquared(Color.Gray);
				}
			}
			
			// Notes settings (this is not so good, calling MainForm in this way...)
			try { notes_monospace_font = new FontFamily("Consolas"); } catch { }
			chkMonospace.Checked = (Todomoo.mainForm.Settings.Get("note_monospace").ToString() == "1");
			chkWordWrap.Checked  = (Todomoo.mainForm.Settings.Get("note_word_wrap").ToString() == "1");
			
			// Draw note accordion
			DrawNotesAccordion();
			
			// Form size and "sizeability"
			TabsSelectedIndexChanged();
			TaskFormResize();
			
		}
		
		/// <summary>
		/// Update properties of the Task object.
		/// </summary>
		public bool Save() {
			
			// Check compulsory fields
			if (txtName.Text == "") {
				Utils.MsgDialog.Warning(Lang.Get("invalid_entry"), Lang.Get("warning"));
				tabs.SelectedTab = tabGeneral;
				txtName.Focus();
				return false; }
			
			// Check if there is no category
			if (cmbCategory.Enabled == false) {
				Utils.MsgDialog.Warning(Lang.Get("category_must_create"), Lang.Get("warning"));
				tabs.SelectedTab = tabGeneral;
				if (btnAddCategory.Visible && btnAddCategory.Enabled) btnAddCategory.Focus();
				return false; }
			
			// Update fields from the GUI (General)
			task.Name = txtName.Text;
			if (txtDescription.Text != "") task.Description = txtDescription.Text; else task.RemoveDescription();
			task.Colour = (Color)(((ImageComboItem)cmbColour.SelectedItem).Tag);
			task.Priority = cmbPriority.SelectedIndex;
			
			// Category switch
			if (task.IsRoot()) {
				int newCategory = (int)(((ImageComboItem)cmbCategory.SelectedItem).Tag);
				if (newCategory != task.CategoryId) Todomoo.ChangeCategoryToHierarchy(task, newCategory);
			}
			
			// Update fields from the GUI (Dates and time)
			task.CreationDate = dtCreationDate.Value;
			if (!chkDueDateNot.Checked) task.DueDate = dtDueDate.Value; else task.RemoveDueDate();
			if (!chkCompletedNot.Checked) task.Completed = dtCompleted.Value; else task.RemoveCompleted();
			if (!task.IsTimerRunning()) if (chkUseTimer.Checked) task.Timer = (int)numTimerS.Value + (int)numTimerM.Value *60 + (int)numTimerH.Value * 60 * 60; else task.RemoveTimer();
			
			// Update fields from the GUI (Payment)
			if (!chkPriceNot.Checked) {
				task.PricingByHour = chkPerHour.Checked;
				if (task.PricingByHour) task.PriceByHour = (float)numPrice.Value;
				else task.Price = (float)numPrice.Value;
			} else task.RemovePrice();
			if ((!chkPaidNot.Checked) && (!chkPriceNot.Checked)) task.Paid = dtPaid.Value; else task.RemovePaid();
			if ((!chkPaidNot.Checked) && (!chkPriceNot.Checked)) task.Payment = cmbPaymentType.Text; else task.RemovePayment();
			if (txtPaymentNote.Text != "") task.PaymentNote = txtPaymentNote.Text; else task.RemovePaymentNote();
			
			// Say to the task object the notes to update
			ArrayList pending_notes = new ArrayList();
			foreach (Control item in accordion.Controls) if (item is AccordionItem) 
				try { pending_notes.Add((Note)item.Tag); } catch { }
			task.SetUnsavedNotes(pending_notes);
			
			return true;
			
		}
		
		#region GUI methods
		
		void ApplyLanguage() {
			
			SuspendLayout();
			
			// Tab titles
			tabGeneral.Text = Lang.Get("task_ufirst");
			tabDatesTime.Text = Lang.Get("task_dates_time");
			tabPayment.Text = Lang.Get("task_payments");
			tabNotes.Text = Lang.Get("task_notes");
			
			// Task tab
			lblCategory.Text = Lang.Get("category") + ":";
			lblName.Text = Lang.Get("task_name") + ":";
			lblDescription.Text = Lang.Get("task_description") + ":";
			lblColour.Text = Lang.Get("colour") + ":";
			lblPriority.Text = Lang.Get("task_priority") + ":";
			btnAddCategory.Text = Lang.Get("category_new_short");
			btnChooseColour.Text = Lang.Get("colour_choose");
			lblSubTaskOf.Text = Lang.Get("task_sub_of") + ":";
			
			// Dates and time tab
			lblCreationDate.Text = Lang.Get("task_creation_date") + ":";
			lblDueDate.Text = Lang.Get("task_due_date") + ":";
			lblCompleted.Text = Lang.Get("task_completed") + ":";
			chkUseTimer.Text = Lang.Get("task_use_timer") + ":";
			chkDueDateNot.Text = Lang.Get("task_due_date_not");
			chkCompletedNot.Text = Lang.Get("task_completed_not");
			btnTimerReset.Text = " " + Lang.Get("task_timer_reset");
			btnSumTimers.Text = Lang.Get("task_timer_sum");
			
			// Payment tab
			lblPrice.Text = Lang.Get("task_price") + ":";
			lblPaid.Text = Lang.Get("task_paid") + ":";
			lblPayment.Text = Lang.Get("task_payment") + ":";
			lblPaymentNote.Text = Lang.Get("task_payment_note") + ":";
			chkPriceNot.Text = Lang.Get("task_price_not");
			btnSumPrice.Text = Lang.Get("task_price_sum");
			chkPaidNot.Text = Lang.Get("task_paid_not");
			chkPerHour.Text = Lang.Get("task_perhour");
			
			// Notes tab
			btnNewNote.Text = Lang.Get("note_new");
			btnDeleteNote.Text = Lang.Get("note_delete");
			chkMonospace.Text = Lang.Get("note_monospace");
			chkWordWrap.Text = Lang.Get("note_word_wrap");
			
			ResumeLayout();
			
		}
		
		void PopulateCategoryCombo(int select_category) {
			int index = 0;
			cmbCategory.Items.Clear();
			cmbCategory.ImageList.Images.Clear();
			cmbCategory.ImageList.ColorDepth = ColorDepth.Depth32Bit;
			foreach (Category c in Todomoo.Categories) {
				cmbCategory.ImageList.Images.Add(IconColoured.GetSquared(c.Colour));
				ImageComboItem item = new ImageComboItem(c.Name, index);
				item.Tag = c.Id;
				cmbCategory.Items.Add(item);
				index++; }
			if (cmbCategory.Items.Count == 0) {
				cmbCategory.Enabled = false;
				cmbCategory.Items.Add(new ImageComboItem(Lang.Get("category_must_create")));
			}
			cmbCategory.SelectedIndex = 0;
			if (select_category != 0) foreach (ImageComboItem item in cmbCategory.Items) {
				if ((int)item.Tag == select_category) cmbCategory.SelectedItem = item;
			}
		}
		
		void PopulateColourCombo() {
			int index = 0;
			cmbColour.Items.Clear();
			cmbColour.ImageList.Images.Clear();
			cmbColour.ImageList.ColorDepth = ColorDepth.Depth32Bit;
			foreach (Task t in Todomoo.Tasks) {
				cmbColour.ImageList.Images.Add(IconColoured.GetSquared(t.Colour));
				ImageComboItem item = new ImageComboItem(Lang.Get("colour_as") + " " + t.Name, index);
				item.Tag = t.Colour;
				cmbColour.Items.Add(item);
				index++; }
			if (cmbColour.Items.Count == 0) {
				cmbColour.ImageList.Images.Add(IconColoured.GetSquared(Color.Gray));
				ImageComboItem item = new ImageComboItem(Lang.Get("default"), index);
				item.Tag = Color.Gray;
				cmbColour.Items.Add(item);
				index++; }
			cmbColour.SelectedIndex = 0;
		}
		
		void PopulatePriorityCombo() {
			cmbPriority.Items.Add(new ImageComboItem(Lang.Get("priority_low"), 0));
			cmbPriority.Items.Add(new ImageComboItem(Lang.Get("priority_medium"), 1));
			cmbPriority.Items.Add(new ImageComboItem(Lang.Get("priority_high"), 2));
			cmbPriority.SelectedIndex = 0;
		}
		
		void PopulatePaymentCombo() {
			ArrayList payment_types = Todomoo.GetPaymentTypes();
			foreach (string payment_type in payment_types) cmbPaymentType.Items.Add(payment_type);
			if (cmbPaymentType.Items.Count > 0) cmbPaymentType.SelectedIndex = 0;
		}
		
		void DrawNotesAccordion() {
			
			// Setup accordion
			panAccordion.Controls.Add(accordion);
			accordion.SetBounds(0, 0, panAccordion.Width - scrollAccordion.Width - 1, panAccordion.Height);
			accordion.MinimumContentHeight = 100;
			accordion.BackColor = SystemColors.Control;
			
			// Add items, Note object as Tag
			ArrayList notes = task.GetNotes();
			foreach (Note note in notes) {
				AccordionItem item = new AccordionItem(ShortenString(note.Text, 50), imgNote.Images[note.Marked ? 1 : 0]);
				
				// Note marking on double click
				item.IconBox.Tag = note;
				item.IconBox.DoubleClick += delegate(object sender, EventArgs e) {
					Note note_w = (Note)(((PictureBox)sender).Tag);
					note_w.Marked = !note_w.Marked;
					note_w.Update();
					item.Icon = imgNote.Images[note_w.Marked ? 1 : 0];
				};
				
				// Setup text box
				RichTextBox text = new RichTextBox();
				text.LinkClicked += NoteLinkClicked;
				text.BorderStyle = BorderStyle.None;
				item.Tag = note;
				text.Text = note.Text;
				text.Multiline = true;
				text.WordWrap = chkWordWrap.Checked;
				text.ScrollBars = RichTextBoxScrollBars.Both;
				text.Font = (chkMonospace.Checked ? new Font(notes_monospace_font, 10) : new Font(this.Font.FontFamily, 10));
				text.Validated += delegate { try { ((Note)item.Tag).Text = text.Text; item.Text = ShortenString(((Note)item.Tag).Text, 50); } catch { } };
				item.Resize += delegate { try { text.SetBounds(0, 1, item.SpaceAvailable.Width, item.SpaceAvailable.Height - 1); } catch {} };
				item.AddControl(text);
				accordion.AddAccordionItem(item);
			}
			
			RedrawNotesScroll();
			
		}
		
		void RedrawNotesScroll() {
			scrollAccordion.Maximum = accordion.Height;
			scrollAccordion.Minimum = 0;
			scrollAccordion.LargeChange = panAccordion.Height;
			scrollAccordion.SmallChange = 10;
			scrollAccordion.Enabled = (scrollAccordion.LargeChange != scrollAccordion.Maximum);
		}
		
		void AddNewNoteAccordionItem(object sender, EventArgs e) { AddNewNoteAccordionItem(); }
		public void AddNewNoteAccordionItem() {
			
			// Create a item with a note
			AccordionItem item = new AccordionItem(Lang.Get("note_new"), imgNote.Images[0]);
			item.Tag = new Note(); // New note
			
			// Setup the new text box
			RichTextBox text = new RichTextBox();
			text.LinkClicked += NoteLinkClicked;
			text.BorderStyle = BorderStyle.None;
			text.Multiline = true;
			text.WordWrap = chkWordWrap.Checked;
			text.ScrollBars = RichTextBoxScrollBars.Both;
			text.Font = (chkMonospace.Checked ? new Font(notes_monospace_font, 10) : new Font(this.Font.FontFamily, 10));
			text.Validated += delegate { try { ((Note)item.Tag).Text = text.Text; item.Text = ShortenString(((Note)item.Tag).Text, 50); } catch { } };
			item.Resize += delegate { try { text.SetBounds(0, 1, item.SpaceAvailable.Width, item.SpaceAvailable.Height - 1); } catch {} };
			item.AddControl(text);
			
			// Add item to the accordion, select it
			accordion.AddAccordionItem(item);
			accordion.SelectItemWithAnimation(item);
			text.Focus();
			
			// Adjust scrolling
			RedrawNotesScroll();
			
		}
		
		void DeleteSelectedNoteAccordionItem(object sender, EventArgs e) { DeleteSelectedNoteAccordionItem(); }
		void DeleteSelectedNoteAccordionItem() {
			
			// If there is no selected note, what i'm doing here?
			if (accordion.SelectedItem == null) return;
			
			// Try to delete note from database
			Note to_delete = (Note)accordion.SelectedItem.Tag;
			
			// Delete selected item
			accordion.RemoveAccordionItem(accordion.SelectedItem);
			
			// Adjust scrolling
			RedrawNotesScroll();
			
		}
		
		private string ShortenString(string s, int length) {
			string r = s.Replace("\r\n", " ").Replace("\n", " ").Replace("\t", " ");
			while (r.Contains("  ")) r = r.Replace("  ", " ");
			if (r.Length > length) r = r.Substring(0, length) + "...";
			return r;
		}
		
		private void NoteLinkClicked(object sender, LinkClickedEventArgs e) {  
			System.Diagnostics.Process.Start(e.LinkText);
		}
		
		#endregion
		
		#region GUI events
		
		void ChkPerHourCheckedChanged(object sender, EventArgs e) {
			lblCurrency.Text = Settings.Get("currency").ToString();
			task.PricingByHour = chkPerHour.Checked;
			if (task.PricingByHour) {
				lblCurrency.Text += "/h";
				try { numPrice.Value = (Decimal)task.PriceByHour; } catch { numPrice.Value = 0; }
			} else {
				try { numPrice.Value = (Decimal)task.Price; } catch { numPrice.Value = 0; }
			}
		}
		
		void BtnOkClick(object sender, EventArgs e) {
			if (Save()) { this.DialogResult = DialogResult.OK; Close(); }
		}
		
		void BtnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel; Close();
		}
		
		void BtnAddCategoryClick(object sender, EventArgs e) {
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
				Todomoo.mainForm.RedrawCategoriesBar();
				Todomoo.mainForm.SelectedCategory = new_category;
				Todomoo.mainForm.CountTasks();
				
				// Update task editing form
				task.CategoryId = new_category.Id;
				if (task.IsRoot()) PopulateCategoryCombo(task.CategoryId);
				cmbCategory.Enabled = true;
				
			} catch {
				Utils.MsgDialog.Error(Lang.Get("task_save_error"), Lang.Get("error")); return;
			}
		}
		
		void BtnChooseColourClick(object sender, EventArgs e) {
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				Color col = colorDialog.Color;
				cmbColour.ImageList.Images.Add(IconColoured.GetSquared(col));
				ImageComboItem item = new ImageComboItem("RGB [" + col.R + ", "+ col.G + ", "+ col.B + "]", cmbColour.Items.Count);
				item.Tag = col;
				cmbColour.Items.Add(item);
				cmbColour.SelectedIndex = cmbColour.Items.Count - 1;
			}
		}
		
		void ChkDueDateNotCheckedChanged(object sender, EventArgs e) {
			dtDueDate.Enabled = !chkDueDateNot.Checked;
		}
		
		void ChkCompletedNotCheckedChanged(object sender, EventArgs e) {
			dtCompleted.Enabled = !chkCompletedNot.Checked;
		}
		
		void ChkUseTimerCheckedChanged(object sender, EventArgs e) {
			numTimerH.Enabled = numTimerM.Enabled = numTimerS.Enabled = chkUseTimer.Checked;
			btnTimerReset.Enabled = chkUseTimer.Checked;
			btnSumTimers.Enabled = chkUseTimer.Checked;
		}
		
		void BtnTimerResetClick(object sender, EventArgs e) {
			numTimerH.Value = 0;
			numTimerM.Value = 0;
			numTimerS.Value = 0;
		}
		
		void ChkPriceNotCheckedChanged(object sender, EventArgs e) {
			numPrice.Enabled = !chkPriceNot.Checked;
			chkPerHour.Enabled = !chkPriceNot.Checked;
			chkPaidNot.Enabled = !chkPriceNot.Checked;
			btnSumPrice.Enabled = !chkPriceNot.Checked;
			dtPaid.Enabled = cmbPaymentType.Enabled = ((!chkPaidNot.Checked) && (!chkPriceNot.Checked));
		}
		
		void BtnSumPriceClick(object sender, EventArgs e) {
			float sum = 0;
			DateTime last = DateTime.MinValue;
			foreach (Task t in Todomoo.GetChildrenTasks(task)) try { 
				sum += t.Price; 
				if (t.Paid > last) last = t.Paid;
			} catch { }
			numPrice.Value = (Decimal)sum;
			if (last != DateTime.MinValue) dtPaid.Value = last;
		}
		
		void BtnSumTimersClick(object sender, EventArgs e) {
			int timer = 0;
			foreach (Task t in Todomoo.GetChildrenTasks(task)) try { 
				timer += t.Timer; 
			} catch { }
			try { 
				numTimerS.Value = timer % 60;
				numTimerM.Value = ((timer - numTimerS.Value) / 60) % 60;
				numTimerH.Value = (timer - numTimerS.Value - numTimerM.Value * 60) / (60 * 60);
			} catch { }
		}
		
		void ChkPaidNotCheckedChanged(object sender, EventArgs e) {
			dtPaid.Enabled = cmbPaymentType.Enabled = ((!chkPaidNot.Checked) && (!chkPriceNot.Checked));
		}
		
		void TaskFormShown(object sender, EventArgs e) {
			if (tabs.SelectedTab == tabGeneral) txtName.Focus();
			if (tabs.SelectedTab == tabDatesTime) dtCreationDate.Focus();
			if (tabs.SelectedTab == tabPayment) chkPriceNot.Focus();
			if (tabs.SelectedTab == tabNotes && giveFocusToNewNote) {
				giveFocusToNewNote = false;
				try { accordion.SelectedItem.PanelFocus(); } catch { } }
			TaskFormResize();
		}
		
		void ScrollAccordionScroll(object sender, ScrollEventArgs e) {
			accordion.Top = -scrollAccordion.Value;
			if (accordion.Top < - accordion.Height + panAccordion.Height) accordion.Top = - accordion.Height + panAccordion.Height;
		}
		
		void ChkMonospaceCheckedChanged(object sender, EventArgs e) {
			Todomoo.mainForm.Settings.Set("note_monospace", (chkMonospace.Checked ? 1 : 0));
			foreach (Control item in accordion.Controls) if (item is AccordionItem) 
				foreach (Control panel in item.Controls) if (panel is Panel)
					foreach (Control textbox in panel.Controls) if (textbox is RichTextBox) {
						((RichTextBox)textbox).Font = (
							chkMonospace.Checked ? 
							new Font(notes_monospace_font, 10) : 
							new Font(this.Font.FontFamily, 10));
						((RichTextBox)textbox).WordWrap = !chkWordWrap.Checked;
						Application.DoEvents();
						((RichTextBox)textbox).WordWrap = chkWordWrap.Checked;
					}
		}
		
		void ChkWordWrapCheckedChanged(object sender, EventArgs e) {
			Todomoo.mainForm.Settings.Set("note_word_wrap", (chkWordWrap.Checked ? 1 : 0));
			foreach (Control item in accordion.Controls) if (item is AccordionItem) 
				foreach (Control panel in item.Controls) if (panel is Panel)
					foreach (Control textbox in panel.Controls) if (textbox is RichTextBox)
						((RichTextBox)textbox).WordWrap = chkWordWrap.Checked;
		}
		
		// Insert task on Return key pressing (thanks to Dege)
		void TxtSimpleFieldEnter(object sender, EventArgs e) { this.AcceptButton = btnOk; }
		void TxtSimpleFieldLeave(object sender, EventArgs e) { this.AcceptButton = null; }
		
		// Expand on note tab
		void TabsSelectedIndexChanged(object sender, EventArgs e) { TabsSelectedIndexChanged(); }
		void TabsSelectedIndexChanged() {
			if (this.tabs.SelectedTab == tabNotes) {
				this.MaximumSize = new Size(0, 0);
				this.SetBounds(this.Left, this.Top, Utils.Conversion.ToInt(Settings.Get("note_form_width")), Utils.Conversion.ToInt(Settings.Get("note_form_height")));
				TaskFormResize();
			} else {
				this.SetBounds(this.Left, this.Top, this.MinimumSize.Width, this.MinimumSize.Height);
				TaskFormResize();
				this.MaximumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height);
			}
		}
		
		// Notes tab resize
		void TaskFormResize(object sender, EventArgs e) { TaskFormResize(); }
		void TaskFormResize() {
			
			// Resize tabs
			tabs.SetBounds(8, 8, this.Width - 25, this.Height - 87);
			shapeLine.SetBounds(8, 8 + tabs.Height + 7, this.Width - 25, 1);
			btnCancel.SetBounds(this.Width - 16 - btnCancel.Width, 7 + tabs.Height + 16, btnCancel.Width, btnCancel.Height);
			btnOk.SetBounds(btnCancel.Left - 8 - btnOk.Width, btnCancel.Top, btnOk.Width, btnOk.Height);
			
			// Resize notes tab controls
			if (this.tabs.SelectedTab != tabNotes) return;
			shapeAccordionLeft.SetBounds(16, 16, 1, tabNotes.Height - 62);
			shapeAccordionRight.SetBounds(tabNotes.Width - 16, 16, 1, tabNotes.Height - 62);
			shapeAccordionTop.SetBounds(16, 16, tabNotes.Width - 32, 1);
			shapeAccordionBottom.SetBounds(16, tabNotes.Height - 46, tabNotes.Width - 31, 1);
			panAccordion.SetBounds(18, 18, shapeAccordionTop.Width - 3, shapeAccordionLeft.Height - 3);
			scrollAccordion.SetBounds(panAccordion.Width - scrollAccordion.Width, 0, scrollAccordion.Width, panAccordion.Height);
			accordion.SetBounds(0, 0, scrollAccordion.Left - 1, panAccordion.Height);
			btnDeleteNote.SetBounds(shapeAccordionBottom.Left + shapeAccordionBottom.Width - btnDeleteNote.Width, shapeAccordionBottom.Top + 8, btnDeleteNote.Width, btnDeleteNote.Height);
			btnNewNote.SetBounds(btnDeleteNote.Left - 8 - btnNewNote.Width, btnDeleteNote.Top, btnNewNote.Width, btnNewNote.Height);
			chkMonospace.SetBounds(16, btnNewNote.Top, chkMonospace.Width, chkMonospace.Height);
			chkWordWrap.SetBounds(Settings.Get("lang").ToString().Equals("it") ? 104 : 112, btnNewNote.Top, chkWordWrap.Width, chkWordWrap.Height);
			
			// Store notes window size
			Settings.Set("note_form_width", this.Width);
			Settings.Set("note_form_height", this.Height);
			
		}
		
		#endregion
		
	}
	
}
