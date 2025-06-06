﻿using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
#if ASPOSE_DRAWING
using Aspose.Page.Drawing;
using Aspose.Page.Drawing.Drawing2D;
#else
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
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
                GraphicsPath rectanglePath = new GraphicsPath();
                rectanglePath.AddRectangle(new RectangleF(0, 0, 300, 200));

////////////////////////////////////// Clipping by shape //////////////////////////////////////////////////////////////////////

                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Displace current graphics state on 100 points to the right and 100 points to the bottom.
                document.Translate(100, 100);

                //Create graphics path from the circle
                GraphicsPath circlePath = new GraphicsPath();
                circlePath.AddEllipse(new RectangleF(50, 0, 200, 200));

                //Add clipping by circle to the current graphics state
                document.Clip(circlePath);

                //Set paint in the current graphics state
                document.SetPaint(new SolidBrush(Color.Blue));

                //Fill the rectangle in the current graphics state (with clipping)
                document.Fill(rectanglePath);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();

                //Displace upper level graphics state on 100 points to the right and 100 points to the bottom.
                document.Translate(100, 100);

                Pen pen = new Pen(new SolidBrush(Color.Blue), 2);
                pen.DashStyle = DashStyle.Dash;

                document.SetStroke(pen);

                //Draw the rectangle in the current graphics state (has no clipping) above clipped rectangle
                document.Draw(rectanglePath);

////////////////////////////////////// Clipping by text //////////////////////////////////////////////////////////////////////

                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Displace current graphics state on 100 points to the right and 100 points to the bottom.
                document.Translate(0, 350);

                int fontSize = 120;
                Font font = new Font("Arial", fontSize, FontStyle.Bold);

                //Clip rectangle by text's outline
                document.ClipText("ABC", font, 20, fontSize + 10);
                document.Fill(rectanglePath);

                document.WriteGraphicsRestore();

                document.Translate(0, 350);

                document.SetStroke(pen);
                //Draw the rectangle in the current graphics state (has no clipping) above clipped rectangle
                document.Draw(rectanglePath);

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
