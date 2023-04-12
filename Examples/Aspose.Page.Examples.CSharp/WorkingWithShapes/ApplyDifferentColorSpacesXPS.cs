using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithShapes
{
    public class ApplyDifferentColorSpacesXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithShapes();
            
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();

            // ARGB solid color filled rectangle
            XpsPath rect1 = doc.AddPath(doc.CreatePathGeometry("M 20,10 L 220,10 220,100 20,100 Z"));
            rect1.Fill = doc.CreateSolidColorBrush(doc.CreateColor(Color.FromArgb(222, 12, 15, 159)));

            // ARGB solid color filled rectangle, another way
            XpsPath rect2 = doc.AddPath(doc.CreatePathGeometry("M 20,210 L 220,210 220,300 20,300 Z"));
            rect2.Fill = doc.CreateSolidColorBrush(doc.CreateColor(222, 12, 15, 159));

            // sRGB solid color filled rectangle
            XpsPath rect3 = doc.AddPath(doc.CreatePathGeometry("M 20,410 L 220,410 220,500 20,500 Z"));
            rect3.Fill = doc.CreateSolidColorBrush(doc.CreateColor(12, 15, 159));

            // scRGB solid color filled rectangle
            XpsPath rect4 = doc.AddPath(doc.CreatePathGeometry("M 20,610 L 220,610 220,700 20,700 Z"));
            rect4.Fill = doc.CreateSolidColorBrush(doc.CreateColor(0.08706f, 0.04706f, 0.05882f, 0.62353f));

            // CMYK (blue) solid color filled rectangle
            XpsPath rect5 = doc.AddPath(doc.CreatePathGeometry("M 20,810 L 220,810 220,900 20,900 Z"));
            rect5.Fill = doc.CreateSolidColorBrush(
                doc.CreateColor(dataDir + "uswebuncoated.icc", 1.0f, 1.000f, 0.000f, 0.000f, 0.000f));
            
            // Save resultant XPS document
            doc.Save(dataDir + "ApplyDifferentColorSpaces_outXPS.xps");
            // ExEnd:1
        }
    }
}
