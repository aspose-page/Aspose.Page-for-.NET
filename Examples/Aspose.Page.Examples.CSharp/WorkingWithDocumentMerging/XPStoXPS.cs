using Aspose.Page.XPS;

namespace CSharp.WorkingWithDocumentMerging
{
    public class XPStoXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithDocumentMerging();
            
            // Load XPS document from XPS file
            XpsDocument document = new XpsDocument(dataDir + "input.xps", new XpsLoadOptions());

            // Create an array of XPS files that will be merged with the first one
            string[] filesToMerge = new string[] { dataDir + "Demo.xps", dataDir + "sample.xps" };

            // Merge XPS files to output XPS document
            document.Merge(filesToMerge, dataDir + "mergedXPSfiles.xps");
            
            // ExEnd:1
        }
    }
}
