namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void IsAcquaDone()
        {
            Aquarium aqua = new Aquarium("akvarium", 10);

            Assert.That(aqua.Name.Equals("akvarium"));
            Assert.That(aqua.Capacity.Equals(10));
        }
        [Test]
        public void IsNameTrowEx()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
        }
        [Test]
        public void IsCapacityTrowEx()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("akva", -2));
        }
        [Test]
        public void CountTest()
        {
            Aquarium aqua = new Aquarium("akvarium", 10);
            aqua.Add(new Fish("Pesho"));
            Assert.That(aqua.Count == 1);
        }
        [Test]
        public void AddIngTest()
        {
            Aquarium aqua = new Aquarium("akvarium", 1);
            aqua.Add(new Fish("Pesho"));
            Assert.Throws<InvalidOperationException>(() => aqua.Add(new Fish("Goshho")));
        }
    }
}
