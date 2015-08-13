/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * TODOMOO FUNCTIONS (Todomoo.cs)
 * Static methods that connect to Todomoo SQLite database.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Todomoo {
	
	/// <summary>
	/// Todomoo main engine.
	/// </summary>
	public static class Todomoo {
		
		// Database
		public static SQLite db;
		private static string database_path;
		public static bool isDbOpen = false;
		
		// Categories and tasks array
		public static ArrayList Categories = new ArrayList();
		public static ArrayList Tasks = new ArrayList();
		
		// Load completed tasks?
		public static bool LoadCompletedTasks = true;
		
		// Hastable that keep track of "lost" timers
		public static Hashtable LostTimers = new Hashtable();
		
		// Main form reference
		public static MainForm mainForm;
		
		/// <summary>
		/// Open the todomoo main database.
		/// </summary>
		/// <param name="database_path">Path of the main SQLite database</param>
		public static void OpenDatabase(string database_path) {
			
			// If not exists, create empty
			if (!File.Exists(database_path)) CreateEmptyDatabase(database_path);
			
			// Open database
			Todomoo.database_path = database_path;
			db = new SQLite(database_path);
			isDbOpen = true;
			
			// Update database
			UpdateDatabase();
			
		}
		
		/// <summary>
		/// Read all the categories in the database and stores in Categories array.
		/// </summary>
		public static void LoadCategories() {
			
			// Read category IDs from the database
			DataTable dt = db.Query("SELECT id FROM category ORDER BY lower(name) ASC");
			
			// Fill in the Categories array
			Categories.Clear();
			foreach (DataRow row in dt.Rows) {
				try { Categories.Add(new Category((int)row["id"])); }
				catch { Utils.MsgDialog.Warning(mainForm.Lang.Get("category_loading_error") + " #" + row["id"].ToString(), mainForm.Lang.Get("warning")); }
			}
			
		}
		
		/// <summary>
		/// Read a summary of all tasks in the database.
		/// Stores an array of Task in Tasks variable.
		/// </summary>
		public static void LoadTasks() {
			LoadTasks(null, true);
		}
		
		/// <summary>
		/// Read a summary of all tasks in the database.
		/// Stores an array of Task in Tasks variable.
		/// </summary>
		/// <param name="category">Filter by category</param>
		public static void LoadTasks(Category category) {
			LoadTasks(category, true);
		}
		
		/// <summary>
		/// Read a summary of all tasks in the database.
		/// Stores an array of Task in Tasks variable.
		/// </summary>
		/// <param name="category">Filter by category</param>
		/// <param name="completed">If FALSE, do not load completed tasks</param>
		public static void LoadTasks(Category category, bool completed) {
			
			// Store running timers, delete paused timers
			foreach (Task t in Tasks) {
				if (t.IsTimerRunning()) { if (!LostTimers.Contains(t.Id)) LostTimers.Add(t.Id, new object[] { t.Timer, DateTime.Now }); }
				else LostTimers.Remove(t.Id);
			}
			
			// Read task IDs from the database
			string whereCondition = "(1)";
			if (category != null) whereCondition += " AND (category = " + category.Id + ")";
			if (!completed) whereCondition += " AND (completed IS NULL) ";
			DataTable dt = db.Query("SELECT id FROM task WHERE " + whereCondition + " GROUP BY task.id ");
			
			// Fill in the Tasks array
			Tasks.Clear();
			foreach (DataRow row in dt.Rows) {
				try { Tasks.Add(new Task((int)row["id"])); }
				catch { Utils.MsgDialog.Warning(mainForm.Lang.Get("task_loading_error") + " #" + row["id"].ToString(), mainForm.Lang.Get("warning")); }
			}
			
			// Restore saved timers
			foreach (Task t in Tasks) if (LostTimers.Contains(t.Id)) {
				int stopped_at = (int)((object[])LostTimers[t.Id])[0]; // Timer was stopper at second
				DateTime stopped_dt = (DateTime)((object[])LostTimers[t.Id])[1]; // Timer was stopped at time
				t.Timer = stopped_at + (int)(DateTime.Now.Subtract(stopped_dt).TotalSeconds); // Restore timer
				t.StartTimer(); // Start timer again!
			}
			
		}
		
		/// <summary>
		/// Get a category from the category buffer
		/// </summary>
		/// <param name="id">Category ID</param>
		/// <returns>Selected category</returns>
		public static Category GetCategoryFromId(int id) {
			foreach (Category c in Categories) {
				if (c.Id == id) return c;
			}
			return null;
		}
		
		/// <summary>
		/// Get the root tasks.
		/// </summary>
		/// <returns>An ArrayList of Task objects</returns>
		public static ArrayList GetRootTasks() {
			ArrayList ret = new ArrayList();
			foreach (Task t in Tasks) if (t.ParentId == 0) if (LoadCompletedTasks || !t.IsCompleted)  { ret.Add(t); }
			return ret;
		}
		
		/// <summary>
		/// Get all the tasks.
		/// </summary>
		/// <returns>An ArrayList of Task objects</returns>
		public static ArrayList GetAllTasks() {
			ArrayList ret = new ArrayList();
			foreach (Task t in Tasks) if (LoadCompletedTasks || !t.IsCompleted) { ret.Add(t); }
			return ret;
		}
		
		/// <summary>
		/// Get the children tasks of a task.
		/// </summary>
		/// <param name="parent">Parent Task</param>
		/// <returns>An ArrayList of Task objects</returns>
		public static ArrayList GetChildrenTasks(Task parent) {
			ArrayList ret = new ArrayList();
			foreach (Task t in Tasks) if (t.ParentId == parent.Id) if (LoadCompletedTasks || !t.IsCompleted) { ret.Add(t); }
			return ret;
		}
		
		/// <summary>
		/// Get the parent of a task.
		/// </summary>
		/// <param name="child">Child Task</param>
		/// <returns>The parent Task, or null</returns>
		public static Task GetParent(Task child) {
			foreach (Task t in Tasks) if (child.ParentId == t.Id) return t;
			return null;
		}
		
		/// <summary>
		/// Get the root task of a task.
		/// </summary>
		/// <param name="child">Child Task</param>
		/// <returns>The root Task</returns>
		public static Task GetRoot(Task child) {
			Task root = child;
			while (root.ParentId != 0) root = GetParent(root);
			return root;
		}
		
		/// <summary>
		/// Check if a task contains another one in its full hierarchy.
		/// </summary>
		/// <param name="parent">Container</param>
		/// <param name="child">Content</param>
		/// <returns>TRUE if container got the content is its full hierarchy, FALSE otherwise</returns>
		public static bool IsContained(Task parent, Task child) {
			while (child != null) {
				if (child.Id == parent.Id) return true;
				child = GetParent(child); }
			return false;
		}
		
		/// <summary>
		/// Change task category to its full hierarchy.
		/// </summary>
		/// <param name="parent">Parent task</param>
		/// <param name="newCategoryId">New category ID</param>
		public static void ChangeCategoryToHierarchy(Task parent, int newCategoryId) {
			
			// Collect hierarchy
			List<Task> tasks = new List<Task>();
			CollectHierarchy(parent, tasks);
			
			// Build and launch query
			string sql = "UPDATE task SET category = " + newCategoryId + " WHERE 0 ";
			foreach (Task task in tasks) sql += "OR (id = " + task.Id + ") ";
			db.Query(sql);
			
			// Change category to objects
			foreach (Task task in tasks) task.CategoryId = newCategoryId;
			
		}
		
		/// <summary>
		/// Fills an List of tasks with a full hierarchy.
		/// </summary>
		/// <param name="parent">Parent task</param>
		/// <param name="tasks">List of tasks, already initialized</param>
		private static void CollectHierarchy(Task parent, List<Task> tasks) {
			if (tasks != null) tasks.Add(parent);
			foreach (Task child in Todomoo.GetChildrenTasks(parent)) CollectHierarchy(child, tasks);
		}
		
		/// <summary>
		/// Count all the tasks in the database
		/// </summary>
		/// <returns>Number of tasks</returns>
		public static int CountTasks() {
			try {
				DataTable dt = Todomoo.db.Query("SELECT COUNT(id) AS num FROM task");
				if (dt.Rows.Count == 0) throw new Exception("No rows");
				return (int)dt.Rows[0]["num"];
			} catch {
				return 0;
			}
		}
		
		/// <summary>
		/// Count the completed tasks that are been loaded with the last LoadTasks() call.
		/// </summary>
		/// <returns>The number of completed tasks.</returns>
		public static int CountCompletedTasks() {
			int completed = 0;
			foreach (Task t in Tasks) try { DateTime d = t.Completed; completed++; } catch { }
			return completed;
		}
		
		/// <summary>
		/// Read all payment different types from the database.
		/// </summary>
		/// <returns>An ArrayList of strings</returns>
		public static ArrayList GetPaymentTypes() {
			try {
				ArrayList ret = new ArrayList();
				DataTable dt = Todomoo.db.Query("SELECT payment FROM task WHERE payment != \"\" GROUP BY lower(payment)");
				foreach (DataRow row in dt.Rows) ret.Add(row["payment"].ToString());
				return ret;
			} catch {
				return new ArrayList();
			}
		}
		
		/// <summary>
		/// Removes a task from the database.
		/// </summary>
		/// <param name="TaskId">Task to remove</param>
		public static void RemoveTask(Task task) {
			ArrayList children = GetChildrenTasks(task);
			foreach (Task child in children) RemoveTask(child);
			db.NonQuery("DELETE FROM note WHERE task = " + task.Id);
			db.NonQuery("DELETE FROM task WHERE id = " + task.Id);
			Tasks.Remove(task);
		}
		
		/// <summary>
		/// Removes a category from the database. Category must be empty.
		/// </summary>
		/// <param name="category">Category to remove</param>
		public static void RemoveCategory(Category category) {
			db.NonQuery("DELETE FROM task WHERE category = " + category.Id);
			db.NonQuery("DELETE FROM category WHERE id = " + category.Id);
			Categories.Remove(category);
		}
		
		/// <summary>
		/// Removes a note from the database.
		/// </summary>
		/// <param name="NoteId">Note to remove</param>
		public static void RemoveNote(Note note) {
			db.NonQuery("DELETE FROM note WHERE id = " + note.Id);
		}
		
		/// <summary>
		/// Export all the database to a CSV file.
		/// </summary>
		/// <param name="path">Output CSV file path</param>
		public static void ExportToCSV(string path) {
			
			// Read tasks from the database
			DataTable dt = db.Query(@"
				SELECT
				    task.id AS ID, task.name AS Name, task.priority AS Priority, 
				    task.creation_date AS 'Creation date', task.due_date AS 'Due date', task.completed AS Completed, 
				    task.timer AS Timer, task.price AS Price, task.paid AS Paid, task.payment AS Payment,
				    category.name AS Category, parent.name AS 'Parent task'
				FROM task 
				    LEFT OUTER JOIN category ON category.id = task.category
				    LEFT OUTER JOIN task AS parent ON task.parent = parent.id
				GROUP BY task.id
				ORDER BY task.id");
			
			// Export to CSV
			StreamWriter sw = new StreamWriter(path);
			CSV.Writer.WriteToStream(sw, dt, true, true);
			sw.Close();
			
		}
		
		/// <summary>
		/// Create the empty database.
		/// </summary>
		public static void CreateEmptyDatabase(string database_path) {
			
			// Open database (create)
			db = new SQLite(database_path);
			string q = "";
			
			// Categories table
			q  = "CREATE TABLE category ( ";
			q += "  id INTEGER PRIMARY KEY AUTOINCREMENT, ";
			q += "  name TEXT NOT NULL, ";
			q += "  colour INTEGER UNSIGNED NOT NULL ";
			q += "); ";
			db.NonQuery(q);
			
			// Notes table
			q  = "CREATE TABLE note ( ";
			q += "  id INTEGER PRIMARY KEY AUTOINCREMENT, ";
			q += "  text TEXT NOT NULL, ";
			q += "  task INTEGER UNSIGNED NOT NULL, ";
			q += "  marked INTEGER UNSIGNED ";
			q += "); ";
			db.NonQuery(q);
			
			// Task table
			q  = "CREATE TABLE task ( ";
			q += "  id INTEGER PRIMARY KEY AUTOINCREMENT, ";
			q += "  name TEXT NOT NULL, ";
			q += "  description TEXT NULL, ";
			q += "  colour INTEGER UNSIGNED NOT NULL, ";
			q += "  priority INTEGER UNSIGNED NOT NULL, ";
			q += "  creation_date TEXT NOT NULL, ";
			q += "  due_date TEXT NULL, ";
			q += "  completed TEXT NULL, ";
			q += "  timer TEXT NULL, ";
			q += "  price TEXT NULL, ";
			q += "  paid TEXT NULL, ";
			q += "  payment TEXT NULL, ";
			q += "  payment_note TEXT NULL, ";
			q += "  parent INTEGER UNSIGNED NULL, ";
			q += "  category INTEGER UNSIGNED NOT NULL ";
			q += "); ";
			db.NonQuery(q);
			
		}
		
		/// <summary>
		/// Update an existing old database.
		/// </summary>
		public static void UpdateDatabase() {
			
			// Try updates
			try { db.NonQuery("ALTER TABLE note ADD COLUMN marked NUMERIC");
				Utils.Debug.Write("Database just updated."); } catch {  }
			try { db.NonQuery("ALTER TABLE task ADD COLUMN pricing_by_hour NUMERIC");
				Utils.Debug.Write("Database just updated."); } catch {  }
			try { db.NonQuery("ALTER TABLE task ADD COLUMN price_by_hour TEXT");
				Utils.Debug.Write("Database just updated."); } catch {  }
				
		}
			
		/// <summary>
		/// Closes the database.
		/// </summary>
		public static void CloseDatabase() {
			db.CloseDatabase();
			isDbOpen = false;
		}
		
	}
	
}
