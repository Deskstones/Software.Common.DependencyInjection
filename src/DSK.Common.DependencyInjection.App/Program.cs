using DSK.Common.DependencyInjection.Providers;

namespace DSK.Common.DependencyInjection.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAssemblyLoader assemblyLoader = new AssemblyLoader(); // manual instantiation
            assemblyLoader.LoadAssembly(@"DSK.Common.DependencyInjection.App.dll");
            Console.WriteLine("donee");
        }
    }
}
