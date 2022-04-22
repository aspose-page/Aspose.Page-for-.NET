using Aspose.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.GettingStarted
{
    public class LoadLicenseFromFile
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_GettingStarted();
            // Initialize license object
            License license = new License();
            // Set license
            license.SetLicense(/*"D:\\Aspose.Total.NET.lic"*/"D:\\Aspose.Page.NET.lic");
            Console.WriteLine("License set successfully.");
            // ExEnd:1
        }
    }
}
