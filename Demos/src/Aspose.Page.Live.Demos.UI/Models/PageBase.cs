using Aspose.Page.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.Page.Live.Demos.UI.Helpers;
using Aspose.Page.Live.Demos.UI.Services;
using Aspose.Page;
using Aspose.Page.EPS;
using Aspose.Page.XPS;
using Aspose.Page.XPS.Presentation.Image;
using Newtonsoft.Json.Linq;
using Path = System.IO.Path;


namespace Aspose.Page.Live.Demos.UI.Models
{
	///<Summary>
	/// PageBase class 
	///</Summary>

	public class PageBase : ModelBase
	{
		/// <summary>
		/// Maximum number of files which can be uploaded for MVC Aspose.Pdf apps
		/// </summary>
		protected static int MaximumUploadFiles = 10;

		/// <summary>
		/// Original file format SaveAs option for multiple files uploading. By default, "-"
		/// </summary>
		protected const string SaveAsOriginalName = ".-";

		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response MaximumFileLimitsResponse = new Response()
		{
			Status = $"Number of files should be equal or less {MaximumUploadFiles}",
			StatusCode = 500
		};

		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};


		///<Summary>
		/// Options class 
		///</Summary>
		public class Options
		{
			///<Summary>
			/// AppName
			///</Summary>
			public string AppName;
			///<Summary>
			/// FolderName
			///</Summary>
			public string FolderName;
			///<Summary>
			/// FileName
			///</Summary>
			public string FileName;
			public string SourceDirectory;
			public string OutputDirectory;

			private string _outputType;

			/// <summary>
			/// By default, it is the extension of FileName - e.g. ".docx"
			/// </summary>
			public string OutputType
			{
				get => _outputType;
				set
				{
					if (!value.StartsWith("."))
						value = "." + value;
					_outputType = value.ToLower();
				}
			}

			/// <summary>
			/// Check if OuputType is a picture extension
			/// </summary>
			public bool IsPicture
			{
				get
				{
					switch (_outputType)
					{
						case ".bmp":
						case ".png":
						case ".jpg":
						case ".jpeg":
						case ".tiff":
							return true;
						default:
							return false;
					}
				}
			}

			///<Summary>
			/// ResultFileName
			///</Summary>
			public string ResultFileName = "";

			///<Summary>
			/// MethodName
			///</Summary>
			public string MethodName;
			///<Summary>
			/// ModelName
			///</Summary>
			public string ModelName;
			///<Summary>
			/// CreateZip
			///</Summary>
			public bool CreateZip = false;
			///<Summary>
			/// CheckNumberOfPages
			///</Summary>
			public bool CheckNumberOfPages = false;
			///<Summary>
			/// DeleteSourceFolder
			///</Summary>
			public bool DeleteSourceFolder = false;

			/// <summary>
			/// Output zip filename (without '.zip'), if CreateZip property is true
			/// By default, FileName + AppName
			/// </summary>
			public string ZipFileName;

			/// <summary>
			/// AppSettings.WorkingDirectory + FolderName + "/" + FileName
			/// </summary>
			public string WorkingFileName
			{
				get
				{
					if (System.IO.File.Exists(Config.Configuration.WorkingDirectory + FolderName + "/" + FileName))
						return Config.Configuration.WorkingDirectory + FolderName + "/" + FileName;
					return Config.Configuration.OutputDirectory + FolderName + "/" + FileName;
				}
			}
		}
		/// <summary>
		/// init Options
		/// </summary>
		protected Options Opts = new Options();

		/// <summary>
		/// UTF8WithoutBom
		/// </summary>
		protected static readonly Encoding UTF8WithoutBom = new UTF8Encoding(false);

		

		private object Lock1 = new object();
		private object Lock2 = new object();

		/// <summary>
		/// PageBase
		/// </summary>
		public PageBase()
		{
			
			Opts.ModelName = GetType().Name;
		}

		/// <summary>
		/// PageBase
		/// </summary>
		static PageBase()
		{
			Aspose.Page.Live.Demos.UI.Models.License.SetAsposePageLicense();
			
		}

	

		

