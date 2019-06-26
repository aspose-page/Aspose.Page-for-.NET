using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.GettingStarted
{
    public class SetLicenseUsingEmbeddedResource
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_GettingStarted();
            // Initialize license object
            Aspose.Page.License license = new Aspose.Page.License();
            // Set license
            license.SetLicense("MergedAPI.Aspose.Total.NET.lic");
            // Set the value to indicate that license will be embedded in the application
            license.Embedded = true;
            Console.WriteLine("License set successfully.");
            // ExEnd:1
        }
    }
}
