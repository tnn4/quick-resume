
using qpdf.Test;

public class EntryPoint
{
    static void Main()
    {
        TestDoc.create_resume_example();
        TestJson.Serialize_Components();
    }
}