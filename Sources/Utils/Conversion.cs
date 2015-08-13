/*
 * ===============================================================
 * UTILS namespace
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * CONVERSION CLASS (Conversion.cs)
 * Static methods to convert into integers and booleans, and to
 * create colours from integer values (and viceversa).
 * ===============================================================
 */

using System;

namespace Utils {
	
	public class Conversion {
		
		public static int ToInt(object o) {
			try { return Convert.ToInt32(o); }
			catch { return 0; }
		}
		
		public static long ToLong(object o) {
			try { return Convert.ToInt64(o); }
			catch { return 0; }
		}
		
		public static bool ToBool(object o) {
			try { return Convert.ToBoolean(o); }
			catch { return false; }
		}
		
		public static System.Drawing.Color ColourFromInt(int number) {
			int R = (byte)((number) % 256);
			int G = (byte)((number / 256) % 256);
			int B = (byte)((number / (256 * 256)) % 256);
			return System.Drawing.Color.FromArgb(R, G, B);
		}
		
		public static int ColourToInt(System.Drawing.Color colour) {
			int number = colour.R;
			number += 256 * colour.G;
			number += 256 * 256 * colour.B;
			return number;
		}
		
	}
	
}
