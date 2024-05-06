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
    public class AddRadialGradient2PS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithGradient();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "RadialGradient2_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                float offsetX = 200;
                float offsetY = 100;
                float width = 200;
                float height = 200;

                //Create graphics path from the rectangle bounds
                RectangleF bounds = new RectangleF(offsetX, offsetY, width, height);
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(bounds);

                //Create and fill color blend object
                Color[] colors = { Color.Green, Color.Blue, Color.Black, Color.Yellow, Color.Beige, Color.Red };
                float[] positions = { 0.0f, 0.2f, 0.3f, 0.4f, 0.9f, 1.0f };
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = colors;
                colorBlend.Positions = positions;

                GraphicsPath brushRect = new GraphicsPath();
                brushRect.AddRectangle(new RectangleF(0, 0, width, height));

                //Create path gradient brush with rectangle as a bounds
                PathGradientBrush brush = new PathGradientBrush(brushRect);
                //Set interpolation colors
                brush.InterpolationColors = colorBlend;
                //Create a transform for brush. X and Y scale component must be equal to width and height of the rectangle correspondingly.
                //Translation components are offsets of the rectangle
                Matrix brushTransform = new Matrix(width, 0, 0, height, offsetX, offsetY);
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
