using QuestPDF.Helpers;

namespace pdf_test1.Resume;

internal class Resume_Data_Source
{

    #region obsolete
    public static ResumeModel generateResumeExample()
    {
        return new ResumeModel
        {
            Contact = GenerateRandomContact(),

            _Education = GenerateRandomEducation(),

            _Experiences = GenerateRandomJobs(),

            _Skills = GenerateRandomSkills(),

            _Projects = GenerateRandomProjects()
        };
    }

    public static ContactInformation GenerateRandomContact()
    {
        var name = "Steve Jobsfinder";

        return new ContactInformation
        {
            Name = name,
            Email = "SteveJobsfinder@crapple.com",
            PhoneNumber = Placeholders.PhoneNumber(),
            Linkedin = new Uri("https://www.linkedin.com/in/" + name),
            Github = new Uri("https://www.github.com/" + name)
        };
    }

    public static List<School> GenerateRandomEducation()
    {
        var schools = new List<School>();

        schools.Add(new School
        {
            Name = "NoWhere College",
            Degree = "B.S. Crapology",
            // GraduationDate = new DateTime(1980, 12, 1)
            GraduationDate = "May 1980"
        });

        return schools;
    }

    public static List<Job> GenerateRandomJobs()
    {
        var Jobs = new List<Job>();
        var responsbilities = new List<string>();
        Jobs.Add(new Job
        {
            Company = "Crapple",
            Role = "Founder/CEO",
            // StartDate = new DateTime(1976, 4, 1),
            // EndDate = new DateTime(1985, 9, 16),
            StartDate = "Apr 1976",
            EndDate = "Sep 1985",
            Tasks = GenerateRandomTasks()
        });
        Jobs.Add(new Job
        {
            Company = "Flixar",
            Role = "CEO",
            // StartDate = new DateTime(1986, 2, 3),
            // EndDate = new DateTime(1987, 1, 2),
            StartDate = "Feb 1986",
            EndDate = "Jan 1987",
            Tasks = GenerateRandomTasks(),

        });


        return Jobs;
    }

    public static List<string> GenerateRandomTasks()
    {
        var jobs = new List<string>();
        jobs.Add("after getting kicked out of Crapple, founded a company that made janky 3d animations");
        jobs.Add("2nd job");
        return jobs;

    }

    public static List<Skill> GenerateRandomSkills()
    {
        var skills = new List<Skill>();
        skills.Add(new Skill
        {
            SkillGroup = "Languages",
            SubSkill = "English, German, French"
        });


        return skills;
    }

    public static List<Project> GenerateRandomProjects()
    {
        var projects = new List<Project>();
        projects.Add(new Project
        {
            ProjectName = "proj name 1",
            Description = "i built a cool 1st project"
        });
        projects.Add(new Project
        {
            ProjectName = "proj name 2",
            Description = "i built a cool 2nd project"
        });

        return projects;
    }
    #endregion
}
