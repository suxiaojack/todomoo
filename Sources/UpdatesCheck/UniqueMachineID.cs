/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * UNIQUE MACHINE ID GENERATION (UniqueMachineID.cs)
 * From: http://www.codeproject.com/KB/cs/ComputerID.aspx
 * ===============================================================
 */

using System;

namespace Todomoo {
	
	public class UniqueMachineID {
		
		public static string Get() {
			return System.Text.MD5.Compute(
				Environment.ProcessorCount + "/" +
				Environment.MachineName + "/" + 
				Environment.UserDomainName + "\\" +
				Environment.UserName + "/" + 
				Environment.GetLogicalDrives().Length
			);
		}
		
	}
	
}
