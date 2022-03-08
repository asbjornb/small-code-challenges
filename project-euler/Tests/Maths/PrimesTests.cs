using NUnit.Framework;
using project_euler.Maths;
using project_euler.Maths.Primes;
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
            var sut = new ListOfPrimes();

            var primes = sut.GeneratePrimesBelow(input);

            primes.ShouldBe(expectedResult.ToList());
        }

        [Test]
        public void ShouldGeneratePrimesBelow20WhenCalledTwice()
        {
            var sut = new ListOfPrimes();

            var _ = sut.GeneratePrimesBelow(10);
            var primes = sut.GeneratePrimesBelow(20);

            primes.ShouldBe((new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }).ToList());
        }

        [Test]
        [TestCaseSource(nameof(TestProductCases))]
        public void ShouldFindPrimeFactorsForExamples(int input, List<PrimeFactor> expectedResult)
        {
            var sut = new ListOfPrimes();

            var result = sut.FindPrimeFactors(input).ToList();

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
