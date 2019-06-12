using Aspose.Page.Xps;
using Aspose.Page.Xps.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithText
{
    public class AddTextUsingUnicodeString
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithText();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            // Add Text
            XpsSolidColorBrush textFill = doc.CreateSolidColorBrush(Color.Black);
            XpsGlyphs glyphs = doc.AddGlyphs("Arial", 20, FontStyle.Regular, 400f, 200f, "TEN. rof SPX.esopsA");
            glyphs.BidiLevel = 1;
            glyphs.Fill = textFill;
            // Save resultant XPS document
            doc.Save(dataDir + "AddText_out.xps");
            // ExEnd:1
        }
    }
}
