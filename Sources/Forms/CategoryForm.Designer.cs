/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 */
namespace Todomoo
{
	partial class CategoryForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbColour = new System.Windows.Forms.ImageCombo();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblColour = new System.Windows.Forms.Label();
			this.btnChooseColour = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
			this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOk.Location = new System.Drawing.Point(112, 72);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(136, 24);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = " Add/edit";
			this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(256, 72);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// colorDialog
			// 
			this.colorDialog.Color = System.Drawing.Color.Gray;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Location = new System.Drawing.Point(8, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(336, 1);
			this.panel1.TabIndex = 5;
			// 
			// cmbColour
			// 
			this.cmbColour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbColour.FormattingEnabled = true;
			this.cmbColour.Location = new System.Drawing.Point(72, 32);
			this.cmbColour.Name = "cmbColour";
			this.cmbColour.Size = new System.Drawing.Size(176, 22);
			this.cmbColour.TabIndex = 1;
			this.cmbColour.SelectedIndexChanged += new System.EventHandler(this.cmbColourSelectedIndexChanged);
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(8, 8);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(64, 16);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name:";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(72, 8);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(272, 21);
			this.txtName.TabIndex = 0;
			// 
			// lblColour
			// 
			this.lblColour.Location = new System.Drawing.Point(8, 32);
			this.lblColour.Name = "lblColour";
			this.lblColour.Size = new System.Drawing.Size(64, 16);
			this.lblColour.TabIndex = 3;
			this.lblColour.Text = "Colour:";
			this.lblColour.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// btnChooseColour
			// 
			this.btnChooseColour.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseColour.Image")));
			this.btnChooseColour.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnChooseColour.Location = new System.Drawing.Point(256, 31);
			this.btnChooseColour.Name = "btnChooseColour";
			this.btnChooseColour.Size = new System.Drawing.Size(88, 24);
			this.btnChooseColour.TabIndex = 2;
			this.btnChooseColour.Text = " More";
			this.btnChooseColour.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnChooseColour.UseVisualStyleBackColor = true;
			this.btnChooseColour.Click += new System.EventHandler(this.BtnChooseColourClick);
			// 
			// CategoryForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(353, 105);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnChooseColour);
			this.Controls.Add(this.lblColour);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.cmbColour);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CategoryForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Category";
			this.Shown += new System.EventHandler(this.CategoryFormShown);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ImageCombo cmbColour;
		private System.Windows.Forms.Button btnChooseColour;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblColour;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblName;
	}
}
