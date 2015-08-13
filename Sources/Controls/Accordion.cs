/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * ACCORDION CONTROL (Accordion.cs)
 * An accordion control.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace System.Windows.Forms {
	
	/// <summary>
	/// A tabbed panel with an orizontal list of items, opened as an accordion.
	/// </summary>
	public class Accordion : Panel {
		
		// Selected accordion item
		private AccordionItem selected = null;
		
		// Minimum content height
		private int minimum_content_height = 100;
		
		/// <summary>
		/// Create an empty accordion panel.
		/// </summary>
		public Accordion() : base() {
			
			// Draw accordion
			Redraw(this, null);
			
			// Raise redraw every time accordion is resized
			this.Resize += new EventHandler(this.Redraw);
			
		}
		
		/// <summary>
		/// Add an item in the accordion control.
		/// </summary>
		/// <param name="item">Item to add</param>
		public void AddAccordionItem(AccordionItem item) {
			item.Click += delegate { Animate(item); }; // Animation on click
			Controls.Add(item);
			if (Controls.Count == 1) SelectedItem = (AccordionItem)Controls[0];
			Redraw();
		}
		
		/// <summary>
		/// Remove an item from the accordion control.
		/// </summary>
		/// <param name="item">Item to remove</param>
		public void RemoveAccordionItem(AccordionItem item) {
			if (SelectedItem == item) SelectedItem = null;
			Controls.Remove(item);
			if (SelectedItem == null && Controls.Count > 0) SelectedItem = (AccordionItem)Controls[0];
			Redraw();
		}
		
		/// <summary>
		/// Remove an item from the accordion control.
		/// </summary>
		/// <param name="index">Index of the item to remove</param>
		public void RemoveAccordionItemAt(int index) {
			if (SelectedItem == Controls[index]) SelectedItem = null;
			Controls.RemoveAt(index);
			if (SelectedItem == null && Controls.Count > 0) SelectedItem = (AccordionItem)Controls[0];
			Redraw();
		}
		
		/// <summary>
		/// Clear all accordion items.
		/// </summary>
		public void ClearAccordion() {
			Controls.Clear();
			SelectedItem = null;
			Redraw();
		}
		
		/// <summary>
		/// Select an item and perform tha animation as on click.
		/// </summary>
		/// <param name="item"></param>
		public void SelectItemWithAnimation(AccordionItem item) {
			Animate(item);
		}
		
		// Redraw the accordion
		private void Redraw() { Redraw(this, null); }
		private void Redraw(object sender, EventArgs e) {
			int y = 0;
			foreach (AccordionItem item in Controls) {
				int height = (item == SelectedItem) ? Math.Max(MinimumContentHeight + 24, this.Height - 25 * (Controls.Count - 1)) : 24;
				item.SetBounds(0, y, this.Width, height);
				item.CanHighlight = !(item == SelectedItem);
				item.panel.Enabled = (item == SelectedItem);
				y += height + 1;
			}
			if ((y - 1) > this.Height) this.Height = (y - 1);
		}
		
		// Animate accordion
		private void Animate(AccordionItem to_select) {
			
			// Animation
			if ((SelectedItem != null) && (to_select != null) && (Controls.Count > 1)) 
			if ((SelectedItem != to_select)) try {
				int prev_height = SelectedItem.Height;
				int sel_h_f = Math.Max(MinimumContentHeight + 24, this.Height - 25 * (Controls.Count - 1));
				for (int sel_h_g = sel_h_f / 10; sel_h_g < sel_h_f - sel_h_f / 10; sel_h_g += sel_h_f / 10) {
					int y = 0;
					foreach (AccordionItem item in Controls) {
						int height = (item == to_select) ? sel_h_g + 24 : 24;
						if (item == SelectedItem) height = prev_height - sel_h_g;
						item.SetBounds(0, y, this.Width, height);
						y += height + 1; }
					Application.DoEvents();
					System.Threading.Thread.Sleep(7);
				}
			} catch { }
			
			// Select item and redraw
			SelectedItem = to_select;
			Redraw();
			
		}
		
		
		/// <summary>
		/// The selected accordion item.
		/// </summary>
		public AccordionItem SelectedItem {
			get { return selected; }
			set { selected = value; Redraw(); }
		}
		
		/// <summary>
		/// The minimum height of an opened accordion item.
		/// </summary>
		public int MinimumContentHeight {
			get { return minimum_content_height; }
			set { minimum_content_height = value; Redraw(); }
		}
		
	}
	
	/// <summary>
	/// An item of the Accordion panel.
	/// </summary>
	public class AccordionItem : Panel {
		
		// The container panel
		private Panel title_bar = new Panel();
		public  Panel panel = new Panel();
		private Label label = new Label();
		private PictureBox icon = new PictureBox();
		
		// Can highlight?
		private bool can_highlight = true;
		
		/// <summary>
		/// Create an empty accordion item.
		/// </summary>
		public AccordionItem() : this("", null) { }
		
		/// <summary>
		/// Create an empty accordion item.
		/// </summary>
		/// <param name="text">Text to be displayed on the title space</param>
		public AccordionItem(string text) : this(text, null) { }
		
		/// <summary>
		/// Create an empty accordion item.
		/// </summary>
		/// <param name="text">Text to be displayed on the title space</param>
		/// <param name="icon">Image to be displayed on the title space</param>
		public AccordionItem(string text, Image icon) : base() {
			
			// Set properties
			Text = text;
			Icon = icon;
			
			// Create controls on the title bar
			title_bar.BackColor = SystemColors.ControlDark;
			title_bar.Controls.Add(label);
			title_bar.Controls.Add(this.icon);
			this.Controls.Add(title_bar);
			this.Controls.Add(panel);
			
			// Mouse events (for highlighting)
			title_bar.MouseEnter += delegate { this.Highlight(true); };
			title_bar.MouseLeave += delegate { this.Highlight(false); };
			label.MouseEnter += delegate { this.Highlight(true); };
			label.MouseLeave += delegate { this.Highlight(false); };
			this.icon.MouseEnter += delegate { this.Highlight(true); };
			this.icon.MouseLeave += delegate { this.Highlight(false); };
			
			// Clicks (for selecting)
			title_bar.Click += delegate { this.OnClick(new EventArgs()); };
			label.Click += delegate { this.OnClick(new EventArgs()); };
			this.icon.Click += delegate { this.OnClick(new EventArgs()); };
			
			// Draw accordion item
			Redraw();
			
			// Raise redraw every time accordion item is resized
			this.Resize += new EventHandler(this.Redraw);
			
		}
		
		/// <summary>
		/// Add a control into the panel.
		/// </summary>
		/// <param name="control">Control to add</param>
		public void AddControl(Control control) {
			panel.Controls.Add(control);
		}
		
		/// <summary>
		/// Remove a control from the panel.
		/// </summary>
		/// <param name="control">Control to remove</param>
		public void RemoveControl(Control control) {
			panel.Controls.Remove(control);
		}
		
		// Redraw inner panel and title bar
		private void Redraw() { Redraw(this, null); }
		private void Redraw(object sender, EventArgs e) {
			title_bar.SetBounds(0, 0, this.Width, 24);
			label.SetBounds((icon.Image == null) ? 8 : 24, 5, this.Width - 5, 16);
			if (icon.Image != null) icon.SetBounds(4, 4, 16, 16);
			panel.SetBounds(0, 24, this.Width, this.Height - 24);
		}
		
		// Highlight title bar
		private void Highlight(bool highlight) {
			title_bar.BackColor = (highlight && CanHighlight) ? SystemColors.ControlLight : SystemColors.ControlDark;
		}
		
		/// <summary>
		/// Gives focus to the first control.
		/// </summary>
		public void PanelFocus() {
			try { panel.Controls[0].Focus(); } catch { }
		}
		
		/// <summary>
		/// Item title.
		/// </summary>
		public override string Text {
			get { return label.Text; }
			set { label.Text = value; }
		}
		
		/// <summary>
		/// Item icon.
		/// </summary>
		public Image Icon {
			get { return icon.Image; }
			set { icon.Image = value; }
		}
		
		/// <summary>
		/// Can this item highligh his title bar on mouse over?
		/// </summary>
		public bool CanHighlight {
			get { return can_highlight; }
			set { can_highlight = value; }
		}
		
		/// <summary>
		/// Returns the space available for controls.
		/// </summary>
		public Size SpaceAvailable {
			get { return panel.Size; }
		}
		
		/// <summary>
		/// Returns the picture box in which the icon is printed
		/// </summary>
		public PictureBox IconBox {
			get { return icon; }
		}
		
	}
	
}
