namespace SRL2Hiya {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.DSiSDList = new System.Windows.Forms.ListView();
			this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Blocks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.availableBlocksLabel = new System.Windows.Forms.Label();
			this.PCDsiWareList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button2 = new System.Windows.Forms.Button();
			this.ToSDButton = new System.Windows.Forms.Button();
			this.ToPCButton = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.PCSelectionBlockTotalLabel = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select HiyaCFW SD Card drive:";
			// 
			// DSiSDList
			// 
			this.DSiSDList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.DSiSDList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Blocks});
			this.DSiSDList.GridLines = true;
			this.DSiSDList.LabelWrap = false;
			this.DSiSDList.LargeImageList = this.icons;
			this.DSiSDList.Location = new System.Drawing.Point(12, 55);
			this.DSiSDList.MaximumSize = new System.Drawing.Size(2000, 2000);
			this.DSiSDList.MinimumSize = new System.Drawing.Size(347, 357);
			this.DSiSDList.Name = "DSiSDList";
			this.DSiSDList.Size = new System.Drawing.Size(347, 357);
			this.DSiSDList.SmallImageList = this.icons;
			this.DSiSDList.TabIndex = 17;
			this.DSiSDList.TileSize = new System.Drawing.Size(184, 64);
			this.DSiSDList.UseCompatibleStateImageBehavior = false;
			this.DSiSDList.View = System.Windows.Forms.View.Details;
			this.DSiSDList.SelectedIndexChanged += new System.EventHandler(this.DSiSDList_SelectedIndexChanged);
			// 
			// Title
			// 
			this.Title.Text = "Title";
			this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Title.Width = 270;
			// 
			// Blocks
			// 
			this.Blocks.Text = "Blocks";
			// 
			// icons
			// 
			this.icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.icons.ImageSize = new System.Drawing.Size(16, 16);
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(13, 30);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(157, 21);
			this.comboBox1.TabIndex = 18;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.SelectSDCardLocation);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(177, 30);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 19;
			this.button1.Text = "Refresh drives";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.UpdateAvailableDrives);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(93, 418);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Blocks available:";
			// 
			// availableBlocksLabel
			// 
			this.availableBlocksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.availableBlocksLabel.AutoSize = true;
			this.availableBlocksLabel.Location = new System.Drawing.Point(186, 418);
			this.availableBlocksLabel.Name = "availableBlocksLabel";
			this.availableBlocksLabel.Size = new System.Drawing.Size(0, 13);
			this.availableBlocksLabel.TabIndex = 21;
			// 
			// PCDsiWareList
			// 
			this.PCDsiWareList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PCDsiWareList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.PCDsiWareList.GridLines = true;
			this.PCDsiWareList.LargeImageList = this.icons;
			this.PCDsiWareList.Location = new System.Drawing.Point(415, 55);
			this.PCDsiWareList.MinimumSize = new System.Drawing.Size(347, 357);
			this.PCDsiWareList.Name = "PCDsiWareList";
			this.PCDsiWareList.Size = new System.Drawing.Size(347, 357);
			this.PCDsiWareList.SmallImageList = this.icons;
			this.PCDsiWareList.TabIndex = 22;
			this.PCDsiWareList.UseCompatibleStateImageBehavior = false;
			this.PCDsiWareList.View = System.Windows.Forms.View.Details;
			this.PCDsiWareList.SelectedIndexChanged += new System.EventHandler(this.PCDsiWareList_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 270;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Blocks";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.Location = new System.Drawing.Point(12, 418);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 23;
			this.button2.Text = "Remove DSiWare";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.DeleteFromSD);
			// 
			// ToSDButton
			// 
			this.ToSDButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToSDButton.Enabled = false;
			this.ToSDButton.Location = new System.Drawing.Point(365, 55);
			this.ToSDButton.Name = "ToSDButton";
			this.ToSDButton.Size = new System.Drawing.Size(44, 23);
			this.ToSDButton.TabIndex = 24;
			this.ToSDButton.Text = "<-";
			this.ToSDButton.UseVisualStyleBackColor = true;
			this.ToSDButton.Click += new System.EventHandler(this.MoveToSD);
			// 
			// ToPCButton
			// 
			this.ToPCButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToPCButton.Enabled = false;
			this.ToPCButton.Location = new System.Drawing.Point(365, 84);
			this.ToPCButton.Name = "ToPCButton";
			this.ToPCButton.Size = new System.Drawing.Size(44, 23);
			this.ToPCButton.TabIndex = 25;
			this.ToPCButton.Text = "->";
			this.ToPCButton.UseVisualStyleBackColor = true;
			this.ToPCButton.Click += new System.EventHandler(this.DSiWareToPC);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(415, 26);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(173, 23);
			this.button5.TabIndex = 26;
			this.button5.Text = "Select NDS rom directory";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.SelectPCLocation);
			// 
			// PCSelectionBlockTotalLabel
			// 
			this.PCSelectionBlockTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.PCSelectionBlockTotalLabel.AutoSize = true;
			this.PCSelectionBlockTotalLabel.Location = new System.Drawing.Point(412, 418);
			this.PCSelectionBlockTotalLabel.Name = "PCSelectionBlockTotalLabel";
			this.PCSelectionBlockTotalLabel.Size = new System.Drawing.Size(149, 13);
			this.PCSelectionBlockTotalLabel.TabIndex = 27;
			this.PCSelectionBlockTotalLabel.Text = "Selection block total: 0 blocks";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(594, 26);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(168, 23);
			this.button3.TabIndex = 28;
			this.button3.Text = "Select .NDS to install";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.InstallNDSFromFileSelect);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(780, 453);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.PCSelectionBlockTotalLabel);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.ToPCButton);
			this.Controls.Add(this.ToSDButton);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.PCDsiWareList);
			this.Controls.Add(this.availableBlocksLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.DSiSDList);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(796, 2000);
			this.MinimumSize = new System.Drawing.Size(796, 492);
			this.Name = "Form1";
			this.Text = "NDS2HiyaCFW";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ListView DSiSDList;
		private System.Windows.Forms.ColumnHeader Title;
		private System.Windows.Forms.ColumnHeader Blocks;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label availableBlocksLabel;
		private System.Windows.Forms.ListView PCDsiWareList;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button ToSDButton;
		private System.Windows.Forms.Button ToPCButton;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label PCSelectionBlockTotalLabel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

