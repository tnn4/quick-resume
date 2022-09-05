
using qpdf.Resume;
using qpdf.Test;
using Tomlet;
using Tomlet.Models;

public class EntryPoint
{
    static void Main()
    {
        // ResumePreviewer.GeneratePreviewAndFile();

        // Resumes resume = new Resumes();

        // resume.getdata(filePath);

        // resume.generatePreview();

        // resume.generatePDF();
        TomlTest.TomletToConsole("examples/section.experience.eg.toml");
        
        
        var re = new ResumeExample();
        TomlTest.TomletToTomlFile(re, "output.ResumeExample.toml");


        var rM = ResumeM.GenerateExample();
        TomlTest.TomletToTomlFile(rM, "output.ResumeM.toml");

        Console.ReadLine();
    }
}