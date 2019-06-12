using Aspose.Page.Xps;

namespace CSharp.WorkingWithDocumentConversion
{
    public class XPStoPDF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentConversion();
            // Initialize PDF output stream
            using (System.IO.Stream pdfStream = System.IO.File.Open(dataDir + "input.xps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
            // Initialize XPS input stream
            using (System.IO.Stream xpsStream = System.IO.File.Open(dataDir + "XPStoPDF.pdf", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                // Load XPS document form the stream
                XpsDocument document = new XpsDocument(xpsStream, new XpsLoadOptions());
                // or load XPS document directly from file. No xpsStream is needed then.
                // XpsDocument document = new XpsDocument(inputFileName, new XpsLoadOptions());

                // Initialize options object with necessary parameters.
                Aspose.Page.Xps.Presentation.Pdf.PdfSaveOptions options = new Aspose.Page.Xps.Presentation.Pdf.PdfSaveOptions()
                {
                    JpegQualityLevel = 100,
                    ImageCompression = Aspose.Page.Xps.Presentation.Pdf.PdfImageCompression.Jpeg,
                    TextCompression = Aspose.Page.Xps.Presentation.Pdf.PdfTextCompression.Flate,
                    PageNumbers = new int[] { 1, 2, 6 }
                };

                // Create rendering device for PDF format
                Aspose.Page.Xps.Presentation.Pdf.PdfDevice device = new Aspose.Page.Xps.Presentation.Pdf.PdfDevice(pdfStream);

                document.Save(device, options);
            }
            // ExEnd:1
        }
    }
}
