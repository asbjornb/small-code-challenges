using NUnit.Framework;
using project_euler.Problems.Problem0128;
using Shouldly;

namespace Tests.Problem0128
{
    [TestFixture]
    internal class HexTests
    {
        [Test]
        public void ShouldRefuteIsInitialized()
        {
            var sut = new Hex(1)
            {
                XUp = new Hex(2)
            };

            sut.IsInitialized.ShouldBeFalse();
        }

        [Test]
        public void ShouldVerifyIsInitialized()
        {
            var sut = new Hex(1)
            {
                XUp = new Hex(2),
                XDown = new Hex(3),
                YUp = new Hex(4),
                YDown = new Hex(5),
                ZUp = new Hex(6),
                ZDown = new Hex(7)
            };

            sut.IsInitialized.ShouldBeTrue();
        }
    }
}