		protected string CheckInputType(MultipartFormDataStreamProviderSafe uploadProvider, string _inputType)
		{
			if (uploadProvider.FileData[0] != null)
			{
				string inputFileName = uploadProvider.FileData[0].LocalFileName;
				string actualInputType = inputFileName.Substring(inputFileName.LastIndexOf('.') + 1);
				if (!_inputType.Equals(actualInputType))
					_inputType = actualInputType;
			}
			return _inputType;
		}

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="docs"></param>
		protected void SetDefaultOptions(AsposePageDocumentInfo[] docs, string outputType)
		{
			if (docs.Length > 0)
			{
				SetDefaultOptions(Path.GetFileName(docs[0].FileName), outputType);
				Opts.CreateZip = docs.Length > 1 || Opts.IsPicture;
			}
		}

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="files"></param>
		protected void SetDefaultOptions(Collection<MultipartFileData> files, string outputType)
		{
			if (files.Count > 0)
			{
				SetDefaultOptions(Path.GetFileName(files.First().LocalFileName), outputType);
				Opts.CreateZip = files.Count > 1 || Opts.IsPicture;
			}
		}

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="filename"></param>
		private void SetDefaultOptions(string filename, string outputType)
		{
			Opts.ResultFileName = filename;
			Opts.FileName = Path.GetFileName(filename);

			//var query = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
			//string outputType = null;
			//if (query.ContainsKey("outputType"))
			//	outputType = query["outputType"];
			Opts.OutputType = !string.IsNullOrEmpty(outputType)
			  ? outputType
			  : Path.GetExtension(Opts.FileName);

			Opts.ResultFileName = Opts.OutputType == SaveAsOriginalName
			  ? Opts.FileName
			  : Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
		}

		protected AsposePageSaveFormatType GetSaveOptions(string outputType, string inputType)
		{
			var _inputType = inputType.ToLower();
			var saveFormat = new AsposePageSaveFormatType();

			if (_inputType.Equals("ps") || _inputType.Equals("eps"))
			{
				if (outputType.Equals("pdf"))
				{
					saveFormat.SaveOptions = new Aspose.Page.EPS.Device.PdfSaveOptions();
					saveFormat.SaveType = AsposePageSaveType.pdf;
				}
				else
				{
					switch (outputType)
					{
						case "bmp":
							{
								saveFormat.SaveType = AsposePageSaveType.bmp;
								break;
							}
						case "tiff":
							{
								saveFormat.SaveType = AsposePageSaveType.tiff;
								break;
							}
						case "jpg":
							{
								saveFormat.SaveType = AsposePageSaveType.jpg;
								break;
							}
						default:
							saveFormat.SaveType = AsposePageSaveType.png;
							break;
					}
					saveFormat.SaveOptions = new Aspose.Page.EPS.Device.ImageSaveOptions();
				}
			}
			else
			{
				switch (outputType)
				{
					case "pdf":
						{
							saveFormat.SaveOptions = new Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions();
							saveFormat.SaveType = AsposePageSaveType.pdf;
							break;
						}
					case "bmp":
						{
							saveFormat.SaveOptions = new Aspose.Page.XPS.Presentation.Image.BmpSaveOptions();
							saveFormat.SaveType = AsposePageSaveType.bmp;
							break;
						}
					case "tiff":
						{
							saveFormat.SaveOptions = new Aspose.Page.XPS.Presentation.Image.TiffSaveOptions();
							saveFormat.SaveType = AsposePageSaveType.tiff;
							break;
						}
					case "jpg":
						{
							saveFormat.SaveOptions = new Aspose.Page.XPS.Presentation.Image.JpegSaveOptions();
							saveFormat.SaveType = AsposePageSaveType.jpg;
							break;
						}
					default:
						saveFormat.SaveOptions = new Aspose.Page.XPS.Presentation.Image.PngSaveOptions();
						saveFormat.SaveType = AsposePageSaveType.png;
						break;
				}
			}

			return saveFormat;
		}

		/// <summary>
		/// Prepare upload files and return FileData
		/// </summary>
		protected async Task<Collection<MultipartFileData>> UploadFiles()
		{
			Opts.FolderName = Guid.NewGuid().ToString();
			var pathProcessor = new PathProcessor(Opts.FolderName);
			var uploadProvider = new MultipartFormDataStreamProviderSafe(pathProcessor.SourceFolder);
			await Request.Content.ReadAsMultipartAsync(uploadProvider);
			return uploadProvider.FileData;
		}

