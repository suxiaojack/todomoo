/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * CATEGORY CLASS (Category.cs)
 * Class for a single category.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Drawing;

namespace Todomoo {
	
	/// <summary>
	/// A single Todomoo category.
	/// </summary>
	public class Category {
		
		// Note properties
		private int id = 0;
		private string name = "";
		private Color colour = Color.Gray;
		
		/// <summary>
		/// Create a new category.
		/// </summary>
		public Category() { }
		
		/// <summary>
		/// Load a category from the database.
		/// </summary>
		/// <param name="Id">ID of the category</param>
		public Category(int id) : base() {
			Load(id);
		}
		
		/// <summary>
		/// Load a specified category from the database. ID will be updated.
		/// </summary>
		/// <param name="id">ID of the category to load</param>
		public void Load(int id) {
			
			// Update ID
			this.id = id;
			
			// Read category from the database
			DataTable dt = Todomoo.db.Query("SELECT * FROM category WHERE id = " + Id + " LIMIT 1");
			if (dt.Rows.Count == 0) throw new Exception("No rows");
			
			// Fill in properties
			DataRow row = dt.Rows[0];
			id = (int)row["id"];
			Name = row["name"].ToString();
			Colour = Utils.Conversion.ColourFromInt((int)row["colour"]);
			
		}
		
		/// <summary>
		/// Update category in the database. If category needs to
		/// be inserted, it will be inserted.
		/// </summary>
		public void Save() {
			
			// Create hastable informations
			Hashtable h = new Hashtable();
			h.Add("name", SQLite.Escape(name, true));
			h.Add("colour", Utils.Conversion.ColourToInt(colour));
			
			// Add category in the database
			if (id == 0) {
				string fields = ""; string data = "";
				foreach (string key in h.Keys) { fields += key + ","; data += h[key].ToString() + ","; }
				string q = "INSERT INTO category (" + fields.TrimEnd(new char[] {','}) + ") VALUES (" + data.TrimEnd(new char[] {','}) + ")";
				Todomoo.db.NonQuery(q);
				id = Todomoo.db.LastInsertId();
				
			// Edit category
			} else {
				string q = "UPDATE category SET ";
				foreach (string key in h.Keys) q += key + "=" + h[key].ToString() + ",";
				q = q.TrimEnd(new char[] {','}) + " WHERE id = " + id.ToString();
				Todomoo.db.NonQuery(q);
			}
			
		}
		
		/// <summary>
		/// Reload the category. If it is an unsaved category, this method does nothing.
		/// </summary>
		public void Reload() { 
			if (Id != 0) Load(Id);
		}
		
		/// <summary>
		/// Save and reload the category. If it is a new category, it will be created and ID will be updated.
		/// </summary>
		public void Update() {
			Save();
			Reload();
		}
		
		/// <summary>
		/// Get the number of tasks in this category
		/// </summary>
		public int GetTasksCount() {
			DataTable dt = Todomoo.db.Query("SELECT COUNT(id) AS num FROM task WHERE category = " + Id);
			if (dt.Rows.Count == 0) throw new Exception("No rows");
			return (int)dt.Rows[0]["num"];
		}
		
		// Properties get/set
		public int Id {
			get { return id; }
		}
		public string Name {
			get { return name; }
			set { name = value; }
		}
		public Color Colour {
			get { return colour; }
			set { colour = value; }
		}
		
	}
	
	/// <summary>
	/// A comparer for category. Based on category name.
	/// </summary>
	public class CategoryComparer : IComparer  {
		
		int IComparer.Compare(object x, object y)  {
			try { return (new CaseInsensitiveComparer()).Compare(((Category)x).Name, ((Category)y).Name); }
			catch { return 0; }
		}
		
   }

	
}
