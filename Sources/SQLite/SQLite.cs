/*
 * ===============================================================
 * UTILS namespace
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * SQLITE CLASS (SQLite.cs)
 * SQLite DLL wrapper.
 * ===============================================================
 */

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.SQLite {
	
	/// <summary>
	/// SQLite wrapper with functions for opening, closing and executing queries.
	/// </summary>
	public class SQLite {
	
		// Imports system functions for work with pointers
		[DllImport("kernel32")] private extern static IntPtr HeapAlloc(IntPtr heap, UInt32 flags, UInt32 bytes);
		[DllImport("kernel32")] private extern static IntPtr GetProcessHeap();
		[DllImport("kernel32")] private extern static int lstrlen(IntPtr str);
		
		// Imports SQLite functions
		[DllImport("sqlite3")] private static extern int sqlite3_open(IntPtr fileName, out IntPtr database);
		[DllImport("sqlite3")] private static extern int sqlite3_close(IntPtr database);
		[DllImport("sqlite3")] private static extern int sqlite3_exec(IntPtr database, IntPtr query, IntPtr callback, IntPtr arguments, out IntPtr error);
		[DllImport("sqlite3")] private static extern IntPtr sqlite3_errmsg(IntPtr database);
		[DllImport("sqlite3")] private static extern int sqlite3_prepare_v2(IntPtr database, IntPtr query, int length, out IntPtr statement, out IntPtr tail);
		[DllImport("sqlite3")] private static extern int sqlite3_step(IntPtr statement);
		[DllImport("sqlite3")] private static extern int sqlite3_column_count(IntPtr statement);
		[DllImport("sqlite3")] private static extern IntPtr sqlite3_column_name(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern int sqlite3_column_type(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern int sqlite3_column_int(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern double sqlite3_column_double(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern IntPtr sqlite3_column_text(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern IntPtr sqlite3_column_blob(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern IntPtr sqlite3_column_table_name(IntPtr statement, int columnNumber);
		[DllImport("sqlite3")] private static extern int sqlite3_finalize(IntPtr handle);
		[DllImport("sqlite3")] private static extern Int64 sqlite3_last_insert_rowid(IntPtr database);
		
		// SQLite constants 
		private const int SQL_OK = 0;
		private const int SQL_ROW = 100;
		private const int SQL_DONE = 101;
		
		/// <summary>
		/// SQLite data types.
		/// </summary>
		public enum SQLiteDataTypes { 
			
			/// <summary>
			/// Integer numbers.
			/// </summary>
			INT = 1, 
			
			/// <summary>
			/// Decimal numbers.
			/// </summary>
			FLOAT,
			
			/// <summary>
			/// All kinds of texts.
			/// </summary>
			TEXT, 
			
			/// <summary>
			/// Blob objects - binary large objects.
			/// </summary>
			BLOB, 
			
			/// <summary>
			/// Nothing.
			/// </summary>
			NULL
		};
		
		// Pointer to database
		private IntPtr database;
		
		/// <summary>
		/// Creates new instance of SQLiteBase class with no database attached.
		/// </summary>
		public SQLite() {
			database = IntPtr.Zero;
		}
		
		/// <summary>
		/// Creates new instance of SQLiteBase class and opens database with given name.
		/// </summary>
		/// <param name="baseName">Name (and path) to SQLite database file</param>
		public SQLite(String baseName) {
			OpenDatabase(baseName);
		}
		
		/// <summary>
		/// Opens database. 
		/// </summary>
		/// <param name="baseName">Name of database file</param>
		public void OpenDatabase(String baseName) {
			
			// Opens database
			if (sqlite3_open(StringToPointer(baseName), out database) != SQL_OK) {
				// If there is some error, database pointer is set to 0 and exception is throws
				database = IntPtr.Zero;
				throw new Exception("Error with opening database " + baseName + "!");
			}
			
		}
		
		/// <summary>
		/// Closes opened database.
		/// </summary>
		public void CloseDatabase() {
			
			// Closes the database if there is one opened
			if (database != IntPtr.Zero) {
				sqlite3_close(database);
			}
			
		}
		
		/// <summary>
		/// Returns the list of tables in opened database.
		/// </summary>
		/// <returns>An array of table names</returns>
		public ArrayList GetTables() {
			
			// Executes query that select names of all tables and views in master table of every database
			String query = "SELECT name FROM sqlite_master " +
				"WHERE type IN ('table','view') AND name NOT LIKE 'sqlite_%'" +
				"UNION ALL " +
				"SELECT name FROM sqlite_temp_master " +
				"WHERE type IN ('table','view') " +
				"ORDER BY 1";
			DataTable table = Query(query);
			
			// When table is generater, it writes all table names in list that is returned
			ArrayList list = new ArrayList();
			foreach (DataRow row in table.Rows) list.Add(row.ItemArray[0].ToString());
			return list;
			
		}
		
		/// <summary>
		/// Executes query that does not return anything (UPDATE, INSERT, DELETE).
		/// </summary>
		/// <param name="query">SQL query string</param>
		public void NonQuery(String query) {
			
			// Calles SQLite function that executes non-query
			IntPtr error;
			sqlite3_exec(database, StringToPointer(query), IntPtr.Zero, IntPtr.Zero, out error);
			
			// If there is error, excetion is thrown
			if (error != IntPtr.Zero) {
				throw new Exception(
					"Error with executing non-query: \"" + query + "\"\n" + 
					PointerToString(sqlite3_errmsg(error))
				);
			}
			
		}
		
		/// <summary>
		/// Executes selection query.
		/// </summary>
		/// <param name="query">SQL query string</param>
		/// <returns>A DataTable object containg data selected</returns>
		public DataTable Query(String query) {
			
			// Process query and make statement
			IntPtr statement;
			IntPtr excessData;
			sqlite3_prepare_v2(database, StringToPointer(query), GetPointerLenght(StringToPointer(query)), out statement, out excessData);
			
			// Table for result of function
			DataTable table = new DataTable();
			
			// Reads first row - it is different from next rows because it also creates table columns
			int result = ReadFirstRow(statement, ref table);
			
			// Reads other rows
			while (result == SQL_ROW) result = ReadNextRow(statement, ref table);
			
			// Finalize executing this query
			sqlite3_finalize(statement);
			
			// Returns table
			return table;
			
		}
		
		/// <summary>
		/// Escape strings for SQL statements
		/// </summary>
		/// <param name="s">String to escape</param>
		/// <returns>Escaped string</returns>
		public static string Escape(string s) {
			return Escape(s, false);
		}
		public static string Escape(string s, bool add_quotes) {
			if (add_quotes) return "'" + s.Replace("'", "''") + "'";
			return s.Replace("'", "''");
		}
		
		/// <summary>
		/// Get last insertion ID
		/// </summary>
		/// <returns>The ID of the most recent successful INSERT into the database</returns>
		public int LastInsertId() {
			if (database == IntPtr.Zero) return 0;
			Int64 id = sqlite3_last_insert_rowid(database);
			return (int)id;
		}
		
		/// <summary>
		/// Tell if a object result of query is a NULL or an empty string
		/// </summary>
		/// <param name="o">Object returned from query</param>
		/// <returns>Boolean answer</returns>
		public static bool IsNull(object o) {
			string type = o.GetType().ToString();
			if ((type != "System.String") && (type != "String") && (type != "string")) return false;
			return (o.ToString() == "");
		}
		
		// Private function for reading firs row and creating DataTable
		private int ReadFirstRow(IntPtr statement, ref DataTable table) {
			
			// Create new instance of DataTable with name "resultTable"
			table = new DataTable("resultTable");
			
			// Evaluates statement 
			int resultType = sqlite3_step(statement);
			
			// If result of statement is SQL_ROW, create new table and write row in it
			if (resultType == SQL_ROW) {
				int columnCount = sqlite3_column_count(statement);
				String columnName = "";
				int columnType = 0;
				object[] columnValues = new object[columnCount];
				
				// Reads columns one by one
				for (int i = 0; i < columnCount; i++) {
					
					// Returns the name and type of current column
					columnName = PointerToString(sqlite3_column_name(statement, i));
					columnType = sqlite3_column_type(statement, i);

					// Checks type of columns - neccessary because different functions are required for different types
					switch (columnType) {
						case (int)SQLiteDataTypes.INT: {
							table.Columns.Add(columnName, Type.GetType("System.Int32"));
							columnValues[i] = sqlite3_column_int(statement, i);
							break; }
						case (int)SQLiteDataTypes.FLOAT: {
							table.Columns.Add(columnName, Type.GetType("System.Single"));
							columnValues[i] = sqlite3_column_double(statement, i);
							break; }
						case (int)SQLiteDataTypes.TEXT: {
							table.Columns.Add(columnName, Type.GetType("System.String"));
							columnValues[i] = PointerToString(sqlite3_column_text(statement, i));
							break; }
						case (int)SQLiteDataTypes.BLOB: {
							table.Columns.Add(columnName, Type.GetType("System.String"));
							columnValues[i] = PointerToString(sqlite3_column_blob(statement, i));
							break; }
						default: {
							table.Columns.Add(columnName, Type.GetType("System.String"));
							columnValues[i] = "";
							break; }
					}
					
				}
				
				// Writes column values to table
				table.Rows.Add(columnValues);
				
			}
			
			// Evalute statemnet for next results
			return sqlite3_step(statement);
			
		}
		
		// Private function for reading rows other than first.
		private int ReadNextRow(IntPtr statement, ref DataTable table) {
			int columnCount = sqlite3_column_count(statement);
			int columnType = 0;
			object[] columnValues = new object[columnCount];
			for (int i = 0; i < columnCount; i++) {
				columnType = sqlite3_column_type(statement, i);
				switch (columnType) {
					case (int)SQLiteDataTypes.INT: {
						columnValues[i] = sqlite3_column_int(statement, i);
						break; }
					case (int)SQLiteDataTypes.FLOAT: {
						columnValues[i] = sqlite3_column_double(statement, i);
						break; }
					case (int)SQLiteDataTypes.TEXT: {
						columnValues[i] = PointerToString(sqlite3_column_text(statement, i));
						break; }
					case (int)SQLiteDataTypes.BLOB: {
						columnValues[i] = PointerToString(sqlite3_column_blob(statement, i));
						break; }
					default: {
						columnValues[i] = "";
						break; }
				}
			}
			table.Rows.Add(columnValues);
			return sqlite3_step(statement);
		}
		
		// Converts string to pointer
		private IntPtr StringToPointer(String str) {
			if (str == null) return IntPtr.Zero;
			Encoding encoding = Encoding.UTF8;
			Byte[] bytes = encoding.GetBytes(str);
			int length = bytes.Length + 1;
			IntPtr pointer = HeapAlloc(GetProcessHeap(), 0, (UInt32)length);
			Marshal.Copy(bytes, 0, pointer, bytes.Length);
			Marshal.WriteByte(pointer, bytes.Length, 0);
			return pointer;
		}
		
		// Convert pointer to string
		private String PointerToString(IntPtr ptr) {
			if (ptr == IntPtr.Zero) return null;
			Encoding encoding = Encoding.UTF8;
			int length = GetPointerLenght(ptr);
			Byte[] bytes = new Byte[length];
			Marshal.Copy(ptr, bytes, 0, length);
			return encoding.GetString(bytes, 0, length);
		}
		
		// Returns length of pointer
		private int GetPointerLenght(IntPtr ptr) {
			if (ptr == IntPtr.Zero) return 0;
			return lstrlen(ptr);
		}
		
	}
	
}
