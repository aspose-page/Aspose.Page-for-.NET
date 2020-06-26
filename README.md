# Aspose.Page-for-.NET

[Aspose.Page for .NET](https://products.aspose.com/page/net) Aspose.Page for .NET offers features of creating new as well as manipulating existing XPS and EPS documents. It also provides functionality to convert [XPS](https://wiki.fileformat.com/page-description-language/xps/) and [EPS](https://wiki.fileformat.com/page-description-language/eps/) files into [PDF](https://wiki.fileformat.com/view/pdf/) and Images Documents and vice versa.

<p align="center">

  <a title="Download complete Aspose.Page for .NET source code" href="https://github.com/aspose-page/Aspose.Page-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

This repository contains [Demos](Demos) and [Examples](Examples) projects for [Aspose.Page for .NET](https://products.aspose.com/page/net) to help you learn and write your own applications.

Directory | Description
--------- | -----------
[Demos](Demos)  | Aspose.Page for .NET Live Demos Source Code
[Examples](Examples)  | A collection of .NET examples that help you learn the product features

# XPS File Manipulation via .NET API

[Aspose.Page for .NET](https://products.aspose.com/page/net) is an on premise .NET API that allows you to add XPS manipulation features to your own applications. The API also supports to convert XPS, EPS & PS documents to other formats.

Developers can perform various operations on XPS documents, such as, add [text](https://docs.aspose.com/display/pagenet/Working+with+Text), [images](https://docs.aspose.com/display/pagenet/Working+with+Images), [pages](https://docs.aspose.com/display/pagenet/Working+with+Pages), [gradient](https://docs.aspose.com/display/pagenet/Working+with+Gradient), grid using [visual brush](https://docs.aspose.com/display/pagenet/Working+with+Visual+Brush), [transparency object](https://docs.aspose.com/display/pagenet/Add+Transparent+Object+inside+XPS+Document) and [set opacity mask](https://docs.aspose.com/display/pagenet/Set+Opacity+Mask). It allows to create, edit and convert the file pages as well as the ability to manipulate documents and elements, create vector graphics, group shapes and specifying colors in different color spaces including sRGB, scRGB, and any space based on ICC profile.

## XPS, EPS & PS Processing Features

- Create & modify XPS documents via API.
- [Add pages to XPS](https://docs.aspose.com/display/pagenet/Add+Pages+to+XPS+Document) documents.
- Create vector graphic shapes (Path element) and text strings (Glyphs element).
- Group various elements as well as modify the appearance of text strings and graphics.
- Support for visual brush, image brush, solid color brush and more.
- Work with multiple documents within an XPS document.
- Preserve print tickets and  add default print tickets to new XPS documents.
- Perform cross-package operations such as, inserting a page from another document.
- Conversion of XPS, PS & EPS documents to other popular formats.
- Supports PostScript language levels 1-3 with an exception of font types: Type2 (CFF), Type14 (Chameleon), Types 9, 10, 11, 32 (CID-Keyed).

## Read & Write XPS Format

**Fixed Layout:** XPS

## Save XPS, PS & EPS Documents As

**Fixed Layout:** PDF\
**Images:** PNG, JPEG, TIFF, BMP

## Save PS & EPS Documents As

**Metafiles:** EMF, WMF\
**Animation:** GIF

## Platform Independence

Aspose.Page for .NET can be integrated with any kind of ASP.NET Web Application or a Windows Application.

## Getting Started with Aspose.Page for .NET

Are you ready to give Aspose.Page for .NET a try? Simply execute `Install-Package Aspose.Page` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.Page for .NET and want to upgrade the version, please execute `Update-Package Aspose.Page` to get the latest version.

## Create an XPS Document from Scratch via C# Code

Execute below code snippet to see how Aspose.Page API performs in your own environment or check the [GitHub Repository](https://github.com/aspose-page/Aspose.Page-for-.NET) for other common usage scenarios. 

```csharp
// create XPS document
XpsDocument xDocs = new XpsDocument();
// add glyph to the document
var glyphs = xDocs.AddGlyphs("Arial", 12, FontStyle.Regular, 300f, 450f, "Hello World!");
glyphs.Fill = xDocs.CreateSolidColorBrush(Color.Black);
// save result
xDocs.Save(dir + "output.xps");
```

## Convert a PostScript (PS) File to PDF Format

Aspose.Page for .NET allows you to work with document conversion, such as; PS to images, PS to PDF, XPS to images, XPS to PDF and so on. The following snippet demonstrates the conversion of PS to PDF using streams:

```csharp
// initialize PostScript input stream
var psStream = new System.IO.FileStream(dir + "template.ps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
// initialize PDF output stream
var pdfStream = new System.IO.FileStream(dir + "output.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write);
// read PS file
var document = new PsDocument(psStream);
// create a device for output steram
var device = new PdfDevice(pdfStream);
try
{
    document.Save(device, options);
}
finally
{
    psStream.Close();
    pdfStream.Close();
}
```

[Product Page](https://products.aspose.com/page/net) | [Docs](https://docs.aspose.com/display/pagenet/Home) | [Demos](https://products.aspose.app/page/family) | [API Reference](https://apireference.aspose.com/page/net) | [Examples](https://github.com/aspose-page/Aspose.Page-for-.NET) | [Blog](https://blog.aspose.com/category/page/) | [Free Support](https://forum.aspose.com/c/page) |  [Temporary License](https://purchase.aspose.com/temporary-license)
