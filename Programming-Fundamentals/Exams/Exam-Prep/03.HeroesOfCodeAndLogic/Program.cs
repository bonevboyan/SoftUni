using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogic
{
    class Hero
    {
        public int MP { get; set; }
        public int HP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            int n = int.Parse(Console.ReadLine());
            string line = string.Empty;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                string[] tokens = line.Split();
                Hero hero = new Hero
                {
                    HP = int.Parse(tokens[1]),
                    MP = int.Parse(tokens[2])
                };
                heroes.Add(tokens[0], hero);
            }
            line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(" - ");
                string action = tokens[0];
                if (action == "CastSpell")
                {
                    string name = tokens[1];
                    int mp = int.Parse(tokens[2]);
                    string spell = tokens[3];
                    if (heroes[name].MP >= mp)
                    {
                        heroes[name].MP -= mp;
                        Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    string name = tokens[1];
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];
                    if(heroes[name].HP - damage > 0)
                    {
                        heroes[name].HP -= damage;
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        heroes.Remove(name);
                    }
                }
                else if(action == "Recharge")
                {
                    string name = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    if (heroes[name].MP + amount > 200)
                    {
                        amount = 200 - heroes[name].MP;
                    }
                    heroes[name].MP += amount;
                    Console.WriteLine($"{name} recharged for {amount} MP!");
                }
                else if (action == "Heal")
                {
                    string name = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    if (heroes[name].HP + amount > 100)
                    {
                        amount = 100 - heroes[name].HP;
                    }
                    heroes[name].HP += amount;
                    Console.WriteLine($"{name} healed for {amount} HP!");
                }
                line = Console.ReadLine();
            }
            foreach (var hero in heroes.OrderByDescending(o => o.Value.HP).ThenBy(o => o.Key))
            {
                Console.WriteLine($"{hero.Key}\n  HP: {hero.Value.HP}\n  MP: {hero.Value.MP}");
            }
        }
    }
}
