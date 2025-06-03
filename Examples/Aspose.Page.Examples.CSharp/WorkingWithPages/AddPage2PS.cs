using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System.IO;

namespace CSharp.WorkingWithPages
{
    public class AddPage2PS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithPages();
            
            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "document2_out.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                //Set variable that indicates if resulting PostScript document will be multipaged
                bool multiPaged = true;

                // Create new multipaged PS Document with one page opened
                PsDocument document = new PsDocument(outPsStream, options, multiPaged);

                //Add content

                //Close the first page
                document.ClosePage();

                //Add the second page with different size
                document.OpenPage(500, 300);

                //Add content

                //Close the second page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
