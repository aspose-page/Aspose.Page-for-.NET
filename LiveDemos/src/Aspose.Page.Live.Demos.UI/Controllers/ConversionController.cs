using Aspose.Page.Live.Demos.UI.Models.Common;
using Aspose.Page.Live.Demos.UI.Models;
using Aspose.Page.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Page.Live.Demos.UI.Controllers
{
	public class ConversionController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];
		
		[HttpPost]
		public Response Conversion(string outputType)
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				string _sourceFolder = Guid.NewGuid().ToString();
				var _docs = UploadDocuments(Request, _sourceFolder);

				AsposePageConversion _asposePageConversion = new AsposePageConversion();
				response = _asposePageConversion.Convert(_docs, outputType, _sourceFolder);

			}

			return response;

		}

		

		public ActionResult Conversion()
		{
			var model = new ViewModel(this, "Conversion")
			{
				SaveAsComponent = true,
				SaveAsOriginal = false,
				MaximumUploadFiles = 1,
				DropOrUploadFileLabel = Resources["DropOrUploadFile"]
			};

			return View(model);
		}
		

	}
}
