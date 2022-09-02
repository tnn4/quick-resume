using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuestPDF.Infrastructure;
using QuestPDF.Elements;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using System.Reflection;
using System.Numerics;
using System.Xml.Linq;
using System.Data.Common;

namespace pdf_test1.Resume;

internal class Resume_Components
{
}

#region 
public class Component_Section : IComponent
{
    public string Section { get; set; }

    public void Compose(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Text($"{Section}");
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

    public Component_Contact(string name, string email, string phone)
    {
        Name = name; Email = email; Phone = phone;
    }

    public Component_Contact(string name, string email, string phone, string linkedin, string github)
    {
        Name = name; Email = email; Phone = phone;
        Linkedin = new Uri(linkedin);
        Github = new Uri(github);
    }

    public void Compose(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                // Contact Info
                // Name
                column.Item().Text($"{Name}").Style(titleStyle);
                // Email
                column.Item().Text($"{Email}");
                // Linkedin
                if (Linkedin is not null)
                    column.Item().Hyperlink($"{Linkedin}");
                // Phone
                column.Item().Text($"{Phone}");
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
        var titleStyle = TextStyle.Default.FontSize(12).SemiBold().FontColor(Colors.Black);
        container.Row(row =>
        {
                // foreach
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("EDUCATION").Style(titleStyle);

                    foreach (School edu in Education)
                    {
                        column.Item().Text($"{edu.Name}");
                        column.Item().Text($"{edu.Degree}");
                        column.Item().Text($"{edu.GraduationDate}");
                    }

                    // Horizontal Line
                    column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Black);
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
                var boldStyle = TextStyle.Default.FontSize(12).SemiBold().FontColor(Colors.Black);

                column.Item().Text("EXPERIENCE").Style(boldStyle);


                foreach (Job job in Experiences)
                {
                    column.Item()
                    //.Text($"{job.Company}" + Constants.LONG_SPACE + job.StartDate.ToString("MMM yyyy") + "-" + job.EndDate.ToString("MMM yyyy"));
                    .Text($"{job.Company} {job.StartDate} - {job.EndDate}");
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
    public string SkillGroup { get; set; }
    public string SkillSub { get; set; }
    public Component_Skill()
    {

    }

    public void Compose(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"{SkillGroup}");
                column.Item().Text($"{SkillSub}");

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
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public Component_Projects(string name, string description)
    {
        ProjectName = name;
        Description = description;
    }

    public void Compose(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(16).SemiBold().FontColor(Colors.Black);
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"{ProjectName}");
                column.Item().Text($"{Description}");

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