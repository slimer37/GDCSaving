using System.Text.Json.Serialization;

namespace GDCSaving;

public class SaveData
{
    [JsonInclude]
    public Dictionary<string, object> Data = new();
}