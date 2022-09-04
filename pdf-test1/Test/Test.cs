﻿using QuestPDF.Fluent;
using QuestPDF.Previewer;

using qpdf.Invoice;
using qpdf.Resume;
using qpdf.Json;

namespace qpdf.Test;

using static TestFn;


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
        // var resume_doc = new ResumeDoc(model);
        var resume_doc = new ResumeExample(model);
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
        var componentsExample = Resumes.GenerateExample();
        Jsons.ToJsonFile(componentsExample, "componentsExample.json");
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