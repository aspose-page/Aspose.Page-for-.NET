using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace CSharp.WorkingWithCanvas
{
    public class ClippingPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCanvas();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "Clipping_outPS.ps", FileMode.Create))
            {
                //Create save options with default values
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                //Create graphics path from the rectangle
                System.Drawing.Drawing2D.GraphicsPath rectangePath = new System.Drawing.Drawing2D.GraphicsPath();
                rectangePath.AddRectangle(new System.Drawing.RectangleF(0, 0, 300, 200));

////////////////////////////////////// Clipping by shape //////////////////////////////////////////////////////////////////////

                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Displace current graphics state on 100 points to the right and 100 points to the bottom.
                document.Translate(100, 100);

                //Create graphics path from the circle
                System.Drawing.Drawing2D.GraphicsPath circlePath = new System.Drawing.Drawing2D.GraphicsPath();
                circlePath.AddEllipse(new System.Drawing.RectangleF(50, 0, 200, 200));

                //Add clipping by circle to the current graphics state
                document.Clip(circlePath);

                //Set paint in the current graphics state
                document.SetPaint(new System.Drawing.SolidBrush(Color.Blue));

                //Fill the rectangle in the current graphics state (with clipping)
                document.Fill(rectangePath);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();

                //Displace upper level graphics state on 100 points to the right and 100 points to the bottom.
                document.Translate(100, 100);

                Pen pen = new Pen(new SolidBrush(Color.Blue), 2);
                pen.DashStyle = DashStyle.Dash;

                document.SetStroke(pen);

                //Draw the rectangle in the current graphics state (has no clipping) above clipped rectngle
                document.Draw(rectangePath);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
