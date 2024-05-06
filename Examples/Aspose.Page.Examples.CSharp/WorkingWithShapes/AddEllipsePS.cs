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

namespace CSharp.WorkingWithShapes
{
    public class AddEllipsePS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithShapes();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "AddEllipse_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                //Create graphics path from the first ellipse
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(new RectangleF(250, 100, 150, 100));
                //Set paint
                document.SetPaint(new SolidBrush(Color.Orange));
                //Fill the ellipse
                document.Fill(path);

                //Create graphics path from the second ellipse
                path = new GraphicsPath();
                path.AddEllipse(new RectangleF(250, 300, 150, 100));
                //Set stroke
                document.SetStroke(new Pen(new SolidBrush(Color.Red), 3));
                //Stroke (outline) the ellipse
                document.Draw(path);

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
