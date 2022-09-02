namespace pdf_test1.Resume;

internal class Resume_Model
{
}
// CONSTANTS
public static class Constants
{
    public const string SPACE = " ";
}

// DOCUMENT MODEL
public class ResumeModel
{
    public ContactInformation Contact { get; set; }
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
public class ContactInformation
{
    public string Name { get; set; }
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public Uri Linkedin { get; set; }
    public Uri Github { get; set; }
}

// EDUCATION
public class School
{
    public string Name { get; set; }
    public string Degree { get; set; }
    public string GraduationDate { get; set; }
}

public class Experiences
{
    public string label {
        get { return "experience";}
    }
    public List<Job>? Jobs { get; set; }
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
    public string SubSkill { get; set; }
}

// PROJECT
public class Project
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
}