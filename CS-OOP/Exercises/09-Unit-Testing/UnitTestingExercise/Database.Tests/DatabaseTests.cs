using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database(new int[] { });
        }
         
        [Test]
        public void When_TryExceedArrayCapacity_ShouldThrowIOE()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(16));
        }
        [Test]
        public void When_ElementIsAdded_ShouldCountRise()
        {
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(database.Count, n);
        }
        [Test]
        public void When_ElementIsAdded_ShouldItBeSaved()
        {
            int element = 16;
            database.Add(element);

            int[] elements = database.Fetch();
            Assert.IsTrue(elements.Contains(element));
        }
        [Test]
        public void When_ElementIsRemovedAndCountIsZero_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        public void When_ElementIsRemoved_ShouldCountFall()
        {
            database.Add(1);
            database.Add(2);
            database.Remove();

            Assert.AreEqual(database.Count, 1);
        }
        [Test]
        public void When_ElementIsRemoved_ShouldItBeRemoved()
        {
            database.Add(1);
            database.Add(2);

            database.Remove();
            int[] elements = database.Fetch();

            Assert.IsFalse(elements.Contains(2));
        }
        [Test]
        public void When_ArrayIsFetched_ShouldItBeACopy()
        {
            database.Add(1);
            database.Add(2);
            int[] copy = database.Fetch();

            database.Add(3);
            int[] newCopy = database.Fetch();

            Assert.AreNotEqual(copy, newCopy);
        }
        [Test]
        public void When_ArrayIsEmpty_ShouldCountBeZero()
        {
            Assert.AreEqual(database.Count, 0);
        }
        [Test]
        public void When_CtorIsCalled_ShouldThrowIfCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database.Database(Enumerable.Range(1, 17).ToArray()));
        }
        public void When_CtorIsCalled_ShouldAddElementsToDB()
        {
            int[] elements = Enumerable.Range(1, 16).ToArray();
            database = new Database.Database(elements);

            Assert.AreEqual(database.Count, elements.Length);
            Assert.That(database.Fetch(), Is.EquivalentTo(elements));
        }
    }
}