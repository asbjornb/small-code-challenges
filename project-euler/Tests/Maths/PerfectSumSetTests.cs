using NUnit.Framework;
using project_euler.Maths.Sets;
using Shouldly;
using System.Linq;

namespace Tests.Maths
{
    [TestFixture]
    internal class PerfectSumSetTests
    {
        [Test]
        [TestCase(new int[] { }, true)]
        [TestCase(new int[] { 2 }, true)]
        [TestCase(new int[] { 2, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { 6, 9, 11, 12, 13 }, true)]
        [TestCase(new int[] { 6, 9, 11, 12, 13 }, true)]
        [TestCase(new int[] { 11, 17, 20, 22, 23, 24 }, true)]
        [TestCase(new int[] { 11, 18, 19, 20, 22, 25 }, true)]
        [TestCase(new int[] { 11, 18, 19, 20, 22, 25 }, true)]
        [TestCase(new int[] { 20, 31, 38, 39, 40, 42, 45 }, true)]
        [TestCase(new int[] { 20, 31, 37, 39, 40, 42, 45 }, false)]
        public void ShouldGenerateCorrectly(int[] candidateSet, bool expectedResult)
        {
            var sut = PerfectSumSet.Create();
            var result = candidateSet.All(x => sut.Add(x));
            
            result.ShouldBe(expectedResult);
        }
    }
}
