using NUnit.Framework;
using project_euler.Maths.Primes.Generation;
using Shouldly;
using System;
namespace Tests.Maths
{
    [TestFixture]
    internal class PrimeBuilderTests
    {
        [Test]
        [TestCase(10000, 1)]
        [TestCase(10000000, 2)]
        public void ShouldGeneratePrimesFast(int limit, int allowedSeconds)
        {
            Should.CompleteIn(() => PrimeBuilder.BuildPrimesBelow(limit), TimeSpan.FromSeconds(allowedSeconds), "PrimesBuilder too slow");
        }
    }
}
