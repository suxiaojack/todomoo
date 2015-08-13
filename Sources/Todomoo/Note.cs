/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * NOTE CLASS (Note.cs)
 * Class for a single note.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;

namespace Todomoo {
	
	/// <summary>
	/// A single Todomoo note.
	/// </summary>
	public class Note {
		
		// Note properties
		private int id = 0;
		private string text = "";
		private int task_id = 0;
		private bool marked = false;
		
		/// <summary>
		/// Create a new note.
		/// </summary>
		public Note() { }
		
		/// <summary>
		/// Load a note from the database.
		/// </summary>
		/// <param name="Id">ID of the note</param>
		public Note(int id) : base() {
			Load(id);
		}
		
		/// <summary>
		/// Load a specified note from the database. ID will be updated.
		/// </summary>
		/// <param name="id">ID of the note to load</param>
		public void Load(int id) {
			
			// Update ID
			this.id = id;
			
			// Read note from the database
			DataTable dt = Todomoo.db.Query("SELECT * FROM note WHERE id = " + Id + " LIMIT 1");
			if (dt.Rows.Count == 0) throw new Exception("No rows");
			
			// Fill in properties
			DataRow row = dt.Rows[0];
			id = (int)row["id"];
			Text = row["text"].ToString();
			TaskId = (int)row["task"];
			Marked = Utils.Conversion.ToBool(row["marked"]);
			
		}
		
		/// <summary>
		/// Update note in the database. If note needs to
		/// be inserted, it will be inserted.
		/// </summary>
		public void Save() {
			
			// Create hastable informations
			Hashtable h = new Hashtable();
			h.Add("text", SQLite.Escape(Text, true));
			h.Add("task", TaskId);
			h.Add("marked", (Marked ? 1 : 0));
			
			// Add note in the database
			if (id == 0) {
				string fields = ""; string data = "";
				foreach (string key in h.Keys) { fields += key + ","; data += h[key].ToString() + ","; }
				string q = "INSERT INTO note (" + fields.TrimEnd(new char[] {','}) + ") VALUES (" + data.TrimEnd(new char[] {','}) + ")";
				Todomoo.db.NonQuery(q);
				id = Todomoo.db.LastInsertId();
				
			// Edit category
			} else {
				string q = "UPDATE note SET ";
				foreach (string key in h.Keys) q += key + "=" + h[key].ToString() + ",";
				q = q.TrimEnd(new char[] {','}) + " WHERE id = " + id.ToString();
				Todomoo.db.NonQuery(q);
			}
			
		}
		
		/// <summary>
		/// Reload the note. If it is an unsaved note, this method does nothing.
		/// </summary>
		public void Reload() { 
			if (Id != 0) Load(Id);
		}
		
		/// <summary>
		/// Save and reload the note. If it is a new category, it will be created and ID will be updated.
		/// </summary>
		public void Update() {
			Save();
			Reload();
		}
		
		// Properties get/set
		public int Id {
			get { return id; }
		}
		public string Text {
			get { return text; }
			set { text = value; }
		}
		public int TaskId {
			get { return task_id; }
			set { task_id = value; }
		}
		public bool Marked {
			get { return marked; }
			set { marked = value; }
		}
		
	}
	
}
