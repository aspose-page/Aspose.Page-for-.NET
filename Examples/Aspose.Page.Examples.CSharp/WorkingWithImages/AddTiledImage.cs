using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithImages
{
    public class AddTiledImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithImages();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            // Tile image
            // ImageBrush filled rectangle in the right top bellow
            XpsPath path = doc.AddPath(doc.CreatePathGeometry("M 10,160 L 228,160 228,305 10,305"));
            path.Fill = doc.CreateImageBrush(dataDir + "R08LN_NN.jpg", new RectangleF(0f, 0f, 128f, 96f), new RectangleF(0f, 0f, 64f, 48f));
            ((XpsImageBrush)path.Fill).TileMode = XpsTileMode.Tile;
            path.Fill.Opacity = 0.5f;
            // Save resultant XPS document
            doc.Save(dataDir + "AddTiledImage_out.xps");
            // ExEnd:1
        }
    }
}
