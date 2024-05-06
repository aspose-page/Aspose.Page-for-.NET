using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsMetadata;
using Aspose.Page.XPS.XpsModel;
using System;

namespace CSharp.WorkingWithPrintTickets
{
    public class EditPrintTicket
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithPrintTickets();

            // Open XPS Document with print tickets
            XpsDocument xDocs = new XpsDocument(dir + "input3.xps");

            JobPrintTicket pt = xDocs.JobPrintTicket;

            // Remove some parameters from job print ticket
            pt.Remove(
                "ns0000:PageDevmodeSnapshot",
                "ns0000:JobInterleaving",
                "ns0000:JobImageType");

            // Add some parameters to job print ticket
            pt.Add(
                new JobCopiesAllDocuments(2),
                new PageMediaSize(PageMediaSize.PageMediaSizeOption.ISOA4));

            // Save the document with changed job print ticket.
            xDocs.Save(dir + "output3.xps");

            // ExEnd:1
        }
    }
}
