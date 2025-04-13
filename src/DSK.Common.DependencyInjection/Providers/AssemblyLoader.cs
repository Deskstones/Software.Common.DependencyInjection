namespace DSK.Common.DependencyInjection.Providers;

using System.Reflection;
public class AssemblyLoader : IAssemblyLoader
{
    public Assembly LoadAssembly(AssemblyName assemblyName)
    {
        return Assembly.Load(assemblyName);
    }
}

