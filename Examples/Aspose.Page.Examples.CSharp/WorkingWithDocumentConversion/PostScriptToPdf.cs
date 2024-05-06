using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithDocumentConversion
{
    public class PostScriptToPdf
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentConversion();
            
            // Initialize PsDocument with the name of PostScript file.
            PsDocument document = new PsDocument(dataDir + "input.ps");

            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;

            //Initialize options object with necessary parameters.
            PdfSaveOptions options = new PdfSaveOptions(suppressErrors);
            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            options.AdditionalFontsFolders = new string[] { @"{FONT_FOLDER}" };
            // Default page size is 595x842 and it is not mandatory to set it in PdfSaveOptions
            // But if you need to specify sizeuse following line
            //PdfSaveOptions options = new PdfSaveOptions(suppressErrorsnew, Aspose.Page.Drawing.Size(595x842));
            // or
            //saveOptions.Size = new Aspose.Page.Drawing.Size(595x842);

            // Save document as PDF
            document.SaveAsPdf(dataDir + "outputPDF_out.pdf", options);

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
