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

internal class Resume_doc_model
{
}

public class ResumeModel
{
    public ContactInformation Contact_Info { get; set; }
    public Education _Education { get; set;}

    public  Experiences _Experiences { get; set; }

    public Skills _Skills { get; set; }

    public Projects _Projects { get; set; }

}

public class ContactInformation
{
    public string Name { get; set; }
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public Uri Linkedin { get; set; }
    public Uri Github { get; set; }
}

public class Education
{
    public List<School> Schools { get; set; }

}

public class School
{
    public string Name { get; set; }
    public string Degree { get; set; }
    public DateTime GraduationDate { get; set; }
}

public class Experiences
{
    public List<Experience> Experience { get; set; }
}

public class Experience
{
    public string Company { get; set; }
    public string Role { get; set; }
    public DateTime Date { get; set; }
    public List<string> Jobs { get; set; }
}

public class Skills
{
    public Dictionary<string,string> SubSkills;
}

public class Projects
{
    public List<Project> _Projects;
}

public class Project
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
}