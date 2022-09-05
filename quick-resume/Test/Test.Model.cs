using Tomlet.Attributes;

namespace qpdf.Test;

// CONSTANTS
public static class Constants
{
    public const string SPACE = " ";
}

// DOCUMENT MODEL
public class ResumeModel
{
    public Contact Contact { get; set; }
    public List<School> _Education { get; set; }
    public List<Job> _Experiences { get; set; }
    public List<Skill> _Skills { get; set; }
    public List<Project> _Projects { get; set; }

}

// Generic Data Structure for Describing a Section
public class Resume_Section<T>
{
    public string? Title { get; set; }
    public List<T>? Nodes { get; set; }
}

// CONTACT
public class Contact
{
    [TomlProperty("name")]
    public string Name { get; set; }
    [TomlProperty("email")]
    public string Email { get; set; }
    [TomlProperty("phone")]
    public string Phone { get; set; }

    public Dictionary<string, string> Links { get; set; }

}

// EDUCATION
public class School
{
    public string Name { get; set; }
    public string Degree { get; set; }
    public string GraduationDate { get; set; }
}

// EXPERIENCE
public class Job
{
    public string Company { get; set; }
    public string Role { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public List<string> Tasks { get; set; }
}


// SKILL
public class Skill
{
    public string SkillGroup { get; set; }
    public string Subskill { get; set; }
    public Dictionary<string, string> _Skills { get; set; }

    public Skill(Dictionary<string, string> skills)
    {
        _Skills = skills;
    }
}

// PROJECT
public class Project
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string> _Projects { get; set; }

    public Project(Dictionary<string, string> projects)
    {
        _Projects = projects;
    }
}
