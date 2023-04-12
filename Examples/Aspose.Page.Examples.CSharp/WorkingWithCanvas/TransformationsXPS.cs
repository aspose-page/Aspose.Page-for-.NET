using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithCanvas
{
    public class TransformationsXPS
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
            XpsPathGeometry rectGeom = doc.CreatePathGeometry("M 0,0 L 200,0 200,100 0,100 Z");

            // Create a fill for rectangles
            XpsBrush fill = doc.CreateSolidColorBrush(doc.CreateColor(12, 15, 159));
            
            // Add new canvas without any transformations to the main canvas
            XpsCanvas canvas2 = canvas1.AddCanvas();
            // Create rectangle in this canvas and fill it
            XpsPath rect = canvas2.AddPath(rectGeom);
            rect.Fill = fill;

            // Add new canvas with translate transformation to the main canvas
            XpsCanvas canvas3 = canvas1.AddCanvas();
            // Translate this canvas to position new rectangle below previous rectnagle
            canvas3.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 200);
            // Translate this canvas to right side of page
            canvas3.RenderTransform.Translate(500, 0);
            // Create rectangle in this canvas and fill it
            rect = canvas3.AddPath(rectGeom);
            rect.Fill = fill;

            // Add new canvas with double scale transformation to the main canvas
            XpsCanvas canvas4 = canvas1.AddCanvas();
            // Translate this canvas to position new rectangle below previous rectnagle
            canvas4.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 400);
            // Scale this canvas
            canvas4.RenderTransform.Scale(2, 2);
            // Create rectangle in this canvas and fill it
            rect = canvas4.AddPath(rectGeom);
            rect.Fill = fill;

            // Add new canvas with rotation around a point transformation to the main canvas
            XpsCanvas canvas5 = canvas1.AddCanvas();
            // Translate this canvas to position new rectangle below previous rectnagle
            canvas5.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 800);
            // Rotate this canvas aroud a point on 45 degrees
            canvas5.RenderTransform.RotateAround(45, new PointF(100, 50));
            rect = canvas5.AddPath(rectGeom);
            rect.Fill = fill;
            
            // Save resultant XPS document
            doc.Save(dataDir + "output1.xps");
            // ExEnd:1
        }
    }
}
