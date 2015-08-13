/*
 * ===============================================================
 * UTILS namespace
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * DEBUG CLASS (Debug.cs)
 * Static method to debug informations.
 * ===============================================================
 */
 
using System;

namespace Utils {
	
	public class Debug {
		
		public static void Dump(object var) {
			System.Diagnostics.Debug.Write("[" + DateTime.Now.ToLongTimeString() + "] ");
			if (var == null) Console.Write("(NullObject) ");
			else System.Diagnostics.Debug.Write("(" + var.GetType().ToString() + ") ");
			Write(var);
		}
		
		public static void Write(object var) {
			if (var == null) System.Diagnostics.Debug.WriteLine("null");
			else System.Diagnostics.Debug.WriteLine(var.ToString());
		}
		
		public static void Popup(object var) {
			string text = "";
			text += DateTime.Now.ToLongTimeString() + "\n";
			if (var == null) text += "NullObject\n\n";
			else text += var.GetType().ToString() + "\n\n";
			if (var == null) text += "null";
			else text += var.ToString();
			MsgDialog.Info(text, "Variable information");
		}
		
	}
	
}
