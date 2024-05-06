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

namespace CSharp.WorkingWithCanvas
{
    public class TransformationsPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithCanvas();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "Transformations_outPS.ps", FileMode.Create))
            {
                //Create save options with default values
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                document.Translate(100, 100);

                //Create graphics path from the rectangle
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new RectangleF(0, 0, 150, 100));

////////////////////////////////////// No transformations ///////////////////////////////////////////////////////////////
                //Set paint in graphics state on upper level
                document.SetPaint(new SolidBrush(Color.Orange));

                //Fill the first rectangle that is on on upper level graphics state and that is without any transformations.
                document.Fill(path);
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                

////////////////////////////////////// Translation //////////////////////////////////////////////////////////////////////

                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Displace current graphics state on 250 to the right. So we add translation component to the current transformation.
                document.Translate(250, 0);

                //Set paint in the current graphics state
                document.SetPaint(new SolidBrush(Color.Blue));

                //Fill the second rectangle in the current graphics state (has translation transformation)
                document.Fill(path);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //Displace on 200 to the bottom.
                document.Translate(0, 200);

////////////////////////////////////// Scaling //////////////////////////////////////////////////////////////////////////
                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Scale current graphics state on 0.5 in X axis and on 0.75f in Y axis. So we add scale component to the current transformation.
                document.Scale(0.5f, 0.75f);

                //Set paint in the current graphics state
                document.SetPaint(new SolidBrush(Color.Red));

                //Fill the third rectangle in the current graphics state (has scale transformation)
                document.Fill(path);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //Displace upper level graphics state on 250 to the right.
                document.Translate(250, 0);


////////////////////////////////////// Rotation //////////////////////////////////////////////////////////////////////
                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Rotate current graphics state on 45 degrees around origin of current graphics state (350, 300). So we add rotation component to the current transformation.
                document.Rotate(45);

                //Set paint in the current graphics state
                document.SetPaint(new SolidBrush(Color.Green));

                //Fill the fourth rectangle in the current graphics state (has rotation transformation)
                document.Fill(path);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //Returns upper level graphics state back to the left and displace on 200 to the bottom.
                document.Translate(-250, 200);


////////////////////////////////////// Shearing //////////////////////////////////////////////////////////////////////
                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Shear current graphics state. So we add shear component to the current transformation.
                document.Shear(0.1f, 0.2f);

                //Set paint in the current graphics state
                document.SetPaint(new SolidBrush(Color.Pink));

                //Fill the fifth rectangle in the current graphics state (has shear transformation)
                document.Fill(path);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //Displace upper level graphics state on 250 to the right.
                document.Translate(250, 0);


////////////////////////////////////// Complex transformation ////////////////////////////////////////////////////////
                //Save graphics state in order to return back to this state after transformation
                document.WriteGraphicsSave();

                //Transform current graphics state with complex transformation. So we add translation, scale and rotation components to the current transformation.
                document.Transform(new Matrix(1.2f, -0.965925f, 0.258819f, 1.5f, 0f, 50));

                //Set paint in the current graphics state
                document.SetPaint(new SolidBrush(Color.Aquamarine));

                //Fill the sixth rectangle in the current graphics state (has complex transformation)
                document.Fill(path);

                //Restore graphics state to the previus (upper) level
                document.WriteGraphicsRestore();
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //Returns upper level graphics state back to the left and displace on 200 to the bottom.
                document.Translate(-250, 200);


////////////////////////////////////// Again no transformation ////////////////////////////////////////////////////////
                // Demonstrates that current graphics state's color is orange that was set up at the beginning of the code. 
                //Fill the seventh rectangle in the current graphics state (has no transformation)
                document.Fill(path);
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
