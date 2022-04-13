using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace Tests.LearningTests
{
    [TestFixture]
    internal class StringParseTests
    {
        [Test]
        [TestCase("5", 5)]
        [TestCase("12", 12)]
        [TestCase("04", 4)]
        public void ShouldParseStringsToInt(string testString, int expected)
        {
            int.Parse(testString).ShouldBe(expected);
        }

        [Test]
        [TestCase("75", new[] { 75 })]
        [TestCase("53 71 44 65 25 43 91 52 97 51 14", new[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 })]
        public void ShouldParseStringsToIntArrays(string testString, int[] expected)
        {
            testString.Split(' ').Select(y => int.Parse(y)).ToArray().ShouldBe(expected);
        }
    }
}
