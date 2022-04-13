using NUnit.Framework;
using project_euler.Maths.Primes;
using project_euler.Problems.ConcreteProblems;
using Shouldly;

namespace Tests.Problem021Tests
{
    [TestFixture]
    internal class Problem021Tests
    {
        [Test]
        [TestCase(10, 8)]
        [TestCase(220, 284)]
        [TestCase(284, 220)]
        public void ProperDivisorSum(int num, int expectedResult)
        {
            var result = Problem021.DivisorSum(PrimesCalculator.FindPrimeFactors(num))-num;

            result.ShouldBe(expectedResult);
        }
    }
}
