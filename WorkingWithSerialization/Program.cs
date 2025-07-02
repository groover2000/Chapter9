using System.Xml.Serialization;
using Packt.Shared;

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