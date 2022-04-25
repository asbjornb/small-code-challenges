using NUnit.Framework;
using project_euler.Problems.ConcreteProblems;
using Shouldly;

namespace Tests.Problem026Tests
{
    [TestFixture]
    internal class FindRecursionLengthTests
    {
        [Test]
        [TestCase(2, 0)]
        [TestCase(3, 1)]
        [TestCase(6, 1)]
        [TestCase(7, 6)]
        public void ShouldReturnRecursionLength(int test, int expectedResult)
        {
            var result = Problem026.GetRecursionLength(test);

            result.ShouldBe(expectedResult);
        }
    }
}
