/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * TASK CLASS (Task.cs)
 * Class for a single task.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;

namespace Todomoo {
	
	/// <summary>
	/// A single Todomoo task.
	/// </summary>
	public class Task : ICloneable {
		
		// Task properties
		private int id = 0;
		private string name = "";
		private bool has_description = false;
		private string description;
		private Color colour = Color.Gray;
		private int priority = 0;
		private DateTime creation_date = DateTime.Now;
		private bool has_due_date = false;
		private DateTime due_date;
		private bool has_completed = false;
		private DateTime completed;
		private bool has_timer = false;
		private int timer;
		private bool has_paid = false;
		private DateTime paid;
		private bool has_price = false;
		private float price;
		private bool has_payment = false;
		private string payment;
		private bool has_payment_note = false;
		private string payment_note;
		private bool pricing_by_hour = false;
		private float price_by_hour = 0F;
		private int parent = 0;
		private int category = 0;
		private int notes = 0;
		
		// Timer variables
		private bool timer_running = false;
		private DateTime timer_started = DateTime.Now;
		
		// Notes that have to be saved
		private ArrayList pending_notes = new ArrayList();
		
		// Glabalization variables for floats and dates
		private CultureInfo culture = CultureInfo.CurrentCulture;
		private NumberFormatInfo num_format = new NumberFormatInfo();
		
		/// <summary>
		/// Create a new task.
		/// </summary>
		public Task() { 
			
			// Setup globalization
			num_format.NumberDecimalSeparator = ".";
			num_format.NumberGroupSeparator = "";
			
		}
		
		/// <summary>
		/// Load a task from the database.
		/// </summary>
		/// <param name="id">ID of the task</param>
		public Task(int id) : base() {
			Load(id);
		}
		
		/// <summary>
		/// Load a specified task from the database. ID will be updated.
		/// </summary>
		/// <param name="id">ID of the task to load</param>
		public void Load(int id) {
			
			// Update ID
			this.id = id;
			
			// Read task from the database
			string q;
			q  = "SELECT task.*, COUNT(note.id) AS notes ";
			q += "FROM task LEFT OUTER JOIN note ON note.task = task.id ";
			q += "WHERE task.id = " + Id + " ";
			q += "GROUP BY task.id ";
			q += "LIMIT 1 ";
			DataTable dt = Todomoo.db.Query(q);
			if (dt.Rows.Count == 0) throw new Exception("No rows " + Id);
			
			// Fill in properties
			DataRow row = dt.Rows[0];
			id = (int)row["id"];
			Name = row["name"].ToString();
			Description = row["description"].ToString();
			Colour = Utils.Conversion.ColourFromInt((int)row["colour"]);
			Priority = (int)row["priority"];
			CreationDate = DateTime.ParseExact(row["creation_date"].ToString(), "yyyy-MM-dd", culture);
			if (!SQLite.IsNull(row["due_date"])) DueDate = DateTime.ParseExact(row["due_date"].ToString(), "yyyy-MM-dd", culture);
			if (!SQLite.IsNull(row["completed"])) Completed = DateTime.ParseExact(row["completed"].ToString(), "yyyy-MM-dd", culture);
			if (!SQLite.IsNull(row["timer"])) Timer = int.Parse(row["timer"].ToString());
			if (!SQLite.IsNull(row["paid"])) Paid = DateTime.ParseExact(row["paid"].ToString(), "yyyy-MM-dd", culture);
			if (!SQLite.IsNull(row["price"])) Price = float.Parse(row["price"].ToString(), num_format);
			if (!SQLite.IsNull(row["pricing_by_hour"])) PricingByHour = (row["pricing_by_hour"].ToString() == "1" ? true : false);
			if (!SQLite.IsNull(row["price_by_hour"])) PriceByHour = float.Parse(row["price_by_hour"].ToString(), num_format);
			Payment = row["payment"].ToString();
			PaymentNote = row["payment_note"].ToString();
			ParentId = Utils.Conversion.ToInt(row["parent"]);
			CategoryId = (int)row["category"];
			notes = (int)row["notes"];
			
		}
		
		/// <summary>
		/// Creates a new Task cloning this one.
		/// </summary>
		/// <returns>The cloned task</returns>
		public Object Clone() {
			Task task = new Task();
			task.name = this.name;
			task.has_description = this.has_description;
			task.description = this.description;
			task.colour = this.colour;
			task.priority = this.priority;
			task.has_due_date = this.has_due_date;
			task.due_date = this.due_date;
			task.has_completed = this.has_completed;
			task.completed = this.completed;
			task.has_timer = this.has_timer;
			task.timer = this.timer;
			task.has_paid = this.has_paid;
			task.paid = this.paid;
			task.has_price = this.has_price;
			task.price = this.price;
			task.has_payment = this.has_payment;
			task.payment = this.payment;
			task.has_payment_note = this.has_payment_note;
			task.payment_note = this.payment_note;
			task.pricing_by_hour = this.pricing_by_hour;
			task.price_by_hour = this.price_by_hour;
			task.category = this.category;
			return task;
		}
		
