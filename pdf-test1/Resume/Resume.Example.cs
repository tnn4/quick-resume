using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using IContainer = QuestPDF.Infrastructure.IContainer;
using IComponent = QuestPDF.Infrastructure.IComponent;

using Tommy;

namespace qpdf.Resume;
/// <summary>
/// Data source for examples
/// </summary>
public partial class ResumeExample : IDocument
{
    public ResumeModel Model { get; }

    public Component_Contact Contact { get; set; }
    public Component_Education Education { get; set; }
    public Component_Experience Experience { get; set; }
    public Component_Skill Skills { get; set; }
    public Component_Projects Projects { get; set; }

    public ResumeExample(ResumeModel model)
    {
        Model = model;
    }

    public ResumeExample()
    {
        Contact = new Component_Contact
        {
            Name = "Steve Jobsfinder",
            Email = "sjobsfinder@crapple.com",
            Phone = "123-456-7890",
            Links = new Dictionary<string, string>
                {
                    { "Linkedin", "https://linkedin.com/in/steve-jobsfinder"},
                    { "Github", "https://github.com/sjobsfinder"}
                }
        };

        Education = new Component_Education(new List<School>
        {
                    new School
                    {
                        Name = "Northsouthern University",
                        Degree = "B.S. Marketing",
                        GraduationDate = "May 1970"
                    },
                    new School
                    {
                        Name = "Southnorthern University",
                        Degree = "MBA",
                        GraduationDate = "May 1972"
                    }
        });

        Experience = new Component_Experience(new List<Job>
        {
                    new Job
                    {
                        Company = "Crapple Inc",
                        Role = "Founder/CEO",
                        StartDate = "Jan 1976",
                        EndDate = "Sep 1985",
                        Tasks = new List<string>
                        {
                            "Founded an electronics startup in a garage ",
                            "Designed the overpriced electronics for the masses",
                        }
                    },
                    new Job
                    {
                        Company = "Flixar",
                        Role = "Founder/CEO",
                        StartDate = "May 1986",
                        EndDate = "May 2006",
                        Tasks = new List<string>
                        {
                            "made janky 3d animated films using computer graphics after getting kicked out at Crapple",
                        }
                    }
        });
        /*
        Skills = new Component_Skill(new Dictionary<string, string>
        {
                { "Design", "UX , UI, Ucry" },
                { "Management", "yelling, micro-management, cutting budgets" },

        });
        */

        Skills = new Component_Skill(new List<Skill>
        {
            new Skill
            {
                SkillGroup = "",
                SkillSub = ""
            },
            new Skill
            {
                SkillGroup = "",
                SkillSub = ""
            }
        });
        Projects = new Component_Projects(new Dictionary<string, string>
        {
            {"Crapple cryMac Computer", "Lead designer of the desktop computer that is so bad it will bring you to tears" },
            {"Crapple cryPod", "Designed an overpriced music player that actually doesn't really work that well" },
            {"Crapple cryPhone", "Lead designer on an overpriced touch screen smartphone that will make your wallet bleed and bring you to tears" },
            {"Crapple cryPad", "Lead designer of a tablet that's actually an overpriced brick" }
        });
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        compose_resume_example(container);
    }
}
public partial class ResumeExample : IDocument
{


    public void compose_resume_example(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(20);
                // page.Header().Element(compose_contact);
                page.Content().Element(compose_components_example);
                // page.Footer().Element();
            });
    }

    // Compose Components
    public void compose_components_example(IContainer container)
    {
        container.Column(column =>
        {
            // CONTACT
            ContactColumnExample(column);

            // EDUCATION
            EducationColumnExample(column);

            // EXPERIENCE
            ExperienceColumnExample(column);
            
            // SKILLS
            SkillsColumnExample(column);
            
            // PROJECTS
            ProjectsColumnExample(column);
        });
    }


    #region example_component_functions

    public void CreateColumn(ColumnDescriptor column, IComponent component)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(component);
        });
    }

    public void ContactColumnExample(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(new Component_Contact
            {
                Name = "Steve Jobsfinder",
                Email = "sjobsfinder@crapple.com",
                Phone = "123-456-7890",
                Links = new Dictionary<string, string>
                {
                    { "Linkedin", "https://linkedin.com/in/steve-jobsfinder"},
                    { "Github", "https://github.com/sjobsfinder"}
                }
            });
        });
    }

    public void EducationColumnExample(ColumnDescriptor column)
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

    public void ExperienceColumnExample(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(new Component_Experience(new List<Job>
                {
                    new Job
                    {
                        Company = "Crapple",
                        Role = "Founder/CEO",
                        StartDate = "Jan 1976",
                        EndDate = "Sep 1985",
                        Tasks = new List<string>
                        {
                            "Founded an electronics startup in a garage ",
                            "Designed the overpriced electronics for the masses",
                        }
                    },
                    new Job
                    {
                        Company = "Flixar",
                        Role = "Founder/CEO",
                        StartDate = "May 1986",
                        EndDate = "May 2006",
                        Tasks = new List<string>
                        {
                            "made janky 3d animated films using computer graphics after getting kicked out at Crapple",
                        }
                    }
                }));
        });
    }

    public void SkillsColumnExample(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            /*
            row.RelativeItem().Component(new Component_Skill(new Dictionary<string, string>
            {
                { "Design", "calligraphy , UX , UI" },
                { "Management", "yelling, micro-management, cutting budgets" },
            }));
            */
            row.RelativeItem().Component(new Component_Skill(new List<Skill>
            {
                new Skill
                {
                    SkillGroup = "Programming Languages",
                    SkillSub = "C/C++, Python, C#, Java"
                },
                new Skill
                {
                    SkillGroup = "",
                    SkillSub = ""
                }
            }));
        });
    }

    public void ProjectsColumnExample(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(new Component_Projects(new Dictionary<string, string>
            {
                {"Crapple cryMac Computer", "Lead designer of the desktop computer that is so bad it will bring you to tears" },
                {"Crapple cryPod", "Designed an overpriced music player that actually doesn't really work that well" },
                {"Crapple cryPhone", "Lead designer on an overpriced touch screen smartphone that will make your wallet bleed and bring you to tears" },
                {"Crapple cryPad", "Lead designer of a tablet that's actually an overpriced brick" }
            }));
        });
    }
}

#endregion
