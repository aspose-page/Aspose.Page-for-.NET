using Aspose.Page.XPS;

namespace CSharp.WorkingWithDocumentMerging
{
    public class XPStoPDF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentMerging();
            // Initialize PDF output stream
            using (System.IO.Stream pdfStream = System.IO.File.Open(dataDir + "mergedXPSfiles.pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            // Initialize XPS input stream
            using (System.IO.Stream xpsStream = System.IO.File.Open(dataDir + "input.xps", System.IO.FileMode.Open))
            {
                // Load XPS document form the stream
                XpsDocument document = new XpsDocument(xpsStream, new XpsLoadOptions());
                // or load XPS document directly from file. No xpsStream is needed then.
                // XpsDocument document = new XpsDocument(inputFileName, new XpsLoadOptions());

                // Initialize options object with necessary parameters.
                Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions options = new Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions()
                {
                    JpegQualityLevel = 100,
                    ImageCompression = Aspose.Page.XPS.Presentation.Pdf.PdfImageCompression.Jpeg,
                    TextCompression = Aspose.Page.XPS.Presentation.Pdf.PdfTextCompression.Flate
                };

                // Create rendering device for PDF format
                Aspose.Page.XPS.Presentation.Pdf.PdfDevice device = new Aspose.Page.XPS.Presentation.Pdf.PdfDevice(pdfStream);

                // Create an array of XPS files that will be merged with the first one
                string[] filesToMerge = new string[] { dataDir + "Demo.xps", dataDir + "sample.xps" };

                // Merge XPS files to output PDF document
                document.Merge(filesToMerge, device, options);
            }
            // ExEnd:1
        }
    }
}
