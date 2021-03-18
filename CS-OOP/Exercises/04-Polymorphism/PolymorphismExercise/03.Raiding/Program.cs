using _03.Raiding.Contracts;
using _03.Raiding.HeroTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                switch (heroType)
                { 
                    case nameof(Druid):
                        heroes.Add(new Druid(heroName));
                        break;
                    case nameof(Paladin):
                        heroes.Add(new Paladin(heroName));
                        break;
                    case nameof(Rogue):
                        heroes.Add(new Rogue(heroName));
                        break;
                    case nameof(Warrior):
                        heroes.Add(new Warrior(heroName));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            int heroesCombinedPower = heroes.Select(h => h.Power).Sum();
            heroes.ForEach(h => Console.WriteLine(h.CastAbility()));

            Console.WriteLine(heroesCombinedPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
