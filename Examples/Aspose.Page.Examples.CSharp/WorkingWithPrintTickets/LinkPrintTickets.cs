using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsMetadata;
using Aspose.Page.XPS.XpsModel;
using System;

namespace CSharp.WorkingWithPrintTickets
{
    public class LinkPrintTickets
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithPrintTickets();

            // Create new XPS document
            XpsDocument xDocs1 = new XpsDocument();

            // Open XPS Document with print tickets
            XpsDocument xDocs2 = new XpsDocument(dir + "input2.xps");

            // Link job print ticket
            xDocs1.JobPrintTicket = xDocs2.JobPrintTicket;

            // Link document print ticket
            xDocs1.SetDocumentPrintTicket(1, xDocs2.GetDocumentPrintTicket(2));

            // Link page print ticket
            xDocs1.SetPagePrintTicket(1, 1, xDocs2.GetPagePrintTicket(3, 2));


            // Save the document with linked print tickets.
            xDocs1.Save(dir + "output1.xps");

            // ExEnd:1
        }
    }
}
