namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Ctor_ShouldInitialiseValue()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(aquarium.Name, name);
            Assert.AreEqual(aquarium.Capacity, capacity);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Name_ShouldThrowException_WhenValueIsInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 50));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Capacity_ShouldThrowException_WhenValueIsInvalid(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("aq", capacity));
        }
        [Test]
        public void Count_ShouldIncrease_WhenFishIsAdded()
        {
            int n = 10;
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            for (int i = 0; i < n; i++)
            {
                aquarium.Add(new Fish("fish"));
            }

            Assert.AreEqual(aquarium.Count, n);
        }
        [Test]
        public void Add_ShouldThrowException_WhenCapacityIsExceeded()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            for (int i = 0; i < capacity; i++)
            {
                aquarium.Add(new Fish("fish"));
            }

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("fish")));
        }
        //}
        //[Test]
        //public void Add_ShouldAddNewFish_WhenCapacityIsNotExceeded()
        //{
        //    string name = "aq";
        //    int capacity = 50;
        //    Aquarium aquarium = new Aquarium(name, capacity);

        //    string fishName = "nemo";

        //    aquarium.Add(new Fish(fishName));

        //    Assert.IsTrue(aquarium.);
        //}
        [Test]
        public void RemoveFish_ShouldThrowException_WhenFishDoesNotExist()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            string fishName = "Nemo";
            aquarium.Add(new Fish(fishName));

            string fasleFishName = "Dori";

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(fasleFishName));
        }
        [Test]
        public void RemoveFish_ShouldRemoveFish_WhenFishExists()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            string fishName = "Nemo";
            aquarium.Add(new Fish(fishName));

            int fishCount = aquarium.Count;
            aquarium.RemoveFish(fishName);

            Assert.AreEqual(fishCount - 1, aquarium.Count);
        }
        [Test]
        public void SellFish_ShouldThrowException_WhenFishDoesNotExist()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            string fishName = "Nemo";
            aquarium.Add(new Fish(fishName));

            string fasleFishName = "Dori";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fasleFishName));
        }

        [Test]
        public void SellFish_ShouldMakeFishUnavailable_WhenFishExists()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            string fishName = "Nemo";
            aquarium.Add(new Fish(fishName));

            Assert.AreEqual(aquarium.SellFish(fishName).Available, false);
        }
        [Test]
        public void Report_ShouldReturnExpectedResult()
        {
            string name = "aq";
            int capacity = 50;
            Aquarium aquarium = new Aquarium(name, capacity);

            string fishName = "Nemo";
            aquarium.Add(new Fish(fishName));

            string expectedResult = $"Fish available at {name}: {fishName}";

            Assert.AreEqual(aquarium.Report(), expectedResult);
        }
    }
}
