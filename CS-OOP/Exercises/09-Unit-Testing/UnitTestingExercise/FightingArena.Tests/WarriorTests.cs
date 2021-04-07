using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("", 10, 10)]
        [TestCase("  ", 10, 10)]
        [TestCase(null, 10, 10)]
        [TestCase("Warrior", 0, 10)]
        [TestCase("Warrior", -10, 10)]
        [TestCase("Warrior", 10, -10)]
        public void When_CtorArgumentIsInvalid_ShouldThrowException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }
        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void When_HPIsLessThanMinimum_ShouldThrowException(int attackerHP, int warriorHP)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHP);
            Warrior warrior = new Warrior("Warrior", 10, warriorHP);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }
        [Test]
        public void When_WarriorsKillsAttacker_ShouldThrowException()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }
        [Test]
        public void When_Attacking_ShouldDecreaseHP()
        {
            int initialAttackerHP = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialAttackerHP);
            Warrior warrior = new Warrior("Warrior", 30, 100);

            attacker.Attack(warrior);

            Assert.AreEqual(attacker.HP, initialAttackerHP - warrior.Damage);
        }
        [Test]
        public void When_AttackerHasEnoughDamage_ShouldDecreaseEnemyHPToZero()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40);

            attacker.Attack(warrior);

            Assert.AreEqual(warrior.HP, 0);
        }
        [Test]
        public void When_Attacking_ShouldDecreaseEnemyHP()
        {
            int warriorInitialHP = 100;
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, warriorInitialHP);

            attacker.Attack(warrior);

            Assert.AreEqual(warrior.HP, warriorInitialHP - attacker.Damage);
        }
    }
}