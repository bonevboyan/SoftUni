using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void When_CallingCtor_ShouldInitialise()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void When_ArenaIsEmpty_ShouldCountBeZero()
        {
            Assert.AreEqual(arena.Count, 0);
        }
        [Test]
        public void When_WarriorExists_ShouldThrowException()
        {
            string name = "Warrior";
            arena.Enroll(new Warrior(name, 50, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior(name, 55, 55)));
        }
        [Test]
        public void When_WarriorIsEnrolled_ShouldIncreaseCount()
        {
            arena.Enroll(new Warrior("Warrior", 50, 50));

            Assert.AreEqual(arena.Count, 1);
        }
        [Test]
        public void When_WarriorIsEnrolled_ShouldBeAddedToCollection()
        {
            string name = "Warrior";
            arena.Enroll(new Warrior(name, 50, 50));

            Assert.IsTrue(arena.Warriors.Any(w => w.Name == name));
        }
        [Test]
        public void When_DefenderDoesNotExist_ShouldThrowException()
        {
            string name = "Attacker";
            arena.Enroll(new Warrior(name, 40, 40));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(name, "Defender"));
        }
        [Test]
        public void When_AttackerDoesNotExist_ShouldThrowException()
        {
            string name = "Defender";
            arena.Enroll(new Warrior(name, 40, 40));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", name));
        }
        [Test]
        public void When_BothWarriorsDoNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        }
        [Test]
        public void When_Fighting_ShouldBothWarriorsLoseHP()
        {
            var initialHP = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialHP);
            Warrior defender = new Warrior("Defender", 50, initialHP);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.AreEqual(attacker.HP, initialHP - defender.HP);
            Assert.AreEqual(defender.HP, initialHP - attacker.HP);
        }
    }
}
