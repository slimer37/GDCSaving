namespace GDCSaving;

public class AdventureConsole
{
    public AdventureConsole(int printIntervalMs)
    {
        PrintIntervalMs = printIntervalMs;
    }

    public int PrintIntervalMs { get; set; }

    /// <summary>
    /// Works like Console.Write, but types out the text character by character.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public void Write(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(PrintIntervalMs);
        }
    }

    /// <summary>
    /// Pauses for some number of seconds.
    /// </summary>
    /// <param name="seconds">How long to pause for. Default is 1 second.</param>
    public void Pause(float seconds = 1)
    {
        Thread.Sleep((int)(seconds * 1000));
    }

    /// <summary>
    /// Works like Console.WriteLine, but types out the text character by character.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public void WriteLine(string text) => Write(text + '\n');

    /// <summary>
    /// Works like WriteLine, but does two linebreaks and pauses.
    /// </summary>
    /// <param name="text">The text to write.</param>
    public void WriteSection(string text)
    {
        Write(text + "\n\n");
        Pause();
    }

    /// <summary>
    /// Shows a yes or no prompt.
    /// </summary>
    /// <param name="prompt">The prompt.</param>
    /// <returns>Whether 'y' was the answer.</returns>
    public bool PromptYN(string prompt) {
        var (Left, Top) = Console.GetCursorPosition();
        Write(prompt + " (y/n) : ");

        string answer = Console.ReadLine()!.ToLower().Trim();

        while (answer != "y" && answer != "n")
        {
            Console.SetCursorPosition(Left, Top - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Left, Top - 1);
            Console.Write(prompt + " (only y/n) : ");
            answer = Console.ReadLine()!.Trim().ToLower();
        }

        Console.WriteLine();

        return answer is "y";
    }

    /// <summary>
    /// Presents a choice to the player and returns the index of that choice.
    /// </summary>
    /// <param name="choices">The choices to display.</param>
    /// <returns>The index of the selected choice.</returns>
    public int PresentChoice(params string[] choices)
    {
        int selection = 0;

        for (int i = 0; i < choices.Length; i++)
        {
            WriteLine(FormatChoice(choices[i], i));
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

        Console.WriteLine("\u001b[0m");

        return selection;

        string FormatChoice(string choice, int index)
        {
            return (index == selection ? "\u001b[1m > " : "\u001b[22m - ") + choice;
        }
    }
}