		/// <summary>
		/// Update task in the database. If task needs to
		/// be inserted, it will be inserted.
		/// </summary>
		public void Save() {
			
			// Create hastable informations
			Hashtable h = new Hashtable();
			h.Add("name", SQLite.Escape(name, true));
			h.Add("description", (has_description) ? SQLite.Escape(description, true) : "NULL");
			h.Add("colour", Utils.Conversion.ColourToInt(colour));
			h.Add("priority", priority);
			h.Add("creation_date", "'" +  creation_date.ToString("yyyy-MM-dd") + "'");
			h.Add("due_date", (has_due_date) ? "'" + due_date.ToString("yyyy-MM-dd") + "'" : "NULL");
			h.Add("completed", (has_completed) ? "'" + completed.ToString("yyyy-MM-dd") + "'" : "NULL");
			h.Add("timer", (has_timer) ? timer.ToString() : "NULL");
			h.Add("price", (has_price) ? price.ToString("0.00", num_format) : "NULL");
			h.Add("paid", (has_paid) ? "'" + paid.ToString("yyyy-MM-dd") + "'" : "NULL");
			h.Add("payment", (has_payment) ? SQLite.Escape(payment, true) : "NULL");
			h.Add("payment_note", (has_payment_note) ? SQLite.Escape(payment_note, true) : "NULL");
			h.Add("pricing_by_hour", (pricing_by_hour) ? "1" : "0");
			h.Add("price_by_hour", price_by_hour.ToString("0.00", num_format));
			h.Add("parent", (parent > 0) ? parent.ToString() : "NULL");
			h.Add("category", category);
			
			// Add task in the database
			if (id == 0) {
				string fields = ""; string data = "";
				foreach (string key in h.Keys) { fields += key + ","; data += h[key].ToString() + ","; }
				string q = "INSERT INTO task (" + fields.TrimEnd(new char[] {','}) + ") VALUES (" + data.TrimEnd(new char[] {','}) + ")";
				Todomoo.db.NonQuery(q);
				id = Todomoo.db.LastInsertId();
				
			// Edit task
			} else {
				string q = "UPDATE task SET ";
				foreach (string key in h.Keys) q += key + "=" + h[key].ToString() + ",";
				q = q.TrimEnd(new char[] {','}) + " WHERE id = " + id.ToString();
				Todomoo.db.NonQuery(q);
			}
			
		}
		
		/// <summary>
		/// Reload the task. If it is an unsaved task, this method does nothing.
		/// </summary>
		public void Reload() { 
			if (Id != 0) Load(Id);
		}
		
		/// <summary>
		/// Save and reload the task. If it is a new task, it will be created and ID will be updated.
		/// </summary>
		public void Update() {
			Save();
			Reload();
		}
		
		/// <summary>
		/// Start the task timer. You NEED to call StopTimer() before any database operation on this task!
		/// </summary>
		public void StartTimer() {
			if (timer_running) return;
			if (has_timer == false) Timer = 0;
			timer_started = DateTime.Now;
			timer_running = true;
		}
		
		/// <summary>
		/// Stop the task timer. Timer property will be increased by the 
		/// number of seconds elapsed from the previus StartTimer() call.
		/// </summary>
		public void StopTimer() {
			if (!has_timer) return;
			if (!timer_running) return;
			timer += (int)((DateTime.Now.Subtract(timer_started)).TotalSeconds);
			timer_running = false;
		}
		
		/// <summary>
		/// Tells if the timer for this task is running
		/// </summary>
		/// <returns>Boolean value</returns>
		public bool IsTimerRunning() {
			return (has_timer && timer_running);
		}
		
		/// <summary>
		/// Get the notes of this task.
		/// </summary>
		/// <returns>Array of notes</returns>
		public ArrayList GetNotes() {
			ArrayList ret = new ArrayList();
			
			// Read notes IDs from the database
			if (Id != 0) {
				DataTable dt = Todomoo.db.Query("SELECT id FROM note WHERE task = " + Id + " ORDER BY id ASC ");
				foreach (DataRow row in dt.Rows) try { ret.Add(new Note((int)row["id"])); } catch {  }
			}
			
			return ret;
		}
		
		/// <summary>
		/// Get the pending notes for this task that have to be saved.
		/// </summary>
		/// <returns>An ArrayList of notes</returns>
		public ArrayList GetUnsavedNotes() {
			return pending_notes;
		}
		
