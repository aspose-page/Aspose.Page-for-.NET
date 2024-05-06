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
    public class AddHatchPatternPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithHatches();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "AddHatchPattern_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                int x0 = 20;
                int y0 = 100;
                int squareSide = 32;
                int width = 500;
                int sumX = 0;

                //Restore graphics state
                document.WriteGraphicsSave();

                //Translate to initial point
                document.Translate(x0, y0);

                //Create rectngle path for every pattern square
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new RectangleF(0, 0, squareSide, squareSide));

                //Create pen for outlining pattern square
                Pen pen = new Pen(Color.Black, 2);

                //For every hatch pattern style 
                for (HatchStyle hatchStyle = 0; hatchStyle <= (HatchStyle)52; hatchStyle++)
                {
                    //Set paint with current hatch brush style
                    document.SetPaint(new HatchBrush(hatchStyle, Color.Black, Color.White));

                    //Calculate displacement in order to don't go beyond the page bounds
                    int x = squareSide;
                    int y = 0;
                    if (sumX >= width)
                    {
                        x = -(sumX - squareSide);
                        y += squareSide;
                    }
                    //Translate current graphics state
                    document.Translate(x, y);
                    //Fill pattern square
                    document.Fill(path);
                    //Set stroke
                    document.SetStroke(pen);
                    //Draw square outline
                    document.Draw(path);

                    //Calculate distance from X0
                    if (sumX >= width)
                    {
                        sumX = squareSide;
                    }
                    else
                        sumX += x;
                }

                //Restore graphics state
                document.WriteGraphicsRestore();

                //Fill text with hatch pattern
                HatchBrush brush = new HatchBrush(HatchStyle.DiagonalCross, Color.Red, Color.Yellow);
                Font font = new Font("Arial", 96, FontStyle.Bold);
                document.FillAndStrokeText("ABC", font, 200, 300, brush, pen);

                //Outline text with hatch pattern
                brush = new HatchBrush(HatchStyle.Percent50, Color.Blue, Color.White);                
                document.OutlineText("ABC", font, 200, 400, new Pen(brush, 5));


                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }



            // ExEnd:1
        }
    }
}
