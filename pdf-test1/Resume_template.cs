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
using System.Reflection;

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
        container.Column(column =>
        {
            column.Item().Row(row =>
            {
                row.RelativeItem().Component(new Component_Contact("name", "email", "phone"));
            });
            column.Item().Row(row =>
            {
                row.RelativeItem().Component(new Component_Contact("name2", "email2", "phone2"));
            });
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
                // Contact Info
                // Name
                column.Item().Text($"{Model.Contact.Name}").Style(titleStyle);
                // Email
                column.Item().Text($"{Model.Contact.Email}");
                // Linkedin
                if (Model.Contact.Linkedin is not null)
                    column.Item().Hyperlink($"{Model.Contact.Linkedin}");
                // Phone
                column.Item().Text($"{Model.Contact.PhoneNumber}");
                // Github
                if (Model.Contact.Github is not null)
                    column.Item().Text($"{Model.Contact.Github}");
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
                var boldStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(Colors.Black);

                column.Item().Text("EDUCATION").Style(boldStyle);

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
                    column.Item().Text($"{exp.Company}" + Constants.LONG_SPACE + exp.StartDate.ToString("MMM yyyy") + "-" + exp.EndDate.ToString("MMM yyyy"));
                    column.Item().Text($"{exp.Role}");
                    foreach (string task in exp.Tasks)
                    {
                        column.Item().ScaleToFit().Text($"> {task}");
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