using Aspose.Page.XPS;
using Aspose.Page.XPS.Presentation.Image;
#if ASPOSE_DRAWING
using SmoothingMode = Aspose.Page.Drawing.Drawing2D.SmoothingMode;
#else
using SmoothingMode = System.Drawing.Drawing2D.SmoothingMode;
#endif
using System.IO;

namespace CSharp.WorkingWithDocumentConversion
{
    public class XPStoBMP
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentConversion();
            
            //Outut file 
            string outputFileName = dataDir + "XPStoImage_out.bmp";
            
            // Load XPS document form the XPS file
            XpsDocument document = new XpsDocument(dataDir + "input.xps", new XpsLoadOptions());
            
            // Initialize options object with necessary parameters.
            BmpSaveOptions options = new BmpSaveOptions()
            {
                SmoothingMode = SmoothingMode.HighQuality,
                Resolution = 300,
                PageNumbers = new int[] { 1, 2, 6 }
            };

            // Save XPS document to the images byte arrays. The first dimension is for inner documents
            // and the second one is for pages within inner documents.
            byte[][][] imagesBytes = document.SaveAsImage(options);

            // Iterate through document partitions (fixed documents, in XPS terms)
            for (int i = 0; i < imagesBytes.Length; i++)
            {
                // Iterate through partition pages
                for (int j = 0; j < imagesBytes[i].Length; j++)
                {
                    // Initialize image output stream
                    using (Stream imageStream = System.IO.File.Open(Path.GetDirectoryName(outputFileName) + Path.DirectorySeparatorChar +
                        Path.GetFileNameWithoutExtension(outputFileName) + "_" + (i + 1) + "_" + (j + 1) +
                        Path.GetExtension(outputFileName), System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        // Write image
                        imageStream.Write(imagesBytes[i][j], 0, imagesBytes[i][j].Length);
                }
            }
            // ExEnd:1
        }
    }
}
