using Aspose.Page.EPS;
using Aspose.Page.EPS.XMP;

namespace CSharp.WorkingWithXMPMetadataInEPS
{
    public class ChangeMetadata_AddNamespace
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithXMPMetadataInEPS();
            // Initialize EPS file input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "add_simple_props_input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // Create PsDocument instance from stream
            PsDocument document = new PsDocument(psStream);            

            try
            {
                // Get XMP metadata. If EPS file doesn't contain XMP metadata we get new one filled with values from PS metadata comments (%%Creator, %%CreateDate, %%Title etc)
                XmpMetadata xmp = document.GetXmpMetadata();

                //Change XMP metadata values

                // Add new XML namespace "tmp".
                xmp.RegisterNamespaceUri("tmp", "http://www.some.org/schema/tmp#");

                // Add new string property in new namespace.
                xmp.Add("tmp:newKey", new XmpValue("NewValue"));

                // Save EPS file with changed XMP metadata

                // Create ouput stream
                using (System.IO.FileStream outPsStream = new System.IO.FileStream(dataDir + "add_namespace_output.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    // Save EPS file
                    document.Save(outPsStream);
                }

            }
            finally
            {
                psStream.Close();
            }

            // ExEnd:1
        }
    }
}
