using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SRL2Hiya {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		public static byte[] ReadBytes(FileStream fs, int location, int size) {
			byte[] bytes = new byte[size];
			fs.Seek(location, SeekOrigin.Begin);
			int nBytesRead = fs.Read(bytes, 0, size);
			return bytes;
		}
	}
}
