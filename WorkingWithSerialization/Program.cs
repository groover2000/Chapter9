using System.Xml.Serialization;
using Packt.Shared;
using FastJson = System.Text.Json.JsonSerializer;

List<Person> people = new()
{
    new(30000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(year: 1974, month: 3, day: 14)
    },
    new(40000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(year: 1969, month: 11, day: 23)
    },
    new(20000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(year: 1984, month: 5, day: 4),
        Children =
        [
            new(0M)
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(year: 2012, month: 7, day: 12)
            }
        ]
    },
};


XmlSerializer xs = new(type: people.GetType());
string path = Path.Combine(Environment.CurrentDirectory, "people.xml");

using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}

Console.WriteLine($"Written {new FileInfo(path).Length:N0} bytes of XML to {path}");

Console.WriteLine();
Console.WriteLine(File.ReadAllText(path));

Console.WriteLine();
Console.WriteLine("* Deserializing XML files");

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            Console.WriteLine($"{p.LastName} has {p.Children?.Count ?? 0} children");
        }
    }
}


string jsonPath = Path.Combine(Environment.CurrentDirectory, "people.json");

using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();

    jss.Serialize(jsonStream, people);
    
}

Console.WriteLine();
Console.WriteLine($"Written {new FileInfo(jsonPath).Length:N0} bytes of JSON to: {jsonPath}");

Console.WriteLine(File.ReadAllText(jsonPath));

Console.WriteLine();
Console.WriteLine("*Deserializing JSON files");

using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    List<Person>? loadedPeople = await FastJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            Console.WriteLine($"{p.LastName} has {p.Children?.Count ?? 0}");
        }
    }
}