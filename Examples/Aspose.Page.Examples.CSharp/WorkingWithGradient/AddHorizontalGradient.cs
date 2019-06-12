using Aspose.Page.Xps;
using Aspose.Page.Xps.XpsModel;
using System.Collections.Generic;
using System.Drawing;


namespace CSharp.WorkingWithGradient
{
    public class AddHorizontalGradient
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
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 244, 253, 225), 0.0673828f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 251, 240, 23), 0.314453f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 252, 209, 0), 0.482422f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 241, 254, 161), 0.634766f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 53, 253, 255), 0.915039f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(255, 12, 91, 248), 1f));
            // Create new path by defining geometery in abbreviation form
            XpsPath path = doc.AddPath(doc.CreatePathGeometry("M 10,210 L 228,210 228,300 10,300"));
            path.RenderTransform = doc.CreateMatrix(1f, 0f, 0f, 1f, 20f, 70f);
            path.Fill = doc.CreateLinearGradientBrush(new PointF(10f, 0f), new PointF(228f, 0f));
            ((XpsGradientBrush)path.Fill).GradientStops.AddRange(stops);
            // Save resultant XPS document
            doc.Save(dataDir + "AddHorizontalGradient_out.xps");
            // ExEnd:1
        }
    }
}
