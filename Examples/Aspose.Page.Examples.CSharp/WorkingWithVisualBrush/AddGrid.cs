using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithVisualBrush
{
    public class AddGrid
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithVisualBrush();

            XpsDocument doc = new XpsDocument();
            // Geometry for magenta grid VisualBrush
            XpsPathGeometry pathGeometry = doc.CreatePathGeometry();
            pathGeometry.AddSegment(doc.CreatePolyLineSegment(
                new PointF[] { new PointF(240f, 5f), new PointF(240f, 310f), new PointF(0f, 310f) }));
            pathGeometry[0].StartPoint = new PointF(0f, 5f);

            // Canvas for magenta grid VisualBrush
            XpsCanvas visualCanvas = doc.CreateCanvas();

            XpsPath visualPath = visualCanvas.AddPath(
                doc.CreatePathGeometry("M 0,4 L 4,4 4,0 6,0 6,4 10,4 10,6 6,6 6,10 4,10 4,6 0,6 Z"));
            visualPath.Fill = doc.CreateSolidColorBrush(doc.CreateColor(1f, .61f, 0.1f, 0.61f));

            XpsPath gridPath = doc.CreatePath(pathGeometry);
            //Create Visual Brush, it is specified by some XPS fragment (vector graphics and glyphs)
            gridPath.Fill = doc.CreateVisualBrush(visualCanvas,
                new RectangleF(0f, 0f, 10f, 10f), new RectangleF(0f, 0f, 10f, 10f));
            ((XpsVisualBrush)gridPath.Fill).TileMode = XpsTileMode.Tile;
            // New canvas
            XpsCanvas canvas = doc.AddCanvas();
            canvas.RenderTransform = doc.CreateMatrix(1f, 0f, 0f, 1f, 268f, 70f);
            // Add grid
            canvas.AddPath(gridPath); 
            // Red transparent rectangle in the middle top
            XpsPath path = canvas.AddPath(doc.CreatePathGeometry("M 30,20 l 258.24,0 0,56.64 -258.24,0 Z"));
            path = canvas.AddPath(doc.CreatePathGeometry("M 10,10 L 228,10 228,100 10,100"));
            path.Fill = doc.CreateSolidColorBrush(doc.CreateColor(1.0f, 0.0f, 0.0f));
            path.Opacity = 0.7f;
            // Save resultant XPS document
            doc.Save(dataDir + "AddGrid_out.xps");
            // ExEnd:1
        }
    }
}