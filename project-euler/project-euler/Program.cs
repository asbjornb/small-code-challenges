// See https://aka.ms/new-console-template for more information

//var problem1 = Problem0001a.SumMultiplesUnder(new List<int>() { 3, 5 }, 1000);
//var problem2 = Problem0002a.SumEvenFibonnaciNumbersUnder(4000000);
//Console.WriteLine($"Problem 1: {problem1}");
//Console.WriteLine($"Problem 2: {problem2}");

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
