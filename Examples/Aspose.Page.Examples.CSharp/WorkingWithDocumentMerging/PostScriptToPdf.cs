using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithDocumentMerging
{
    public class PostScriptToPdf
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentMerging();
            // Initialize PDF output stream
            System.IO.FileStream pdfStream = new System.IO.FileStream(dataDir + "outputPDF_out.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            // Initialize the first PostScript file input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "input.ps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            PsDocument document = new PsDocument(psStream);

            // Create an array of PostScript files that will be merged with the first one
            string[] filesForMerge = new string[] { dataDir + "input2.ps", dataDir + "input3.ps" };

            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;

            //Initialize options object with necessary parameters.
            PdfSaveOptions options = new PdfSaveOptions(suppressErrors);
            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            options.AdditionalFontsFolders = new string[] { @"{FONT_FOLDER}" };

            // Default page size is 595x842 and it is not mandatory to set it in PdfDevice
            Aspose.Page.EPS.Device.PdfDevice device = new Aspose.Page.EPS.Device.PdfDevice(pdfStream);
            // But if you need to specify size and image format use following line
            //Aspose.Page.EPS.Device.PdfDevice device = new Aspose.Page.EPS.Device.PdfDevice(pdfStream, new System.Drawing.Size(595, 842));

            try
            {
                document.Merge(filesForMerge, device, options);
            }
            finally
            {
                psStream.Close();
                pdfStream.Close();
            }

            //Review errors
            if (suppressErrors)
            {
                foreach (Exception ex in options.Exceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // ExEnd:1
        }
    }
}
