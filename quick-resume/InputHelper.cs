using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qpdf;

internal class InputHelper
{
    public static bool ArgsValid(string[] args)
    {
        if(args.Length == 0)
        {
            printWarning();
            return false;
        }
        if (args.Length == 2)
        {
            var str1 = args[0];
            var str2 = args[1];
            return true;
        }
        else
            return false;
    }

    public static void printWarning()
    {
        var warn = @"Warning: this program needs 2 arguments:
        path to input file(.toml), path to output file(.pdf)";
        var usage = "usage: quick-resume '/input/input.ResumeExample.toml' 'output/output.ResumeExample.pdf'";
        Console.WriteLine(warn);
        Console.WriteLine(usage);
    }
}
