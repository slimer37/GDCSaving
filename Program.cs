namespace GDCSaving;

public class Program
{
    static AdventureConsole c = new AdventureConsole(10);

    public static void Main(string[] args)
    {
        c.WriteSection("\n\nWelcome to GENERIC TEXT ADVENTURE WITH SAVING by slimer37.");

        if (!c.PromptYN("Play?")) {
            return;
        }
        
        if (File.Exists("save"))
        {
            Serialization.Load("save");

            if (Serialization.CurrentSaveData.Data.ContainsKey("destination")) {
                int choice = int.Parse(Serialization.CurrentSaveData.Data["destination"]);

                switch (choice)
                {
                    case 0:
                        InVegas();
                        break;
                    case 1:
                        TakeMeThere();
                        break;
                    case 2:
                        DropMeOff();
                        break;
                }
            }
        }
        else
        {
            Part1Taxi();
        }

        // Reset console format

        Console.Write("\u001b[0m");
    }

    static void Part1Taxi()
    {
        c.WriteSection("You find yourself in the back of a taxi with just 50 dollars in your pocket.\n" +
        "You don't know how you got there, but you really need some water.");

        c.WriteSection("The taxi driver looks at you and tells you you're in Nevada. He notices you're awake and does some explaining.\n" +
        "Apparently you fell asleep for a bit and were getting out of some hotel in Vegas.\n" +
        "\"I was taking you to the border to Cali but I imagine you might wanna go somewhere else now that you're sane.\"");

        c.WriteSection("You're stopped at a light in some downtown-looking zone and there's a payphone a few feet away.");

        int choice = c.PresentChoice("\"Take me back to the hotel.\"", "\"Just take me wherever I was going.\"", "\"Drop me off here.\"");
        
        Serialization.CurrentSaveData.Data["destination"] = choice.ToString();

        // { "destination" : choice "0", "1", "2" }

        Serialization.Save("save");

        switch (choice)
        {
            case 0:
                InVegas();
                break;
            case 1:
                TakeMeThere();
                break;
            case 2:
                DropMeOff();
                break;
        }
    }

    static void InVegas()
    {
        c.WriteSection("He says okay and makes a U-turn." +
        "\nYou know who to talk to once you get there and they won't like what you have to say.");
    }

    static void TakeMeThere()
    {
        c.WriteSection("He says okay and continues straight." +
        "\nYou clearly don't want anything to do with where you just escaped from.");
    }

    static void DropMeOff()
    {
        c.WriteSection("He says okay and unlocks the door." +
        "\nYou really need to talk to some authorities because you can at least remember what was at the hotel.");
    }
}