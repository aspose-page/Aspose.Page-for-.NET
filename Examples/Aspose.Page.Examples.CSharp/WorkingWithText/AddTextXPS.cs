using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;
#if ASPOSE_DRAWING
using FontStyle = Aspose.Page.Drawing.FontStyle;
#else
using FontStyle = System.Drawing.FontStyle;
#endif

namespace CSharp.WorkingWithText
{
    public class AddTextXPS
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
