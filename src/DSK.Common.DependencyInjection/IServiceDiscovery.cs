namespace DSK.Common.DependencyInjection;

using DSK.Common.DependencyInjection.Providers;
using Microsoft.Extensions.Configuration;
using System.Reflection;

public interface IServiceDiscovery
{
    IAssemblyLoader AssemblyLoader { get; }

    IFileSystemProvider FileSystemProvider { get; }

    IServiceDiscovery AddAssembly(Assembly assembly);

    IServiceDiscovery AddConfiguration(IConfiguration configuration);

    void Discover();

}
