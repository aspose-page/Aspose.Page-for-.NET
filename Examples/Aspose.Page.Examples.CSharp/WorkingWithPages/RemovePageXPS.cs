using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithPages
{
    public class RemovePageXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithPages();

            // Create new XPS Document
            XpsDocument doc = new XpsDocument(dataDir + "Sample2.xps");

            // Remove the first page (at index 1).
            doc.RemovePageAt(1);
            
            // Save resultant XPS document
            doc.Save(dataDir + "Sample2_out.xps");
            // ExEnd:1
        }
    }
}
