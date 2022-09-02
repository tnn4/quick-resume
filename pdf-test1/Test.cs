using pdf_test1.Invoice;
using pdf_test1.Resume;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_test1;

using static TestFn;

internal class Test
{

}

public class TestFn
{
    public static void test()
    {
        Console.WriteLine("invoked test function");
    }
}

public class DocTest
{

    public static void create_test_resume1()
    {
        var filePath = "resume.test1.pdf";
        var model = Resume_data_source.generateExampleResume();
        var resume_doc = new ResumeDoc(model);
        resume_doc.GeneratePdf(filePath);
        resume_doc.ShowInPreviewer();
    }

    public static void create_invoice_doc()
    {
        var filePath = "invoice.pdf";
        var model = InvoiceDocumentDataSource.GetInvoiceDetails(); // data source
        var invoice_doc = new InvoiceDocument(model); // template layer
        invoice_doc.GeneratePdf(filePath);
    }

    public static void create_test_doc()
    {
        var document = Document.Create(container =>
        {
            container
            .Page(page => test()) // Page takes Action which is a delegate
            .Page(page => { test(); test(); })
            .Page(page =>
            {
                test();
                test();
            });

        });
        document.GeneratePdf("test1.pdf");
        document.ShowInPreviewer(12345);

    }
}

public class JsonTest
{
    public static void Test_Serialize_Experience()
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

        Json.PrintSerializedObject(experiences);
        
        Write_To_Json_File("experience.json", experiences);
    }

    public static void Test_Serialize_Experiences()
    {
        var experiences = new Experiences
        {
            Jobs = new List<Job>
            {
                new Job
                {
                    Company = "company",
                    Role = "role",
                    // StartDate = new DateTime(2000, 12, 30),
                    // EndDate = new DateTime(2001, 1, 1),
                    StartDate = "Dec 2000",
                    EndDate = "Jan 2001",
                    Tasks = new List<string>
                    {
                        "task1",
                        "task2",
                        "task3"
                    }
                },
                new Job
                {
                    Company = "company2",
                    Role = "role2",
                    // StartDate = new DateTime(2001, 12, 30),
                    // EndDate = new DateTime(2002, 1, 1),
                    StartDate = "Dec 2000",
                    EndDate = "Jan 2001",
                    Tasks = new List<string>
                    {
                        "task1.2",
                        "task2.2",
                        "task3.2"
                    }
                }
            }
        };

        Write_To_Json_File("experiences.json", experiences);
    }

    public static void Write_To_Json_File(string filePath, object obj)
    {
        var path = filePath;
        var jsonString = Json.SerializeObject(obj);
        File.WriteAllText(path, jsonString);
    }
}