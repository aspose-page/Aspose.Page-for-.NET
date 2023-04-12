using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Collections.Generic;
using System.Drawing;


namespace CSharp.WorkingWithShapes
{
    public class AddEllipseXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithShapes();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            // Radial gradient stroked ellipse in the lower left
            List<XpsGradientStop> stops = new List<XpsGradientStop>();
            stops.Add(doc.CreateGradientStop(doc.CreateColor(0, 0, 255), 0f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 0, 0), .25f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(0, 255, 0), .5f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 255, 0), .75f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 0, 0), 1f));

            XpsPath path = doc.AddPath(doc.CreatePathGeometry("M 20,250 A 100,50 0 1 1 220,250 100,50 0 1 1 20,250"));
            path.Stroke = doc.CreateRadialGradientBrush(new PointF(575f, 125f), new PointF(575f, 100f), 75f, 50f);
            ((XpsGradientBrush)path.Stroke).SpreadMethod = XpsSpreadMethod.Reflect;
            ((XpsGradientBrush)path.Stroke).GradientStops.AddRange(stops);
            stops.Clear();
            path.StrokeThickness = 12f;
            // Save resultant XPS document
            doc.Save(dataDir + "AddEllipse_outXPS.xps");
            // ExEnd:1
        }
    }
}
