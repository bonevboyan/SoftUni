using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("","Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -50)]
        public void When_DataIsInvalid_ShouldCtorThrowException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void When_DataIsValid_ShouldCtorInitialise()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void When_FuelIsInvalid_ShouldThrowException(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }
        [Test]
        public void When_FuelAmountIsValid_ShouldFuelIncrease()
        {
            double refuelAmount = car.FuelCapacity / 2;
            car.Refuel(refuelAmount);
            Assert.AreEqual(car.FuelAmount, refuelAmount);
        }
        [Test]
        public void When_FuelCapacityIsExceeded_ShouldFuelBeSetToCapacity()
        {
            car.Refuel(car.FuelCapacity * 1.2);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
        [Test]
        public void When_FuelIsZero_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }
        [Test]
        public void When_DistanceIsValid_ShouldDecreaseFuelAmount()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);

            car.Drive(100);

            Assert.AreEqual(car.FuelAmount, initialFuel - car.FuelConsumption);

        }
        [Test]
        public void When_FuelIsJustEnough_ShouldDecreaseFuelAmountToZero()
        {
            car.Refuel(car.FuelCapacity);

            double distance = car.FuelCapacity * 100 / car.FuelConsumption;
            car.Drive(distance);
            Assert.AreEqual(car.FuelAmount, 0);

        }
        [Test]
        public void When_FuelIsNegative_ShouldThrowException()
        {
            car.Refuel(car.FuelCapacity);
            double before = car.FuelAmount;

            car.Drive(100);
            double after = car.FuelAmount;

            Assert.Less(after, before);

        }
    }
}