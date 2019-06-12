
using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System;
using System.IO;

namespace CSharp.WorkingWithDocumentConversion
{
    class PostScriptToImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentConversion();
            // Initialize PDF output stream
            System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Png;
            // Initialize PostScript input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "inputForImage.ps", System.IO.FileMode.Open, System.IO.FileAccess.Read);

            PsDocument document = new PsDocument(psStream);

            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;

            //Initialize options object with necessary parameters.
            ImageSaveOptions options = new ImageSaveOptions(suppressErrors);
            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            options.AdditionalFontsFolders = new string[] { @"{FONT_FOLDER}" };

            // Default image format is PNG and it is not mandatory to set it in ImageDevice
            // Default image size is 595x842 and it is not mandatory to set it in ImageDevice
            Aspose.Page.EPS.Device.ImageDevice device = new Aspose.Page.EPS.Device.ImageDevice();
            // But if you need to specify size and image format use constructor with parameters
            //ImageDevice device = new ImageDevice(new System.Drawing.Size(595, 842), System.Drawing.Imaging.ImageFormat.Jpeg);

            try
            {
                document.Save(device, options);
            }
            finally
            {
                psStream.Close();
            }

            byte[][] imagesBytes = device.ImagesBytes;

            int i = 0;

            foreach (byte[] imageBytes in imagesBytes)
            {
                string imagePath = Path.GetFullPath("out_image" + i.ToString() +"." + imageFormat.ToString().ToLower());
                using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(imageBytes, 0, imageBytes.Length);
                }
                i++;
            }

            //Review errors
            if (suppressErrors)
            {
                foreach (PsConverterException ex in options.Exceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // ExEnd:1
        }
    }
}
