
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qpdf.Resume;

internal class ResumePreviewer
{

    public static void GeneratePreview()
    {
        var filePath = "resume.example1.pdf";
        var rDoc = new ResumeExample();
        // rDoc.GeneratePdf(filePath);
        rDoc.GeneratePdf();
        rDoc.ShowInPreviewer();
    }

    public static void GeneratePreviewAndFile(string path="resume.example1.pdf")
    {
        var filePath = path;
        var rDoc = new ResumeExample();
        rDoc.GeneratePdf(filePath);
        rDoc.ShowInPreviewer();
    }

}
