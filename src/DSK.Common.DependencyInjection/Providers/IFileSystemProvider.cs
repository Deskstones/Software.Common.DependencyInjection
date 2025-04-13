namespace DSK.Common.DependencyInjection.Providers;

public interface IFileSystemProvider
{
    string[] GetFilesFromDirectory(string path, string searchPattern);

}
