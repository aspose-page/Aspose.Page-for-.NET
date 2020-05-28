using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using Aspose.Page.Live.Demos.UI.Models;
using Newtonsoft.Json;
using Document = Aspose.Page.Document;
using Aspose.Page.Live.Demos.UI.Helpers;
using Aspose.Page.EPS;
using Aspose.Page.XPS;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using File = System.IO.File;

namespace Aspose.Page.Live.Demos.UI.Controllers
{
	///<Summary>
	/// AsposeViewerController class to get document page
	///</Summary>
	public class AsposeViewerController : ApiController
	{
		
		///<Summary>
		/// GetDocumentPage method to get document page
		///</Summary>
		[HttpGet]		
		public HttpResponseMessage GetDocumentPage( string file, string folderName,  int currentPage)
		{
			string outfileName = Path.GetFileNameWithoutExtension(file) + "_{0}";
			string outPath = Config.Configuration.OutputDirectory + folderName + "/" + outfileName;

			currentPage = currentPage - 1;

			string imagePath = string.Format(outPath, currentPage) + ".jpeg";
			Directory.CreateDirectory(Config.Configuration.OutputDirectory + folderName);

			if (System.IO.File.Exists(imagePath))
			{
				return GetImageFromPath(imagePath);
			}
			int i = currentPage;
			return null;

			
		}
		
		///<Summary>
		/// DocumentPages method to get document pages
		///</Summary>
		[HttpGet]		
		public List<string> DocumentPages( string file, string folderName, int currentPage)
		{			
			List<string> output;			
			
			
			try
			{
				output = GetDocumentPages( file, folderName, currentPage);

				
			}
			catch (Exception ex)
			{
				
				throw ex;
			}

			return output;
		}

