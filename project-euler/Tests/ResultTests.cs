﻿using NUnit.Framework;
using project_euler;
using Shouldly;
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
        public void TestSolvers(string problem, string expectedResult, int secondsAllowed = 2)
        {
            var solver = Resolver.GetAllSolvers().First(x => x.Name == "Problem" + problem);
            string result = "";

            Should.CompleteIn(() => result = solver.Solve(), System.TimeSpan.FromSeconds(secondsAllowed), $"{solver.Name} took longer than expected");

            result.ShouldBe(expectedResult);
        }
    }
}