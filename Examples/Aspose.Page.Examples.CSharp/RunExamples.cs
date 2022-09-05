using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSharp.GettingStarted;
using CSharp.WorkingWithGradient;
using CSharp.WorkingWithImages;
using CSharp.WorkingWithShapes;
using CSharp.WorkingWithText;
using CSharp.WorkingWithPages;
using CSharp.WorkingWithTransparency;
using CSharp.WorkingWithVisualBrush;
using CSharp.WorkingWithDocument;
using CSharp.WorkingWithDocumentConversion;
using CSharp.WorkingWithDocumentMerging;
using CSharp.WorkingWithPrintTickets;
using CSharp.WorkingWithCrossPackageOperations;
using CSharp.WorkingWithImageConversion;
using CSharp.WorkingWithCanvas;

namespace CSharp
{
    class RunExamples
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");
            // Uncomment the one you want to try out

            // =====================================================
            // =====================================================
            // Getting Started
            // =====================================================
            // =====================================================
            LoadLicenseFromFile.Run();
            // LoadLicenseFromStreamObject.Run();
            // SetLicenseUsingEmbeddedResource.Run();
            // SecureLicense.Run();

            // =====================================================
            // =====================================================
            // WorkingWithDocument
            // =====================================================
            // =====================================================
            //CreateDocument.Run();
            //ChangeDocument.Run();

            // =====================================================
            // =====================================================
            // WorkingWithDocumentConversion
            // =====================================================
            // =====================================================
            //PostScriptToPdf.Run();
            //PostScriptToImage.Run();
            //XPStoPNG.Run();
            //XPStoBMP.Run();
            //XPStoJPEG.Run();
            //XPStoTIFF.Run();
            //XPStoPDF.Run();

            // =====================================================
            // =====================================================
            // WorkingWithDocumentMerging
            // =====================================================
            // =====================================================
            //CSharp.WorkingWithDocumentMerging.PostScriptToPdf.Run();
            //CSharp.WorkingWithDocumentMerging.XPStoPDF.Run();
            //CSharp.WorkingWithDocumentMerging.XPStoXPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithXMPMetadataInEPS
            // =====================================================
            // =====================================================
            //CSharp.WorkingWithXMPMetadataInEPS.GetMetadata.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.AddMetadata.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_ChangeValues.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddSimpleProperties.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddArrayItems.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_ChangeArrayItems.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddNamedValueItem.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_ChangeNamedValueItem.Run();
            //CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddNamespace.Run();

            // =====================================================
            // =====================================================
            // WorkingWithText
            // =====================================================
            // =====================================================
            //AddText.Run();
            //AddTextUsingUnicodeString.Run();

            // =====================================================
            // =====================================================
            // WorkingWithImages
            // =====================================================
            // =====================================================
            //AddImage.Run();
            //AddTiledImage.Run();

            // =====================================================
            // =====================================================
            // WorkingWithGradient
            // =====================================================
            // =====================================================
            //AddLinearGradient.Run();
            //AddVerticalGradient.Run();
            //AddHorizontalGradient.Run();

            // =====================================================
            // =====================================================
            // WorkingWithShapes
            // =====================================================
            // =====================================================
            //AddRectangle.Run();
            //AddEllipse.Run();
            ApplyDifferentColorSpaces.Run();

            // =====================================================
            // =====================================================
            // WorkingWithPages
            // =====================================================
            // =====================================================
            //AddPage.Run();
            //RemovePage.Run();

            // =====================================================
            // =====================================================
            // WorkingWithPrintTickets
            // =====================================================
            // =====================================================
            //GetPrintTickets.Run();
            //LinkPrintTickets.Run();
            //CreateCustomPrintTicket.Run();
            //EditPrintTicket.Run();

            // =====================================================
            // =====================================================
            // WorkingWithTransparency
            // =====================================================
            // =====================================================
            //AddTransparentObject.Run();
            //SetOpacityMask.Run();

            // =====================================================
            // =====================================================
            //WorkingWithGrid
            // =====================================================
            // =====================================================
            //AddGrid.Run();

            // =====================================================
            // =====================================================
            //WorkingWithCrossPackageOperations
            // =====================================================
            // =====================================================
            //AddImageFilledGlyphAndForeignImage.Run();
            //AddGlyphCloneAndChangeColor.Run();
            //ManipulatePages.Run();

            // =====================================================
            // =====================================================
            //WorkingWithImageConversion
            // =====================================================
            // =====================================================
            //SaveImageAsEPS.Run();

            // =====================================================
            // =====================================================
            //WorkingWithCanvas
            // =====================================================
            // =====================================================
            Transformations.Run();

            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }

        public static String GetDataDir_GettingStarted()
        {
            return Path.GetFullPath(GetDataDir_Data() + "GettingStarted/");
        }

        public static String GetDataDir_WorkingWithGradient()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithGradient/");
        }

        public static String GetDataDir_WorkingWithVisualBrush()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithVisualBrush/");
        }

        public static String GetDataDir_WorkingWithImages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithImages/");
        }

        public static String GetDataDir_WorkingWithShapes()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithShapes/");
        }

        public static String GetDataDir_WorkingWithText()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithText/");
        }

        public static String GetDataDir_WorkingWithPages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithPages/");
        }

        public static String GetDataDir_WorkingWithPrintTickets()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithPrintTickets/");
        }

        public static String GetDataDir_WorkingWithTransparency()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithTransparency/");
        }
        public static String GetDataDir_WorkingWithDocument()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithDocument/");
        }

        public static String GetDataDir_WorkingWithDocumentConversion()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithDocumentConversion/");
        }

        public static String GetDataDir_WorkingWithDocumentMerging()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithDocumentMerging/");
        }

        public static String GetDataDir_WorkingWithXMPMetadataInEPS()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithXMPMetadataInEPS/");
        }

        public static String GetDataDir_WorkingWithCrossPackageOperations()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithCrossPackageOperations/");
        }

        public static String GetDataDir_WorkingWithImageConversion()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithImageConversion/");
        }

        public static String GetDataDir_WorkingWithCanvas()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithCanvas/");
        }

        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return Path.Combine(startDirectory, "Data\\");
        }
    }
}
