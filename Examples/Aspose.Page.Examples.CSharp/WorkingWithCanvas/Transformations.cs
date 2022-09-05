using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithCanvas
{
    public class Transformations
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCanvas();
            
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();

            XpsCanvas canvas1 = doc.CreateCanvas();
            canvas1.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 20, 10);

            XpsPathGeometry rectGeom = doc.CreatePathGeometry("M 0,0 L 200,0 200,100 0,100 Z");
            XpsBrush fill = doc.CreateSolidColorBrush(doc.CreateColor(12, 15, 159));
            
            XpsCanvas canvas2 = canvas1.AddCanvas();
            XpsPath rect = canvas2.AddPath(rectGeom);
            rect.Fill = fill;

            /*XpsCanvas canvas3 = canvas1.AddCanvas();
            canvas3.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 0);
            canvas3.RenderTransform.Translate(500, 0);
            rect = canvas3.AddPath(rectGeom);
            rect.Fill = fill;

            XpsCanvas canvas4 = canvas1.AddCanvas();
            canvas4.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 200);
            canvas4.RenderTransform.Scale(2, 2);
            rect = canvas4.AddPath(rectGeom);
            rect.Fill = fill;

            XpsCanvas canvas5 = canvas1.AddCanvas();
            canvas5.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 400);
            canvas5.RenderTransform.Rotate(45);
            rect = canvas5.AddPath(rectGeom);
            rect.Fill = fill;*/
            
            // Save resultant XPS document
            doc.Save(dataDir + "output1.xps");
            // ExEnd:1
        }
    }
}
