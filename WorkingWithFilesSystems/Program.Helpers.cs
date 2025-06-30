partial class Program
{
    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("+");
        Console.WriteLine($"* {title}");
        Console.WriteLine("+");
        Console.ForegroundColor = previousColor;

    }
}