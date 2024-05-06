using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
#if ASPOSE_DRAWING
using Aspose.Page.Drawing;
using Aspose.Page.Drawing.Drawing2D;
#else
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
using System.IO;


namespace CSharp.WorkingWithGradient
{
    public class AddVerticalGradientPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithGradient();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "VerticalGradient_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                float offsetX = 200;
                float offsetY = 100;
                float width = 200;
                float height = 100;

                //Create graphics path from the first rectangle
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new RectangleF(offsetX, offsetY, width, height));

                //Create an array of interpolation colors
                Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.DarkOliveGreen };
                float[] positions = { 0.0f, 0.1873f, 0.492f, 0.734f, 1.0f };
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = colors;
                colorBlend.Positions = positions;

                //Create linear gradient brush with rectangle as a bounds, start and end colors
                LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 0, width, height), Color.Beige, Color.DodgerBlue, 0f);
                //Set interpolation colors
                brush.InterpolationColors = colorBlend;
                //Create a transform for brush. X and Y scale component must be equal to width and height of the rectangle correspondingly.
                //Translation components are offsets of the rectangle
                Matrix brushTransform = new Matrix(width, 0, 0, height, offsetX, offsetY);
                //Rotate transform to get colors change in vertical direction from up to down
                brushTransform.Rotate(90);
                //Set transform
                brush.Transform = brushTransform;

                //Set paint
                document.SetPaint(brush);

                //Fill the rectangle
                document.Fill(path);

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
