using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace AradExtract {
	public partial class MainForm : Form {

		private Extract _ext;
		private Dictionary<string, string> _fileList;
		const string DEFAULT_DIR_PATH = @"C:\Nexon\ARADTEST\ImagePacks2";


		public MainForm() {
			InitializeComponent();
		}
		
		private void MainForm_Load( object sender, EventArgs e ) {
			if( !Directory.Exists( DEFAULT_DIR_PATH ) ) {
				return;
			}
			this._fileList = Directory.GetFiles( DEFAULT_DIR_PATH ).Where( x => Regex.IsMatch( x, @"\.npk$", RegexOptions.IgnoreCase ) ).ToDictionary( Path.GetFileName, x => x );
			this.lbFiles.Items.Clear();
			this.lbIndex.Items.Clear();
			this.lbImg.Items.Clear();
			this.lbFiles.Items.AddRange( this._fileList.Keys.ToArray() );

			if( this.lbFiles.Items.Count > 0 ) {
				this.lbFiles.SelectedIndex = 0;
			}
		}

		private void button1_Click( object sender, EventArgs e ) {
			var fbd = new FolderBrowserDialog();
			fbd.SelectedPath = DEFAULT_DIR_PATH;
			if( fbd.ShowDialog() != DialogResult.OK) {
				return;
			}
			var dir = fbd.SelectedPath;
			this._fileList = Directory.GetFiles( dir ).Where( x => Regex.IsMatch( x, @"\.npk$", RegexOptions.IgnoreCase ) ).ToDictionary( Path.GetFileName, x => x );
			this.lbFiles.Items.Clear();
			this.lbIndex.Items.Clear();
			this.lbImg.Items.Clear();
			this.lbFiles.Items.AddRange( this._fileList.Keys.ToArray() );

			if( this.lbFiles.Items.Count > 0 ) {
				this.lbFiles.SelectedIndex = 0;
			}
		}

		private void txtFileNameFilter_KeyPress( object sender, KeyPressEventArgs e ) {
			if( e.KeyChar != (char)13 ) {
				return;
			}
			var filter = this.txtFileNameFilter.Text;
			try {
				var tmp = this._fileList.Keys.Where( x => Regex.IsMatch( x, filter ) ).Select( x => x ).ToArray();
				this.lbFiles.Items.Clear();
				this.lbIndex.Items.Clear();
				this.lbImg.Items.Clear();
				this.lbFiles.Items.AddRange( tmp );
			} catch(Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		private void lbFiles_SelectedIndexChanged( object sender, EventArgs e ) {
			if( this.lbFiles.SelectedIndex == -1 ) {
				return;
			}
			var filename = this._fileList[this.lbFiles.SelectedItem.ToString()];
			if( IsFileLocked( filename ) ) {
				MessageBox.Show( "ファイル使用中" );
				return;
			}
			this._ext = new Extract( filename );
			this.txtFileName.Text = filename;
			this.lbIndex.Items.Clear();
			this.lbImg.Items.Clear();
			foreach( var index in this._ext.npkIndexList ) {
				//listboxのアイテム削除時に不整合を起こすためもう少しマシな方法を
				this.lbIndex.Items.Add( index.shortName );
			}
			if( this.lbIndex.Items.Count > 0 ) {
				this.lbIndex.SelectedIndex = 0;
			}
		}

		private void lbIndex_SelectedIndexChanged( object sender, EventArgs e ) {
			if( this.lbIndex.SelectedIndex == -1 ) {
				return;
			}
			var nimgHeader = this._ext.npkIndexList[this.lbIndex.SelectedIndex].NImgHeader;
			this.lbImg.Items.Clear();
			foreach( var nimgIndex in nimgHeader.NImgIndex ) {
				//listboxのアイテム削除時に不整合を起こすためもう少しマシな方法を
				this.lbImg.Items.Add( nimgIndex.ToString() );
			}
			if( this.lbImg.Items.Count > 0 ) {
				this.lbImg.SelectedIndex = 0;
			}
		}

		private void lbImg_SelectedIndexChanged( object sender, EventArgs e ) {
			if( this.lbImg.SelectedIndex == -1 ) {
				return;
			}
			try {
				var nn = this._ext.npkIndexList[this.lbIndex.SelectedIndex].NImgHeader;
				var  nii = this._ext.npkIndexList[this.lbIndex.SelectedIndex].NImgHeader.NImgIndex[this.lbImg.SelectedIndex];
				this.pb.Image = nii.NImg.ToBitmap();
				this.pb.Padding = new Padding( (int)nii.keyX, (int)nii.keyY,0,0);
			} catch( Exception ex) {
				Console.WriteLine(ex);
				this.pb.Image = Properties.Resources.Error;
				this.pb.Padding = new Padding();
			}
		}

		private static bool IsFileLocked( string path ) {
			FileStream stream = null;
			try {
				stream = new FileStream( path, FileMode.Open, FileAccess.Read );
			} catch {
				return true;
			} finally {
				stream?.Close();
			}

			return false;
		}

		private void btnSave_Click( object sender, EventArgs e ) {
			var sfd = new SaveFileDialog();
			sfd.FileName = this._ext.npkIndexList[this.lbIndex.SelectedIndex].shortName.Substring(0, this._ext.npkIndexList[this.lbIndex.SelectedIndex].shortName.LastIndexOf('.') ) + this._ext.npkIndexList[this.lbIndex.SelectedIndex].NImgHeader.NImgIndex[this.lbImg.SelectedIndex].index + ".png";
			sfd.Filter = "*.png|*.*";
			if( sfd.ShowDialog() == DialogResult.OK ) {
				this._ext.npkIndexList[this.lbIndex.SelectedIndex].NImgHeader.NImgIndex[this.lbImg.SelectedIndex].NImg.ToBitmap().Save(sfd.FileName);
			}
		}
	}
}
