using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weigth { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class CatalogVehicle
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            CatalogVehicle vehicle = new CatalogVehicle()
            {
                Cars = new List<Car>(),
                Trucks = new List<Truck>()
            };
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] input = line.Split('/');
                if (input[0] == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = input[1],
                        Model = input[2],
                        HorsePower = int.Parse(input[3])
                    };
                    vehicle.Cars.Add(car);
                }
                else if (input[0] == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = input[1],
                        Model = input[2],
                        Weigth = int.Parse(input[3])
                    };
                    vehicle.Trucks.Add(truck);
                }
                line = Console.ReadLine();
            }
            vehicle.Cars = vehicle.Cars.OrderBy(o => o.Brand).ToList();
            vehicle.Trucks = vehicle.Trucks.OrderBy(o => o.Brand).ToList();
            if (vehicle.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
            }
            for (int i = 0; i < vehicle.Cars.Count; i++)
            {
                Console.WriteLine($"{vehicle.Cars[i].Brand}: {vehicle.Cars[i].Model} - {vehicle.Cars[i].HorsePower}hp");
            }
            if (vehicle.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
            }
            for (int i = 0; i < vehicle.Trucks.Count; i++)
            {
                Console.WriteLine($"{vehicle.Trucks[i].Brand}: {vehicle.Trucks[i].Model} - {vehicle.Trucks[i].Weigth}kg");
            }
        }
    }
}

