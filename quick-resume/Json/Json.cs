using System.Text.Json;
using System.Diagnostics;

namespace qpdf.Json;

public class Jsons
{
    public static string ToJson(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static object FromJson(string json)
    {
        return JsonSerializer.Deserialize<object>(json);
    }

    public static void PrintJsonObject(object obj)
    {
        Console.WriteLine(ToJson(obj));
        Debug.WriteLine(ToJson(obj));
    }

    public static void ToJsonFile(object obj, string filePath)
    {
        var path = filePath;
        var jsonString = ToJson(obj);
        File.WriteAllText(path, jsonString);
    }
}
