using System.Text;

Console.WriteLine("Encodings");
Console.WriteLine("[1] ASCII");
Console.WriteLine("[2] UTF-7");
Console.WriteLine("[3] UTF-8");
Console.WriteLine("[4] UTF-16 (Unicode)");
Console.WriteLine("[5] UTF-32");
Console.WriteLine("[6] Latin1");
Console.WriteLine("[any other key Default encoding]");
Console.WriteLine();

Console.Write("Press number to choose an encoding.");
ConsoleKey number = Console.ReadKey(intercept: true).Key;
Console.WriteLine(); Console.WriteLine();

Encoding encoder = number switch
{
    ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
    ConsoleKey.D2 or ConsoleKey.NumPad2 => Encoding.UTF7,
    ConsoleKey.D3 or ConsoleKey.NumPad3 => Encoding.UTF8,
    ConsoleKey.D4 or ConsoleKey.NumPad4 => Encoding.Unicode,
    ConsoleKey.D5 or ConsoleKey.NumPad5 => Encoding.UTF32,
    ConsoleKey.D6 or ConsoleKey.NumPad6 => Encoding.Latin1,
    _ => Encoding.Default
};

string message = "Café £4.39";
Console.WriteLine($"Text to encode: {message} Characters: {message.Length}");

byte[] encoded = encoder.GetBytes(message);

Console.WriteLine($"{encoder.GetType().Name} used {encoded.Length:N0} bytes");

Console.WriteLine($"BYTE | HEX | CHAR");
foreach (byte b in encoded)
{
    Console.WriteLine($"{b,4} | {b.ToString(),4} | {(char)b,4}");
}

string decoded = encoder.GetString(encoded);
Console.WriteLine(decoded);