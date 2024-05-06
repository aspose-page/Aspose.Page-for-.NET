using Aspose.Page;
using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using Aspose.Page.Font;
#if ASPOSE_DRAWING
using Aspose.Page.Drawing;
using Aspose.Page.Drawing.Drawing2D;
#else
using System.Drawing;
using System.Drawing.Drawing2D;
#endif
using System.IO;

namespace CSharp.WorkingWithText
{
    public class AddTextUsingUnicodeStringPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithText();

            string FONTS_FOLDER = RunExamples.GetDataDir_Data() + @"necessary_fonts/";

            //Create output stream for PostScript document
            using (Stream outPsStream = new FileStream(dataDir + "AddTextUsingUnocodeString_outPS.ps", FileMode.Create))
            {
                //Create save options with A4 size
                PsSaveOptions options = new PsSaveOptions();
                // Set custom fonts folder. It will be added to system fonts folders for finding needed font.
                options.AdditionalFontsFolders = new string[] { FONTS_FOLDER };
                //A text to write to PS file
                string str = "試してみます。";
                int fontSize = 48;

                // Create new 1-paged PS Document
                PsDocument document = new PsDocument(outPsStream, options, false);

////////////////////////////////////// Using custom font (located in custom fonts folders) for filling text /////////////////
                DrFont drFont = ExternalFontCache.FetchDrFont("Arial Unicode MS", fontSize, FontStyle.Regular);
                //Fill text with default or already defined color. In given case it is black.
                document.FillText(str, drFont, 50, 200);
                //Fill text with Blue color.
                document.FillText(str, drFont, 50, 250, new SolidBrush(Color.Blue));
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////// Using custom font (located in custom fonts folders) for outlining text /////////////////
                //Outline text with default or already defined pen. In given case it is black colored 1-points width pen.
                /*document.OutlineText(str, drFont, 50, 450);
                //Outline text with blue-violet colored 2-points width pen.
                document.OutlineText(str, drFont, 50, 500, new Pen(new SolidBrush(Color.BlueViolet), 2));
                //Fill text with orange color and stroke with blue colored 2-points width pen.
                document.FillAndStrokeText(str, drFont, 50, 550, new SolidBrush(Color.Orange), new Pen(new SolidBrush(Color.Blue), 2));*/
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Close current page
                document.ClosePage();

                //Save the document
                document.Save();
            }
            // ExEnd:1
        }
    }
}
