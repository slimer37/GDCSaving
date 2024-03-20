namespace GDCSaving;

public class Program
{
    public static async Task Main(string[] args)
    {
        if (File.Exists("save"))
            Serialization.Load("save");

        AdventureConsole c = new AdventureConsole(20);

        await c.WriteLine("Hello...?");

        int choice = await c.PresentChoice("Talk", "B", "C");

        Serialization.CurrentSaveData.Data["choice"] = choice;

        Serialization.Save("save");
    }
}