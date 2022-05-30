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
            // Initialize XPS output stream
            using (System.IO.Stream outStream = System.IO.File.Open(dataDir + "mergedXPSfiles.xps", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            // Initialize XPS input stream
            using (System.IO.Stream inStream = System.IO.File.Open(dataDir + "input.xps", System.IO.FileMode.Open))
            {
                // Load XPS document from the stream
                XpsDocument document = new XpsDocument(inStream, new XpsLoadOptions());
                // or load XPS document directly from file. No xpsStream is needed then.
                // XpsDocument document = new XpsDocument(inputFileName, new XpsLoadOptions());

                // Create an array of XPS files that will be merged with the first one
                string[] filesToMerge = new string[] { dataDir + "Demo.xps", dataDir + "sample.xps" };

                // Merge XPS files to output PDF document
                document.Merge(filesToMerge, outStream);
            }
            // ExEnd:1
        }
    }
}
