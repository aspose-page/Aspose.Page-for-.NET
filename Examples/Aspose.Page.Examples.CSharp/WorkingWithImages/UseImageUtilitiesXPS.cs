using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;

namespace CSharp.WorkingWithImages
{
    public class UseImageUtilitiesXPS
    {
        public static void Run()
        {
            // ExStart:UsingImageUtils
            // For complete examples and data files, please go to https://github.com/aspose-page/Aspose.Page-for-.NET
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithImages();
            // Create new XPS Document
            using (XpsDocument doc = new XpsDocument())
            {
                // Set first page's size.
                doc.Page.Width = 540f;
                doc.Page.Height = 220f;

                // Draw the image box.
                RectangleF imageBox = new RectangleF(10f, 10f, 200f, 200f);
                XpsPath path = doc.AddPath(doc.Utils.CreateRectangle(imageBox));
                path.Stroke = doc.CreateSolidColorBrush(Color.Black);
                // Add an image to fit width.
                path = doc.Utils.CreateImage(dataDir + "R08LN_NN.jpg", imageBox, ImageMode.FitToWidth);
                // Prevent tiling.
                ((XpsImageBrush)path.Fill).TileMode = XpsTileMode.None;
                doc.Add(path);

                // Add an image to fit width.
                doc.Add(doc.Utils.CreateImage(dataDir + "R08LN_NN.jpg", new RectangleF(220f, 10f, 200f, 100f), ImageMode.FitToHeight));

                // Add an image to fit width.
                doc.Add(doc.Utils.CreateImage(dataDir + "R08LN_NN.jpg", new RectangleF(430f, 10f, 100f, 200f), ImageMode.FitToBox));

                // Save resultant XPS document 
                doc.Save(dataDir + "UseImageUtilsXPS_out.xps");
            }
            // ExEnd:UsingImageUtils
        }
    }
}
