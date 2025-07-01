// using static System.IO.Directory;
// using static System.IO.Path;
// using static System.Environment;


using System.ComponentModel;
using System.Diagnostics;

SectionTitle("* Handling cross-platform environments and filesystems");
Console.WriteLine("{0, -33} {1}", "Path.PathSeparator", Path.PathSeparator);
Console.WriteLine("{0, -33} {1}", "Path.DirectorySeparatorChar", Path.DirectorySeparatorChar);
Console.WriteLine("{0, -33} {1}", "Directory.GetCurrentDirectory()", Directory.GetCurrentDirectory());
Console.WriteLine("{0, -33} {1}", "Environment.CurrentDirectory", Environment.CurrentDirectory);
Console.WriteLine("{0, -33} {1}", "Environment.SystemDirectory", Environment.SystemDirectory);
Console.WriteLine("{0, -33} {1}", "Path.GetTempPath()", Path.GetTempPath());

Console.WriteLine("GetFolderPath(SpecialFolder");

Console.WriteLine("{0, -33} {1}", ".Systemc", Environment.GetFolderPath(Environment.SpecialFolder.System));
Console.WriteLine("{0, -33} {1}", ".ApplicationData", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
Console.WriteLine("{0, -33} {1}", ".MyDocuments", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
Console.WriteLine("{0, -33} {1}", ".Personal", Environment.GetFolderPath(Environment.SpecialFolder.Personal));



SectionTitle("Managing drivers");

Console.WriteLine("{0, -10} | {1, -10} | {2, -7} | {3, 18} | {4, 18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    if (drive.IsReady)
    {
        Console.WriteLine(
            "{0, -10} | {1, -10} | {2, -7} | {3, 18:N0} | {4,18:N0}",
            drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace
        );
    }
}

SectionTitle("Managing Deirectories");

string newFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "NewFolder");

Console.WriteLine($"Working with: {newFolder}");
Console.WriteLine($"Does it exist? {Path.Exists(newFolder)}");
Console.WriteLine("Creating it...");
Directory.CreateDirectory(newFolder);
Console.Write("Confirm the directory exists, and then press Enter: ");
Console.ReadLine();
Console.WriteLine("Deleting it...");
Directory.Delete(newFolder, recursive: true);


SectionTitle("Managing files");

string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OutputFiles");
Directory.CreateDirectory(dir);

string textFile = Path.Combine(dir, "Dummy.txt");
string backupFile = Path.Combine(dir, "Dummy.bak");
Console.WriteLine($"Working with: {textFile}");

Console.WriteLine($"Does it exist? {File.Exists(textFile)}");


StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Hello C#");
textWriter.Close();
Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

Console.WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
Console.Write("Confirm the files exist, and then press ENTER: ");
Console.ReadLine();

File.Delete(textFile);
Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

Console.WriteLine($"Reading contents of {backupFile}");
StreamReader textReader = File.OpenText(backupFile);
Console.WriteLine(textReader.ReadToEnd());
textReader.Close();

SectionTitle("Managing paths");

Console.WriteLine($"Folder Name: {Path.GetDirectoryName(textFile)}");
Console.WriteLine($"File Name: {Path.GetFileName(textFile)}");
Console.WriteLine("File name without Extensions: {0}", Path.GetFileNameWithoutExtension(textFile));
Console.WriteLine($"File extension: {Path.GetExtension(textFile)}");
Console.WriteLine($"Random File Name: {Path.GetRandomFileName()}");
Console.WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

SectionTitle("Getting file information");
FileInfo info = new(backupFile);
Console.WriteLine($"{backupFile}:");
Console.WriteLine($"Contains {info.Length} bytes");
Console.WriteLine($"Last accessed {info.LastAccessTime}");
Console.WriteLine($"Has readonly set to {info.IsReadOnly}");