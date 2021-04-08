using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitCar car;
        private UnitDriver driver;
        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            car = new UnitCar("AE86", 100, 1000);
            driver = new UnitDriver("Takumi", car);
        }

        [Test]
        public void AddDriver_ShouldThrowException_WhenDriverIsNull()
        {
            UnitDriver driver = null;
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }
        [Test]
        public void AddDriver_ShouldThrowException_WhenDriverExists()
        {
            race.AddDriver(driver);

            UnitDriver sameDriver = new UnitDriver(driver.Name, car);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(sameDriver));
        }
        [Test]
        public void AddDriver_ShouldIncreaseCount_WhenDriverIsValidAndDoesNotAlreadyExist()
        {
            race.AddDriver(driver);
            UnitCar newCar = new UnitCar("GTR", 200, 2000);
            UnitDriver newDriver = new UnitDriver("Tofu", newCar);
            race.AddDriver(newDriver);

            Assert.AreEqual(race.Counter, 2);
        }
        [Test]
        public void CalculateAverageHorsePower_ShouldThrowException_WhenDriverCountIsLessThanMin()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePower_ShouldReturnExpectedResult_WhenDriverCountIsValid()
        {
            race.AddDriver(driver);
            UnitCar newCar = new UnitCar("GTR", 200, 2000);
            UnitDriver newDriver = new UnitDriver("Tofu", newCar);
            race.AddDriver(newDriver);

            Assert.AreEqual(race.CalculateAverageHorsePower(), 150);
        }
    }
}