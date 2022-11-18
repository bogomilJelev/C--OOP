using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestOne()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver pesho = new UnitDriver("Pesho", new UnitCar("mazda", 200, 200));
            race.AddDriver(pesho);
            Assert.That(race.Counter.Equals(1));
        }
        [Test]
        public void Testtwo()
        {
            RaceEntry race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }
        [Test]
        public void Testthree()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver pesho = new UnitDriver("Pesho", new UnitCar("mazda", 200, 200));
            race.AddDriver(pesho);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(pesho));
        }

        [Test]
        public void Testfour()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver pesho = new UnitDriver("Pesho", new UnitCar("mazda", 200, 200));
            race.AddDriver(pesho);
            UnitDriver pesho2 = new UnitDriver("Pesho2", new UnitCar("opel", 300, 300));
            race.AddDriver(pesho2);
            Assert.That(race.CalculateAverageHorsePower().Equals(250));
        }

        [Test]
        public void Testfive()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver pesho = new UnitDriver("Pesho", new UnitCar("mazda", 200, 200));
            race.AddDriver(pesho);
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());


        }
    }
}