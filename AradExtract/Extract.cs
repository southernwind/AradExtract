using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace AradExtract {
	internal class Extract {

		private const uint ARGB_1555 = 0x0e;
		private const uint ARGB_4444 = 0x0f;
		private const uint ARGB_8888 = 0x10;
		private const uint ARGB_NONE = 0x11;

		private const uint COMPRESS_ZLIB = 0x06;
		private const uint COMPRESS_NONE = 0x05;

		private static char[] _decordFlag = ( "puchikon@neople dungeon and fighter DNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNFDNF\0" ).ToCharArray();

		internal List<NpkIndex> npkIndexList;

		internal Extract( string file ) {
			var offset = 0;
			using( var fs = new FileStream( file, FileMode.Open, FileAccess.Read ) ) {
				var fileData = new byte[fs.Length];

				fs.Read( fileData, 0, (int)fs.Length );

				var header = new NpkHeader();
				header.flag = Encoding.UTF8.GetString( fileData, offset, 16 );
				offset += 16;
				header.count = BitConverter.ToUInt32( fileData, offset );
				offset += 4;

				this.npkIndexList = new List<NpkIndex>();
				for( var i = 0; i < header.count; ++i ) {
					var index = new NpkIndex();
					index.startOffset = (int)( BitConverter.ToUInt32( fileData, offset ) );
					offset += 4;
					index.size = BitConverter.ToUInt32( fileData, offset );
					offset += 4;

					var indexName = new char[256];
					for( var j = 0; j < 256; j++ ) {
						indexName[j] = (char)( fileData[offset++] ^ _decordFlag[j] );
					}
					index.name = new string( indexName );
					index.name = index.name.Replace( "\0", "" );
					index.shortName = Regex.Replace( index.name, @"^.*/", "" );
					index.fileData = fileData;
					this.npkIndexList.Add( index );
				}
			}
		}

		internal struct NpkHeader {

			/// <summary>
			///     NeoplePack_Bill\0
			/// </summary>
			internal string flag;

			/// <summary>
			///     件数
			/// </summary>
			internal uint count;

		};

		internal struct NpkIndex {

			/// <summary>
			///     fileDataに対する開始位置
			/// </summary>
			internal int startOffset;

			/// <summary>
			///     用途不明
			/// </summary>
			internal uint size;

			/// <summary>
			///     Imgの名前
			/// </summary>
			internal string name;

			/// <summary>
			///     短い名前
			/// </summary>
			internal string shortName;

			/// <summary>
			///     ファイルデータ
			/// </summary>
			internal byte[] fileData;

			/// <summary>
			///     このNpkファイルに含まれるNImgファイルのヘッダ
			/// </summary>
			internal NImgHeader NImgHeader {
				get {
					var offset = this.startOffset;
					var header = new NImgHeader();
					header.flag = Encoding.UTF8.GetString( this.fileData, offset, 16 );
					offset += 16;
					header.indexSize = BitConverter.ToUInt32( this.fileData, offset );
					offset += 4;
					header.unknown1 = BitConverter.ToUInt32( this.fileData, offset );
					offset += 4;
					header.unknown2 = BitConverter.ToUInt32( this.fileData, offset );
					offset += 4;
					header.indexCount = BitConverter.ToUInt32( this.fileData, offset );
					offset += 4;
					header.startOffset = offset;
					if( header.flag.IndexOf( "Neople Img File", StringComparison.Ordinal ) != 0 ) {
						throw new Exception( "error flag " + header.flag + " in file " + this.name );
					}
					header.fileData = this.fileData;
					return header;
				}
			}

		};

		internal struct NImgHeader {

			/// <summary>
			///     Neople Img File
			/// </summary>
			internal string flag;

			/// <summary>
			///     NImgIndexのサイズ
			/// </summary>
			internal uint indexSize;

			/// <summary>
			///     用途不明
			/// </summary>
			internal uint unknown1;

			/// <summary>
			///     用途不明
			/// </summary>
			internal uint unknown2;

			/// <summary>
			///     NImgIndexの件数
			/// </summary>
			internal uint indexCount;

			/// <summary>
			///     ファイルデータ
			/// </summary>
			internal byte[] fileData;

			/// <summary>
			///     開始位置
			/// </summary>
			internal int startOffset;

			/// <summary>
			///     このヘッダに対応するNImgIndexの一覧
			/// </summary>
			internal NImgIndex[] NImgIndex {
				get {
					var offset = this.startOffset;
					var allImgIndex = new List<NImgIndex>();
					var totalIndexSize = 0;
					for( var i = 0; i < this.indexCount; ++i ) {
						var index = new NImgIndex();

						index.startOffset = (int)( this.startOffset + this.indexSize + totalIndexSize );
						index.fileData = this.fileData;
						index.index = i;
						index.dwType = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.dwCompress = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;

						if( index.dwType == ARGB_NONE ) {
							allImgIndex.Add( index );
							continue;
						}

						index.width = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.height = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.size = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.keyX = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.keyY = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.maxWidth = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						index.maxHeight = BitConverter.ToUInt32( this.fileData, offset );
						offset += 4;
						if( index.dwCompress == COMPRESS_NONE ) {
							switch( index.dwType ) {
								case ARGB_8888:
									totalIndexSize += (int)index.size;
									break;
								case ARGB_1555:
								case ARGB_4444:
									totalIndexSize += (int)index.size / 2;
									break;
							}
						} else {
							totalIndexSize += (int)index.size;
						}
						allImgIndex.Add( index );
					}
					return allImgIndex.ToArray();
				}
			}

		};

		internal struct NImgIndex {

			/// <summary>
			///     ファイル形式
			///     0x0E : 1555
			///     0x0F : 4444
			///     0x10 : 8888
			///     0x11 : NONE
			/// </summary>
			internal uint dwType;

			/// <summary>
			///     圧縮形式
			///     0x06 : zlib
			///     0x05 : 未圧縮
			/// </summary>
			internal uint dwCompress;

			/// <summary>
			///     幅
			/// </summary>
			internal uint width;

			/// <summary>
			///     高さ
			/// </summary>
			internal uint height;

			/// <summary>
			///     NImg圧縮前サイズ
			/// </summary>
			internal uint size;

			/// <summary>
			///     左上のX座標
			/// </summary>
			internal uint keyX;

			/// <summary>
			///     左上のY座標
			/// </summary>
			internal uint keyY;

			/// <summary>
			///     最大幅
			/// </summary>
			internal uint maxWidth;

			/// <summary>
			///     最大高さ
			/// </summary>
			internal uint maxHeight;

			/// <summary>
			///     開始位置
			/// </summary>
			internal int startOffset;

			/// <summary>
			///     ファイルデータ
			/// </summary>
			internal byte[] fileData;

			/// <summary>
			///     ファイル番号
			/// </summary>
			internal int index;

			/// <summary>
			///     このIndexに対応するNImgファイル
			/// </summary>
			internal NImg NImg {
				get {
					const int bufferSize = 1024 * 1024 * 3;

					var tempFileData = new byte[bufferSize];

					if( this.dwType == ARGB_NONE ) {
						return new NImg();
					}

					var compressedSize = this.size;

					if( this.dwCompress == COMPRESS_NONE ) {
						switch( this.dwType ) {
							case ARGB_8888:
								compressedSize = this.size;
								break;
							case ARGB_1555:
							case ARGB_4444:
								compressedSize = this.size / 2;
								break;
						}
					}
					switch( this.dwCompress ) {
						case COMPRESS_ZLIB: {
							var ms = new MemoryStream( this.fileData, this.startOffset + 2, (int)compressedSize - 2 );
							var ds = new DeflateStream( ms, CompressionMode.Decompress );
							try {
								ds.Read( tempFileData, 0, tempFileData.Length );
							} catch( Exception e ) {
								throw new Exception( "compress " + "error!" + e.Message );
							}
							ms.Close();
							ds.Close();
						}
							break;
						case COMPRESS_NONE: {
							var ms = new MemoryStream( this.fileData, this.startOffset + 2, (int)compressedSize );
							ms.Read( tempFileData, 0, tempFileData.Length );
							ms.Close();
						}
							break;
						default:
							throw new Exception( "error unknown compress type: " + this.dwCompress + " in file " );
					}
					return new NImg( (int)this.width, (int)this.height, this.dwType, tempFileData, this.index );
				}
			}

			public override string ToString() {
				string argbType;
				switch( this.dwType ) {
					case ARGB_1555:
						argbType = "ARGB_1555";
						break;
					case ARGB_4444:
						argbType = "ARGB_4444";
						break;
					case ARGB_8888:
						argbType = "ARGB_8888";
						break;
					case ARGB_NONE:
						return "Link file." + " offset=>" + this.startOffset;
					default:
						argbType = "nonononononono";
						break;
				}
				return "{ " + this.index + ": key=>(" + this.keyX + "," + this.keyY + "), wh=>(" + this.width + ", " + this.height + "), max=>(" + this.maxWidth + ", " + this.maxHeight + "), type=>" + argbType + " offset=>" + this.startOffset + "}";
			}

		};

		internal struct NImg {

			internal int width;
			internal int height;
			internal uint type;
			internal byte[] data;
			internal int index;

			internal NImg( int width, int height, uint type, byte[] data, int index ) {
				this.width = width;
				this.height = height;
				this.type = type;
				this.data = data;
				this.index = index;
			}

			public override string ToString() {
				string argbType;
				switch( this.type ) {
					case ARGB_1555:
						argbType = "ARGB_1555";
						break;
					case ARGB_4444:
						argbType = "ARGB_4444";
						break;
					case ARGB_8888:
						argbType = "ARGB_8888";
						break;
					case ARGB_NONE:
						argbType = "ARGB_NONE";
						break;
					default:
						argbType = "nonononononono";
						break;
				}
				return "{ " + this.index + ": wh=>(" + this.width + "," + this.height + "), type=>" + argbType + " }";
			}

			/// <summary>
			///     NImgファイルをBitmap化する
			/// </summary>
			/// <returns></returns>
			public Bitmap ToBitmap() {
				var bmp = new Bitmap( this.width, this.height );
				for( var i = 0; i < this.height; i++ ) {
					for( var j = 0; j < this.width; ++j ) {
						switch( this.type ) {
							case ARGB_1555: {
								var r = ( ( ( this.data[i * this.width * 2 + j * 2 + 1] & 127 ) >> 2 ) << 3 ) % 256; // red
								var g = ( ( ( ( this.data[i * this.width * 2 + j * 2 + 1] & 0x0003 ) << 3 ) | ( ( this.data[i * this.width * 2 + j * 2] >> 5 ) & 0x0007 ) ) << 3 ) % 256; // green
								var b = ( ( this.data[i * this.width * 2 + j * 2] & 0x003f ) << 3 ) % 256; // blue
								var a = ( ( this.data[i * this.width * 2 + j * 2 + 1] >> 7 ) ) % 256 == 0 ? 0 : 255; // alpha

								bmp.SetPixel( j, i, Color.FromArgb( a, r, g, b ) );
							}
								break;
							case ARGB_4444: {
								var r = ( ( this.data[i * this.width * 2 + j * 2 + 1] & 0x0f ) << 4 ) % 256; // red
								var g = ( ( ( this.data[i * this.width * 2 + j * 2 + 0] & 0xf0 ) >> 4 ) << 4 ) % 256; // green
								var b = ( ( this.data[i * this.width * 2 + j * 2 + 0] & 0x0f ) << 4 ) % 256; // blue
								var a = ( ( this.data[i * this.width * 2 + j * 2 + 1] & 0xf0 ) >> 4 ) << 4; // alpha

								bmp.SetPixel( j, i, Color.FromArgb( a, r, g, b ) );
							}
								break;
							case ARGB_8888: {
								int r = this.data[i * this.width * 4 + j * 4 + 2]; // red
								int g = this.data[i * this.width * 4 + j * 4 + 1]; // green
								int b = this.data[i * this.width * 4 + j * 4 + 0]; // blue
								int a = this.data[i * this.width * 4 + j * 4 + 3]; // alpha

								bmp.SetPixel( j, i, Color.FromArgb( a, r, g, b ) );
							}
								break;
							case ARGB_NONE:
								break;
							default:
								Console.WriteLine( "error known type:" + this.type );
								break;
						}
					}
				}
				return bmp;
			}

		}

	}
}