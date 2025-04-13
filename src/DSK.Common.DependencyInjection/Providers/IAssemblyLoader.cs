namespace DSK.Common.DependencyInjection.Providers;

using System.Reflection;
public interface IAssemblyLoader
{
    Assembly LoadAssembly(AssemblyName assemblyName);
}





