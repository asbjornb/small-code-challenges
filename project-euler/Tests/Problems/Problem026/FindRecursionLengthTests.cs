using NUnit.Framework;
using project_euler.Problems.ConcreteProblems;
using Shouldly;

namespace Tests.Problem026Tests
{
    [TestFixture]
    internal class FindRecursionLengthTests
    {
        [Test]
        [TestCase("abbaabba", 4)]
        [TestCase("abbaabbaabba", 4)]
        [TestCase("123123", 3)]
        [TestCase("23123123", 3)]
        [TestCase("28571428571428", 6)]
        public void ShouldReturnRecursionLength(string testString, int expectedResult)
        {
            var result = Problem026.GetRecursionLength(testString);

            result.ShouldBe(expectedResult);
        }
    }
}
