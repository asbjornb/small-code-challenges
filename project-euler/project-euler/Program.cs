// See https://aka.ms/new-console-template for more information
using project_euler.Problems.ConcreteProblems;
using System.Diagnostics;

var solver = new Problem058();
var solutionWatch = Stopwatch.StartNew();
Console.WriteLine($"Solving {solver.Name}");
for (int i = 0; i < 1; i++)
{
    solver.Solve();
}
solutionWatch.Stop();
Console.WriteLine($"All solvers combined took {solutionWatch.ElapsedMilliseconds} milliseconds");
