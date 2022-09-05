using QuestPDF.Fluent;
using QuestPDF.Previewer;

using qpdf.Invoice;
using qpdf.Resume;
using qpdf.Json;


using Tommy;

namespace qpdf.Test;

using static TestFn;


public class TestFn
{
    public static void test()
    {
        Console.WriteLine("invoked test function");
    }
}
public class TestJson
{
    public static void Serialize_Components()
    {
        var componentsExample = ResumeM.GenerateExample();
        Jsons.ToJsonFile(componentsExample, "componentsExample.json");
    }

    public static void SerializeToFile(object obj, string path)
    {
        if (obj is not null && path is not null)
            Jsons.ToJsonFile(obj, path);
        else
            Console.WriteLine("Error: Missing valid obj or path");
    }

    public static void Serialize_Experience()
    {
        var experiences = new List<Job>();


        experiences.Add(new Job
        {
            Company = "company",
            Role = "Role",
            StartDate = "Dec 2000",
            EndDate = "Jan 2001",
            Tasks = new List<string>
                {
                    "task1",
                    "task2",
                    "task3"
                }
        });

        Jsons.PrintJsonObject(experiences);

        Jsons.ToJsonFile(experiences, "experience.json");
    }


}