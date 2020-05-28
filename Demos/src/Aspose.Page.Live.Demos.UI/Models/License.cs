using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Page.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.Product.Family.lic";

		///<Summary>
		/// SetAsposePageLicense method to Aspose.ThreeD License
		///</Summary>
		public static void SetAsposePageLicense()
		{
			try
			{

				Aspose.Page.License lic = new Aspose.Page.License();
				lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}	
		
	}
}
