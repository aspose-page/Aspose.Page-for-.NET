
using Aspose.Page.Xps;
using Aspose.Page.Xps.XpsModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithGradient
{
    public class AddVerticalGradient
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
            stops.Add(doc.CreateGradientStop(doc.CreateColor(253, 255, 12, 0), 0f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(252, 255, 154, 0), 0.359375f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(252, 255, 56, 0), 0.424805f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(253, 255, 229, 0), 0.879883f));
            stops.Add(doc.CreateGradientStop(doc.CreateColor(252, 255, 255, 234), 1f));
            // Create new path by defining geometery in abbreviation form
            XpsPath path = doc.AddPath(doc.CreatePathGeometry("M 10,110 L 228,110 228,200 10,200"));
            path.RenderTransform = doc.CreateMatrix(1f, 0f, 0f, 1f, 20f, 70f);
            path.Fill = doc.CreateLinearGradientBrush(new PointF(10f, 110f), new PointF(10f, 200f));
            ((XpsGradientBrush)path.Fill).GradientStops.AddRange(stops);
            // Save resultant XPS document
            doc.Save(dataDir + "AddVerticalGradient_out.xps");
            // ExEnd:1
        }
    }
}
