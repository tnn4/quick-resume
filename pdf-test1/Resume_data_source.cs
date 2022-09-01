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
            Contact_Info = GenerateRandomContact(),

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
            Email = Placeholders.Email(),
            PhoneNumber = Placeholders.PhoneNumber(),
            Linkedin = new Uri("https://www.linkedin.com/in/" + name),
            Github = new Uri("https://www.github.com/" + name)
        };
    }

    public static Education GenerateRandomEducation()
    {
        var schools = new List<School>();

        schools.Add(new School
        {
            Name = "NoWhere College",
            Degree = "B.S. Crapology",
            GraduationDate = new DateTime(1980, 12, 1)
        }) ;

        return new Education
        {
            Schools = schools
        };
    }

    public static Experiences GenerateRandomExperiences()
    {
        var experiences = new List<Experience>();
        var responsbilities = new List<string>();
        
        experiences.Add(new Experience
        {
            Company = "Flixar",
            Role = "CEO",
            Date = new DateTime(1986, 2, 3),
            Jobs = GenerateRandomJobs(),
            
        });


        return new Experiences
        {
            Experience = experiences
        };
    }

    public static List<string> GenerateRandomJobs()
    {
        var jobs = new List<string>();
        jobs.Add("1st job");
        jobs.Add("2nd job");
        return jobs;

    }

    public static Skills GenerateRandomSkills()
    {
        var skills = new Dictionary<string, string>();
        skills.Add("Languages", "English, Spanish, German, Russian, Japanese");
        skills.Add("Random", "calligraphy");


        return new Skills
        {
            SubSkills = skills
        };
    }

    public static Projects GenerateRandomProjects()
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

        return new Projects
        {
            _Projects = projects
        };
    }
}
