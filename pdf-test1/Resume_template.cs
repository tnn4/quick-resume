using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_test1;

internal class Resume_template
{
}

public partial class ResumeDoc : IDocument
{
    public ResumeModel Model { get; }

    public ResumeDoc(ResumeModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    
    public void Compose(IDocumentContainer container)
    {

    }
}

public partial class ResumeDoc : IDocument
{
    
    public void compose_resume_example(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(20);
                page.Header().Element(compose_contact);
            });
    }
    
    // Create Contact info template
    public void compose_contact(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"{Model.Contact_Info.Name}").Style(titleStyle);
                column.Item().Hyperlink($"{Model.Contact_Info.Linkedin}");
                column.Item().Text($"{Model.Contact_Info.PhoneNumber}");
                column.Item().Text($"{Model.Contact_Info.Github}");
                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });
        });
    }

    // Create Education background template
    public void compose_education()
    {

    }

    // Create (Work) Experience template
    public void compose_experience()
    {

    }

    // Create Skills template
    public void compose_skills()
    {

    }

    // Create Projects template
    public void compose_projects()
    {

    }
}