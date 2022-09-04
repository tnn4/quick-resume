using qpdf.Resume;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

namespace qpdf.Preview;

internal class Previewer
{

    public void GeneratePreview()
    {
        var filePath = "resume.example1.pdf";
        var model = Resume_Data_Source.generateResumeExample();
        var rDoc = new ResumeExample();
        // rDoc.GeneratePdf(filePath);
        rDoc.GeneratePdf();
        rDoc.ShowInPreviewer();
    }

    public void GeneratePreviewAndFile(string path)
    {
        var filePath = path;
        var rDoc = new Resumes();
        rDoc.GeneratePdf(filePath);
        rDoc.ShowInPreviewer();
    }

}
