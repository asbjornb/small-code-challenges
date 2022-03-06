using NUnit.Framework;
using project_euler.Maths;
using Shouldly;
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
            var sut = new Primes();

            var primes = sut.GeneratePrimesBelow(input);

            primes.ShouldBe(expectedResult.ToList());
        }

        [Test]
        public void ShouldGeneratePrimesBelow20WhenCalledTwice()
        {
            var sut = new Primes();

            var _ = sut.GeneratePrimesBelow(10);
            var primes = sut.GeneratePrimesBelow(20);

            primes.ShouldBe((new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }).ToList());
        }

        [Test]
        [TestCase(2, new int[] { 1 })]
        [TestCase(3, new int[] { 0, 1 })]
        [TestCase(4, new int[] { 2, 0 })]
        [TestCase(12, new int[] { 2, 1, 0, 0, 0 })]
        [TestCase(15, new int[] { 0, 1, 1, 0, 0, 0 })]
        public void ShouldFindPrimeFactorsForExamples(int input, int[] expectedResult)
        {
            var sut = new Primes();

            var result = sut.FindPrimeFactors(input);

            result.ShouldBe(expectedResult.ToList());
        }
    }
}
