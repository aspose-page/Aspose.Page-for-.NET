using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Collections.Generic;
using System.Drawing;


namespace CSharp.WorkingWithGradient
{
    public class AddDiagonalGradientXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithGradient();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            // Initialize List of XpsGradentStop
            List<XpsGradientStop> stops = new List<XpsGradientStop>();
            // Add Colors to Gradient
            stops.Add(doc.CreateGradientStop(doc.CreateColor(0, 142, 4), 0f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 202, 0), 0.144531f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 250, 0), 0.264648f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 0, 0), 0.414063f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(233, 0, 255), 0.544922f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(107, 27, 190), 0.694336f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(63, 0, 255), 0.844727f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(0, 199, 80), 1f));
            // Create new path by defining geometery in abbreviation form
            XpsPath path = doc.AddPath(doc.CreatePathGeometry("M 10,10 L 228,10 228,100 10,100"));
            path.RenderTransform = doc.CreateMatrix(1f, 0f, 0f, 1f, 20f, 70f);
            path.Fill = doc.CreateLinearGradientBrush(new PointF(10f, 10f), new PointF(228f, 100f));
            ((XpsGradientBrush)path.Fill).GradientStops.AddRange(stops);
            // Save resultant XPS document
            doc.Save(dataDir + "AddDiagonalGradient_outXPS.xps");
            // ExEnd:1
        }
    }
}
