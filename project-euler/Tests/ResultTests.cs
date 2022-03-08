using NUnit.Framework;
using project_euler;
using System.Linq;
using Shouldly;

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
        public void TestSolvers(string problem, string expectedResult)
        {
            var solvers = Resolver.GetAllSolvers();
            var result = solvers.First(x => x.Name == "Problem" + problem).Solve();

            result.ShouldBe(expectedResult);
        }
    }
}
