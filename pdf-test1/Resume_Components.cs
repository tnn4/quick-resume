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

namespace pdf_test1;

internal class Resume_Components
{
}

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

    public Component_Contact(string name, string email, string phone, string linkedin, string github )
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

#region Experience

public class Component_Experience : IComponent
{
    public List<Experience> Experiences { get; set; }

    public Component_Experience()
    {
        Experiences = new List<Experience>();
        Experiences.Add(new Experience
        {
            Company = "",
            Role = "",
            StartDate = new DateTime(0, 0, 0),
            EndDate = new DateTime(1,1,1),
            Tasks = new List<string>()
        }) ;
    }


    public void Compose(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                var boldStyle = TextStyle.Default.FontSize(14).SemiBold().FontColor(Colors.Black);

                column.Item().Text("EXPERIENCE").Style(boldStyle);


                foreach (Experience exp in Experiences)
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
            
        });
    }
}

#endregion