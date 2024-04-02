
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
            
            // Initialize PsDocument with the name of PostScript file.
            PsDocument document = new PsDocument(dataDir + "inputForImage.ps");

            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;

            //Initialize options object with necessary parameters.
            ImageSaveOptions options = new ImageSaveOptions();

            //Set output image format.
            options.ImageFormat = Aspose.Page.Drawing.Imaging.ImageFormat.Png;

            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            options.AdditionalFontsFolders = new string[] { @"{FONT_FOLDER}" };

            // Save PS document as array of image bytes, one bytes array for one page.
            byte[][] imagesBytes = document.SaveAsImage(options);

            //Save images bytes arrays as image files.

            int i = 0;

            foreach (byte[] imageBytes in imagesBytes)
            {
                string imagePath = Path.GetFullPath(dataDir + "out_image" + i.ToString() +"." + options.ImageFormat.ToString().ToLower());
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
