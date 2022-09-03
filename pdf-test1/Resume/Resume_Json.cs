
using QuestPDF.Infrastructure;
using System.Text.Json;

namespace qpdf.Resume;

internal class Resume_Json
{
    public void component_to_json(IComponent component)
    {
        //  component object -->[serialize] --> JSON --> [PDF]
        Json.ToJson(component);
    }

    public void json_to_component()
    {
        //  JSON -->[deserialize] --> component object --> [PDF]
    }
}
