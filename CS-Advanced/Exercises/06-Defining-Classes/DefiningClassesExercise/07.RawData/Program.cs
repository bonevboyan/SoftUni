using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                cars.Add(new Car(
                    commands[0],
                    new Engine
                    {
                        Speed = double.Parse(commands[1]),
                        Power = double.Parse(commands[2])
                    },
                    new Cargo
                    {
                        Weight = double.Parse(commands[3]),
                        Type = commands[4]
                    },
                    new Tire[] 
                    {
                        new Tire
                        {
                            Age = double.Parse(commands[6]),
                            Pressure = double.Parse(commands[5])
                        },
                        new Tire
                        {
                            Age = double.Parse(commands[8]),
                            Pressure = double.Parse(commands[7])
                        },
                        new Tire
                        {
                            Age = double.Parse(commands[10]),
                            Pressure = double.Parse(commands[9])
                        },
                        new Tire
                        {
                            Age = double.Parse(commands[12]),
                            Pressure = double.Parse(commands[11])
                        },
                    }));
            }
            string cargoType = Console.ReadLine();
            if(cargoType == "fragile")
            {
                cars.Where(c => c.Tires.Any(t => t.Pressure < 1))
                    .Where(c => c.Cargo.Type == "fragile")
                    .ToList()
                    .ForEach(c =>
                    {
                        Console.WriteLine(c.Model);
                    });
            }
            else if(cargoType == "flamable")
            {
                cars.Where(c => c.Engine.Power > 250)
                    .Where(c => c.Cargo.Type == "flamable")
                    .ToList()
                    .ForEach(c =>
                    {
                        Console.WriteLine(c.Model);
                    });
            }
        }
    }
}
