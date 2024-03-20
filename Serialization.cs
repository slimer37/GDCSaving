using System.Text.Json;

namespace GDCSaving;

public static class Serialization
{
    public static SaveData CurrentSaveData { get; private set; } = new();

    public static void Save(string path)
    {
        string json = JsonSerializer.Serialize(CurrentSaveData, new JsonSerializerOptions() { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public static void Load(string path)
    {
        CurrentSaveData = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(path)) ?? new();
    }
}