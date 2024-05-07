![Nuget](https://img.shields.io/nuget/v/Aspose.Page) ![Nuget](https://img.shields.io/nuget/dt/Aspose.Page) ![GitHub](https://img.shields.io/github/license/aspose-page/Aspose.Page-for-.NET)

# XPS & Postscript File Manipulation API

[Aspose.Page for .NET](https://products.aspose.com/page/net) is an on premise .NET API that allows you to add XPS manipulation features to your own applications. The API also supports to convert XPS, EPS & PS documents to other formats.

<p align="center">

  <a title="Download complete Aspose.Page for .NET source code" href="https://github.com/aspose-page/Aspose.Page-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Demos](Demos)  | Source code for live demos hosted at https://products.aspose.app/page/family.
[Examples](Examples)  | A collection of .NET examples that help you learn the product features.

## XPS, EPS & PS Processing Features

- Create & modify XPS documents via API.
- [Add pages to XPS](https://docs.aspose.com/page/net/add-pages-to-xps-document/) documents.
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
> [!IMPORTANT] 
> From version 24.4 we started to support non-Windows operation systems, like Linux, MacOS etc. New nuget package [Aspose.Page.Drawing](https://www.nuget.org/packages/Aspose.Page.Drawing) 
has been released for this purpose. The separate solutions for .Net Standard 2.0 and .NET 7.0 are added to these examples.

## Get Started with Aspose.Page for .NET

Are you ready to give Aspose.Page for .NET a try? Simply execute `Install-Package Aspose.Page` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.Page for .NET and want to upgrade the version, please execute `Update-Package Aspose.Page` to get the latest version.

## Create an XPS Document from Scratch

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

```csharp
// read PS file
var document = new PsDocument(dir + "template.ps");
// create a device for output steram
var device = new PdfDevice(dir + "output.pdf");
// save PS document as PDF
document.SaveAsPdf(dir + "output.pdf", new PdfSaveOptions());
```

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/page/net) | [Docs](https://docs.aspose.com/page/net/) | [Demos](https://products.aspose.app/page/family) | [API Reference](https://apireference.aspose.com/page/net) | [Examples](https://github.com/aspose-page/Aspose.Page-for-.NET) | [Blog](https://blog.aspose.com/category/page/) | [Search](https://search.aspose.com/) | [Free Support](https://forum.aspose.com/c/page) |  [Temporary License](https://purchase.aspose.com/temporary-license)
