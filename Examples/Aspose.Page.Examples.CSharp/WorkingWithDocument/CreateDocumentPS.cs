using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System.IO;

namespace CSharp.WorkingWithDocument
{
    public class CreateDocumentPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithDocument();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dir + "document_out.ps", FileMode.Create))
            {
                //Create save options
                PsSaveOptions options = new PsSaveOptions();
                //If you want to aassign page size other than A4, set page size in options
                options.PageSize = PageConstants.GetSize(PageConstants.SIZE_A4, PageConstants.ORIENTATION_PORTRAIT);
                //If you want to aassign page margins other empty, set page margins in options
                options.Margins = PageConstants.GetMargins(PageConstants.MARGINS_ZERO);
                //If you plan to use fonts that located in non system folders, set additional fonts folders in options
                options.AdditionalFontsFolders = new string[] { dir };

                //Set variable that indicates if resulting PostScript document will be multipaged
                bool multiPaged = false;

                // Create new multipaged PS Document with one page opened
                PsDocument document = new PsDocument(outPsStream, options, multiPaged);

                //Close current page
                document.ClosePage();
                //Save the document
                document.Save();
            }            
            // ExEnd:1
        }
    }
}
