using DSK.Common.DependencyInjection.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DSK.Common.DependencyInjection;

internal class ServiceDiscovery : IServiceDiscovery
{
    private readonly IServiceCollection _services;
    private IConfiguration? _configuration;
    private readonly List<Assembly> _allAssemblies = new List<Assembly>();

    public IAssemblyLoader AssemblyLoader { get; private set; }
    public IFileSystemProvider FileSystemProvider { get; private set; }

    public IServiceDiscovery AddAssembly(Assembly assembly) 
    {
        _allAssemblies.Add(assembly);

        return this;
    }

    public IServiceDiscovery AddConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
        return this;
    }

    public void Discover()
    {
        var allTypes = GetAllConfigurationTypes(_allAssemblies);
        var allConfiguration = GetConfigurations(allTypes);

        foreach (var configuration in allConfiguration)
        {
            configuration.RegisterServices(_services, _configuration);
        }
    }

    public ServiceDiscovery(IServiceCollection services, IAssemblyLoader assemblyLoader, IFileSystemProvider fileSystemProvider)
    {
        _services = services;
        this.AssemblyLoader = assemblyLoader;
        this.FileSystemProvider = fileSystemProvider;
    }



    private static IEnumerable<IServicesConfiguration> GetConfigurations(IEnumerable<Type> configurationTypes)
    {
        foreach (var configurationType in configurationTypes)
        {
            var configuration = Activator.CreateInstance(configurationType) as IServicesConfiguration;

            if(configuration == null)
            {
                throw new InvalidOperationException($"Failed to instantiate class of type {configurationType}");
            }

            yield return configuration;
        }
    }

    private static IEnumerable<Type> GetAllConfigurationTypes(IEnumerable<Assembly> assemblies)
    {
        var allTypes = new List<Type>();
        foreach (var assembly in assemblies)
        {
            var assemblyTypes = assembly.GetTypes();
            var configurationTypes = assemblyTypes.Where(typeof(IServicesConfiguration).IsAssignableFrom)
                .Where(type => !type.IsInterface);

            allTypes.AddRange(configurationTypes);
        }

        return allTypes;

    }


}
