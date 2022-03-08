// See https://aka.ms/new-console-template for more information
using project_euler;
using System.Diagnostics;

var solvers = Resolver.GetAllSolvers();
Stopwatch watch;
foreach (var solver in solvers)
{
    Console.WriteLine($"Solving {solver.Name}");
    watch = Stopwatch.StartNew();
    Console.WriteLine(solver.Solve());
    watch.Stop();
    Console.WriteLine($"Solution took {watch.ElapsedMilliseconds} milliseconds");
}
