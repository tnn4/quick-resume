using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using IContainer = QuestPDF.Infrastructure.IContainer;
using System.Xml.Linq;
using System.Data.Common;

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
        compose_resume_example(container);
    }
}

public partial class ResumeDoc : IDocument
{
    public  string LONG_SPACE = "                                                    ";

    public void compose_resume_example(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(20);
                page.Header().Element(compose_contact);
                page.Content().Element(compose_content);

            });
    }
    
    public void compose_content(IContainer container)
    {
        compose_experience(container);
        compose_education(container);
        compose_skills(container);
        compose_projects(container);

    }
    // Create Contact info template
    public void compose_contact(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                // Contact Info
                column.Item().Text($"{Model.Contact_Info.Name}").Style(titleStyle);
                column.Item().Text($"{Model.Contact_Info.Email}");
                column.Item().Hyperlink($"{Model.Contact_Info.Linkedin}");
                column.Item().Text($"{Model.Contact_Info.PhoneNumber}");
                column.Item().Text($"{Model.Contact_Info.Github}");
                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });
        });
    }

    // Create Education background template
    public void compose_education(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                foreach (Education edu in Model._Education)
                {
                    container.Column(column =>
                    {

                        column.Item().Text($"{edu.Name}");
                        column.Item().Text($"{edu.Degree}");
                        column.Item().Text($"{edu.GraduationDate}");

                    });
                }
            });
        });

        


    }

    // Create (Work) Experience template
    public void compose_experience(IContainer container)
    {
        

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                var boldStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(Colors.Black);
                
                column.Item().Text("EXPERIENCE").Style(boldStyle);

                
                foreach (Experience exp in Model._Experiences)
                {
                    column.Item().Text($"{exp.Company}" + LONG_SPACE + exp.StartDate.ToString("MMM yyyy") + "-" + exp.EndDate.ToString("MMM yyyy"));

                    column.Item().Text($"{exp.Role}");
                    foreach (string job in exp.Jobs)
                    {
                        column.Item().ScaleToFit().Text($"> {job}");
                    }
                    
                    
                }
                
                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });
            // row.RelativeItem().Column()
        });
        
    }

    // Create Skills template
    public void compose_skills(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                var boldStyle = TextStyle.Default.FontSize(12).SemiBold().FontColor(Colors.Black);

                column.Item().Text("SKILLS").Style(boldStyle);

                foreach (Skill skill in Model._Skills)
                {

                }
                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });

            // row.RelativeItem().Column()
        });
    }

    // Create Projects template
    public void compose_projects(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                var boldStyle = TextStyle.Default.FontSize(12).SemiBold().FontColor(Colors.Black);
                column.Item().Text("PROJECTS").Style(boldStyle);

                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });

        }
        );
    }
}