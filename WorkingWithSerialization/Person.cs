using System.Xml.Serialization; // [XMLAttribute]
namespace Packt.Shared;


public class Person
{
    protected decimal Salary { get; set; }

    public Person() { }
    public Person(decimal initialSalary)
    {
        Salary = initialSalary;
    }

    [XmlAttribute("fname")]
    public string? FirstName { get; set; }
    [XmlAttribute("lname")]
    public string? LastName { get; set; }
    [XmlAttribute("dob")]
    public DateTime DateOfBirth { get; set; }
    public HashSet<Person>? Children { get; set; }

}