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
// CONSTANTS
public static class Constants
{
    public const string LONG_SPACE = "                                                      ";
}

// DOCUMENT MODEL
public class ResumeModel
{
    public ContactInformation Contact { get; set; }
    public List<Education> _Education { get; set;}

    public  List<Experience> _Experiences { get; set; }

    public List<Skill> _Skills { get; set; }

    public List<Project> _Projects { get; set; }

}
// CONTACT
public class ContactInformation
{
    public string Name { get; set; }
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public Uri Linkedin { get; set; }
    public Uri Github { get; set; }
}

// EDUCATION
public class Education
{
    public string Name { get; set; }
    public string Degree { get; set; }
    public DateTime GraduationDate { get; set; }
}

// EXPERIENCE
public class Experience
{
    public string Company { get; set; }
    public string Role { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<string> Tasks { get; set; }
}


// SKILL
public class Skill
{
    public string SkillGroup { get; set; }
    public string SubSkill { get; set; }
}

// PROJECT
public class Project
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
}