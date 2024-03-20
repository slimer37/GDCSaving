namespace GDCSaving;

public class Program
{
    public static void Main(string[] args)
    {
        if (File.Exists("save"))
            Serialization.Load("save");

        AdventureConsole c = new AdventureConsole(20);

        c.WriteLine("Hello...?");

        int choice = c.PresentChoice("Talk", "B", "C");

        Serialization.CurrentSaveData.Data["choice"] = choice;

        Serialization.Save("save");

        // Reset console format

        Console.Write("\u001b[0m");
    }
}