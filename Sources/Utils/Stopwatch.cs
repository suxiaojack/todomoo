/*
 * ===============================================================
 * UTILS namespace
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * STOPWATCH CLASS (Stopwatch.cs)
 * A simple stopwatch.
 * ===============================================================
 */

using System;

namespace Utils {
	
	public class Stopwatch {
		
		DateTime start;
		
		public Stopwatch() { Restart(); }
		public void Restart() { start = DateTime.Now; }
		public TimeSpan GetSpan() { return DateTime.Now.Subtract(start); }
		
		public long GetTotalMilliseconds() {
			TimeSpan t = GetSpan();
			return (long)Math.Round(t.TotalMilliseconds, 0);
		}
		
		public long GetTotalSeconds() {
			TimeSpan t = GetSpan();
			return (long)Math.Round(t.TotalSeconds, 0);
		}
		
		public long GetTotalMinutes() {
			TimeSpan t = GetSpan();
			return (long)Math.Round(t.TotalMinutes, 0);
		}
		
		public override string ToString() {
			TimeSpan t = GetSpan();
			return (t.Minutes + t.Hours*60 + t.Days*24*60).ToString() + ":" + t.Seconds.ToString("00") + "." + t.Milliseconds.ToString("000");
		} 
		
	}
}
