using Aspose.Page.Xps;
using Aspose.Page.Xps.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithPages
{
    public class AddPage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithPages();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument(dataDir + "Sample1.xps");

            // Insert an empty page at beginning of pages list
            doc.InsertPage(1, true);
            
            // Save resultant XPS document
            doc.Save(dataDir + "AddPages_out.xps");
            // ExEnd:1
        }
    }
}
