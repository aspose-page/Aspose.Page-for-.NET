using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;
#if ASPOSE_DRAWING
using FontStyle = Aspose.Page.Drawing.FontStyle;
#else
using FontStyle = System.Drawing.FontStyle;
#endif

namespace CSharp.WorkingWithCrossPackageOperations
{
    public class AddImageFilledGlyphAndForeignImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCrossPackageOperations();

            // Create the first XPS Document
            XpsDocument doc1 = new XpsDocument();

            // Add glyphs to the first document
            XpsGlyphs glyphs1 = doc1.AddGlyphs("Times New Roman", 200, FontStyle.Bold, 50, 250, "Test");

            // Fill the glyphs with an image brush
            glyphs1.Fill = doc1.CreateImageBrush(dataDir + "R08SY_NN.tif", new RectangleF(0f, 0f, 128f, 192f),
                new RectangleF(0f, 0f, 64f, 96f));
            ((XpsImageBrush)glyphs1.Fill).TileMode = XpsTileMode.Tile;

            // Create the second XPS Document
            XpsDocument doc2 = new XpsDocument();

            // Add glyphs with the font from the first document to the second document
            XpsGlyphs glyphs2 = doc2.AddGlyphs(glyphs1.Font, 200, 50, 250, "Test");

            // Create an image brush from the fill of the the first document and fill glyphs in the second document
            glyphs2.Fill = doc2.CreateImageBrush(((XpsImageBrush)glyphs1.Fill).Image, new RectangleF(0f, 0f, 128f, 192f),
                new RectangleF(0f, 0f, 128f, 192f));
            ((XpsImageBrush)glyphs2.Fill).TileMode = XpsTileMode.Tile;

            // Save the first XPS document
            doc1.Save(dataDir + "out1.xps");

            // Save the second XPS document
            doc2.Save(dataDir + "out2.xps");
            // ExEnd:1
        }
    }
}
