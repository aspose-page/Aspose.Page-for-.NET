using Aspose.Page.XPS;

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
            using (System.IO.Stream pdfStream = System.IO.File.Open(dataDir + "XPStoPDF_out.pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            { 
                // Load XPS document form the XPS file
                XpsDocument document = new XpsDocument(dataDir + "input.xps", new XpsLoadOptions());
                
                // Initialize options object with necessary parameters.
                Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions options = new Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions()
                {
                    JpegQualityLevel = 100,
                    ImageCompression = Aspose.Page.XPS.Presentation.Pdf.PdfImageCompression.Jpeg,
                    TextCompression = Aspose.Page.XPS.Presentation.Pdf.PdfTextCompression.Flate,
                    PageNumbers = new int[] { 1, 2, 6 }
                };

                document.SaveAsPdf(pdfStream, options);
            }
            // ExEnd:1
        }
    }
}
