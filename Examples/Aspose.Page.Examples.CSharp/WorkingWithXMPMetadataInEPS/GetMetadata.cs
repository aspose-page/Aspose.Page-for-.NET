using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using Aspose.Page.EPS.XMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithXMPMetadataInEPS
{
    public class GetMetadata
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithXMPMetadataInEPS();
            // Initialize EPS file input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "get_input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // Create PsDocument instance from stream
            PsDocument document = new PsDocument(psStream);            

            try
            {
                // Get XMP metadata. If EPS file doesn't contain XMP metadata we get new one filled with values from PS metadata comments (%%Creator, %%CreateDate, %%Title etc)
                XmpMetadata xmp = document.GetXmpMetadata();

                // Get "CreatorTool" value
                if (xmp.Contains("xmp:CreatorTool"))
                    Console.WriteLine("CreatorTool: " + xmp["xmp:CreatorTool"].ToStringValue());
                
                // Get "CreateDate" value
                if (xmp.Contains("xmp:CreateDate"))
                    Console.WriteLine("CreateDate: " + xmp["xmp:CreateDate"].ToStringValue());

                // Get a width of a thumbnail image if exists
                if (xmp.Contains("xmp:Thumbnails") && xmp["xmp:Thumbnails"].IsArray)
                {
                    XmpValue val = xmp["xmp:Thumbnails"].ToArray()[0];
                    if (val.IsNamedValues && val.ToDictionary().ContainsKey("xmpGImg:width"))
                        Console.WriteLine($"Thumbnail Width: {val.ToDictionary()["xmpGImg:width"].ToInteger()}");
                }

                // Get "format" value
                if (xmp.Contains("dc:format"))
                    Console.WriteLine("Format: " + xmp["dc:format"].ToStringValue());

                // Get "DocumentID" value
                if (xmp.Contains("xmpMM:DocumentID"))
                    Console.WriteLine("DocumentID: " + xmp["xmpMM:DocumentID"].ToStringValue());

            }
            finally
            {
                psStream.Close();
            }

            // ExEnd:1
        }
    }
}
