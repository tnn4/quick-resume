using QuestPDF.Infrastructure;
using QuestPDF.Elements;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

namespace qpdf.Resume;

internal class Resume_Components
{
}

#region 
public class Component_Section : IComponent
{
    public string SectionName { get; set; }
    public IComponent Component { get; set; }

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
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Uri? Linkedin { get; set; }
    public Uri? Github { get; set; }

    public Component_Contact()
    {

    }
    public Component_Contact(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public Component_Contact(string name, string email, string phone, string linkedin, string github)
    {
        Name = name; 
        Email = email; 
        Phone = phone;
        Linkedin = new Uri(linkedin);
        Github = new Uri(github);
    }

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
                // Linkedin
                if (Linkedin is not null)
                    column.Item().Text($"{Linkedin}");
                // Github
                if (Github is not null)
                    column.Item().Text($"{Github}");
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
    public List<School> Education { get; set; }
    public Component_Education(List<School> education)
    {
        Education = education;
    }

    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
                // foreach here if you want row | row
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("EDUCATION").Style(Style.SectionStyle);

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
    public List<Job> Experiences { get; set; }

    public Component_Experience()
    {
        Experiences = new List<Job>();
        Experiences.Add(new Job
        {
            Company = "",
            Role = "",
            StartDate = "",
            EndDate = "",
            Tasks = new List<string>()
        });
    }

    public Component_Experience(List<Job> experiences)
    {
        Experiences = experiences;
    }
    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                

                column.Item().Text("EXPERIENCE").Style(Style.SectionStyle);


                foreach (Job job in Experiences)
                {
                    /*
                    //.Text($"{job.Company}" + Constants.LONG_SPACE + job.StartDate.ToString("MMM yyyy") + "-" + job.EndDate.ToString("MMM yyyy"));
                    //.Text($"{job.Company} {job.StartDate} - {job.EndDate}");
                        .Text(text =>
                        {
                            text.Span($"{job.Company}");
                        });
                    */
                    column.Item().Row(row =>
                    {
                        // HELLO         Start Date - End Date
                        row.RelativeItem().Text($"{job.Company}");
                        row.RelativeItem().AlignRight().Text($"{job.StartDate} - {job.EndDate}");
                    });

                    column.Item().Text($"{job.Role}").Italic();
                    
                    foreach (string task in job.Tasks)
                    {
                        column.Item().ScaleToFit().Text($"> {task}");
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
    public Dictionary<String, String> Skills { get; set; }
    
    public Component_Skill(Dictionary<String, String> skills)
    {
        Skills = skills;
    }

    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
            
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("SKILLS AND INTERESTS").Style(Style.SectionStyle);
                foreach (KeyValuePair<string,string> kvp in Skills)
                {
                    // column.Item().Text($"{kvp.Key}: {kvp.Value}");
                    column.Item().Text(text =>
                    {
                        text.Span($"{kvp.Key}: ").Bold();
                        text.Span($"{kvp.Value}");
                    });
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
    public Dictionary<string,string> Projects { get; set; }
    public Component_Projects(Dictionary<String, String> projects)
    {
        Projects = projects;
    }

    public void Compose(IContainer container)
    {

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("PROJECTS").Style(Style.SectionStyle);
                foreach (KeyValuePair<string, string> kvp in Projects)
                {
                    column.Item().Text($"{kvp.Key}").Style(Style.SubsectionStyle);
                    column.Item().Text($"{kvp.Value}");
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