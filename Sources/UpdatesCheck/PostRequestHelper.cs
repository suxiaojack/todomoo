/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * POST REQUEST HELPER (PostRequestHelper.cs)
 * Sends HTTP POST request and receive response.
 * ===============================================================
 */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace System.Net {
	
	public class PostRequestHelper {
		
		private HttpWebRequest req;
		
		private NameValueCollection data;
		private string file_name = null;
		private string file_path = null;
		private string file_mime = null;
		
		private bool response_ready = false;
		private string response = "";
		
		public delegate void ResponseReadyHandler(PostRequestHelper sender, string response);
		public event ResponseReadyHandler ResponseReady;
		public delegate void ErrorHandler(PostRequestHelper sender, Exception exception);
		public event ErrorHandler Error;
		
		public PostRequestHelper(string url) : this(url, Timeout.Infinite) { }
		
		public PostRequestHelper(string url, int timeout) {
			req = (HttpWebRequest)HttpWebRequest.Create(url);
			req.Method = "POST";
			req.KeepAlive = true;
			req.Timeout = timeout;
			req.ReadWriteTimeout = timeout;
			data = new NameValueCollection();
		}
		
		public void AddPostData(string name, string val) {
			data.Add(name, val);
		}
		
		public void SetFile(string name, string path, string mime) {
			file_name = name;
			file_path = path;
			file_mime = mime;
		}
		
		private void PackRequestData() {
			
			// Prepare multipart
			string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
		    req.ContentType = "multipart/form-data; boundary=" + boundary;
		    
			// Pack POST data
			string post_data = "";
			foreach(string key in data.Keys) {
				post_data += "--" + boundary + "\r\n";
				post_data += "Content-Disposition: form-data; name=\"" + key + "\"\r\n\r\n";
				post_data += data[key] + "\r\n";
			}
		    
			// Create byte[] array for POST data
			byte[] post_data_bytes = Encoding.UTF8.GetBytes(post_data);
			
			// Set content lenght
			long content_length = post_data_bytes.Length;
			
			// If file attached
			byte[] file_data_bytes = new byte[0];
			byte[] file_end = new byte[0];
			FileStream file = null;
			if (file_path != null) {
		    
				// Prepare FILE header
				string file_data = "";
				file_data += "--" + boundary + "\r\n";
			    file_data += "Content-Disposition: form-data; name=\"" + file_name + "\"; ";
				file_data +=   "filename=\"" + Path.GetFileName(file_path) + "\"" + "\r\n";
			    file_data += "Content-Type: " + file_mime + "\r\n" + "\r\n";             
				
				// Create byte[] array for FILE header
				file_data_bytes = Encoding.UTF8.GetBytes(file_data);
				
				// Read file
				file_end = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
				file = new FileStream(file_path, FileMode.Open, FileAccess.Read);
				
				// Set content lenght
				content_length += file_data_bytes.Length + file.Length + file_end.Length;
				
			}
			
			// Set content lenght
			req.ContentLength = content_length;
			
			// Get request stream
			Stream req_stream = req.GetRequestStream();
			
			// Write out initial data into the stream
			req_stream.Write(post_data_bytes, 0, post_data_bytes.Length);
			
			// Write out attached file
			if (file_path != null) {
				req_stream.Write(file_data_bytes, 0, file_data_bytes.Length);
				byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)file.Length))];
				int bytes_read = 0;
				while ((bytes_read = file.Read(buffer, 0, buffer.Length)) != 0) 
					req_stream.Write(buffer, 0, bytes_read);
				file.Close();
				req_stream.Write(file_end, 0, file_end.Length);
			}
			
		}
		
		private string GetResponseToString() {
			try {
				PackRequestData();
				WebResponse response_w = req.GetResponse();
				StreamReader stream = new StreamReader(response_w.GetResponseStream());
				return stream.ReadToEnd();
			} catch (Exception ex) {
				if (Error != null) Error(this, ex);
				return "";
			}
		}
		
		public void BeginGetResponse() {
			response_ready = false;
			Thread thread = new Thread(new ThreadStart(this.GetResponse));
			thread.Name = "HTTP POST request thread";
			thread.Start();
			System.Diagnostics.Debug.WriteLine("HTTP POST request started...");
		}
		
		private void GetResponse() {
			System.Diagnostics.Debug.WriteLine("HTTP POST response receiving...");
			string r = GetResponseToString();
			System.Diagnostics.Debug.WriteLine("HTTP POST response received. ");
			if (r.Length == 0) return;
			response = r;
			response_ready = true;
			if (ResponseReady != null) ResponseReady(this, response);
		}
		
		public void StopRequest() {
			if (req != null) req.Abort();
		}
		
		public bool IsResponseReady {
			get { return response_ready; }
		}
		
		public string Response {
			get { if (!response_ready) return ""; return response; }
		}
		
		public NameValueCollection PostData {
			set { data = value; }
			get { return data; }
		}
		
		public string UserAgent {
			set { req.UserAgent = value; }
			get { return req.UserAgent; }
		}
		
		public string Accept {
			set { req.Accept = value; }
			get { return req.Accept; }
		}
		
		public bool KeepAlive {
			set { req.KeepAlive = value; }
			get { return req.KeepAlive; }
		}
		
		public int ReadWriteTimeout {
			set { req.ReadWriteTimeout = value; }
			get { return req.ReadWriteTimeout; }
		}
		
		public string Referer {
			set { req.Referer = value; }
			get { return req.Referer; }
		}
		
	}
}
