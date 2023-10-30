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
            //Create file stream for EPS file
            System.IO.Stream psStream = new System.IO.FileStream(dataDir + "input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //Create an instance of PostScript document from stream
            PsDocument document = new PsDocument(psStream);
            //Create Image device for converting EPS file to PNG image
            ImageDevice device = new ImageDevice();
            //Save EPS file as image
            document.Save(device, new ImageSaveOptions());
            //Get images bytes. One bytes array for one page. In our case we have one page.
            byte[][] imagesBytes = device.ImagesBytes;
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