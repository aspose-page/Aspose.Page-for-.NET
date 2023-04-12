using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithCanvas
{
    public class ClippingXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCanvas();
            
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();

            // Create main canvas, common for all page elemnts
            XpsCanvas canvas1 = doc.AddCanvas();

            // Make left and top offsets in the main canvas
            canvas1.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 20, 10);

            // Create rectangle path geometry
            XpsPathGeometry rectGeom = doc.CreatePathGeometry("M 0,0 L 500,0 500,300 0,300 Z");

            // Create a fill for rectangles
            XpsBrush fill = doc.CreateSolidColorBrush(doc.CreateColor(12, 15, 159));
            
            // Add another canvas with clip to the main canvas
            XpsCanvas canvas2 = canvas1.AddCanvas();

            // Create circle geometry for clip
            XpsPathGeometry clipGeom = doc.CreatePathGeometry("M250,250 A100,100 0 1 1 250,50 100,100 0 1 1 250,250");
            canvas2.Clip = clipGeom;

            // Create rectangle in this canvas and fill it
            XpsPath rect = canvas2.AddPath(rectGeom);
            rect.Fill = fill;

            // Add the second canvas with stroked rectangle to the main canvas
            XpsCanvas canvas3 = canvas1.AddCanvas();

            // Create rectangle in this canvas and stroke it
            rect = canvas3.AddPath(rectGeom);
            rect.Stroke = fill;
            rect.StrokeThickness = 2;

            // Save resultant XPS document
            doc.Save(dataDir + "output2.xps");
            // ExEnd:1
        }
    }
}
