using Aspose.Page.XPS;
using Aspose.Page.XPS.Features.EventBasedModifications;
using Aspose.Page.XPS.Presentation.Pdf;
using Aspose.Page.XPS.XpsModel;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CSharp.WorkingWithPages
{
    public class ModifyXpsPageOnConversion
    {
        public static void Run()
        {
            // ExStart:ModifyingXpsPageOnConversion
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithPages();
            // Create new XPS Document
            using (XpsDocument doc = new XpsDocument(dataDir + "Sample3.xps"))
            // Create a font
            using (Stream fontStream = File.OpenRead(dataDir + "arialbd.ttf"))
            {
                // Create options for conversion to PDF
                PdfSaveOptions options = new PdfSaveOptions();
                // Set the filter for the pages that need conversion
                options.PageNumbers = new int[] { 2, 6, 7, 13 };
                // Add the event handler that will execute right before the conversion each page
                options.BeforePageSavingEventHandlers.Add(new NavigationInjector(doc.CreateFont(fontStream), options.PageNumbers));
                // Save resultant XPS document
                doc.SaveAsPdf(dataDir + "ModifyPageOnConversion_out.pdf", options);
            }
            // ExEnd:ModifyingXpsPageOnConversion
        }

        // ExStart:OnXpsPageConversionEventHandler
        /// <summary>
        /// The class to handle the before-page event while converting an XPS document.
        /// </summary>
        public class NavigationInjector : BeforePageSavingEventHandler
        {
            // The font in which navigation hyperlinks and page numbers will be displayed.
            private readonly XpsFont _font;
            // The page numbers to convert.
            private readonly SortedList<int, int> _pageNumbers;

            public NavigationInjector(XpsFont font, int[] pageNumbers)
            {
                _font = font;
                if (pageNumbers == null)
                    return;

                // Turn the page number array into a sorted collection of unique values.
                _pageNumbers = new SortedList<int, int>();
                foreach (int pn in pageNumbers)
                    _pageNumbers[pn] = 0;
            }

            /// <summary>
            /// The action itself to be triggered on a before-page event.
            /// </summary>
            /// <param name="args">The event arguments.</param>
            public override void Handle(BeforeSavingEventArgs<PageAPI> args)
            {
                PageAPI api = args.ElementAPI;

                XpsGlyphs glyphs;
                // For all pages in the output PDF except the first one...
                if (args.OutputPageNumber > 1)
                {
                    // ...insert a hyperlink to the first page...
                    glyphs = api.CreateGlyphs(_font, 15f, 5f, api.Height - 10f, "[First]");
                    glyphs.Fill = api.CreateSolidColorBrush(Color.Blue);
                    glyphs.HyperlinkTarget = new XpsPageLinkTarget(_pageNumbers == null ? 1 : _pageNumbers.Keys[0]);
                    api.Add(glyphs);

                    // ...and to the previous page.
                    glyphs = api.CreateGlyphs(_font, 15f, 60f, api.Height - 10f, "[Prev]");
                    glyphs.Fill = api.CreateSolidColorBrush(Color.Blue);
                    glyphs.HyperlinkTarget = new XpsPageLinkTarget(
                        _pageNumbers == null ? args.AbsolutePageNumber - 1 : _pageNumbers.Keys[args.OutputPageNumber - 2]);
                    api.Add(glyphs);
                }

                // For all pages in the output PDF except the last one...
                if ((_pageNumbers != null && args.OutputPageNumber < _pageNumbers.Count) ||
                    (_pageNumbers == null && args.OutputPageNumber < api.TotalPageCount))
                {
                    // ...insert a hyperlink to the next page...
                    glyphs = api.CreateGlyphs(_font, 15f, 110f, api.Height - 10f, "[Next]");
                    glyphs.Fill = api.CreateSolidColorBrush(Color.Blue);
                    glyphs.HyperlinkTarget = new XpsPageLinkTarget(
                        _pageNumbers == null ? args.AbsolutePageNumber + 1 : _pageNumbers.Keys[args.OutputPageNumber]);
                    api.Add(glyphs);

                    // ...and to the last page.
                    glyphs = api.CreateGlyphs(_font, 15f, 160f, api.Height - 10f, "[Last]");
                    glyphs.Fill = api.CreateSolidColorBrush(Color.Blue);
                    glyphs.HyperlinkTarget = new XpsPageLinkTarget(
                        _pageNumbers == null ? api.TotalPageCount : _pageNumbers.Keys[_pageNumbers.Keys.Count - 1]);
                    api.Add(glyphs);
                }

                // Insert a page number in the bottom-right corner.
                glyphs = api.CreateGlyphs(_font, 15f, api.Width - 20f, api.Height - 10f, args.OutputPageNumber.ToString());
                glyphs.Fill = api.CreateSolidColorBrush(Color.Black);
                api.Add(glyphs);

                // Add an outline entry to display the links to the converted pages in the navigation pane of a PDF viewer.
                api.AddOutlineEntry(string.Format("Page {0}", args.OutputPageNumber), 1, args.AbsolutePageNumber);
            }
        }
        // ExEnd:OnXpsPageConversionEventHandler
    }
}
