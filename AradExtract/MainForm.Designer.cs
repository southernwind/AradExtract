namespace AradExtract {
	partial class MainForm {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.btnExtract = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.splitContainer5 = new System.Windows.Forms.SplitContainer();
			this.txtFileNameFilter = new System.Windows.Forms.TextBox();
			this.lbFiles = new System.Windows.Forms.ListBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.lbIndex = new System.Windows.Forms.ListBox();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.lbImg = new System.Windows.Forms.ListBox();
			this.pb = new System.Windows.Forms.PictureBox();
			this.splitContainer6 = new System.Windows.Forms.SplitContainer();
			this.splitContainer7 = new System.Windows.Forms.SplitContainer();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
			this.splitContainer5.Panel1.SuspendLayout();
			this.splitContainer5.Panel2.SuspendLayout();
			this.splitContainer5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
			this.splitContainer6.Panel1.SuspendLayout();
			this.splitContainer6.Panel2.SuspendLayout();
			this.splitContainer6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
			this.splitContainer7.Panel2.SuspendLayout();
			this.splitContainer7.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnExtract
			// 
			this.btnExtract.Location = new System.Drawing.Point(28, 18);
			this.btnExtract.Name = "btnExtract";
			this.btnExtract.Size = new System.Drawing.Size(75, 23);
			this.btnExtract.TabIndex = 0;
			this.btnExtract.Text = "抽出";
			this.btnExtract.UseVisualStyleBackColor = true;
			this.btnExtract.Click += new System.EventHandler(this.button1_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtFileName);
			this.splitContainer1.Panel1.Controls.Add(this.btnExtract);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
			this.splitContainer1.Size = new System.Drawing.Size(1449, 829);
			this.splitContainer1.SplitterDistance = 53;
			this.splitContainer1.TabIndex = 1;
			this.splitContainer1.TabStop = false;
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(141, 19);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(781, 19);
			this.txtFileName.TabIndex = 1;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer4.Size = new System.Drawing.Size(1449, 772);
			this.splitContainer4.SplitterDistance = 262;
			this.splitContainer4.TabIndex = 1;
			this.splitContainer4.TabStop = false;
			// 
			// splitContainer5
			// 
			this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer5.Location = new System.Drawing.Point(0, 0);
			this.splitContainer5.Name = "splitContainer5";
			this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer5.Panel1
			// 
			this.splitContainer5.Panel1.Controls.Add(this.txtFileNameFilter);
			// 
			// splitContainer5.Panel2
			// 
			this.splitContainer5.Panel2.Controls.Add(this.lbFiles);
			this.splitContainer5.Size = new System.Drawing.Size(262, 772);
			this.splitContainer5.SplitterDistance = 25;
			this.splitContainer5.TabIndex = 0;
			// 
			// txtFileNameFilter
			// 
			this.txtFileNameFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFileNameFilter.Location = new System.Drawing.Point(0, 0);
			this.txtFileNameFilter.Name = "txtFileNameFilter";
			this.txtFileNameFilter.Size = new System.Drawing.Size(262, 19);
			this.txtFileNameFilter.TabIndex = 0;
			this.txtFileNameFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileNameFilter_KeyPress);
			// 
			// lbFiles
			// 
			this.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbFiles.FormattingEnabled = true;
			this.lbFiles.ItemHeight = 12;
			this.lbFiles.Location = new System.Drawing.Point(0, 0);
			this.lbFiles.Name = "lbFiles";
			this.lbFiles.Size = new System.Drawing.Size(262, 743);
			this.lbFiles.TabIndex = 0;
			this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_SelectedIndexChanged);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.lbIndex);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(1183, 772);
			this.splitContainer2.SplitterDistance = 312;
			this.splitContainer2.TabIndex = 0;
			this.splitContainer2.TabStop = false;
			// 
			// lbIndex
			// 
			this.lbIndex.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbIndex.FormattingEnabled = true;
			this.lbIndex.ItemHeight = 12;
			this.lbIndex.Location = new System.Drawing.Point(0, 0);
			this.lbIndex.Name = "lbIndex";
			this.lbIndex.Size = new System.Drawing.Size(312, 772);
			this.lbIndex.TabIndex = 0;
			this.lbIndex.SelectedIndexChanged += new System.EventHandler(this.lbIndex_SelectedIndexChanged);
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.lbImg);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.splitContainer6);
			this.splitContainer3.Size = new System.Drawing.Size(867, 772);
			this.splitContainer3.SplitterDistance = 229;
			this.splitContainer3.TabIndex = 0;
			this.splitContainer3.TabStop = false;
			// 
			// lbImg
			// 
			this.lbImg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbImg.FormattingEnabled = true;
			this.lbImg.ItemHeight = 12;
			this.lbImg.Location = new System.Drawing.Point(0, 0);
			this.lbImg.Margin = new System.Windows.Forms.Padding(0);
			this.lbImg.Name = "lbImg";
			this.lbImg.Size = new System.Drawing.Size(867, 229);
			this.lbImg.TabIndex = 0;
			this.lbImg.SelectedIndexChanged += new System.EventHandler(this.lbImg_SelectedIndexChanged);
			// 
			// pb
			// 
			this.pb.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb.Location = new System.Drawing.Point(0, 0);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(867, 510);
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			// 
			// splitContainer6
			// 
			this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer6.IsSplitterFixed = true;
			this.splitContainer6.Location = new System.Drawing.Point(0, 0);
			this.splitContainer6.Name = "splitContainer6";
			this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer6.Panel1
			// 
			this.splitContainer6.Panel1.Controls.Add(this.splitContainer7);
			// 
			// splitContainer6.Panel2
			// 
			this.splitContainer6.Panel2.Controls.Add(this.pb);
			this.splitContainer6.Size = new System.Drawing.Size(867, 539);
			this.splitContainer6.SplitterDistance = 25;
			this.splitContainer6.TabIndex = 1;
			this.splitContainer6.TabStop = false;
			// 
			// splitContainer7
			// 
			this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer7.IsSplitterFixed = true;
			this.splitContainer7.Location = new System.Drawing.Point(0, 0);
			this.splitContainer7.Name = "splitContainer7";
			// 
			// splitContainer7.Panel2
			// 
			this.splitContainer7.Panel2.Controls.Add(this.btnSave);
			this.splitContainer7.Size = new System.Drawing.Size(867, 25);
			this.splitContainer7.SplitterDistance = 730;
			this.splitContainer7.TabIndex = 0;
			this.splitContainer7.TabStop = false;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(46, 1);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1449, 829);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.splitContainer5.Panel1.ResumeLayout(false);
			this.splitContainer5.Panel1.PerformLayout();
			this.splitContainer5.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
			this.splitContainer5.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.splitContainer6.Panel1.ResumeLayout(false);
			this.splitContainer6.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
			this.splitContainer6.ResumeLayout(false);
			this.splitContainer7.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
			this.splitContainer7.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnExtract;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox lbIndex;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.ListBox lbImg;
		private System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.ListBox lbFiles;
		private System.Windows.Forms.SplitContainer splitContainer5;
		private System.Windows.Forms.TextBox txtFileNameFilter;
		private System.Windows.Forms.SplitContainer splitContainer6;
		private System.Windows.Forms.SplitContainer splitContainer7;
		private System.Windows.Forms.Button btnSave;
	}
}

