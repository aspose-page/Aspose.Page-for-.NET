using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
#if ASPOSE_DRAWING
using Aspose.Page.Drawing;
using Aspose.Page.Drawing.Drawing2D;
using GradientBrush = Aspose.Page.Drawing.Drawing2D.GradientBrush;
#else
using System.Drawing;
using System.Drawing.Drawing2D;
using GradientBrush = Aspose.Page.EPS.GradientBrush;
#endif
using System.IO;


namespace CSharp.WorkingWithTransparency
{
    public class ShowPseudoTransparencyPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithTransparency();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "ShowPseudoTransparency_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                float offsetX = 50;
                float offsetY = 100;
                float width = 200;
                float height = 100;

///////////////////////////////// Create rectangle with opaque gradient fill /////////////////////////////////////////////////////////
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new RectangleF(offsetX, offsetY, width, height));

                LinearGradientBrush opaqueBrush = new LinearGradientBrush(new RectangleF(0, 0, 200, 100), Color.FromArgb(0, 0, 0),
                    Color.FromArgb(40, 128, 70), 0f);
                Matrix brushTransform = new Matrix(width, 0, 0, height, offsetX, offsetY);
                opaqueBrush.Transform = brushTransform;
                GradientBrush gradientBrush = new GradientBrush(opaqueBrush);
                gradientBrush.WrapMode = WrapMode.Clamp;

                document.SetPaint(gradientBrush);
                document.Fill(path);
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                offsetX = 350;

///////////////////////////////// Create rectangle with translucent gradient fill ///////////////////////////////////////////////////
                //Create graphics path from the first rectangle
                path = new GraphicsPath();
                path.AddRectangle(new RectangleF(offsetX, offsetY, width, height));

                //Create linear gradient brush colors which transparency are not 255, but 150 and 50. So it are translucent.
                LinearGradientBrush translucentBrush = new LinearGradientBrush(new RectangleF(0, 0, width, height), Color.FromArgb(150, 0, 0, 0),
                    Color.FromArgb(50, 40, 128, 70), 0f);
                //Create a transform for brush.
                brushTransform = new Matrix(width, 0, 0, height, offsetX, offsetY);
                //Set transform
                translucentBrush.Transform = brushTransform;
                //Create GradientBrush object containing the linear gradient brush
                gradientBrush = new GradientBrush(translucentBrush);
                gradientBrush.WrapMode = WrapMode.Clamp;
                //Set paint
                document.SetPaint(gradientBrush);
                //Fill the rectangle
                document.Fill(path);
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
