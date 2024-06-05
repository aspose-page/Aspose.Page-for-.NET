using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsMetadata;

namespace CSharp.WorkingWithPrintTickets
{
    public class CreateCustomPrintTicket
    {
        public static void Run()
        {
            // ExStart:CreateCustomPrintTicket
            // For complete examples and data files, please go to https://github.com/aspose-page/Aspose.Page-for-.NET
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithPrintTickets();

            // Create new XPS document
            using (XpsDocument document = new XpsDocument())
            {
                // Set a custom job-level print ticket
                document.JobPrintTicket = new JobPrintTicket(
                    // Specify input bin.
                    new JobInputBin(InputBin.InputBinOption.Manual.Clone().Add(
                        InputBin.FeedFace.FaceDown, InputBin.FeedDirection.LongEdgeFirst, new InputBin.MediaSheetCapacity(100))),
                    // Specify output bin.
                    new JobOutputBin(new OutputBin.OutputBinOption(OutputBin.BinType.Sorter),
                        new OutputBin.OutputBinOption(OutputBin.BinType.Stacker, new OutputBin.MediaSheetCapacity(100))),
                    // Specify page orientation.
                    new PageOrientation(PageOrientation.PageOrientationOption.Landscape),
                    // Specify duplex mode fof the output.
                    new JobDuplexAllDocumentsContiguously(Duplex.DuplexOption.TwoSidedLongEdge(Duplex.DuplexMode.Automatic)),
                    // Specify the color settings for the output.
                    new PageOutputColor(PageOutputColor.PageOutputColorOption.Grayscale(0, 8)));

                // Save the document with the custom job-level print ticket.
                document.Save(dir + "output1.xps");
            }
            // ExEnd:CreateCustomPrintTicket
        }
    }
}
