﻿using System;
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
//using CSharp.WorkingWithDocumentMerging;
using CSharp.WorkingWithPrintTickets;
using CSharp.WorkingWithCrossPackageOperations;
using CSharp.WorkingWithImageConversion;
using CSharp.WorkingWithCanvas;
using CSharp.WorkingWithEPS;
using CSharp.WorkingWithFonts;

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
            //ApplyMeteredLicense.Run();
            // LoadLicenseFromStreamObject.Run();
            // SetLicenseUsingEmbeddedResource.Run();
            // SecureLicense.Run();

            // =====================================================
            // =====================================================
            // WorkingWithDocument
            // =====================================================
            // =====================================================
            CreateDocumentXPS.Run();
            ChangeDocumentXPS.Run();
            CreateDocumentPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithDocumentConversion
            // =====================================================
            // =====================================================
            PostScriptToPdf.Run();
            PostScriptToImage.Run();
            XPStoPNG.Run();
            XPStoBMP.Run();
            XPStoJPEG.Run();
            XPStoTIFF.Run();
            XPStoPDF.Run();

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
            CSharp.WorkingWithXMPMetadataInEPS.GetMetadata.Run();
            CSharp.WorkingWithXMPMetadataInEPS.AddMetadata.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_ChangeValues.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddSimpleProperties.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddArrayItems.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_ChangeArrayItems.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddNamedValueItem.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_ChangeNamedValueItem.Run();
            CSharp.WorkingWithXMPMetadataInEPS.ChangeMetadata_AddNamespace.Run();

            // =====================================================
            // =====================================================
            // WorkingWithText
            // =====================================================
            // =====================================================
            AddTextXPS.Run();
            AddTextUsingUnicodeStringXPS.Run();
            AddTextPS.Run();
            AddTextUsingUnicodeStringPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithImages
            // =====================================================
            // =====================================================
            AddImageXPS.Run();
            AddTiledImageXPS.Run();
            AddImagePS.Run();

            UseImageUtilitiesXPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithTextures
            // =====================================================
            // =====================================================
            AddTextureTilingPatternPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithHatchPattern
            // =====================================================
            // =====================================================
            AddHatchPatternPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithGradient
            // =====================================================
            // =====================================================
            AddDiagonalGradientXPS.Run();
            AddVerticalGradientXPS.Run();
            AddHorizontalGradientXPS.Run();
            AddHorizontalGradientPS.Run();
            AddVerticalGradientPS.Run();
            AddDiagonalGradientPS.Run();
            AddRadialGradient1PS.Run();
            AddRadialGradient2PS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithShapes
            // =====================================================
            // =====================================================
            AddRectangleXPS.Run();
            AddEllipseXPS.Run();
            ApplyDifferentColorSpacesXPS.Run();
            AddEllipsePS.Run();
            AddRectanglePS.Run();

            UseShapeUtilitiesXPS.Run();

            // =====================================================
            // =====================================================
            // WorkingWithPages
            // =====================================================
            // =====================================================
            AddPageXPS.Run();
            RemovePageXPS.Run();
            AddPage1PS.Run();
            AddPage2PS.Run();

            ModifyXpsPageOnConversion.Run();

            // =====================================================
            // =====================================================
            // WorkingWithPrintTickets
            // =====================================================
            // =====================================================
            GetPrintTickets.Run();
            LinkPrintTickets.Run();
            CreateCustomPrintTicket.Run();
            EditPrintTicket.Run();

            // =====================================================
            // =====================================================
            // WorkingWithTransparency
            // =====================================================
            // =====================================================
            AddTransparentObjectXPS.Run();
            SetOpacityMaskXPS.Run();
            ShowPseudoTransparencyPS.Run();
            AddTransparentImagePS.Run();

            // =====================================================
            // =====================================================
            //WorkingWithGrid
            // =====================================================
            // =====================================================
            AddGrid.Run();

            // =====================================================
            // =====================================================
            //WorkingWithCrossPackageOperations
            // =====================================================
            // =====================================================
            AddImageFilledGlyphAndForeignImage.Run();
            AddGlyphCloneAndChangeColor.Run();
            ManipulatePages.Run();

            // =====================================================
            // =====================================================
            //WorkingWithImageConversion
            // =====================================================
            // =====================================================
            SaveImageAsEPS.Run();

            // =====================================================
            // =====================================================
            //ResizeEPS
            // =====================================================
            // =====================================================
            ResizeEPS.RunPoints();
            ResizeEPS.RunInches();
            ResizeEPS.RunMms();
            ResizeEPS.RunPercents();
            CropEPS.Run();

            // =====================================================
            // =====================================================
            //WorkingWithFonts
            // =====================================================
            // =====================================================
            ConvertType1Font.Run();
            ConvertType3Font.Run();

            // =====================================================
            // =====================================================
            //WorkingWithCanvas
            // =====================================================
            // =====================================================
            TransformationsXPS.Run();
            ClippingXPS.Run();
            TransformationsPS.Run();
            ClippingPS.Run();


            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }

        public static String GetDataDir_GettingStarted()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "GettingStarted" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithGradient()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithGradient" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithVisualBrush()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithVisualBrush" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithImages()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithImages" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithTextures()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithTextures" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithShapes()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithShapes" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithText()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithText" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithPages()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithPages" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithPrintTickets()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithPrintTickets" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithTransparency()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithTransparency" + Path.DirectorySeparatorChar);
        }
        public static String GetDataDir_WorkingWithDocument()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithDocument" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithDocumentConversion()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithDocumentConversion" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithDocumentMerging()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithDocumentMerging" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithXMPMetadataInEPS()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithXMPMetadataInEPS" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithEPS()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithEPS" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithCrossPackageOperations()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithCrossPackageOperations" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithImageConversion()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithImageConversion" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithCanvas()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithCanvas" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithHatches()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithHatches" + Path.DirectorySeparatorChar);
        }

        public static String GetDataDir_WorkingWithFonts()
        {
            return Path.GetFullPath(RunExamples.GetDataDir_Data() + "WorkingWithFonts" + Path.DirectorySeparatorChar);
        }


        public static string GetDataDir_Data()
        {
#if ASPOSE_DRAWING
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
#else
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
#endif
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
            return Path.Combine(startDirectory, "Data" + Path.DirectorySeparatorChar);
        }
    }
}
