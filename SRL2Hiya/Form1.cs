using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRL2Hiya {
	public partial class Form1 : Form {

		private bool validDriveSelected = false;
		private bool directorySelected = false;

		private String pcDirectory = "";

		List<String> drives = new List<String>();

		int availableBlocks = 1024;

		public Form1() {
			InitializeComponent();
			icons.ImageSize = new Size(48, 48);
			UpdateAvailableDrives(null,null);
		}

		private void SelectSDCardLocation(object sender, EventArgs e) {
			validDriveSelected = false;
			if (Directory.Exists(comboBox1.Text + "hiya") && Directory.Exists(comboBox1.Text + "title\\00030004")) {
				RefreshSDList();
			} else {
				availableBlocks = 1024;
				availableBlocksLabel.Text = "";
			}
		}

		private void RefreshSDList() {
			availableBlocks = 1024;
			validDriveSelected = true;
			DSiSDList.Items.Clear();

			//This is an SD card with hiya CFW
			String DSiWareLocation = comboBox1.Text + "title\\00030004";
			var ext = new List<string> { ".app" };
			var myFiles = Directory.GetFiles(DSiWareLocation, "*.*", SearchOption.AllDirectories)
				 .Where(s => ext.Contains(Path.GetExtension(s)));

			foreach (String NDSFile in myFiles) {
				DSiWareTitle dsiWare = new DSiWareTitle(NDSFile);

				icons.Images.Add(dsiWare.gameCode, dsiWare.icon);

				ListViewItem item = new ListViewItem(new string[] { dsiWare.title, dsiWare.blocks.ToString() + " blocks" });
				item.ImageIndex = icons.Images.Count - 1;
				item.Tag = dsiWare;

				DSiSDList.Items.Add(item);

				availableBlocks -= dsiWare.blocks;
				availableBlocksLabel.Text = availableBlocks + " blocks";
			}
		}

		private void RefreshPCList() {
			PCDsiWareList.Items.Clear();
			var ext = new List<string> { ".app", ".nds", ".srl" };
			var myFiles = Directory.GetFiles(pcDirectory, "*.*", SearchOption.AllDirectories)
				 .Where(s => ext.Contains(Path.GetExtension(s)));

			foreach (String NDSFile in myFiles) {
				if (CheckValidNDSDSiWareFile(NDSFile)) {
					DSiWareTitle dsiWare = new DSiWareTitle(NDSFile);

					icons.Images.Add(dsiWare.gameCode, dsiWare.icon);

					ListViewItem item = new ListViewItem(new string[] { dsiWare.title, dsiWare.blocks.ToString() + " blocks" });
					item.ImageIndex = icons.Images.Count - 1;
					item.Tag = dsiWare;

					PCDsiWareList.Items.Add(item);
				}
			}
		}

		private void UpdateAvailableDrives(object s = null, EventArgs e = null) {
			//Clear drives list
			drives.RemoveRange(0, drives.Count);

			//Detect drives
			System.IO.DriveInfo[] drivesListing = System.IO.DriveInfo.GetDrives();
			foreach (var drive in drivesListing) {
				System.IO.DriveType driveType = drive.DriveType;
				string driveName = drive.Name; // C:\, E:\, etc:\
				switch (driveType) {
					case System.IO.DriveType.Removable:
						// Usually a USB Drive
						drives.Add(drive.Name);
						break;
				}
			}

			comboBox1.Items.Clear();
			comboBox1.Text = "";

			//Add drives to combobox
			foreach (string d in drives) {
				comboBox1.Items.Add(d);
			}
		}

		

		/*
		 * For later DSi animated icon loading
		private Bitmap GetIconData(FileStream fs, int iconOffset) {
			Bitmap ret = new Bitmap(32, 64*8);
			int iconFrames = 5 + ReadBytes(fs, iconOffset, 1)[0];
			int animated = ReadBytes(fs, iconOffset+1, 1)[0];
			if (animated != 1)
				iconFrames = 1;
			Console.WriteLine(iconFrames);

			byte[] image = ReadBytes(fs, iconOffset + 0x1240, 4096);

			Color[] colors = GetPallet(fs, iconOffset);

			int cnt = 0;
			for (int frame = 0; frame < iconFrames; frame++) {
				for (int ty = 0; ty < 4; ty++) {
					for (int tx = 0; tx < 4; tx++) {
						for (int y = 0; y < 8; y++) {
							for (int x = 0; x < 4; x++) {
								ret.SetPixel(tx * 8 + x * 2, (ty+4*frame) * 8 + y, colors[image[cnt] & 0x0F]);
								ret.SetPixel(tx * 8 + x * 2 + 1, (ty + 4 * frame) * 8 + y, colors[(image[cnt] & 0xF0) >> 4]);
								cnt++;
							}
						}
					}
				}
			}
			return ret;
		}
		*/

		private bool CheckValidNDSDSiWareFile(String filename) {
			FileStream fs = File.OpenRead(filename);
			byte[] systemType = Program.ReadBytes(fs, 0x12, 1);
			return systemType[0] == 0x03;
		}

		/*
		private void Export2Hiya(object sender, EventArgs e) {
			// Show the FolderBrowserDialog.
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK) {
				string folderName = folderBrowserDialog1.SelectedPath + "\\" + TitleID.ToLower();
				Directory.CreateDirectory(folderName);
				Directory.CreateDirectory(folderName + "\\content");
				Directory.CreateDirectory(folderName + "\\data");

				if (System.IO.File.Exists(folderName + "\\data\\public.sav"))
					File.Delete(folderName + "\\data\\public.sav");
				if (System.IO.File.Exists(folderName + "\\data\\private.sav"))
					File.Delete(folderName + "\\data\\private.sav");
				if (System.IO.File.Exists(folderName + "\\content\\00000000.app"))
					File.Delete(folderName + "\\content\\00000000.app");

				if (ware.PublicSaveSize != 0)
					File.WriteAllBytes(folderName + "\\data\\public.sav", new byte[PublicSaveSize]);
				if (PrivateSaveSize != 0)
					File.WriteAllBytes(folderName + "\\data\\private.sav", new byte[PublicSaveSize]);
				File.Copy(NDSFile, folderName + "\\content\\00000000.app");
				string path = Path.Combine(Path.GetTempPath(), "maketmd.exe");
				File.WriteAllBytes(path, Resource1.maketmd);
				Process.Start(path, folderName + "\\content\\00000000.app " + folderName + "\\content\\title.tmd");
			}
		}
		*/

		private void SelectPCLocation(object sender, EventArgs e) {
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK) {
				directorySelected = true;
				pcDirectory = folderBrowserDialog1.SelectedPath;
				RefreshPCList();
			}
		}

		private void MoveToSD(object sender, EventArgs e) {
			if (PCDsiWareList.SelectedItems[0] != null && validDriveSelected) {
				foreach (ListViewItem item in PCDsiWareList.SelectedItems) {
					DSiWareTitle ware = (DSiWareTitle)item.Tag;

					String onelineTitle = ware.title.Replace("\n", " ");
					if (ware.blocks <= availableBlocks || MessageBox.Show(onelineTitle+ " cannot be installed onto the SD card. (WILL CRASH LAUNCHER!)\nContinue anyways?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
						string folderName = comboBox1.Text + "title\\00030004\\" + ware.titleID.ToLower();
						Directory.CreateDirectory(folderName);
						Directory.CreateDirectory(folderName + "\\content");
						Directory.CreateDirectory(folderName + "\\data");

						if (System.IO.File.Exists(folderName + "\\data\\public.sav"))
							File.Delete(folderName + "\\data\\public.sav");
						if (System.IO.File.Exists(folderName + "\\data\\private.sav"))
							File.Delete(folderName + "\\data\\private.sav");
						if (System.IO.File.Exists(folderName + "\\content\\00000000.app"))
							File.Delete(folderName + "\\content\\00000000.app");


						File.Copy(ware.NDSFile, folderName + "\\content\\00000000.app");
						if (File.Exists(ware.NDSFile.Replace(".nds", ".pub"))) {
							Console.WriteLine(ware.NDSFile.Replace(".nds", ".pub"));
							File.Copy(ware.NDSFile.Replace(".nds", ".pub"), folderName + "\\data\\public.sav");
						} else if (ware.publicSaveSize != 0)
							File.WriteAllBytes(folderName + "\\data\\public.sav", new byte[ware.publicSaveSize]);
						if (ware.privateSaveSize != 0)
							File.WriteAllBytes(folderName + "\\data\\private.sav", new byte[ware.privateSaveSize]);
						string path = Path.Combine(Path.GetTempPath(), "maketmd.exe");
						File.WriteAllBytes(path, Resource1.maketmd);
						Process.Start(path, folderName + "\\content\\00000000.app " + folderName + "\\content\\title.tmd");

						RefreshSDList();
					}
				}
			}
		}

		//Remove DSiWare from SD
		private void DeleteFromSD(object sender, EventArgs e) {
			if (DSiSDList.SelectedItems.Count > 0 && validDriveSelected) {
				foreach (ListViewItem item in DSiSDList.SelectedItems) {
					DSiWareTitle ware = (DSiWareTitle)item.Tag;

					if (Directory.Exists(comboBox1.Text + "title\\00030004\\" + ware.titleID.ToLower())) {
						Console.WriteLine("Removing: " + comboBox1.Text + "title\\00030004\\" + ware.titleID.ToLower());

						Directory.Delete(comboBox1.Text + "title\\00030004\\" + ware.titleID.ToLower(), true);
					}
				}
			}
			RefreshSDList();
		}

		//Move DSiWare to PC dir
		private void DSiWareToPC(object sender, EventArgs e) {
			if (directorySelected && DSiSDList.SelectedItems.Count > 0) {
				foreach (ListViewItem item in DSiSDList.SelectedItems) {
					DSiWareTitle ware = (DSiWareTitle)item.Tag;
					String fileName = ware.title.Replace("\n", "-").Replace(" ", "_").Replace("\0", "").Replace(":", "_");

					File.Copy(ware.NDSFile, pcDirectory + "\\" + fileName + ".nds");
					if (ware.publicSaveSize > 0 && File.Exists(comboBox1.Text + "title\\00030004\\" + ware.titleID + "\\data\\public.sav"))
						File.Copy(comboBox1.Text + "title\\00030004\\" + ware.titleID + "\\data\\public.sav", pcDirectory + "\\" + fileName + ".pub");
				}
				RefreshPCList();
			} else {
				MessageBox.Show("Select a directory on PC to move DSiWare to.");
			}
		}

		private void DSiSDList_SelectedIndexChanged(object sender, EventArgs e) {
			if (DSiSDList.SelectedItems.Count > 0 && directorySelected) {
				ToPCButton.Enabled = true;
			} else {
				ToPCButton.Enabled = false;
			}
		}

		private void PCDsiWareList_SelectedIndexChanged(object sender, EventArgs e) {
			if (PCDsiWareList.SelectedItems.Count > 0 && validDriveSelected) {
				ToSDButton.Enabled = true;
				int blockTotal = 0;
				foreach (ListViewItem item in PCDsiWareList.SelectedItems) {
					blockTotal += ((DSiWareTitle)item.Tag).blocks;
				}
				PCSelectionBlockTotalLabel.Text = "Selection block total: " + blockTotal + " blocks";
			} else {
				ToSDButton.Enabled = false;
			}
		}
	}
}
