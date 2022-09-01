﻿using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

using pdf_test1;

using static TestFn;

public class EntryPoint
{
    static void Main()
    {
        DocTest.create_resume_test1();
    }
}

public class TestFn
{
    public static void test() {
        Console.WriteLine("invoked test function");
    }
}

public class DocTest
{
    
    public static void create_resume_test1()
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