/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * CATEGORY FORM (filename)
 * The small form for create and edit categories.
 * ===============================================================
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Todomoo {
	
	/// <summary>
	/// Category Form.
	/// </summary>
	public partial class CategoryForm : Form {
		
		// Category to add/edit
		private Category category;
		
		// Language and settings
		private Languages.Language Lang;
		
		/// <summary>
		/// Edit a Category object.
		/// </summary>
		/// <param name="category">Category to edit</param>
		public CategoryForm(Languages.Language language, Category category) {
			
			// Windows Forms designer support.
			InitializeComponent();
			
			// Setup task
			this.category = category;
			
			// Create form icon
			this.Icon = IconColoured.GetSquaredIcon(category.Colour);
			
			// Setup language
			Lang = language;
			Text = Lang.Get((category.Id == 0) ? "category_add" : "category_edit");
			btnOk.Text = " " + Lang.Get((category.Id == 0) ? "add" : "edit");
			btnCancel.Text = Lang.Get("cancel");
			btnChooseColour.Text = " " + Lang.Get("colour_choose");
			lblName.Text = Lang.Get("name") + ":";
			lblColour.Text = Lang.Get("colour") + ":";
			
			// Populate colours combo
			int index = 0;
			cmbColour.ImageList.ColorDepth = ColorDepth.Depth32Bit;
			foreach (Category cat in Todomoo.Categories) {
				cmbColour.ImageList.Images.Add(IconColoured.GetSquared(cat.Colour));
				ImageComboItem item = new ImageComboItem(Lang.Get("colour_as") + " " + cat.Name, index);
				item.Tag = cat.Colour;
				cmbColour.Items.Add(item);
				index++; }
			if (cmbColour.Items.Count == 0) {
				cmbColour.ImageList.Images.Add(IconColoured.GetSquared(Color.Gray));
				ImageComboItem item = new ImageComboItem(Lang.Get("default"), index);
				item.Tag = Color.Gray;
				cmbColour.Items.Add(item); }
			cmbColour.SelectedIndex = 0;
			
			// Fill in GUI fields
			txtName.Text = category.Name;
			foreach (ImageComboItem item in cmbColour.Items)
				if (item.Text == Lang.Get("colour_as") + " " + category.Name)
					cmbColour.SelectedItem = item;
			
		}
		
		/// <summary>
		/// Update properties of the Category object.
		/// </summary>
		public bool Save() {
			
			// Check compulsory fields
			if (txtName.Text == "") {
				Utils.MsgDialog.Warning(Lang.Get("invalid_entry"), Lang.Get("warning"));
				txtName.Focus();
				return false; }
			
			// Update fileld from GUI
			category.Name = txtName.Text;
			category.Colour = (Color)(((ImageComboItem)cmbColour.SelectedItem).Tag);
			
			return true;
			
		}
		
		#region GUI events
		
		void BtnOkClick(object sender, EventArgs e) {
			if (Save()) { this.DialogResult = DialogResult.OK; Close(); }
		}
		
		void BtnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel; Close();
		}
		
		void CategoryFormShown(object sender, EventArgs e) {
			txtName.Focus();
			txtName.SelectAll();
		}
		
		void BtnChooseColourClick(object sender, EventArgs e) {
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				Color col = colorDialog.Color;
				cmbColour.ImageList.Images.Add(IconColoured.GetSquared(col));
				ImageComboItem item = new ImageComboItem("RGB [" + col.R + ", "+ col.G + ", "+ col.B + "]" , cmbColour.Items.Count);
				item.Tag = col;
				cmbColour.Items.Add(item);
				cmbColour.SelectedIndex = cmbColour.Items.Count - 1;
			}
		}
		
		void cmbColourSelectedIndexChanged(object sender, EventArgs e) {
			this.Icon = IconColoured.GetSquaredIcon((Color)(((ImageComboItem)cmbColour.SelectedItem).Tag));
		}
		
		#endregion
		
	}
	
}
