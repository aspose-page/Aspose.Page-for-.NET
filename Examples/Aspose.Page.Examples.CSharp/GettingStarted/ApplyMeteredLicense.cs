using Aspose.Page;
using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.GettingStarted
{
    public class ApplyMeteredLicense
    {
        public static void Run()
        {
            // ExStart:1
            // set metered public and private keys
            Aspose.Page.Metered metered = new Aspose.Page.Metered();
            // Access the setMeteredKey property and pass public and private keys as parameters
            metered.SetMeteredKey(
                "<type public key here>",
                "<type private key here>");

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_GettingStarted();
            //Create an instance of PostScript document from PS file
            PsDocument document = new PsDocument(dataDir + "input.eps");
            //Save EPS file as image bytes. One bytes array for one page. In our case we have one page.
            byte[][] imagesBytes = document.SaveAsImage(new ImageSaveOptions());
            //Save image bytes to file
            using (FileStream fos = File.OpenWrite(dataDir + "eps_out.png"))
            {
                fos.Write(imagesBytes[0], 0, imagesBytes[0].Length);
            }
            
            //Now we can check visually if Metered License is applied.
            //If resulting image doesn't contain red evaluation message It means Metered License is applied successfully.
            // ExEnd:1
        }
    }
}