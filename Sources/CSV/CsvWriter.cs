/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * CSV WRITER (CsvWriter.cs)
 * http://knab.ws/blog/index.php?/archives/3-CSV-file-parser-and-writer-in-C-Part-1.html
 * ===============================================================
 */

using System;
using System.Data;
using System.IO;
using System.Text;
using System.Globalization;

namespace CSV {
	
public class Writer {
		
        public static string WriteToString(DataTable table, bool header, bool quoteall) {
				StringWriter writer = new StringWriter();
                WriteToStream(writer, table, header, quoteall);
                return writer.ToString();
        }

        public static void WriteToStream(TextWriter stream, DataTable table, bool header, bool quoteall) {
			if (header) {
                        for (int i = 0; i < table.Columns.Count; i++) {
                                WriteItem(stream, table.Columns[i].Caption, quoteall);
                                if (i < table.Columns.Count - 1) stream.Write(',');
                                else stream.Write('\n');
                        }
                }
                foreach (DataRow row in table.Rows) {
                        for (int i = 0; i < table.Columns.Count; i++) {
                                WriteItem(stream, row[i], quoteall);
                                if (i < table.Columns.Count - 1) stream.Write(',');
                                else stream.Write('\n');
                        }
                }
        }

        private static void WriteItem(TextWriter stream, object item, bool quoteall) {
            if (item == null) return;
            string s = item.ToString();
            if (quoteall || s.IndexOfAny("\",\x0A\x0D".ToCharArray()) > -1) stream.Write("\"" + s.Replace("\"", "\"\"") + "\"");
            else stream.Write(s);
        }
        
	}
	
}
