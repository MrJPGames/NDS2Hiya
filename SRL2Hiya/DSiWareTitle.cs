using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRL2Hiya {
	class DSiWareTitle {
		public String title = "No title loaded";
		public String gameCode = "GAME";
		public String titleID = "00000000";
		public int publicSaveSize = 0;
		public int privateSaveSize = 0;
		public int blocks=0;
		public Bitmap icon = new Bitmap(Resource1.UnknownIcon);
		public String NDSFile = "";

		public DSiWareTitle(String file = null) {
			if (file != null) {
				NDSFile = file;
				FileStream fs = File.OpenRead(NDSFile);
				byte[] TitleIDBytes = Program.ReadBytes(fs, 0x230, 8);
				byte[] publicSave = Program.ReadBytes(fs, 0x238, 4);
				byte[] privateSave = Program.ReadBytes(fs, 0x23C, 4);
				publicSaveSize = BitConverter.ToInt32(publicSave, 0);
				privateSaveSize = BitConverter.ToInt32(privateSave, 0);
				int iconOffset = BitConverter.ToInt32(Program.ReadBytes(fs, 0x068, 4), 0);
				title = TitleToString(Program.ReadBytes(fs, iconOffset + 0x340, 0x100));
				titleID = TitleIDTransform(Program.ReadBytes(fs, 0x230, 4));

				icon = GetIconData(fs, iconOffset);
				int totalFileSize = 520 + publicSaveSize + privateSaveSize + (int)(new FileInfo(NDSFile)).Length;

				blocks = (int)Math.Ceiling(((totalFileSize / (1024.0*1024))*8));

				fs.Close();
			}
		}

		private static string TitleToString(byte[] data) {
			string title = "";
			title = new String(Encoding.Unicode.GetChars(data));

			return title;
		}

		private String TitleIDTransform(byte[] tid) {
			return tid[3].ToString("X").PadLeft(2, '0') +
					tid[2].ToString("X").PadLeft(2, '0') +
					tid[1].ToString("X").PadLeft(2, '0') +
					tid[0].ToString("X").PadLeft(2, '0');
		}

		private string GetGameCode(FileStream fs) {
			byte[] gameCode = Program.ReadBytes(fs, 0x0C, 4);
			return System.Text.Encoding.Default.GetString(gameCode);
		}

		private Bitmap GetIconData(FileStream fs, int iconOffset) {
			Bitmap ret = new Bitmap(32, 32);

			byte[] image = Program.ReadBytes(fs, iconOffset + 0x20, 0x200);

			Color[] colors = GetPallet(fs, iconOffset);

			int cnt = 0;
			for (int ty = 0; ty < 4; ty++) {
				for (int tx = 0; tx < 4; tx++) {
					for (int y = 0; y < 8; y++) {
						for (int x = 0; x < 4; x++) {
							ret.SetPixel(tx * 8 + x * 2, ty * 8 + y, colors[image[cnt] & 0x0F]);
							ret.SetPixel(tx * 8 + x * 2 + 1, ty * 8 + y, colors[(image[cnt] & 0xF0) >> 4]);
							cnt++;
						}
					}
				}
			}
			return ret;
		}

		private Color[] GetPallet(FileStream fs, int iconOffset) {
			byte[] pallet = Program.ReadBytes(fs, iconOffset + 0x220, 0x20);
			Color[] colors = new Color[16];
			colors[0] = Color.Transparent;
			for (int i = 2; i < 0x20; i += 2) {
				int intCol = BitConverter.ToInt16(new byte[2] { pallet[i], pallet[i + 1] }, 0);
				int red = (intCol) & 0x1F;
				int green = (intCol >> 5) & 0x1F;
				int blue = (intCol >> 10) & 0x1F;
				colors[i / 2] = Color.FromArgb(255, (int)(red / 31f * 255), (int)(green / 31f * 255), (int)(blue / 31f * 255));
			}
			return colors;
		}

	}
}
