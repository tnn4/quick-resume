
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
        TomlTest.TomletTestExample("examples/section.experience.eg.toml");

        var re = new ResumeExample();
        TomlDocument tomlDoc = TomletMain.DocumentFrom(re);
        string tomlString = TomletMain.TomlStringFrom(re);
        Console.WriteLine(tomlString);
        File.WriteAllText("examples/output.ResumeExample.toml", tomlString);
        Console.ReadLine();
    }
}