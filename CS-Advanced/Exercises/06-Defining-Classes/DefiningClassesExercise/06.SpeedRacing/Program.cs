using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car
                {
                    Model = inputs[0],
                    FuelAmount = double.Parse(inputs[1]),
                    FuelConsumptionPerKilometer = double.Parse(inputs[2]),
                    DistanceTravelled = 0,
                };
                cars.Add(car);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] inputs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                cars.Where(m => m.Model == inputs[1]).ToList()[0].Drive(double.Parse(inputs[2]));
                command = Console.ReadLine();
            }
            cars.ForEach(c =>
            {
                Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTravelled:f0}");
            });
        }
    }
}
