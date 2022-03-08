using NUnit.Framework;
using project_euler.Maths.Primes;
using Shouldly;
using System.Collections.Generic;

namespace Tests.Maths
{
    [TestFixture]
    internal class PrimeFactorizationTests
    {
        [Test]
        [TestCaseSource(nameof(TestProductCases))]
        public void ShouldReturnCorrectProduct(List<PrimeFactor> input, int expectedResult)
        {
            var sut = new PrimeFactorization(input);

            sut.Product().ShouldBe(expectedResult);
        }

        static readonly object[] TestProductCases =
        {
            new object[] { new List<PrimeFactor>() { new PrimeFactor(2,2) }, 4 },
            new object[] { new List<PrimeFactor>() { new PrimeFactor(2,2), new PrimeFactor(5, 1) }, 20 },
            new object[] { new List<PrimeFactor>() { new PrimeFactor(3,1), new PrimeFactor(7, 1), new PrimeFactor(11, 1) }, 231 }
        };

        [Test]
        public void ShouldCompare()
        {
            var sut = new PrimeFactorization();
            sut.AddFactor(3);
            sut.AddFactor(11);
            sut.AddFactor(11);
            var comparable = new PrimeFactorization(new List<PrimeFactor>() { new PrimeFactor(3, 1), new PrimeFactor(11, 2) });

            sut.Compare(comparable).ShouldBeTrue();
        }
    }
}
