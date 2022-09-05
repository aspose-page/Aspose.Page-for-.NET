using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithCrossPackageOperations
{
    public class AddGlyphCloneAndChangeColor
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCrossPackageOperations();

            // Create the first XPS Document
            XpsDocument doc1 = new XpsDocument();

            // Add glyphs to the first document
            XpsGlyphs glyphs = doc1.AddGlyphs("Times New Roman", 200, FontStyle.Bold, 50, 250, "Test");

            // Fill glyphs in the first document with one color
            glyphs.Fill = doc1.CreateSolidColorBrush(Color.Green);

            // Create the second XPS Document
            XpsDocument doc2 = new XpsDocument();

            // Add glyphs cloned from the one's from the first document
            glyphs = doc2.Add(glyphs.Clone());

            // Fill glyphs in the second document with another color
            ((XpsSolidColorBrush)glyphs.Fill).Color = doc2.CreateColor(Color.Red);

            // Save the first XPS document
            doc1.Save(dataDir + "out1.xps");

            // Save the second XPS document
            doc2.Save(dataDir + "out2.xps");
            // ExEnd:1
        }
    }
}
