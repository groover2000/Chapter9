using System.Text.Json;

Book myBook = new(title: "C# and .NET 7")
{
    Author = "Mark J Price",
    PublishDate = new(2022, 11, 8),
    Pages = 823,
    Created = DateTimeOffset.UtcNow
};

JsonSerializerOptions options = new()
{
    IncludeFields = true,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string filePath = Path.Combine(Environment.CurrentDirectory, "mybook.json");

using (Stream fileStream = File.Create(filePath))
{
    JsonSerializer.Serialize<Book>(utf8Json: fileStream, value: myBook, options: options);
}

Console.WriteLine($"Written {new FileInfo(filePath).Length} bytes of JSON to {filePath}");
Console.WriteLine(File.ReadAllText(filePath));