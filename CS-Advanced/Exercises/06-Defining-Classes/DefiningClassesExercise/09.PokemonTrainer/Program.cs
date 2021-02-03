using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (command != "Tournament")
            {
                string[] inputs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer = new Trainer
                {
                    Name = inputs[0],
                    NumberOfBadges = 0,
                    Pokemons = new List<Pokemon>()
                };
                if (!trainers.Any(t => t.Name == inputs[0]))
                {
                    trainers.Add(trainer);
                }
                trainers.Where(t => t.Name == inputs[0]).ToList()[0].Pokemons.Add(new Pokemon
                {
                    Name = inputs[1],
                    Element = inputs[2],
                    Health = int.Parse(inputs[3])
                });
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    if(trainers[i].Pokemons.Any(p => p.Element == command))
                    {
                        trainers[i].NumberOfBadges++;
                    }
                    else
                    {
                        trainers[i].Pokemons.ForEach(o => o.Health -= 10);
                        trainers[i].Pokemons = trainers[i].Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
                command = Console.ReadLine();
            }
            trainers.OrderByDescending(t => t.NumberOfBadges).ToList().ForEach(t => 
            {
                Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemons.Count}");
            });
        }
    }
}
