using System.Xml;

SectionTitle("Writing to text streams");

string textFile = Path.Combine(Environment.CurrentDirectory, "streams.txt");

StreamWriter text = File.CreateText(textFile);


foreach (string item in Viper.Callsigns)
{
    text.WriteLine(item);
}
text.Close();

Console.WriteLine("{0}, contains {1:N0} bytes", textFile, new FileInfo(textFile).Length);

Console.WriteLine(File.ReadAllText(textFile));

SectionTitle("Writing to XML streams");

string xmlFile = Path.Combine(Environment.CurrentDirectory, "streams.xml");

FileStream? xmlFileStream = null;
XmlWriter? xml = null;

try
{
    xmlFileStream = File.Create(xmlFile);

    xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

    xml.WriteStartDocument();

    xml.WriteStartElement("callsigns");

    foreach (string item in Viper.Callsigns)
    {
        xml.WriteElementString("callsign", item);
    }

    xml.WriteEndElement();

    xml.Close();
    xmlFileStream.Close();
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
finally
{
    if (xml != null)
    {
        xml.Dispose();
        Console.WriteLine("The XML Writers unmanaged resources have been disposed");
    }

}

Console.WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length:N0} bytes");
Console.WriteLine(File.ReadAllText(xmlFile));

SectionTitle("Compressing streams");
Compress(algorithm: "gzip");
Compress(algorithm: "brotil");
