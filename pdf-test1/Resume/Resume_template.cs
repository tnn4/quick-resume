using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using IContainer = QuestPDF.Infrastructure.IContainer;
using IComponent = QuestPDF.Infrastructure.IComponent;

using System.ComponentModel;

using pdf_test1.Resume;

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
            // EDUCATION

            EducationColumn(column);
            
            // EXPERIENCE

            column.Item().Row(row =>
            {
                row.RelativeItem().Component(new Component_Experience(new List<Job>
                {
                    new Job
                    {
                        Company = "company",
                        Role = "role",
                        StartDate = "May 1000",
                        EndDate = "May 2000",
                        Tasks = new List<string>
                        {
                            "task 1", "task 2", "task 3"
                        }
                    },
                    new Job
                    {
                        Company = "company",
                        Role = "role",
                        StartDate = "May 1000",
                        EndDate = "May 2000",
                        Tasks = new List<string>
                        {
                            "task 1", "task 2", "task 3"
                        }
                    }
                }));
            });

            // SKills
            SkillsColumn(column);
            // Projects
        });
    }

    #region component_functions

    public void EducationColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(new Component_Education(new List<School>
                {
                    new School
                    {
                        Name = "Northsouthern University",
                        Degree = "B.S. Marketing",
                        GraduationDate = "May 1990"
                    },
                    new School
                    {
                        Name = "Southnorthern University",
                        Degree = "M.S. Finance",
                        GraduationDate = "May 1992"
                    }
                }));
        });
    }

    public void ExperienceColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(new Component_Experience(new List<Job>
                {
                    new Job
                    {
                        Company = "company",
                        Role = "role",
                        StartDate = "May 1000",
                        EndDate = "May 2000",
                        Tasks = new List<string>
                        {
                            "task 1", "task 2", "task 3"
                        }
                    },
                    new Job
                    {
                        Company = "company",
                        Role = "role",
                        StartDate = "May 1000",
                        EndDate = "May 2000",
                        Tasks = new List<string>
                        {
                            "task 1", "task 2", "task 3"
                        }
                    }
                }));
        });
    }

    public void SkillsColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(new Component_Skill(new Dictionary<string, string>
            {
                { "skill type 1", "skill1 , skill2 , skill3" },
                { "skill type 2", "skill2.1, skill2.2, skill 2.3" },
                { "skill type 3", "skill3.1, skill3.2, skill 3.3" },
            }));
        });
    }

    public void ProjectsColumn(ColumnDescriptor column)
    {

    }
    #endregion

    public void compose_section(IContainer container, string section_name, IComponent component)
    {
        container.Column(column =>
        {
            column.Item().Row(row =>
            {
                row.RelativeItem().Component(new Component_Section
                {
                    Section = section_name
                });
            });
            column.Item().Row(row =>
            {
                if (component is null)
                    row.RelativeItem().Component(new Component_Empty());
                else
                    row.RelativeItem().Component(component);
            });
        });
    }

    // Contact info
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

    // Education
    public void compose_education(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                var boldStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(Colors.Black);

                column.Item().Text("EDUCATION").Style(boldStyle);

                foreach (School edu in Model._Education)
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

    // Experience
    public void compose_experience(IContainer container)
    {
        

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                var boldStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(Colors.Black);
                
                column.Item().Text("EXPERIENCE").Style(boldStyle);

                
                foreach (Job exp in Model._Experiences)
                {
                    // column.Item().Text($"{exp.Company}" + Constants.LONG_SPACE + exp.StartDate.ToString("MMM yyyy") + "-" + exp.EndDate.ToString("MMM yyyy"));
                    column.Item().Text($"{exp.Company} {exp.StartDate}-{exp.EndDate}");
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

    // Skills
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

    // Projects
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