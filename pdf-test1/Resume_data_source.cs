using QuestPDF.Drawing;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace pdf_test1;

internal class Resume_data_source
{
    public static ResumeModel generateExampleResume()
    {
        return new ResumeModel
        {
            Contact = GenerateRandomContact(),

            _Education = GenerateRandomEducation(),

            _Experiences = GenerateRandomExperiences(), 

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

    public static List<Education> GenerateRandomEducation()
    {
        var schools = new List<Education>();

        schools.Add(new Education
        {
            Name = "NoWhere College",
            Degree = "B.S. Crapology",
            GraduationDate = new DateTime(1980, 12, 1)
        }) ;

        return schools;
    }

    public static List<Experience> GenerateRandomExperiences()
    {
        var experiences = new List<Experience>();
        var responsbilities = new List<string>();
        experiences.Add(new Experience
        {
            Company = "Crapple",
            Role = "Founder/CEO",
            StartDate = new DateTime(1976, 4, 1),
            EndDate = new DateTime(1985, 9, 16),
            Jobs = GenerateRandomJobs()
        });
        experiences.Add(new Experience
        {
            Company = "Flixar",
            Role = "CEO",
            StartDate = new DateTime(1986, 2, 3),
            EndDate = new DateTime(1987,1,2),
            Jobs = GenerateRandomJobs(),
            
        });


        return experiences;
    }

    public static List<string> GenerateRandomJobs()
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
}
