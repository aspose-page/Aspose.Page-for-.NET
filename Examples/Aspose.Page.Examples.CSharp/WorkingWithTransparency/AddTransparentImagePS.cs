using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace CSharp.WorkingWithTransparency
{
    public class AddTransparentImagePS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithTransparency();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "AddTransparentImage_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();
                //Set page's background color to see white image on it's own transparent background
                options.BackgroundColor = Color.FromArgb(211, 8, 48);

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);


                document.WriteGraphicsSave();
                document.Translate(20, 100);

                //Create bitmap from translucent image file
                using (Bitmap image = new Bitmap(dataDir + "mask1.png"))
                {
                    //Add this image to document as usual opaque RGB image
                    document.DrawImage(image, new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, 100, 0), Color.Empty);
                }

                //Again create bitmap from the same image file
                using (Bitmap image = new Bitmap(dataDir + "mask1.png"))
                {
                    //Add this image to document as transparent image image
                    document.DrawTransparentImage(image, new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, 350, 0), 255);
                }

                document.WriteGraphicsRestore();

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
