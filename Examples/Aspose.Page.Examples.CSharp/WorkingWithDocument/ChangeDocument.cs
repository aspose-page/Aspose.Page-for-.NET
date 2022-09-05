using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;
using System.IO;

namespace CSharp.WorkingWithDocument
{
    public class ChangeDocument
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithDocument();
            // Open a stream of XPS file
            using (FileStream xpsStream = File.Open(dir + "input1.xps", FileMode.Open, FileAccess.Read))
            {
                // Create PS document from stream
                XpsDocument document = new XpsDocument(xpsStream, new XpsLoadOptions());

                // Create fill of the signature text
                XpsSolidColorBrush textFill = document.CreateSolidColorBrush(Color.BlueViolet);

                // Define pages where signature will be set
                int[] pageNumbers = new int[] {1, 2, 3};

                // For every defined page set signature "Confirmed" at coordinates x=650 and y=950
                for (int i = 0; i < pageNumbers.Length; i++)
                {
                    // Define active page
                    document.SelectActivePage(pageNumbers[i]);

                    // Create glyphs object
                    XpsGlyphs glyphs = document.AddGlyphs("Arial", 24, FontStyle.Bold, 650, 900, "Confirmed");

                    // define fill for glyphs
                    glyphs.Fill = textFill;
                }

                // save changed XPS document
                document.Save(dir + "input1_out.xps");
            }
            // ExEnd:1
        }
    }
}
