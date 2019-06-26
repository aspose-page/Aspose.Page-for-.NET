using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.GettingStarted
{
    public class SecureLicense
    {
        public static void Run()
        {
            // ExStart:1
            using (Stream zip = new SecureLicense().GetType().Assembly.GetManifestResourceStream("Aspose.Total.NET.lic.zip"))
            {
                using (ZipFile zf = ZipFile.Read(zip))
                {
                    MemoryStream ms = new MemoryStream();
                    ZipEntry e = zf["Aspose.Total.NET.lic"];
                    e.ExtractWithPassword(ms, "test");
                    ms.Position = 0;
                }
            }
            // ExEnd:1
        }
    }
}
