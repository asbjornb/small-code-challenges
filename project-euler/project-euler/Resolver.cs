// See https://aka.ms/new-console-template for more information
using project_euler.Problems;

namespace project_euler
{
    internal static class Resolver
    {
        public static IEnumerable<IProblem> GetAllSolvers()
        {
            var interfaceType = typeof(IProblem);
            return AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(x => x.GetTypes())
              .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(x => (IProblem)Activator.CreateInstance(x)!)
              .OrderBy(x => x.Name);
        }
    }
}
