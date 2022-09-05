using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qpdf;

internal class FileHelper
{
    public static void CreateDirectory(string path)
    {
        // ResumePreviewer.GeneratePreviewAndFile();
        Directory.CreateDirectory("TestFolder");
    }

    public static void WriteToFile(string path)
    {
        File.WriteAllText("TestFolder/TestFiles.txt", "hello");
    }
}
