using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using Aspose.Page.EPS.XMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithXMPMetadataInEPS
{
    public class AddMetadata
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithXMPMetadataInEPS();
            // Initialize EPS file input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "add_input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // Create PsDocument instance from stream
            PsDocument document = new PsDocument(psStream);            

            try
            {
                // Get XMP metadata. If EPS file doesn't contain XMP metadata we get new one filled with values from PS metadata comments (%%Creator, %%CreateDate, %%Title etc)
                XmpMetadata xmp = document.GetXmpMetadata();

                // Check metadata values extracted from PS metadata comments and set up in new XMP metadata

                // Get "CreatorTool" value
                if (xmp.Contains("xmp:CreatorTool"))
                    Console.WriteLine("CreatorTool: " + xmp["xmp:CreatorTool"].ToStringValue());

                // Get "CreateDate" value
                if (xmp.Contains("xmp:CreateDate"))
                    Console.WriteLine("CreateDate: " + xmp["xmp:CreateDate"].ToStringValue());

                // Get "format" value
                if (xmp.Contains("dc:format"))
                    Console.WriteLine("Format: " + xmp["dc:format"].ToStringValue());

                // Get "title" value
                if (xmp.Contains("dc:title"))
                    Console.WriteLine("Title: " + xmp["dc:title"].ToArray()[0].ToStringValue());

                // Get "creator" value
                if (xmp.Contains("dc:creator"))
                    Console.WriteLine("Creator: " + xmp["dc:creator"].ToArray()[0].ToStringValue());

                // Get "MetadataDate" value
                if (xmp.Contains("xmp:MetadataDate"))
                    Console.WriteLine("MetadataDate: " + xmp["xmp:MetadataDate"].ToStringValue());

                // Save EPS file with new XMP metadata
                
                // Create ouput stream
                System.IO.FileStream outPsStream = new System.IO.FileStream(dataDir + "add_output.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write);

                // Save EPS file
                try
                {
                    document.Save(outPsStream);
                    outPsStream.Flush();
                }
                finally
                {
                    outPsStream.Close();
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
