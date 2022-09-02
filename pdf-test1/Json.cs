using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
