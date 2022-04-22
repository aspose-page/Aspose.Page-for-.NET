using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using Aspose.Page.EPS.XMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithXMPMetadataInEPS
{
    public class ChangeMetadata_AddSimpleProperties
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


                DateTime now = DateTime.UtcNow;

                // Add Integer poperty
                xmp.Add("xmp:Intg1", new XmpValue(111));

                // Add DateTime poperty
                xmp.Add("xmp:Date1", new XmpValue(now));

                // Add Double poperty
                xmp.Add("xmp:Double1", new XmpValue(111.11D));

                // Add String poperty
                xmp.Add("xmp:String1", new XmpValue("ABC"));

                // Save EPS file with changed XMP metadata

                // Create ouput stream
                System.IO.FileStream outPsStream = new System.IO.FileStream(dataDir + "add_simple_props_output.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write);

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
