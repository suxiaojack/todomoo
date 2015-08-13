/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * MD5 HASH (MD5.cs)
 * From: http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5.aspx
 * ===============================================================
 */
 
using System;
using System.Security.Cryptography;
using System.Text;

namespace System.Text {

	public class MD5 {

		public static string Compute(string s) {
			System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(s));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
			return sBuilder.ToString();
		}

	}

}
