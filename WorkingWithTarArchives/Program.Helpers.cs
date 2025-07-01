partial class Program
{
    static void WriteError(string message)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"FAIL: {message}");
        Console.ForegroundColor = previousColor;
    }

    static void WriteWarning(string message)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"WARN: {message}");
        Console.ForegroundColor = previousColor;
    }

    static void WriteInformation(string message)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"INFO: {message}");
        Console.ForegroundColor = previousColor;
    }
}