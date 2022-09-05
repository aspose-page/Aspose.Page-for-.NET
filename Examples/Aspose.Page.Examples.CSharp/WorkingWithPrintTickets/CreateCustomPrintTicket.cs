using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsMetadata;
using Aspose.Page.XPS.XpsModel;
using System;
using System.Drawing;

namespace CSharp.WorkingWithPrintTickets
{
    public class CreateCustomPrintTicket
    {
        public sealed class PageDevModeSnaphot : ParameterInit, IJobPrintTicketItem
        {
            public PageDevModeSnaphot(string value) : base("ns0000:PageDevmodeSnapshot", new StringValue(value))
            {
            }
        }

        public sealed class Borders : Feature, NUp.INUpItem
        {
            public sealed class BordersOption : Option
            {
                public static BordersOption On = new BordersOption("ns0000:On");
                public static BordersOption Off = new BordersOption("ns0000:Off");

                private BordersOption(string name) : base(name)
                {
                }
            }

            public Borders(BordersOption option, params IFeatureItem[] items) : base("ns0000:Borders", option, items)
            {
            }
        }


        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dir = RunExamples.GetDataDir_WorkingWithPrintTickets();

            // Create new XPS document
            XpsDocument xDocs = new XpsDocument();

            // Add custom job print ticket
            xDocs.JobPrintTicket = new JobPrintTicket(
                new PageDevModeSnaphot("SABlAGwAbABvACEAAAA="),             // Custom page parameter initializer
                new DocumentCollate(Collate.CollateOption.Collated),
                new JobCopiesAllDocuments(1),
                new PageICMRenderingIntent(PageICMRenderingIntent.PageICMRenderingIntentOption.Photographs),
                new PageColorManagement(PageColorManagement.PageColorManagementOption.None),
                new JobNUpAllDocumentsContiguously(
                    new NUp.PresentationDirection(NUp.PresentationDirection.PresentationDirectionOption.RightBottom),
                    new Borders(Borders.BordersOption.On) /* Custom nested feature */).AddPagesPerSheetOption(1),
                new PageMediaSize(PageMediaSize.PageMediaSizeOption.NorthAmericaLetter),
                new JobInputBin(InputBin.InputBinOption.AutoSelect),
                new JobDuplexAllDocumentsContiguously(Duplex.DuplexOption.OneSided),
                new PageOrientation(PageOrientation.PageOrientationOption.Portrait),
                new PageResolution(
                    new PageResolution.PageResolutionOption("ns0000:ESDL300x300")             // Custom page resolution option
                        .SetResolutionX(300).SetResolutionY(300)),
                new PageMediaType(PageMediaType.PageMediaTypeOption.Plain),
                new PageOutputColor(PageOutputColor.PageOutputColorOption.Color.Clone().SetDeviceBitsPerPixel(0).SetDriverBitsPerPixel(24)));


            // Save the document with custom job print ticket.
            xDocs.Save(dir + "output1.xps");

            // ExEnd:1
        }
    }
}
