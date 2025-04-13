namespace DSK.Common.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public interface IServicesConfiguration
{
    void RegisterServices(IServiceCollection services, IConfiguration? configuration);
}
