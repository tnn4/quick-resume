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

    public static bool ValidPath(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Invalid file. Please check that the file exists or that the path is typed correctly");
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool IsValidPath(string path, bool allowRelativePaths = false)
    {
        bool isValid = true;

        try
        {
            string fullPath = Path.GetFullPath(path);

            if (allowRelativePaths)
            {
                isValid = Path.IsPathRooted(path);
            }
            else
            {
                string root = Path.GetPathRoot(path);
                isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
            }
        }
        catch (Exception ex)
        {
            isValid = false;
        }

        return isValid;
    }
}
