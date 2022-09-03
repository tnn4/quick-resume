using System.Text.Json;
using System.Diagnostics;

namespace qpdf;

public class Json
{
    public static string ToJson(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static object FromJson(string json)
    {
        return JsonSerializer.Deserialize<object>(json);
    }

    public static void PrintSerializedObject(object obj)
    {
        Console.WriteLine(ToJson(obj));
        Debug.WriteLine(ToJson(obj));
    }

    public static void ToJsonFile(object obj, string filePath )
    {
        var path = filePath;
        var jsonString = Json.ToJson(obj);
        File.WriteAllText(path, jsonString);
    }
}
