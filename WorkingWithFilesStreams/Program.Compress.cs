using System.IO.Compression;
using System.Xml;


partial class Program
{
    static void Compress(string algorithm = "gzip")
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, $"streams.{algorithm}");
        FileStream file = File.Create(filePath);
        Stream compressor;
        if (algorithm == "gzip")
        {
            compressor = new GZipStream(file, CompressionMode.Compress);
        }
        else
        {
            compressor = new BrotliStream(file, CompressionMode.Compress);
        }

        using (compressor)
        {
            using (XmlWriter xml = XmlWriter.Create(compressor))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach (string item in Viper.Callsigns)
                {
                    xml.WriteElementString("callsigns", item);
                }
            }
        }
        Console.WriteLine($"{filePath} contains {new FileInfo(filePath).Length} bytes");
        Console.WriteLine($"The compressed contents:");
        Console.WriteLine(File.ReadAllText(filePath));

        Console.WriteLine("Reading the compressed XML file: ");
        file = File.Open(filePath, FileMode.Open);
        Stream decompressor;
        if (algorithm == "gzip")
        {
            decompressor = new GZipStream(file, CompressionMode.Decompress);
        }
        else
        {
            decompressor = new BrotliStream(file, CompressionMode.Decompress);
        }

        using (decompressor)
        using (XmlReader reader = XmlReader.Create(decompressor))

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                {
                    reader.Read();
                    Console.WriteLine($"{reader.Value}");
                }
        }
    }
}