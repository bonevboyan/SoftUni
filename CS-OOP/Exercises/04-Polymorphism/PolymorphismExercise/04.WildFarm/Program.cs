using _04.WildFarm.Contracts;
using _04.WildFarm.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while(command != "End")
            {
                string[] tokens = command.Split();
                animals.Add(GetAnimal(tokens));
                Console.WriteLine(animals[animals.Count - 1].MakeSound());

                command = Console.ReadLine();
                tokens = command.Split();
                animals[animals.Count - 1].Eat(tokens[0], int.Parse(tokens[1]));

                command = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
        static Animal GetAnimal(string[] info)
        {
            switch (info[0])
            {
                case nameof(Cat):
                    return new Cat { Name = info[1], Weight = double.Parse(info[2]), LivingRegion = info[3], Breed = info[4], FoodEaten = 0 };

                case nameof(Tiger):
                    return new Tiger { Name = info[1], Weight = double.Parse(info[2]), LivingRegion = info[3], Breed = info[4], FoodEaten = 0 };

                case nameof(Mouse):
                    return new Mouse { Name = info[1], Weight = double.Parse(info[2]), LivingRegion = info[3], FoodEaten = 0 };

                case nameof(Dog):
                    return new Dog { Name = info[1], Weight = double.Parse(info[2]), LivingRegion = info[3], FoodEaten = 0 };

                case nameof(Owl):
                    return new Owl { Name = info[1], Weight = double.Parse(info[2]), WingSize = double.Parse(info[3]), FoodEaten = 0 };

                case nameof(Hen):
                    return new Hen { Name = info[1], Weight = double.Parse(info[2]), WingSize = double.Parse(info[3]), FoodEaten = 0 };

                default:
                    return null;
            }
        }
    }
}
