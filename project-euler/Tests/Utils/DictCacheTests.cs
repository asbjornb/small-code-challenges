using NUnit.Framework;
using project_euler.Util;
using Shouldly;

namespace Tests.Utils
{
    [TestFixture]
    internal class DictCacheTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(12)]
        public void ShouldOnlyInvokeFirstTime(int testValue)
        {
            var sut = new DictCache<int, int>();

            var counter = 0;
            int function(int x) { counter++; return x; }

            var result = sut.Get(testValue, function);
            result.ShouldBe(testValue);
            counter.ShouldBe(1);

            result = sut.Get(testValue, function);
            result.ShouldBe(testValue);
            counter.ShouldBe(1);

            result = sut.Get(testValue + 1, function);
            result.ShouldBe(testValue + 1);
            counter.ShouldBe(2);
        }
    }
}
