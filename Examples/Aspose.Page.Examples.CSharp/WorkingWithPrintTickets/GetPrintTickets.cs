using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsMetadata;
using Aspose.Page.XPS.XpsModel;
using System;
using System.Drawing;

namespace CSharp.WorkingWithPrintTickets
{
    public class GetPrintTickets
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithPrintTickets();

            // Open XPS Document without print tickets
            XpsDocument xDocs = new XpsDocument(dir + "input1.xps");

            // Get job print ticket
            JobPrintTicket jobPrintTicket = xDocs.JobPrintTicket; // must be null for this document

            // Get document print ticket
            DocumentPrintTicket docPrintTicket = xDocs.GetDocumentPrintTicket(1); // must be null for this document

            // Get page print ticket
            PagePrintTicket pagePrintTicket = xDocs.GetPagePrintTicket(1, 1); // must be null for this document


            // Save the document. Default print tickets are automatically added to document while saving.
            xDocs.Save(dir + "output1.xps");

            // Open saved earlier XPS Document with print tickets
            XpsDocument xDocs2 = new XpsDocument(dir + "output1.xps");

            // Print tickets must not be null

            Console.WriteLine(xDocs2.JobPrintTicket);

            Console.WriteLine(xDocs2.GetDocumentPrintTicket(1));

            Console.WriteLine(xDocs2.GetPagePrintTicket(1, 1));

            // ExEnd:1
        }
    }
}
