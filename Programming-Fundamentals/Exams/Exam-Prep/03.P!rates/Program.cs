using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, City> cities= new Dictionary<string, City>();
            while(line != "Sail")
            {
                string[] input = line.Split("||");
                string name = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (cities.ContainsKey(name))
                {
                    cities[name].Population += population;
                    cities[name].Gold += gold;
                }
                else
                {
                    City city = new City
                    {
                        Population = population,
                        Gold = gold
                    };
                    cities.Add(name, city);
                }
                line = Console.ReadLine();
            }
            line = Console.ReadLine();
            while (line != "End")
            {
                string[] input = line.Split("=>");
                string type = input[0];
                if (type == "Plunder")
                {

                    string town = input[1];
                    int people = int.Parse(input[2]);
                    int gold = int.Parse(input[3]);
                    cities[town].Population -= people;
                    cities[town].Gold -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                } 
                else if (type == "Prosper")
                {
                    string town = input[1];
                    int gold = int.Parse(input[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");

                    }
                }
                line = Console.ReadLine();
            }
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var city in cities.OrderByDescending(o => o.Value.Gold).ThenBy(o => o.Key))
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
            }
        }
    }
}
