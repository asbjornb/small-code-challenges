// See https://aka.ms/new-console-template for more information
using project_euler.Problems.Problem0001;

var problem1 = Problem0001a.SumMultiplesUnder(new List<int>() { 3, 5 }, 1000);
var problem2 = Problem0002a.SumEvenFibonnaciNumbersUnder(4000000);
Console.WriteLine($"Problem 1: {problem1}");
Console.WriteLine($"Problem 2: {problem2}");
