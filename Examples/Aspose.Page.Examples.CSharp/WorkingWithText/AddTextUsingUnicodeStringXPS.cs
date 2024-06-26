﻿using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;
#if ASPOSE_DRAWING
using FontStyle = Aspose.Page.Drawing.FontStyle;
#else
using FontStyle = System.Drawing.FontStyle;
#endif

namespace CSharp.WorkingWithText
{
    public class AddTextUsingUnicodeStringXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithText();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();
            // Add Text
            XpsSolidColorBrush textFill = doc.CreateSolidColorBrush(Color.Black);
            XpsGlyphs glyphs = doc.AddGlyphs("Arial", 20, FontStyle.Regular, 400f, 200f, "TEN. rof SPX.esopsA");
            glyphs.BidiLevel = 1;
            glyphs.Fill = textFill;
            // Save resultant XPS document
            doc.Save(dataDir + "AddTextRTL_out.xps");
            // ExEnd:1
        }
    }
}
