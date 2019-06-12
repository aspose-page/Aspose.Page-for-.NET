using Aspose.Page.Xps;
using Aspose.Page.Xps.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithText
{
    public class AddText
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithText();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            //Create a brush 
            XpsSolidColorBrush textFill = doc.CreateSolidColorBrush(Color.Black);
            //Add glyph to the document
            XpsGlyphs glyphs = doc.AddGlyphs("Arial", 12, FontStyle.Regular, 300f, 450f, "Hello World!");
            glyphs.Fill = textFill;
            // Save resultant XPS document
            doc.Save(dataDir + "AddText_out.xps");
            // ExEnd:1
        }
    }
}
