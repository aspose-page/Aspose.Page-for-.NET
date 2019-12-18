using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithShapes
{
    public class AddRectangle
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithShapes();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            // CMYK (blue) solid color stroked rectangle in the lower left
            XpsPath path = doc.AddPath(doc.CreatePathGeometry("M 20,10 L 220,10 220,100 20,100 Z"));
            path.Stroke = doc.CreateSolidColorBrush(
                doc.CreateColor(dataDir + "uswebuncoated.icc", 1.0f, 1.000f, 0.000f, 0.000f, 0.000f));
            path.StrokeThickness = 12f;
            // Save resultant XPS document
            doc.Save(dataDir + "AddRectangle_out.xps");
            // ExEnd:1
        }
    }
}
