using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;


SectionTitle("* Handling cross-platform environments and filesystems");
Console.WriteLine("{0, -33} {1}", "Path.PathSeparator", Path.PathSeparator);
Console.WriteLine("{0, -33} {1}", "Path.DirectorySeparatorChar", Path.DirectorySeparatorChar);
Console.WriteLine("{0, -33} {1}", "Directory.GetCurrentDirectory()", Directory.GetCurrentDirectory());
Console.WriteLine("{0, -33} {1}", "Environment.CurrentDirectory", Environment.CurrentDirectory);
Console.WriteLine("{0, -33} {1}", "Environment.SystemDirectory", Environment.SystemDirectory);
Console.WriteLine("{0, -33} {1}", "Path.GetTempPath()", Path.GetTempPath());

Console.WriteLine("GetFolderPath(SpecialFolder");

Console.WriteLine("{0, -33} {1}", ".Systemc", GetFolderPath(SpecialFolder.System));
Console.WriteLine("{0, -33} {1}", ".ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
Console.WriteLine("{0, -33} {1}", ".MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
Console.WriteLine("{0, -33} {1}", ".Personal", GetFolderPath(SpecialFolder.Personal));



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