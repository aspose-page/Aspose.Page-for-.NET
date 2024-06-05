using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithShapes
{
    public class UseShapeUtilitiesXPS
    {
        public static void Run()
        {
            // ExStart:UsingShapeUtils
            // For complete examples and data files, please go to https://github.com/aspose-page/Aspose.Page-for-.NET
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithShapes();
            // Create new XPS Document
            using (XpsDocument doc = new XpsDocument())
            {
                // Set first page's size.
                doc.Page.Width = 650f;
                doc.Page.Height = 240f;

                // Draw a circle with center (120, 120) and radius 100.
                XpsPath path = doc.CreatePath(doc.Utils.CreateCircle(new PointF(120f, 120f), 100f));
                path.Fill = doc.CreateSolidColorBrush(Color.Green);
                doc.Add(path);

                // Inscribe a regular pentagon in the circle.
                path = doc.CreatePath(doc.Utils.CreateRegularInscribedNGon(5, new PointF(120f, 120f), 100f));
                path.Fill = doc.CreateSolidColorBrush(Color.Red);
                doc.Add(path);

                // Circumscribe a regular hexagon around the circle.
                path = doc.CreatePath(doc.Utils.CreateRegularCircumscribedNGon(6, new PointF(120f, 120f), 100f));
                path.Stroke = doc.CreateSolidColorBrush(Color.Magenta);
                path.StrokeThickness = 3f;
                doc.Add(path);

                // Draw a sector of the circle centered at (340, 120), starting at -45 degrees and ending at +45 degrees.
                path = doc.CreatePath(doc.Utils.CreatePieSlice(new PointF(340f, 120f), 100f, -45f, 45f));
                path.Stroke = doc.CreateSolidColorBrush(Color.Red);
                path.StrokeThickness = 5f;
                doc.Add(path);

                // Draw a segment of the circle centered at (340, 120), starting at -45 degrees and ending at +45 degrees.
                path = doc.CreatePath(doc.Utils.CreateCircularSegment(new PointF(340f, 120f), 100f, -45f, 45f));
                path.Fill = doc.CreateSolidColorBrush(Color.Black);
                doc.Add(path);

                // Draw a rectangle with the top left vertex (530, 20), width 100 units and height 200 units.
                path = doc.CreatePath(doc.Utils.CreateRectangle(new RectangleF(530f, 20f, 100f, 200f)));
                path.Stroke = doc.CreateSolidColorBrush(Color.Red);
                doc.Add(path);

                // Draw an ellipse with center (580, 120) and radii 50 and 100.
                path = doc.CreatePath(doc.Utils.CreateEllipse(new PointF(580f, 120f), 50f, 100f));
                path.Fill = doc.CreateSolidColorBrush(Color.Yellow);
                doc.Add(path);

                doc.Save(dataDir + "UseShapeUtilsXPS_out.xps");
            }
            // ExEnd:UsingShapeUtils
        }
    }
}
