using qpdf.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Tomlet;
using Tomlet.Models;

namespace qpdf.Test;

internal class TomlTest
{

    string TomlTestString1 = "title = \"TOML Example\"\r\n\r\n[owner]\r\nname = \"Tom Preston-Werner\"\r\ndob = 1979-05-27T07:32:00-08:00\r\n\r\n[database]\r\nserver = \"192.168.1.1\"\r\nports = [ 8001, 8001, 8002 ]\r\nconnection_max = 5000\r\nenabled = true";
    string TomlTestString2 = @"global = ""this is a string""
# This is a comment of a table
[my_table]
key = 1 # Comment a key
value = true
list = [4, 5, 6]";
    
    
    public static void TomlynParseTomlExample1() { 
    }

    public static void TommyParseTomlExample()
    {

    }

    public static void TomletToConsole(string path)
    {
        string testTomlString = File.ReadAllText(path);
        Console.WriteLine(testTomlString);


    }

    public static void TomletToTomlFile(object obj, string path)
    {
        // parse one section and return the section
        // use that section inside
        
        TomlDocument tomlDoc = TomletMain.DocumentFrom(obj);
        string tomlString = TomletMain.TomlStringFrom(obj);
        Console.WriteLine(tomlString);
        File.WriteAllText("examples/"+path, tomlString);
        Console.WriteLine("press key to continue");
        Console.ReadLine();
    }

    public static void CreateSectionExample()
    {
        var comp_exp = new Component_Experience(new List<Job>
                {
                    new Job
                    {
                        Company = "Crapple",
                        Role = "Founder/CEO",
                        StartDate = "Jan 1976",
                        EndDate = "Sep 1985",
                        Tasks = new List<string>
                        {
                            "Founded an electronics startup in a garage ",
                            "Designed the overpriced electronics for the masses",
                        }
                    },
                    new Job
                    {
                        Company = "Flixar",
                        Role = "Founder/CEO",
                        StartDate = "May 1986",
                        EndDate = "May 2006",
                        Tasks = new List<string>
                        {
                            "made janky 3d animated films using computer graphics after getting kicked out at Crapple",
                        }
                    }
                });
    }
}
