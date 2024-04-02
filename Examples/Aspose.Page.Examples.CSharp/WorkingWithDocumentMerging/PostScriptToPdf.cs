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
            
            // Initialize PS document with the first PostScript file
            PsDocument document = new PsDocument(dataDir + "input.ps");

            // Create an array of PostScript files that will be merged with the first one
            string[] filesForMerge = new string[] { dataDir + "input2.ps", dataDir + "input3.ps" };

            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;

            //Initialize options object with necessary parameters.
            PdfSaveOptions options = new PdfSaveOptions(suppressErrors);
            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            options.AdditionalFontsFolders = new string[] { @"{FONT_FOLDER}" };

            // Default page size is 595x842 and it is not mandatory to set it in SaveOptions
            // But if you need to specify the page size following line
            //PdfSaveOptions options = new PdfSaveOptions(suppressErrors, new Aspose.Page.Drawing.Size(595, 842));

            document.MergeToPdf(dataDir + "outputPDF_out.pdf", filesForMerge, options);

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
