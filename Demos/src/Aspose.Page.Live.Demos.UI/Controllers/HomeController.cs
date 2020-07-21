using Aspose.Page.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Page.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Free Apps for XPS, PS, EPS viewing | PDF and Image Conversion";
			ViewBag.MetaDescription = "Platform independent Free Apps providing capabilities to view and convert XPS, PS and EPS files to PDF or Raster Image formats. No subscription required.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
