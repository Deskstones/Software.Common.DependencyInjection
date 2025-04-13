namespace DSK.Common.DependencyInjection.Providers;

internal class FileSystemProvider : IFileSystemProvider
{
    public string[] GetFilesFromDirectory(string path, string searchPattern)
    {
        return Directory.GetFiles(path, searchPattern);
    }
}