		/// <summary>
		/// Process
		/// </summary>
		protected Response Process(ActionDelegate action)
		{
			if (string.IsNullOrEmpty(Opts.OutputType) && !string.IsNullOrEmpty(Opts.FileName))
				Opts.OutputType = Path.GetExtension(Opts.FileName);

			if (Opts.IsPicture)
				Opts.CreateZip = true;

			if (string.IsNullOrEmpty(Opts.ZipFileName))
				Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.AppName;

			var outputType = Opts.OutputType;
			if (outputType == SaveAsOriginalName && !string.IsNullOrEmpty(Opts.FileName))
				outputType = Path.GetExtension(Opts.FileName);
			
			return Process(Opts.ModelName, Opts.ResultFileName, Opts.FolderName, outputType, Opts.CreateZip, Opts.CheckNumberOfPages,
				 Opts.MethodName, action, Opts.DeleteSourceFolder, Opts.ZipFileName, Opts.SourceDirectory, Opts.OutputDirectory);
		}
		
		/// <summary>
		/// Check if the OutputType is a picture and saves the document
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="outPath"></param>
		/// <param name="zipOutFolder"></param>
		/// <param name="saveOptions"></param>
		protected void SaveDocument(AsposePageDocumentInfo doc, string outPath, string zipOutFolder, AsposePageSaveFormatType saveOptions)
		{
			string filename;
			if (Opts.CreateZip)
				filename = zipOutFolder + "/" +
						   (Opts.OutputType == SaveAsOriginalName
							 ? Path.GetFileName(doc.FileName)
							 : Path.GetFileNameWithoutExtension(doc.FileName) + Opts.OutputType);
			else
				filename = outPath;
			SaveDocument(doc, filename, saveOptions);
		}

		/// <summary>
		/// Check if the OutputType is a picture and saves the document
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="filename">The output full FileName</param>
		/// <param name="saveOptions"></param>
		protected void SaveDocument(AsposePageDocumentInfo doc, string filename, AsposePageSaveFormatType saveOptions)
		{
			//string outPath;
			var zipOutFolder = $"{Path.GetDirectoryName(filename)}\\{Path.GetFileNameWithoutExtension(filename)}";
			//Directory.CreateDirectory(zipOutFolder);
			//Device device = null;
			SaveDocument(doc, filename, saveOptions, zipOutFolder);
		}
		protected void SaveDocument(AsposePageDocumentInfo doc, string filename, AsposePageSaveFormatType saveOptions, string outFolder)
		{
			lock (Lock1)
			{
				if (doc.Document is PsDocument)
				{
					if (saveOptions.SaveType.Equals(AsposePageSaveType.pdf))
					{
						Stream pdfStream = null;
						try
						{
							pdfStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
							Aspose.Page.EPS.Device.PdfDevice pdfDevice = new Aspose.Page.EPS.Device.PdfDevice(pdfStream);
							doc.Document.Save(pdfDevice, saveOptions.SaveOptions);
							doc.NumberOfPages = ((PsDocument)doc.Document).NumberOfPages;
							doc.PageSize = pdfDevice.Size;
						}
						finally
						{
							pdfStream.Close();
						}
					}
					else
					{
						Aspose.Page.EPS.Device.ImageDevice device = null;
						switch (saveOptions.SaveType)
						{
							case AsposePageSaveType.bmp:
								device = new Aspose.Page.EPS.Device.ImageDevice(ImageFormat.Bmp);
								break;
							case AsposePageSaveType.jpg:
								device = new Aspose.Page.EPS.Device.ImageDevice(ImageFormat.Jpeg);
								break;
							case AsposePageSaveType.tiff:
								device = new Aspose.Page.EPS.Device.ImageDevice(ImageFormat.Tiff);
								break;
							default://case AsposePageSaveType.png:
								device = new Aspose.Page.EPS.Device.ImageDevice(ImageFormat.Png);
								break;
						}
						doc.Document.Save(device, saveOptions.SaveOptions);
						doc.NumberOfPages = ((PsDocument)doc.Document).NumberOfPages;
						doc.PageSize = device.Size;
						byte[][] imagesBytes = device.ImagesBytes;
						Directory.CreateDirectory(outFolder);
						filename = outFolder + "\\" + Path.GetFileNameWithoutExtension(filename);
						SaveImagesBytesAsImageFilesForEps(imagesBytes, filename, device.Format);
					}
				}
				else
				{

					if (saveOptions.SaveType == AsposePageSaveType.pdf)
					{
						Stream pdfStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
						Aspose.Page.XPS.Presentation.Pdf.PdfDevice pdfDevice = new Aspose.Page.XPS.Presentation.Pdf.PdfDevice(pdfStream);
						try
						{
							doc.Document.Save(pdfDevice, saveOptions.SaveOptions);
							doc.NumberOfPages = ((XpsDocument)doc.Document).PageCount;
							doc.PageSize = pdfDevice.Size;
						}
						finally
						{
							pdfStream.Close();
						}
					}
					else
					{
						string ext = null;
						switch (saveOptions.SaveType)
						{
							case AsposePageSaveType.bmp:
								ext = "bmp";
								break;
							case AsposePageSaveType.jpg:
								ext = "jpg";
								break;
							case AsposePageSaveType.tiff:
								ext = "tiff";
								break;
							default:
								ext = "png";
								break;
						}
						Aspose.Page.XPS.Presentation.Image.ImageDevice imageDevice = new Aspose.Page.XPS.Presentation.Image.ImageDevice();
						doc.Document.Save(imageDevice, saveOptions.SaveOptions);
						doc.NumberOfPages = ((XpsDocument)doc.Document).PageCount;
						doc.PageSize = imageDevice.Size;
						byte[][][] result = imageDevice.Result;

						Directory.CreateDirectory(outFolder);
						filename = outFolder + "\\" + Path.GetFileNameWithoutExtension(filename);
						SaveImagesBytesAsImageFilesForXps(result, filename, ext);
					}
				}
			}


			
		}

