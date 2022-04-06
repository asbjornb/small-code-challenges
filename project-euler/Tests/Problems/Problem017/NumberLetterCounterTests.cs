using NUnit.Framework;
using project_euler.Problems.ConcreteProblems.Problem017Model;
using Shouldly;

namespace Tests.Problem017Tests
{
    [TestFixture]
    internal class NumberLetterCounterTests
    {
        [Test]
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 5)]
        [TestCase(4, 4)]
        [TestCase(5, 4)]
        [TestCase(6, 3)]
        [TestCase(7, 5)]
        [TestCase(8, 5)]
        [TestCase(9, 4)]
        [TestCase(10, 3)]
        [TestCase(11, 6)]
        [TestCase(12, 6)]
        [TestCase(13, 8)]
        [TestCase(14, 8)]
        [TestCase(15, 7)]
        [TestCase(16, 7)]
        [TestCase(17, 9)]
        [TestCase(18, 8)]
        [TestCase(19, 8)]
        [TestCase(20, 6)]
        [TestCase(21, 9)]
        [TestCase(30, 6)]
        [TestCase(38, 11)]
        [TestCase(115, 20)]
        [TestCase(200, 10)]
        [TestCase(220, 19)]
        [TestCase(342, 23)]
        [TestCase(719, 23)]
        [TestCase(720, 21)]
        [TestCase(960, 19)]
        [TestCase(963, 24)]
        public void ShouldReturnLetterCount(int testNum, int expectedResult)
        {
            var sut = new NumberLetterCounter();

            var result = sut.Convert(testNum);

            result.ShouldBe(expectedResult);
        }
    }
}
