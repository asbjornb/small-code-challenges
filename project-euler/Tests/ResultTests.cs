using NUnit.Framework;
using project_euler;
using Shouldly;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    internal class ResultTests
    {
        [Test]
        [TestCase("001", "233168")]
        [TestCase("002", "4613732")]
        [TestCase("003", "6857")]
        [TestCase("004", "906609")]
        [TestCase("005", "232792560")]
        [TestCase("006", "25164150")]
        [TestCase("007", "104743")]
        [TestCase("008", "23514624000")]
        [TestCase("009", "31875000")]
        [TestCase("010", "142913828922")]
        [TestCase("011", "70600674")]
        [TestCase("012", "76576500")]
        [TestCase("013", "5537376230")]
        [TestCase("014", "837799")]
        [TestCase("015", "137846528820")]
        [TestCase("016", "1366")]
        public void TestSolvers(string problem, string expectedResult, int secondsAllowed = 2)
        {
            var solver = Resolver.GetAllSolvers().First(x => x.Name == "Problem" + problem);
            string result = "";

            Should.CompleteIn(() => result = solver.Solve(), TimeSpan.FromSeconds(secondsAllowed), $"{solver.Name} took longer than expected");

            result.ShouldBe(expectedResult);
        }
    }
}