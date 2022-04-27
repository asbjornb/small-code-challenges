using NUnit.Framework;
using project_euler.Maths.Permutations;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Maths
{
    [TestFixture]
    internal class CombinationCalculatorTests
    {
        [Test]
        [TestCaseSource(nameof(TestCombinationCases))]
        public void RepeatPermutationsShouldGenerateCorrectly(int[] candidateSet, int length, List<int[]> expectedPermutations)
        {
            var result = CombinationCalculator.GetCombinations(candidateSet.ToList(), length);
            var test2 = result.ToList();
            test2.Count.ShouldBe(expectedPermutations.Count);
            foreach (var permutation in result)
            {
                var test = expectedPermutations.First(x => x.SequenceEqual(permutation));
                test.ShouldBe(permutation);
                expectedPermutations.Remove(test).ShouldBe(true);
            }
        }

        private static readonly object[] TestCombinationCases =
        {
            new object[] { new int[] { 2 }, 1, new List<int[]>() { new int[] { 2 } } },
            new object[] { new int[] { 2, 3 }, 2, new List<int[]>() { new int[] { 2, 2 }, new int[] { 2, 3 }, new int[] { 3, 2 }, new int[] { 3, 3 } } },
        };

        [Test]
        public void CombinationsShouldPerform()
        {
            var allowedTime = TimeSpan.FromSeconds(2);
            var listToTest = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Should.CompleteIn(() => CombinationCalculator.GetCombinations(listToTest, 7).ToList(), allowedTime);
        }

        [Test]
        public void DangerPermutationsShouldPerform()
        {
            var allowedTime = TimeSpan.FromMilliseconds(500);
            var listToTest = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Should.CompleteIn(() => CombinationCalculator.GetCombinationsDanger(listToTest, 7).ToList(), allowedTime);
        }

        [Test]
        public void CombinationsShouldFindRightAmount()
        {
            var listToTest = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CombinationCalculator.GetCombinations(listToTest, 2).Count().ShouldBe(9*9);
        }
    }
}
