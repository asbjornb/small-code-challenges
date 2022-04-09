// See https://aka.ms/new-console-template for more information
using project_euler;
using System.Diagnostics;

var solvers = Resolver.GetAllSolvers();
var solutionWatch = Stopwatch.StartNew();
Stopwatch individualWatch;
foreach (var solver in solvers)
{
    Console.WriteLine($"Solving {solver.Name}");
    individualWatch = Stopwatch.StartNew();
    Console.WriteLine(solver.Solve());
    Console.WriteLine($"Solution took {individualWatch.ElapsedMilliseconds} milliseconds");
}
solutionWatch.Stop();
Console.WriteLine($"All solvers combined took {solutionWatch.ElapsedMilliseconds} milliseconds");
