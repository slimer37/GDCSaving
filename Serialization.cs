using System.Text.Json;

namespace GDCSaving;

public static class Serialization
{
    public static SaveData CurrentSaveData { get; private set; } = new();

    public static void Save(string path)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(CurrentSaveData, new JsonSerializerOptions() { WriteIndented = true }));
    }

    public static void Load(string path)
    {
        CurrentSaveData = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(path)) ?? new();
    }
}