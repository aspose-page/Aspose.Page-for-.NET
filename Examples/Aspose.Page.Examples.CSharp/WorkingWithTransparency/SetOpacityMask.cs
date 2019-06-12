using Aspose.Page.Xps;
using Aspose.Page.Xps.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithTransparency
{
    public class SetOpacityMask
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithTransparency();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            //Add Canvas to XpsDocument instance
            XpsCanvas canvas = doc.AddCanvas();
            // Rectangle with opacity masked by ImageBrush
            XpsPath path = canvas.AddPath(doc.CreatePathGeometry("M 10,180 L 228,180 228,285 10,285"));
            path.Fill = doc.CreateSolidColorBrush(doc.CreateColor(1.0f, 0.0f, 0.0f));
            path.OpacityMask = doc.CreateImageBrush(dataDir + "R08SY_NN.tif", new RectangleF(0f, 0f, 128f, 192f),
                new RectangleF(0f, 0f, 64f, 96f));
            ((XpsImageBrush)path.OpacityMask).TileMode = XpsTileMode.Tile;
            // Save resultant XPS document
            doc.Save(dataDir + "OpacityMask_out.xps");
            // ExEnd:1
        }
    }
}