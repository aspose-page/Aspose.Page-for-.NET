using Aspose.Page;
using Aspose.Page.Xps;
using Aspose.Page.Xps.Presentation.Image;
using System.Drawing;
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
            // Input file
            string inputFileName = dataDir + "input.xps";
            //Outut file 
            string outputFileName = dataDir + "XPStoImage_out.bmp";
            // Initialize XPS input stream
            using (Stream xpsStream = File.Open(inputFileName, FileMode.Open, FileAccess.Read))
            {
                // Load XPS document form the stream
                XpsDocument document = new XpsDocument(xpsStream, new XpsLoadOptions());
                // or load XPS document directly from file. No xpsStream is needed then.
                // XpsDocument document = new XpsDocument(inputFileName, new XpsLoadOptions());

                // Initialize options object with necessary parameters.
                BmpSaveOptions options = new BmpSaveOptions()
                {
                    SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality,
                    Resolution = 300,
                    PageNumbers = new int[] { 1, 2, 6 }
                };

                // Create rendering device for PDF format
                ImageDevice device = new ImageDevice();

                document.Save(device, options);

                // Iterate through document partitions (fixed documents, in XPS terms)
                for (int i = 0; i < device.Result.Length; i++)
                    // Iterate through partition pages
                    for (int j = 0; j < device.Result[i].Length; j++)
                    {
                        // Initialize image output stream
                        using (Stream imageStream = System.IO.File.Open(Path.GetDirectoryName(outputFileName) +
                            Path.GetFileNameWithoutExtension(outputFileName) + "_" + (i + 1) + "_" + (j + 1) +
                            Path.GetExtension(outputFileName), System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            // Write image
                            imageStream.Write(device.Result[i][j], 0, device.Result[i][j].Length);
                    }
            }
            // ExEnd:1
        }
    }
}
