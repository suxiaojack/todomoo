/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * PROGRAM (Program.cs)
 * Program entry point.
 * ===============================================================
 */

using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Todomoo {
	
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program {
		
		// Mutex
		static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
		
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args) {
			
			// No instances
			if (mutex.WaitOne(TimeSpan.Zero, true)) {
				
				// Create main form
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				
				// Release Mutex
				mutex.ReleaseMutex();
				
			// Disallow multiple istances
			} else {
				
				// Open previous instance
				NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST,	NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
				
			}
			
		}
		
	}
	
	internal class NativeMethods {
	    public const int HWND_BROADCAST = 0xffff;
	    public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
	    [DllImport("user32")] public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
	    [DllImport("user32")] public static extern int RegisterWindowMessage(string message);
	    [DllImportAttribute ("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
	}
	
}
