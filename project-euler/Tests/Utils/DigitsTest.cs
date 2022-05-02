using NUnit.Framework;
using project_euler.Util;
using Shouldly;
using System.Collections.Generic;

namespace Tests.Utils
{
    [TestFixture]
    internal class DigitsTest
    {
        [Test]
        [TestCaseSource(nameof(TestCasesDigits))]
        public void DigitsShouldDeconstructCorrectly(int candidate, List<int> expectedResult)
        {
            var test = Digits.GetDigits(candidate);
            test.ShouldBe(expectedResult);
        }

        private static readonly object[] TestCasesDigits =
        {
            new object[] { 2, new List<int>() { 2 } },
            new object[] { 12, new List<int>() { 1,2 } },
            new object[] { 5729, new List<int>() { 5,7,2,9 } },
        };

        [Test]
        [TestCaseSource(nameof(TestCasesDigits))]
        public void DigitsShouldReconstructCorrectly(int expectedResult, List<int> candidate)
        {
            var test = Digits.ToNum(candidate.ToArray());
            test.ShouldBe(expectedResult);
        }
    }
}