		private List<string> GetDocumentPages(string file, string folderName,  int currentPage)
		{
			List<string> lstOutput = new List<string>();
			string outfileName = "page_{0}";
			string outPath =  Config.Configuration.OutputDirectory + folderName + "/" + outfileName;

			currentPage = currentPage - 1;
			Directory.CreateDirectory(Config.Configuration.OutputDirectory + folderName);
			string imagePath = string.Format(outPath, currentPage) + ".jpeg";
						
			if (System.IO.File.Exists(imagePath) && currentPage > 0)
			{
				lstOutput.Add(imagePath);
				return lstOutput;
			}

			int i = currentPage;

			var filename = System.IO.File.Exists(Config.Configuration.WorkingDirectory + folderName + "/" + file)
				? Config.Configuration.WorkingDirectory + folderName + "/" + file
				: Config.Configuration.OutputDirectory + folderName + "/" + file;
			
			using (FilePathLock.Use(filename))
			{


				try
				{
					if (!System.IO.File.Exists(Config.Configuration.OutputDirectory + folderName + "/" + "outputPDF.pdf"))
					{
						Aspose.Page.Live.Demos.UI.Models.License.SetAsposePageLicense();
						System.IO.FileStream pdfStream = new System.IO.FileStream(Config.Configuration.OutputDirectory + folderName + "/" + "outputPDF.pdf", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
						System.IO.FileStream psStream = new System.IO.FileStream(Config.Configuration.WorkingDirectory + folderName + "/" + file, System.IO.FileMode.Open, System.IO.FileAccess.Read);

						try
						{
							if (file.ToLower().EndsWith(".xps"))
							{
								Page.XPS.XpsDocument document = new XpsDocument(psStream, new Page.XPS.XpsLoadOptions());
								Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions options = new Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions();
								Aspose.Page.XPS.Presentation.Pdf.PdfDevice device = new Aspose.Page.XPS.Presentation.Pdf.PdfDevice(pdfStream, new Size(595, 842));
								document.Save(device, options);
							}
							else
							{
								PsDocument document = new PsDocument(psStream);
								Aspose.Page.EPS.Device.PdfSaveOptions options = new Aspose.Page.EPS.Device.PdfSaveOptions(true);
								Aspose.Page.EPS.Device.PdfDevice device = new Aspose.Page.EPS.Device.PdfDevice(pdfStream, new Size(595, 842));
								document.Save(device, options);
							}
						}
						finally
						{
							psStream.Close();
							pdfStream.Close();
						}
					}

					
					PdfConverter objConverter = new PdfConverter();
					objConverter.BindPdf(Config.Configuration.OutputDirectory + folderName + "/" + "outputPDF.pdf");
					objConverter.DoConvert();
					objConverter.CoordinateType = PageCoordinateType.CropBox;
					if (currentPage < objConverter.PageCount)
					{
						lstOutput.Add(objConverter.PageCount.ToString());
						i = 0;
						while (objConverter.HasNextImage() && i < objConverter.PageCount)
						{
							objConverter.StartPage = (currentPage + 1);
							objConverter.GetNextImage(imagePath, System.Drawing.Imaging.ImageFormat.Png);
							lstOutput.Add(imagePath);
							break;
						}
					}
					objConverter.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return lstOutput;

			}
			
		}
		///<Summary>
		/// DownloadDocument method to download document
		///</Summary>
		[HttpGet]
		
		public HttpResponseMessage DownloadDocument(string file, string folderName, bool isImage)
		{			
			string outfileName = Path.GetFileNameWithoutExtension(file) + "_Out.zip";
			string outPath;

			if (!isImage)
			{
				if (System.IO.File.Exists(Config.Configuration.WorkingDirectory + folderName + "/" + file))
					outPath = Config.Configuration.WorkingDirectory + folderName + "/" + file;
				else
					outPath = Config.Configuration.OutputDirectory + folderName + "/" + file;
			}
			else
			{
				outPath = Config.Configuration.OutputDirectory + outfileName;
			}

			using (FilePathLock.Use(outPath))
			{
				if (isImage)
				{
					if (System.IO.File.Exists(outPath))
						System.IO.File.Delete(outPath);

					List<string> lst = GetDocumentPages(file, folderName,  1);

					if (lst.Count > 1)
					{
						int tmpPageCount = int.Parse(lst[0]);
						for (int i = 2; i <= tmpPageCount; i++)
						{
							GetDocumentPages( file, folderName,  i);
						}
					}

					ZipFile.CreateFromDirectory(Config.Configuration.OutputDirectory + folderName + "/", outPath);
				}


				if ((!System.IO.File.Exists(outPath)) || !Path.GetFullPath(outPath).StartsWith(Path.GetFullPath( System.Web.HttpContext.Current.Server.MapPath("~/Assets/"))))
				{
					var exception = new HttpResponseException(HttpStatusCode.NotFound);
					
					throw exception;
				}

				try
				{
					using (var fileStream = new FileStream(outPath, FileMode.Open, FileAccess.Read))
					{
						
						using (var ms = new MemoryStream())
						{
							fileStream.CopyTo(ms);
							var result = new HttpResponseMessage(HttpStatusCode.OK)
							{
								Content = new ByteArrayContent(ms.ToArray())
							};
							result.Content.Headers.ContentDisposition =
								new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
								{
									FileName = (isImage ? outfileName : file)
								};
							result.Content.Headers.ContentType =
								new MediaTypeHeaderValue("application/octet-stream");

							return result;
						}
					}

				}
				catch (Exception x)
				{

					Console.WriteLine(x.Message);
				}
			}

			return null;
		}

		///<Summary>
		/// PageImage method to get page image
		///</Summary>
		[HttpGet]
		
		public HttpResponseMessage PageImage(string imagePath)
		{
			return GetImageFromPath(imagePath);
		}

		private HttpResponseMessage GetImageFromPath(string imagePath)
		{
			HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
			FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
			System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream);
			MemoryStream memoryStream = new MemoryStream();


			image.Save(memoryStream, ImageFormat.Jpeg);
			result.Content = new ByteArrayContent(memoryStream.ToArray());
			result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
			fileStream.Close();

			return result;
		}
	}
}
