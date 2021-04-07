using NUnit.Framework;
using ExtendedDatabase;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void When_CapacityIsExceeded_ShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new Person(i, $"Username{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, "InvalidUsername")));
        }
        [Test]
        public void When_UsernameIsTaken_ShouldThrowException()
        {
            string username = "Pesho";
            extendedDatabase.Add(new Person(1, username));
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(16, username)));
        }
        [Test]
        public void When_IdIsTaken_ShouldThrowException()
        {
            int id = 1;
            extendedDatabase.Add(new Person(id, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(id, "Gosho")));
        }
        [Test]
        public void When_PersonIsValid_ShouldIncreaseCounter()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(2, "Gosho"));
            Assert.AreEqual(extendedDatabase.Count, 2);
        }
        [Test]
        public void When_DBIsEmptyAndRemoveIsUsed_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }
        [Test]
        public void When_ElementIsRemoved_ShouldCountDecrease()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                extendedDatabase.Add(new Person(i, $"Username{i}"));
            }
            extendedDatabase.Remove();

            Assert.AreEqual(extendedDatabase.Count, n - 1);
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(n - 1));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_FindByUsernameIsNotValid_ShouldThrowException(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(username));
        }
        [Test]
        public void When_FindByUsernameDoesNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("username"));
        }
        [Test]
        public void When_UserExists_ShouldReturnExpecterUser()
        {
            Person person = new Person(1, "Pesho");
            extendedDatabase.Add(person);

            Person samePerson = extendedDatabase.FindByUsername(person.UserName);
            Assert.AreEqual(person, samePerson);

        }
        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void When_IdIsLessThanZero_ShouldThrowException(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(id));

        }
        [Test]
        public void When_IdDoesNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(100));

        }
        [Test]
        public void When_IdExists_ShouldReturnExpectedUser()
        {
            Person person = new Person(1, "Pesho");
            extendedDatabase.Add(person);

            Person samePerson = extendedDatabase.FindByUsername(person.UserName);
            Assert.AreEqual(person, samePerson);

        }
        [Test]
        public void When_CapacityIsExceeded_ShouldCtorThrowException()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people));

        }
        [Test]
        public void When_CapacityIsNotExceeded_ShouldCtorAddToDB()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.AreEqual(extendedDatabase.Count, people.Length);

            foreach (var person in people)
            {
                Person samePerson = extendedDatabase.FindById(person.Id);
                Assert.AreEqual(person, samePerson);
            }

        }
    }
}