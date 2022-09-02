using System.Text.Json;
using System.Diagnostics;

namespace pdf_test1;

public class Json
{
    public static string JsonifyObject(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static object ObjectifyJson(string json)
    {
        return JsonSerializer.Deserialize<object>(json);
    }

    public static void PrintSerializedObject(object obj)
    {
        Console.WriteLine(JsonifyObject(obj));
        Debug.WriteLine(JsonifyObject(obj));
    }

    public static void Write_To_Json_File(object obj, string filePath )
    {
        var path = filePath;
        var jsonString = Json.JsonifyObject(obj);
        File.WriteAllText(path, jsonString);
    }
}
