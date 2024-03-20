namespace GDCSaving;

public class AdventureConsole
{
    public AdventureConsole(int printIntervalMs)
    {
        PrintIntervalMs = printIntervalMs;
    }

    public int PrintIntervalMs { get; set; }

    public async Task Write(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            await Task.Delay(PrintIntervalMs);
        }
    }

    public async Task WriteLine(string text) => await Write(text + '\n');

    public async Task<int> PresentChoice(params string[] choices)
    {
        int selection = 0;

        for (int i = 0; i < choices.Length; i++)
        {
            await WriteLine(FormatChoice(choices[i], i));
        }

        ConsoleKeyInfo key;

        do
        {
            var (Left, Top) = Console.GetCursorPosition();
            Console.SetCursorPosition(Left, Top - choices.Length);

            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine(FormatChoice(choices[i], i));
            }

            key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow)
            {
                selection--;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selection++;
            }

            selection = (selection + choices.Length) % choices.Length;
        } while (key.Key != ConsoleKey.Enter);

        return selection;

        string FormatChoice(string choice, int index)
        {
            return (index == selection ? "\u001b[1m > " : "\u001b[22m - ") + choice;
        }
    }
}