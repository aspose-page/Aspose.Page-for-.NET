using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace CSharp.WorkingWithShapes
{
    public class AddImagePS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithImages();

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "AddImage_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

                
                document.WriteGraphicsSave();
                document.Translate(100, 100);

                //Create a Bitmap object from image file
                using (Bitmap image = new Bitmap(dataDir + "TestImage Format24bppRgb.jpg"))
                {
                    //Create image transform
                    System.Drawing.Drawing2D.Matrix transform = new System.Drawing.Drawing2D.Matrix();
                    transform.Translate(35, 300);
                    transform.Scale(3, 3);
                    transform.Rotate(-45);

                    //Add image to document
                    document.DrawImage(image, transform, Color.Empty);
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
