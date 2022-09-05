using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using IContainer = QuestPDF.Infrastructure.IContainer;
using IComponent = QuestPDF.Infrastructure.IComponent;
using System.Data.Common;

namespace qpdf.Resume;


public class ResumeM : IDocument
{
    public Component_Contact? Contact { get; set; }
    public Component_Education? Education { get; set; }
    public Component_Experience? Experience { get; set; }
    public Component_Skill? Skills { get; set; }
    public Component_Projects? Projects { get; set; }

    public ResumeM()
    {

    }
    
    public ResumeM(Component_Contact contact, Component_Education education, Component_Experience experience, Component_Skill skills, Component_Projects projects)
    {
        Contact = contact;
        Education = education;
        Experience = experience;
        Skills = skills;
        Projects = projects;
    }

    // constructor that accepts path to file, then parses file into objects
    public ResumeM(string path)
    {
        // call Toml library to parse file
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    // Called by Generate PDF
    public void Compose(IDocumentContainer container)
    {
        // Compose logic here
        composeResume(container);
    }

    public void composeResume(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(20);
                // page.Header().Element(compose_contact);
                page.Content().Element(ComposeComponents);
                // page.Footer().Element();
            });
    }

    // Compose Components
    public void ComposeComponents(IContainer container)
    {
        container.Column(column =>
        {
            // CONTACT
            ContactColumn(column);

            // EDUCATION
            EducationColumn(column);

            // EXPERIENCE
            //ExperienceColumn(column);

            // SKILLS
            //SkillsColumn(column);

            // PROJECTS
            //ProjectsColumn(column);
        });
    }

    public void ContactColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            if (Contact is not null)
                row.RelativeItem().Component(Contact);
        });
    }

    public void EducationColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            if (Education is not null)
                row.RelativeItem().Component(Education);
        });
    }

    public void ExperienceColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            if (Experience is not null)
                row.RelativeItem().Component(Experience);
        });
    }

    public void SkillsColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            if (Skills is not null)
                row.RelativeItem().Component(Skills);
        });
    }

    public void ProjectsColumn(ColumnDescriptor column)
    {
        column.Item().Row(row =>
        {
            if (Projects is not null)
                row.RelativeItem().Component(Projects);
        });
    }

    public static ResumeM GenerateExample()
    {
        return new ResumeM()
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

            },

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
        }),

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
                        Role = "Owner",
                        StartDate = "May 1986",
                        EndDate = "May 2006",
                        Tasks = new List<string>
                        {
                            "made janky 3d animated films using computer graphics after getting kicked out at Crapple",
                        }
                    }
        }),

            /*
            Skills = new Component_Skill(new Dictionary<string, string>
            {
                    { "Design", "UX , UI, Ucry" },
                    { "Management", "yelling, micro-management, cutting budgets" },

            }),
            */

            Skills = new Component_Skill(new List<Skill>
            {
                new Skill
                {
                    MajorSkill = "Languages",
                    SubSkill = "English, French"
                },
                new Skill
                {
                    MajorSkill = "Programming Languages",
                    SubSkill = "C/C++, Python, C#, Java"
                }
            }),

        Projects = new Component_Projects(new Dictionary<string, string>
        {
            {"Crapple cryMac Computer", "Lead designer of the desktop computer that is so bad it will bring you to tears" },
            {"Crapple cryPod", "Designed an overpriced music player that actually doesn't really work that well" },
            {"Crapple cryPhone", "Lead designer on an overpriced touch screen smartphone that will make your wallet bleed and bring you to tears" },
            {"Crapple cryPad", "Lead designer of a tablet that's actually an overpriced brick" }
        })
    };
    }




    public void CreateColumnComponent(ColumnDescriptor column, IComponent component)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Component(component);
        });
    }


}