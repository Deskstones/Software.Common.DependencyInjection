namespace DSK.Common.DependencyInjection.Extensions;

using DSK.Common.DependencyInjection;
using System.Reflection;

/// <summary>
/// Extension methods for <see cref="IServiceDiscovery"/>.
/// </summary>
public static class ServiceDiscoveryFilterExtensions
{
    /// <summary>
    /// Adds assemblies from a directory.
    /// </summary>
    /// <param name="serviceDiscovery">An <see cref="IServiceDiscovery"/> instance.</param>
    /// <param name="directoryPath">The directory to add assemblies from.</param>
    /// <param name="searchPattern">The search pattern to filter the assembly files.</param>
    /// <returns>The service discovery instance.</returns>
    public static IServiceDiscovery AddDirectory(this IServiceDiscovery serviceDiscovery, string directoryPath, string searchPattern)
    {
        var assemblyLoader = serviceDiscovery.AssemblyLoader;
        var fileSystemProvider = serviceDiscovery.FileSystemProvider;

        var files = fileSystemProvider.GetFilesFromDirectory(directoryPath, searchPattern);

        var assemblies = files
            .Select(file => Path.GetFileNameWithoutExtension(file))
            .Select(file => new AssemblyName(file))
            .Select(assemblyName => assemblyLoader.LoadAssembly(assemblyName));

        foreach (var assembly in assemblies)
        {
            serviceDiscovery.AddAssembly(assembly);
        }

        return serviceDiscovery;
    }

    /// <summary>
    /// Adds assemblies from current directory.
    /// </summary>
    /// <param name="serviceDiscovery">An <see cref="IServiceDiscovery"/> instance.</param>
    /// <param name="searchPattern">The search pattern to filter the assembly files.</param>
    /// <returns>The service discovery instance.</returns>
    public static IServiceDiscovery AddDirectory(this IServiceDiscovery serviceDiscovery, string searchPattern)
    {
        var assemblyPath = Assembly.GetExecutingAssembly().Location;
        var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

        return AddDirectory(serviceDiscovery, assemblyDirectory!, searchPattern);
    }
}