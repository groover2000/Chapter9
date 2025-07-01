using System.Formats.Tar;

try
{
    string current = Environment.CurrentDirectory;
    WriteInformation($"Current directory: {current}");

    string sourceDirectory = Path.Combine(current, "images");
    string destinationDirectory = Path.Combine(current, "extracted");
    string tarFile = Path.Combine(current, "images-archive.tar");

    if (!Directory.Exists(sourceDirectory))
    {
        WriteError($"The {sourceDirectory} directory must exists. Please create it before add some files");
        return;
    }

    if (File.Exists(tarFile))
    {
        File.Delete(tarFile);
        WriteWarning($"{tarFile} already existed so it was deleted");
    }

    WriteInformation($"Archiving directory: {sourceDirectory}\n To .tar file: {tarFile}");

    TarFile.CreateFromDirectory(sourceDirectoryName: sourceDirectory, destinationFileName: tarFile, includeBaseDirectory: true);

    WriteInformation($"Does {tarFile} exists? {File.Exists(tarFile)}");

}
catch
{

}
