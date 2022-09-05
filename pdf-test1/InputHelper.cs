using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qpdf;

internal class InputHelper
{
    public static void checkArgs(string[] args)
    {
        if(args.Length == 0)
        {
            printWarn();
        }
        if(args.Length == 2)
        {
            var str1 = args[0];
            var str2 = args[1];
        }
    }

    public static void printWarn()
    {
        var warn = @"Warning: this program needs 2 arguments:
        path to input file(.toml), path to output file(.pdf)";
        var usage = "usage: quick-resume 'in.file.toml' 'out.file.pdf'";
        Console.WriteLine(warn);
        Console.WriteLine(usage);
    }
}
