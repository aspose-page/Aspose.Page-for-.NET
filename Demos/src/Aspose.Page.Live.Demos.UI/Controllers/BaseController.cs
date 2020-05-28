using Aspose.Page.Live.Demos.UI.Config;
using Aspose.Page.Live.Demos.UI.Models;
using Aspose.Page.Live.Demos.UI.Services;
using Aspose.Page.Live.Demos.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using Aspose.Page.XPS;
using Aspose.Page.XPS.Presentation.Image;
using System.IO;

namespace Aspose.Page.Live.Demos.UI.Controllers
{
	public abstract class BaseController : Controller
	{
	
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};
		

		public abstract string Product { get; }

		protected override void OnActionExecuted(ActionExecutedContext ctx)
		{
			base.OnActionExecuted(ctx);			
			ViewBag.Title = ViewBag.Title ?? Resources["ApplicationTitle"];
			ViewBag.MetaDescription = ViewBag.MetaDescription ?? "Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications.";
		}
		/// <summary>
		/// Prepare upload files and return as documents
		/// </summary>
		/// <param name="inputType"></param>
		protected AsposePageDocumentInfo[] UploadDocuments(HttpRequestBase Request, string sourceFolder)
		{
			
			try
			{
				var pathProcessor = new PathProcessor(sourceFolder);
				List<AsposePageDocumentInfo> documents = new List<AsposePageDocumentInfo>();

				for (int i = 0; i < Request.Files.Count; i++)
				{
					HttpPostedFileBase postedFile = Request.Files[i];

					if (postedFile != null)
					{
						// Check if File is available.
						if (postedFile != null && postedFile.ContentLength > 0)
						{
							string _savepath = pathProcessor.SourceFolder + "\\" + System.IO.Path.GetFileName(postedFile.FileName);
							postedFile.SaveAs(_savepath);

							string _extension = System.IO.Path.GetExtension(postedFile.FileName);
							_extension = _extension.Replace(".", "");

							if ((_extension == "ps") || (_extension == "eps"))

							{
								documents.Add(new AsposePageDocumentInfo()
								{
									FileName = _savepath,
									InputType = _extension,
									Document = new PsDocument(new FileStream(_savepath, FileMode.Open, FileAccess.Read))
								});
							}
							else if (_extension == "xps") 

							{
								documents.Add(new AsposePageDocumentInfo()
								{
									FileName = _savepath,
									InputType = _extension,
									Document = new XpsDocument(_savepath)
								});
							}

						}
					}
				}


				return documents.ToArray();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new AsposePageDocumentInfo[0];
			}
		}
		private AsposePageContext _atcContext;
		

		/// <summary>
		/// Main context object to access all the dcContent specific context info
		/// </summary>
		public AsposePageContext AsposePageContext
		{
			get
			{
				if (_atcContext == null) _atcContext = new AsposePageContext(HttpContext.ApplicationInstance.Context);
				return _atcContext;
			}
		}

		private Dictionary<string, string> _resources;

		/// <summary>
		/// key/value pair containing all the error messages defined in resources.xml file
		/// </summary>
		public Dictionary<string, string> Resources
		{
			get
			{
				if (_resources == null) _resources = AsposePageContext.Resources;
				return _resources;
			}
		}

		

		
	}
}
