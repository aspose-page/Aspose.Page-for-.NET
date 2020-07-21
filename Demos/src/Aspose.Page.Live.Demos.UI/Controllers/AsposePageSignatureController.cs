using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Aspose.Page.Live.Demos.UI.Models;
using System.Threading.Tasks;
using System.Drawing;
using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;

namespace Aspose.Page.Live.Demos.UI.Controllers
{
	///<Summary>
	/// AsposePageSignatureController class to sign pdf file
	///</Summary>
	public class AsposePageSignatureController : PageBase
	{
		///<Summary>
		/// Sign documents
		///</Summary>
		[MimeMultipart]
		[HttpPost]
		[AcceptVerbs("GET", "POST")]
		public async Task<Response> Sign(string outputType, string signatureType)
		{
			outputType = outputType == "-" ? "xps" : outputType.ToLower();
			try
			{
				var form = HttpContext.Current.Request.Form;
				string _imageFile = form["image"];
				string _text = form["text"];
				string _textColor = form["textColor"];
			 string workingDirectory =	Aspose.Page.Live.Demos.UI.Config.Configuration.WorkingDirectory;
				string OutputDirectory = Aspose.Page.Live.Demos.UI.Config.Configuration.OutputDirectory;
				var files = await UploadFiles();
				var docs = files.Where(x => x.Headers.ContentDisposition.Name != "\"imageFile\"").Select(
					x => new AsposePageDocumentInfo() {
						FileName = x.LocalFileName, Document = new XpsDocument(x.LocalFileName)
					}).ToArray();
				if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
					return MaximumFileLimitsResponse;

				SetDefaultOptions(docs, outputType);
				Opts.AppName = "SignatureApp";
				Opts.MethodName = "Sign";
				Opts.ResultFileName = Path.GetFileNameWithoutExtension(docs[0].FileName) + "." + outputType;
				Opts.ZipFileName = "Signed documents";
				Opts.OutputDirectory = OutputDirectory;
				Opts.SourceDirectory = workingDirectory;

				var imageFile = files.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "\"imageFile\"")?.LocalFileName;
				if (signatureType == "image" && imageFile == null)
					return new Response
					{
						Status = "Can't process the image file",
						StatusCode = 500
					};
				Aspose.Page.Live.Demos.UI.Models.License.SetAsposePageLicense();
				return  Process((inFilePath, outPath, zipOutFolder) =>
				{
					var tasks = docs.Select(doc => Task.Factory.StartNew(() =>
					{
						switch (signatureType)
						{
							case "drawing":
								AddDrawing(doc, _imageFile, outPath);
								break;
							case "text":
								AddText(doc, _text, _textColor);
								break;
							case "image":
								AddImage(doc, imageFile);
								break;
						}
						((XpsDocument)doc.Document).Save(outPath/*, GetSaveFormat(outputType.ToLower())*/);
						//SaveDocument(doc, outPath, zipOutFolder, new SaveFormatType() { SaveOptions = new PdfSaveOptions(), SaveType = SaveType.pdf});
					})).ToArray();

					Task.WaitAll(tasks);
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new Response
				{
					Status = "Error during processing your file",
					StatusCode = 500
				};
			}
		}

		private void AddImage(AsposePageDocumentInfo doc, string imageFile)
		{
			XpsDocument document = doc.Document as XpsDocument;

			string signatureImageName = imageFile;

			XpsPath path = document.AddPath(document.CreatePathGeometry("M 413.65,0 L 611.95,0 L 611.95,99.15 L 413.65,99.15 Z"));
			path.Clip = document.CreatePathGeometry("M 0.000008454,0 L 612,0 L 612,792 L 0.000008454,792 Z ");
			var imageBrush = document.CreateImageBrush(signatureImageName, new RectangleF(0, 0, 350.05f, 150.02f), new RectangleF(0, 0, 1f, 1f));
			imageBrush.Transform = document.CreateMatrix(198.3f, 0, 0, 99.15f, 413.65f, 0);
			imageBrush.TileMode = XpsTileMode.None;
			path.Fill = imageBrush;
		}

		private void AddText(AsposePageDocumentInfo doc, string signatureText, string signatureTextColor)
		{
			XpsDocument document = doc.Document as XpsDocument;
			XpsSolidColorBrush textFill = document.CreateSolidColorBrush(Color.Black);
			if (signatureTextColor != "")
			{
				if (!signatureTextColor.StartsWith("#"))
				{
					signatureTextColor = "#" + signatureTextColor;
				}
				textFill = document.CreateSolidColorBrush(System.Drawing.ColorTranslator.FromHtml(signatureTextColor));
			}

			//Add glyph to the document
			XpsGlyphs glyphs = document.AddGlyphs("Arial", 24, FontStyle.Regular, 450f, 50f, signatureText);
			glyphs.Fill = textFill;
		}

		private void AddDrawing(AsposePageDocumentInfo doc, string signatureImageStr, string outPath)
		{
			byte[] imageBytes = Convert.FromBase64String(signatureImageStr);
			var signatureImageFileName = outPath.Replace("xps", "png");
			System.IO.File.WriteAllBytes(signatureImageFileName, imageBytes);

			XpsDocument document = doc.Document as XpsDocument;
			XpsPath path = document.AddPath(document.CreatePathGeometry("M 413.65,0 L 611.95,0 L 611.95,99.15 L 413.65,99.15 Z"));
			path.Clip = document.CreatePathGeometry("M 0.000008454,0 L 612,0 L 612,792 L 0.000008454,792 Z ");
			var imageBrush = document.CreateImageBrush(signatureImageFileName, new RectangleF(0, 0, 350.05f, 150.02f), new RectangleF(0, 0, 1f, 1f));
			imageBrush.Transform = document.CreateMatrix(198.3f, 0, 0, 99.15f, 413.65f, 0);
			imageBrush.TileMode = XpsTileMode.None;
			path.Fill = imageBrush;
		}


		
		
		
	}
}
