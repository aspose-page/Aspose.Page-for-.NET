using Aspose.Page.Live.Demos.UI.Config;
using System;
using System.Web;
using System.Web.UI;

namespace Aspose.Page.Live.Demos.UI.ViewerApp
{
	public partial class Default : BasePage
	{
		public string fileName = "";
		public string downloadFileName = "";
		public string productName = "";
		public string fileFormat = "";
		public string folderName = "";
		public string callbackURL = "";
        public string apiUrl = "";

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				fileName = Get("filename");

				if (fileName != string.Empty)
					downloadFileName = HttpUtility.UrlEncode(fileName);                

				
				folderName = Get("foldername");
				callbackURL = Get("callbackURL");

                apiUrl = Configuration.AsposePageLiveDemosPath;

                Page.Title = Resources["pageViewerPageTitle"];
				Page.MetaDescription = Resources["pageViewerMetaDescription"];
			}
		}

		private string Get(string key)
		{
			return Page.RouteData.Values[key]?.ToString() ?? Request.QueryString[key];
		}
	}
}
