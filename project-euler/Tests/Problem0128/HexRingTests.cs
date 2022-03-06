using NUnit.Framework;
using project_euler.Problems.Problem0128;
using Shouldly;

namespace Tests.Problem0128
{
    [TestFixture]
    internal class HexRingTests
    {
        [Test]
        public void ShouldConstructFirstRing()
        {
            var sut = HexRing.ConstructRing();

            sut.ShouldNotBeNull();
            sut.RingNumber.ShouldBe(1);
            sut.Ring.Count.ShouldBe(1);
        }

        [Test]
        public void ShouldConstructSecondRing()
        {
            var ring1 = HexRing.ConstructRing();
            var sut = HexRing.ConstructRing(ring1);

            sut.ShouldNotBeNull();
            sut.RingNumber.ShouldBe(2);
            sut.Ring.Count.ShouldBe(6);
        }

        //Fails - current implementation don't handle case where new Hex binds to 2 hexes in inner ring
        [Test]
        public void ShouldConstructThirdRing()
        {
            var ring1 = HexRing.ConstructRing();
            var ring2 = HexRing.ConstructRing(ring1);
            var sut = HexRing.ConstructRing(ring2);

            sut.ShouldNotBeNull();
            sut.RingNumber.ShouldBe(3);
            sut.Ring.Count.ShouldBe(12);
        }
    }
}
