using NUnit.Framework;
using project_euler.Maths.Permutations;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Maths
{
    [TestFixture]
    internal class PermutationCalculatorTests
    {
        [Test]
        [TestCaseSource(nameof(TestPermutationCases))]
        public void PermutationsShouldGenerateCorrectly(int[] candidateSet, List<int[]> expectedPermutations)
        {
            foreach (var permutation in PermutationCalculator.GetPermutations(candidateSet))
            {
                var test = expectedPermutations.First(x => x.SequenceEqual(permutation));
                test.ShouldBe(permutation);
                expectedPermutations.Remove(test).ShouldBe(true);
            }
        }

        private static readonly object[] TestPermutationCases =
        {
            new object[] { new int[] { 2 }, new List<int[]>() { new int[] { 2 } } },
            new object[] { new int[] { 2, 3 }, new List<int[]>() { new int[] { 2, 3 }, new int[] { 3, 2 } } },
            new object[] { new int[] { 1, 2, 3 }, new List<int[]>() { new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }, new int[] { 1, 3, 2 }, new int[] { 3, 1, 2 }, new int[] { 2, 1, 3 }, new int[] { 2, 3, 1 } } },
        };

        [Test]
        public void PermutationsShouldPerform()
        {
            var allowedTime = TimeSpan.FromMilliseconds(500);
            var listToTest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Should.CompleteIn(() => PermutationCalculator.GetPermutations(listToTest).ToList(), allowedTime);
        }

        [Test]
        public void DangerPermutationsShouldPerform()
        {
            var allowedTime = TimeSpan.FromMilliseconds(100);
            var listToTest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Should.CompleteIn(() => { while (PermutationCalculator.NextPermutationDanger(listToTest)) { } }, allowedTime);
        }

        [Test]
        public void PermutationsShouldFindRightAmount()
        {
            var listToTest = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            PermutationCalculator.GetPermutations(listToTest).Count().ShouldBe(9*8*7*6*5*4*3*2);
        }
    }
}