		private static void SaveImagesBytesAsImageFilesForEps(byte[][] imagesBytes, string outFileName, ImageFormat imageFormat)
		{
			string fileNameWithoutExt = Path.GetDirectoryName(outFileName) + @"\" + Path.GetFileNameWithoutExtension(outFileName);
			int i = 0;

			foreach (byte[] imageBytes in imagesBytes)
			{
				string imagePath = Path.GetFullPath(string.Format("{0}_{1}.{2}", fileNameWithoutExt, i.ToString(), imageFormat.ToString().ToLower()/*IMAGE_EXT*/));

				using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
				{
					fs.Write(imageBytes, 0, imageBytes.Length);
				}
				i++;
			}
		}

		private static void SaveImagesBytesAsImageFilesForXps(byte[][][] result, string outFileName, string extensions)
		{
			string fileNameWithoutExt = Path.GetDirectoryName(outFileName) + @"\" + Path.GetFileNameWithoutExtension(outFileName);
			int i = 0;

			foreach (byte[][] doc in result)
				foreach (byte[] page in doc)
				{
					{
						string imagePath = Path.GetFullPath(string.Format("{0}_{1}.{2}", fileNameWithoutExt, i.ToString(), extensions.ToLower()));

						using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
						{
							fs.Write(page, 0, page.Length);
						}
						i++;
					}
				}
		}

		

		#region Common
		/// <summary>
		/// IsValidRegex
		/// </summary>
		public static bool IsValidRegex(string pattern)
		{
			if (string.IsNullOrEmpty(pattern))
				return false;
			try
			{
				Regex.Match("", pattern);
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Prepare output folder for using when multiple files are uploaded
		/// Creates folder by filename without extension
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="path">Zip folder name</param>
		/// <returns>Tuple(original filename, output folder)</returns>
		protected static (string, string) PrepareFolder(Document doc, string path)
		{
			/*var filename = Path.GetFileNameWithoutExtension(doc.FileName);
			var folder = path + "/";
			folder += filename;
			while (Directory.Exists(folder))
				folder += "_";
			folder += "/";
			Directory.CreateDirectory(folder);
			return (Path.GetFileName(doc.FileName), folder);*/
			return (null, null);
		}

		
		#endregion
	}

	public class AsposePageSaveFormatType
	{
		public SaveOptions SaveOptions { get; set; }
		public AsposePageSaveType? SaveType { get; set; }
	}
	public enum AsposePageSaveType
	{
		pdf,
		bmp,
		png,
		tiff,
		jpg
	}
	public class AsposePageDocumentInfo
	{
		public Document Document { get; set; }
		public string FileName { get; set; }

		public Stream InputStream { get; set; }

		public string InputType { get; set; }

		public int NumberOfPages { get; set; }

		public Size PageSize { get; set; }
	}
}
