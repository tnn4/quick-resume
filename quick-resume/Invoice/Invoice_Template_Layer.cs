using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using qpdf.Invoice;

namespace qpdf;

internal class Invoice_Template_Layer
{
}

/// <summary>
/// This class implements basic document structure. <br></br>
/// Has the model of the document that is defined in Document_Models
/// </summary>
public partial class InvoiceDocument : IDocument
{
    public InvoiceModel Model { get; }

    public InvoiceDocument(InvoiceModel model)
    {
        Model = model;
    }
    
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    /// <summary>
    /// GeneratePdf runs the code in here
    /// </summary>
    /// <param name="container"></param>
    public void Compose(IDocumentContainer container)
    {
        // compose_quick_start_example(container);
        compose_invoice_example(container);
    }

    public void compose_quick_start_example(IDocumentContainer container)
    {
        container
            .Page(page => // type: Action<PageDescriptor> 
            {
                page.Margin(50);

                page.Header().Height(100).Background(Colors.Grey.Lighten1);
                page.Content().Background(Colors.Grey.Lighten3);
                page.Footer().Height(50).Background(Colors.Grey.Lighten1);

                page.Footer().AlignCenter().Text(x => // type: Action<TextDescriptor>
                {
                    x.CurrentPageNumber();
                    // span = inline container used to makr part of a text or part of a document
                    // e.g.  span element used to color a part of text
                    // <p>My mother has <span style="color:blue">blue</span> eyes.</p> 
                    x.Span("/");
                    x.TotalPages();
                });
            });
    }

    public void compose_invoice_example(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Element(Compose_Header);
                page.Content().Element(Compose_Content);

                page.Footer().AlignCenter().Text(x =>
                {
                    /*
                    x.CurrentPageNumber();
                    x.Span("/");
                    x.TotalPages();
                    */
                    Compose_Footer(x);
                });
            });
    }
}

public partial class InvoiceDocument : IDocument
{
    // Header
    void Compose_Header(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
        // Row is a container that divides space into columns layout element
        container.Row( row =>
        {
            // Column is multi-element container
            row.RelativeItem().Column(column =>
            {
                // e.g.
                // Invoice #8000
                column.Item().Text($"Invoice #{Model.InvoiceNumber}").Style(titleStyle);

                // e.g.
                // Issue date: 10.11.2020
                column.Item().Text(text =>
                {
                    text.Span("Issue date: ").SemiBold();
                    text.Span($"{Model.IssueDate:d}");
                });

                // e.g.
                // Due date: 20.12.2020
                column.Item().Text(text =>
                {
                    text.Span("Due date: ").SemiBold();
                    text.Span($"{Model.DueDate:d}");
                });
            });

            row.ConstantItem(100).Height(50).Placeholder();
        });
    }

    // Content
    void Compose_Content(IContainer container)
    {
        container
            .PaddingVertical(40)
            .Height(250)
            .Background(Colors.Grey.Lighten3)
            .AlignCenter()
            .AlignMiddle()
            .Text("Content").FontSize(16);
    }

    // Table
    void Compose_Table(IContainer container)
    {
        container
            .Height(250)
            .Background(Colors.Grey.Lighten3)
            .AlignCenter()
            .AlignMiddle()
            .Text("Table").FontSize(16);
    }

    // Comments
    void Compose_Comments(IContainer container)
    {
        container
            .Background(Colors.Grey.Lighten3)
            .Padding(10)
            .Column(column =>
        {
            column.Spacing(5);
            column.Item().Text("Comments").FontSize(14);
            column.Item().Text(Model.Comments);
        });
    }

    void Compose_Footer(TextDescriptor x)
    {
        x.CurrentPageNumber();
        x.Span("/");
        x.TotalPages();
    }
}

public static class InvoiceDocumentExtensions
{
    public static void Compose_Footer( TextDescriptor x)
    {
        x.CurrentPageNumber();
        x.Span("/");
        x.TotalPages();
    }
}