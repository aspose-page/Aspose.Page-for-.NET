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
            
            // Load XPS document form the XPS file
            XpsDocument document = new XpsDocument(dataDir + "input.xps", new XpsLoadOptions());

            // Initialize options object with necessary parameters.
            Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions options = new Aspose.Page.XPS.Presentation.Pdf.PdfSaveOptions()
            {
                JpegQualityLevel = 100,
                ImageCompression = Aspose.Page.XPS.Presentation.Pdf.PdfImageCompression.Jpeg,
                TextCompression = Aspose.Page.XPS.Presentation.Pdf.PdfTextCompression.Flate
            };

            // Create an array of XPS files that will be merged with the first one
            string[] filesToMerge = new string[] { dataDir + "Demo.xps", dataDir + "sample.xps" };

            // Merge XPS files to output PDF file
            document.MergeToPdf(dataDir + "mergedXPSfiles.pdf", filesToMerge, options);
            
            // ExEnd:1
        }
    }
}
