using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    class Program
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
            }
            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                cars.Where(m => m.Model == inputs[1]).ToList()[0].Drive(double.Parse(inputs[2]));
            }
            cars.ForEach(c => 
            {
                Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTravelled:f0}");
            });
        }
    }
}
/*2
AudiA4 23 0,3
BMW-M2 45 0,42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End
*/