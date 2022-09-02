using pdf_test1.Invoice;
using pdf_test1.Resume;
using QuestPDF.Fluent;
using QuestPDF.Previewer;


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

public class TestDoc
{

    public static void create_resume_example()
    {
        var filePath = "resume.example1.pdf";
        var model = Resume_Data_Source.generateResumeExample();
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

public class TestJson
{
    
    
    
    public static void Serialize_Components()
    {
        var componentsExample = new ResumeComponentsExample();
        Json.Write_To_Json_File(componentsExample, "componentsExample.json");
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

        Json.PrintSerializedObject(experiences);
        
        Json.Write_To_Json_File(experiences, "experience.json" );
    }

    public static void Serialize_Experiences()
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

        Json.Write_To_Json_File(experiences, "experiences.json");
    }


}