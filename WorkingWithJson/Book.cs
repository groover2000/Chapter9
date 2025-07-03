using System.Text.Json.Serialization; // [JsonInclude]

public class Book
{
    public Book(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public string? Author { get; set; }

    [JsonInclude]
    public DateTimeOffset Created;

    [JsonInclude]
    public DateTime PublishDate;

    public ushort Pages;
}