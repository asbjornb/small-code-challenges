using NUnit.Framework;
using project_euler.Maths.Primes;
using project_euler.Maths.Primes.Generation;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Maths
{
    [TestFixture]
    internal class PrimesTests
    {
        [Test]
        [TestCase(2, new int[] { })]
        [TestCase(3, new int[] { 2 })]
        [TestCase(4, new int[] { 2, 3 })]
        [TestCase(20, new int[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
        public void ShouldGeneratePrimesBelowForExamples(int input, int[] expectedResult)
        {
            var sut = ListOfPrimes.Construct();

            var primes = sut.GetPrimesBelow(input).ToList();

            primes.ShouldBe(expectedResult.ToList());
        }

        [Test]
        public void ShouldGeneratePrimesBelow20WhenCalledTwice()
        {
            var sut = ListOfPrimes.Construct();

            var _ = sut.GetPrimesBelow(10);
            var primes = sut.GetPrimesBelow(20);

            primes.ShouldBe((new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }).ToList());
        }

        [Test]
        [TestCaseSource(nameof(TestProductCases))]
        public void ShouldFindPrimeFactorsForExamples(int input, List<PrimeFactor> expectedResult)
        {
            var result = PrimesCalculator.FindPrimeFactors(input).ToList();

            result.ShouldBe(expectedResult.ToList());
        }

        static readonly object[] TestProductCases =
        {
            new object[] { 2, new List<PrimeFactor>() { new PrimeFactor(2,1) } },
            new object[] { 3, new List<PrimeFactor>() { new PrimeFactor(3,1) } },
            new object[] { 4, new List<PrimeFactor>() { new PrimeFactor(2,2) } },
            new object[] { 12, new List<PrimeFactor>() { new PrimeFactor(2,2), new PrimeFactor(3,1) } },
            new object[] { 15, new List<PrimeFactor>() { new PrimeFactor(3,1), new PrimeFactor(5,1) } }
        };
    }
}
