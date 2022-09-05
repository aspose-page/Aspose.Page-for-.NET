using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithCrossPackageOperations
{
    public class ManipulatePages
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCrossPackageOperations();

            // Create the first XPS Document
            XpsDocument doc1 = new XpsDocument(dataDir + "input1.xps");

            // Create the second XPS Document
            XpsDocument doc2 = new XpsDocument(dataDir + "input2.xps");

            // Create the third XPS Document
            XpsDocument doc3 = new XpsDocument(dataDir + "input3.xps");

            // Create the fourth XPS Document
            XpsDocument doc4 = new XpsDocument();

            // Insert active page (1 in this case) from the second document to the beginning of the fourth document
            doc4.InsertPage(1, doc2.Page, false);

            // Insert active page (1 in this case) from the third document to the end of the fourth document
            doc4.AddPage(doc3.Page, false);

            // Remove page 2 from the fourth document. This is an empty page that was created when document has been created.
            doc4.RemovePageAt(2);

            // Insert page 3 from the first document to the second postion of the fourth document
            doc4.InsertPage(2, doc1.SelectActivePage(3), false);

            // Save the fourth XPS document
            doc4.Save(dataDir + "out.xps");
            // ExEnd:1
        }
    }
}
