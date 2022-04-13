using NUnit.Framework;
using project_euler.Maths.NumberTheory;
using Shouldly;

namespace Tests.Problem021Tests
{
    [TestFixture]
    internal class NumberTheoryCalculatorTests
    {
        [Test]
        [TestCase(10, 8)]
        [TestCase(220, 284)]
        [TestCase(284, 220)]
        public void ProperDivisorSum(int num, int expectedResult)
        {
            var result = NumberTheoryCalculator.ProperDivisorSum(num);

            result.ShouldBe(expectedResult);
        }
    }
}
