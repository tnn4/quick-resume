using QuestPDF.Infrastructure;
using QuestPDF.Elements;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

namespace qpdf.Resume;
// Components are Models and Templates for the Document
// Fields and properties of the components act as the Model
// The Compose method act as the Templating for the data
#region 
public class Component_Section : IComponent
{
    // Data
    public string SectionName { get; set; }
    public IComponent Component { get; set; }

    // Constructors

    // Methods
    public void Compose(IContainer container)
    {
        PrintTitle(container);
    }

    public void PrintTitle(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Text($"{SectionName}");
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"{SectionName}");
            });
        });
    }
}
#endregion

#region Contact
public class Component_Contact : IComponent
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Dictionary<string, string>? Links { get; set; }

    // Constructors
    public Component_Contact()
    {

    }
    public Component_Contact(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public Component_Contact(string name, string email, string phone, Dictionary<string,string> links)
    {
        Name = name; 
        Email = email; 
        Phone = phone;
        Links = links;
    }

    // Printed in PDF
    public void Compose(IContainer container)
    {
        
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                // Contact Info
                // Name
                column.Item().Text($"{Name}").Style(Style.TitleStyle);
                // Email
                column.Item().Text($"{Email}");
                // Phone
                column.Item().Text($"{Phone}");
                /*
                // Linkedin
                if (Linkedin is not null)
                    column.Item().Text($"{Linkedin}");
                // Github
                if (Github is not null)
                    column.Item().Text($"{Github}");
                */
                if (Links is not null)
                {
                    foreach (KeyValuePair<string, string> kvp in Links)
                    {
                        column.Item().Text($"{kvp.Key}: {kvp.Value} ");
                    }
                }

                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });
        });
    }
}
#endregion

#region Education

public class Component_Education : IComponent
{
    // Data
    public List<School>? Education { get; set; }

    // Constructors
    public Component_Education()
    {

    }

    public Component_Education(List<School> education)
    {
        Education = education;
    }

    // Printed in PDF
    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
                // foreach here if you want row | row
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("EDUCATION").Style(Style.SectionStyle);

                    if (Education is not null)
                    {
                        foreach (School edu in Education)
                        {
                            // column.Item().Text($"{edu.Name}");
                            // Row relative item | relative item |
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text($"{edu.Name}");
                                row.RelativeItem().AlignRight().Text($"{edu.GraduationDate}");
                            });
                            // column item
                            // column item
                            column.Item().Text($"{edu.Degree}").Italic();
                            // column.Item().Text($"{edu.GraduationDate}");
                        }
                    }


                    // Horizontal Line
                    column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
                    // Line.make_horizontal_line_break(column, Colors.Red.Medium);
                });


        });

    }
}

#endregion

#region Experience

public class Component_Experience : IComponent
{
    // Data
    public List<Job>? Jobs { get; set; }

    // Constructors
    public Component_Experience()
    {

    }

    public Component_Experience(List<Job> jobs)
    {
        Jobs = jobs;
    }

    // Printed in PDF
    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                

                column.Item().Text("EXPERIENCE").Style(Style.SectionStyle);

                if (Jobs is not null)
                {
                    foreach (Job job in Jobs)
                    {

                        column.Item().Row(row =>
                        {
                            // HELLO         Start Date - End Date
                            row.RelativeItem().Text($"{job.Company}").Bold();
                            row.RelativeItem().AlignRight().Text($"{job.StartDate} - {job.EndDate}");
                        });

                        column.Item().Text($"{job.Role}").Italic();

                        foreach (string task in job.Tasks)
                        {
                            // remove ScaleToFit()
                            column.Item().ScaleToFit().Text($"> {task}");
                        }
                    }
                }


                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);

            });

        });
    }
}

#endregion

#region Skills
public class Component_Skill : IComponent
{
    // Data
    public List<Skill>? Skills { get; set; }

    // public Dictionary<String, String>? SkillsDict { get; set; }

    // Constructors
    public Component_Skill()
    {

    }
    
    public Component_Skill(List<Skill> skills)
    {
        Skills = skills;
    }
    
    /*
    public Component_Skill(Dictionary<String, String> skills)
    {
        SkillsDict = skills;
    }
    */
    // Printed in PDF
    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
            
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("SKILLS AND INTERESTS").Style(Style.SectionStyle);
                /*
                foreach (KeyValuePair<string,string> kvp in SkillsDict)
                {
                    // column.Item().Text($"{kvp.Key}: {kvp.Value}");
                    column.Item().Text(text =>
                    {
                        text.Span($"{kvp.Key}: ").Bold();
                        text.Span($"{kvp.Value}");
                    });
                }
                */
                if (Skills is not null)
                {
                    foreach (Skill skill in Skills)
                    {
                        column.Item().Text(text =>
                        {
                            text.Span($"{skill.MajorSkill} : ").Bold();
                            text.Span($"{skill.SubSkill}");
                        });
                    }
                }

                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });
        });
    }

}
#endregion

#region Projects
public class Component_Projects : IComponent
{
    // Data
    // public List<Project>? Projects { get; set; }
    public Dictionary<string,string>? ProjectsDict { get; set; }
    
    // Constructors
    public Component_Projects()
    {

    }
    /*
    public Component_Projects(List<Project> projects)
    {
        Projects = projects;
    }
    */
    public Component_Projects(Dictionary<String, String> projects)
    {
        ProjectsDict= projects;
    }

    // Printed in PDF
    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("PROJECTS").Style(Style.SectionStyle);
                
                
                if (ProjectsDict is not null)
                {
                    foreach (KeyValuePair<string, string> kvp in ProjectsDict)
                    {
                        column.Item().Text($"{kvp.Key}").Style(Style.SubsectionStyle);
                        column.Item().Text($"{kvp.Value}");
                    }
                }

                
                // Horizontal Line
                column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
            });
        });
    }

}
#endregion

public class Component_Empty : IComponent
{
    public void Compose(IContainer container)
    {

    }
}

public static class Style
{
    public static TextStyle TitleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);
    public static TextStyle SectionStyle = TextStyle.Default.FontSize(12).SemiBold().FontColor(Colors.Black);
    public static TextStyle SubsectionStyle = TextStyle.Default.FontSize(11).SemiBold().FontColor(Colors.Black);
}

public static class Line
{
    public static void LineHorizontal(ColumnDescriptor column, string color=Colors.Black)
    {
        column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(color);
    }
}