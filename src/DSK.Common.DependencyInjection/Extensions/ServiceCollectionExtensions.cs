namespace DSK.Common.DependencyInjection.Extensions;

using DSK.Common.DependencyInjection.Providers;
using DSK.Common.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Creates a <see cref="IServiceDiscovery"/> object to be used for configuration of the discovery process.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>An <see cref="IServiceDiscovery"/> object.</returns>
    public static IServiceDiscovery ServiceDiscovery(this IServiceCollection services)
    {
        return new ServiceDiscovery(services, new AssemblyLoader(), new FileSystemProvider());
    }
}