using QuestPDF.Infrastructure;
using System.Text.Json;

using qpdf.Json;

namespace qpdf.Resume;


internal class Resume_Json
{
    public void component_to_json(IComponent component)
    {
        //  component object -->[serialize] --> JSON --> [PDF]
        Jsons.ToJson(component);
    }

    public void json_to_component()
    {
        //  JSON -->[deserialize] --> component object --> [PDF]
    }

    public static void SerializeToFile(object obj, string path)
    {
        if (obj is not null && path is not null)
            Jsons.ToJsonFile(obj, path);
        else
            Console.WriteLine("Error: Missing valid obj or path");
    }
}
