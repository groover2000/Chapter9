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

    if (!Directory.Exists(destinationDirectory))
    {
        Directory.CreateDirectory(destinationDirectory);
        WriteWarning($"{destinationDirectory} did not exists so it was created");
    }

    WriteInformation($"Extracting archive: {tarFile}\n To directory: {destinationDirectory}");
    TarFile.ExtractToDirectory(sourceFileName: tarFile, destinationDirectoryName: destinationDirectory, overwriteFiles: true);

    if (Directory.Exists(destinationDirectory))
    {
        foreach (string dir in Directory.GetDirectories(destinationDirectory))
        {
            WriteInformation($"Extracted directory {dir} containing these files: " + string.Join(',', Directory.EnumerateFiles(dir).Select(file => Path.GetFileName(file))));
        }
    }

}
catch(Exception ex)
{
    WriteError(ex.Message);
}
