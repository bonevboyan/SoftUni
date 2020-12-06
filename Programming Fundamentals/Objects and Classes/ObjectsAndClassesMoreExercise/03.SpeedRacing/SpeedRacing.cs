using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPerKm { get; set; }
        public double DistanceTravelled { get; set; }
        public void canDrive(double distanceToTravel)
        {
            if (distanceToTravel > FuelAmount / FuelPerKm)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= distanceToTravel * FuelPerKm;
                DistanceTravelled += distanceToTravel;
            }
        }

    }
    class SpeedRacing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < cars.Capacity; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelPerKm = double.Parse(input[2]);
                Car car = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelPerKm = fuelPerKm,
                    DistanceTravelled = 0
                };
                cars.Add(car);
            }
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] input = line.Split();
                string model = input[1];
                double distance = double.Parse(input[2]);
                cars[cars.FindIndex(o => o.Model == model)].canDrive(distance);
                line = Console.ReadLine();
            }
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{cars[i].Model} {cars[i].FuelAmount:f2} {cars[i].DistanceTravelled}");
            }
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
3
AudiA4 18 0,34
BMW-M2 33 0,41
Ferrari-488Spider 50 0,47
Drive Ferrari-488Spider 97
Drive Ferrari-488Spider 35
Drive AudiA4 85
Drive AudiA4 50
End
*/