		/// <summary>
		/// Create an array of pending notes that needs to be saved.
		/// </summary>
		/// <param name="notes">ArrayList of Note objects</param>
		public void SetUnsavedNotes(ArrayList notes) {
			pending_notes.Clear();
			this.pending_notes = notes;
		}
		
		/// <summary>
		/// Clear the array that contains the pending notes. This will NOT save these notes.
		/// </summary>
		public void ClearUnsavedNotes() {
			this.pending_notes.Clear();
		}
		
		#region Properties get/set
		
		/// <summary>
		/// Is this task a root task? Based on ParentId property.
		/// </summary>
		/// <returns>A boolean value</returns>
		public bool IsRoot() {
			return ParentId == 0;
		}
		
		// Optional properties remove
		public void RemoveDescription() { has_description = false; }
		public void RemoveDueDate() { has_due_date = false; }
		public void RemoveCompleted() { has_completed = false; }
		public void RemoveTimer() { has_timer = false; }
		public void RemovePrice() { has_price = false; price_by_hour = 0F; pricing_by_hour = false; }
		public void RemovePaid() { has_paid = false; }
		public void RemovePayment() { has_payment = false; }
		public void RemovePaymentNote() { has_payment_note = false; }
		
		// Properties get/set
		public int Id {
			get { return id; }
		}
		public string Name {
			get { return name; }
			set { name = value; }
		}
		public string Description {
			get { if (has_description) return description; else throw new Exception("NULL"); }
			set { has_description = (value.Trim() != ""); if (has_description) description = value.Trim(); }
		}
		public Color Colour {
			get { return colour; }
			set { colour = value; }
		}
		public int Priority {
			get { return priority; }
			set { priority = value; }
		}
		public DateTime CreationDate {
			get { return creation_date; }
			set { creation_date = value; }
		}
		public DateTime DueDate {
			get { if (has_due_date) return due_date; else throw new Exception("NULL"); }
			set { due_date = value; has_due_date = true; }
		}
		public DateTime Completed {
			get { if (has_completed) return completed; else throw new Exception("NULL"); }
			set { completed = value; has_completed = true; }
		}
		public bool IsCompleted {
			get { return has_completed; }
		}
		
		/// <summary>
		/// Timer, in seconds
		/// </summary>
		public int Timer {
			get { 
				if (!has_timer) throw new Exception("NULL");
				if (!timer_running) return timer;
				return timer + (int)((DateTime.Now.Subtract(timer_started)).TotalSeconds); }
			set { timer = value; has_timer = true; }
		}
		
		/// <summary>
		/// Timer, as h:mm:ss string
		/// </summary>
		public string TimerString {
			get {
				try {
					return TimerToString(Timer);
				} catch {
					return TimerToString(0);
				}
			}
		}
		
		public float Price {
			get { 
				if (pricing_by_hour) {
					if ((!has_timer) || (price_by_hour == 0)) return 0F;
					else return (Timer / 3600F) * price_by_hour;
				} else {
					if (has_price) return price; else throw new Exception("NULL");
				}
			}
			set { price = value; has_price = true; }
		}
		public DateTime Paid {
			get { if (has_paid) return paid; else throw new Exception("NULL"); }
			set { paid = value; has_paid = true; }
		}
		public string Payment {
			get { if (has_payment) return payment; else throw new Exception("NULL"); }
			set { has_payment = (value.Trim() != ""); if (has_payment) payment = value.Trim(); }
		}
		public string PaymentNote {
			get { if (has_payment_note) return payment_note; else throw new Exception("NULL"); }
			set { has_payment_note = (value.Trim() != ""); if (has_payment_note) payment_note = value.Trim(); }
		}
		public bool PricingByHour {
			get { return pricing_by_hour; }
			set { pricing_by_hour = value; }
		}
		public float PriceByHour {
			get { if (price_by_hour > 0) return price_by_hour; else return 0F; }
			set { price_by_hour = value; }
		}
		public int ParentId {
			get { return parent; }
			set { parent = value; }
		}
		public int CategoryId {
			get { return category; }
			set { category = value; }
		}
		public int NotesCount {
			get { return notes; }
		}
		
		#endregion
		
		/// <summary>
		/// Convert a integer number (seconds) to h:mm:ss string (utils static method).
		/// </summary>
		public static string TimerToString(int timer) {
			int o = timer;
			if (o <= 0) return "";
			int s = o % 60;
			int m = ((o - s) / 60) % 60;
			int h = (o - s - m * 60) / (60 *60);
			return h + ":" + m.ToString("00") + ":" + s.ToString("00");
		}
		
	}
	
}
