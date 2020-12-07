using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    class VehicleCatalogue
    {
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string line = Console.ReadLine();
            double totalCarHP = 0, totalTruckHP = 0; 
            while (line != "End")
            {
                string[] input = line.Split(" ");

                string type = input[0];
                string model = input[1];
                string color = input[2];
                int hp = int.Parse(input[3]);

                Vehicle vehicle = new Vehicle
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    HorsePower = hp
                };
                if(vehicle.Type == "car")
                {
                    totalCarHP += vehicle.HorsePower;
                }
                else if (vehicle.Type == "truck")
                {
                    totalTruckHP += vehicle.HorsePower;
                }
                vehicles.Add(vehicle);
                line = Console.ReadLine();
            }
            line = Console.ReadLine();
            while (line != "Close the Catalogue")
            {
                Vehicle match = new Vehicle();
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if(vehicles[i].Model == line)
                    {
                        match = vehicles[i];
                        break;
                    }
                }

                Console.WriteLine($"Type: {UppercaseFirst(match.Type)}\nModel: {match.Model}\nColor: {match.Color}\nHorsepower: {match.HorsePower}");
                
                line = Console.ReadLine();
            }
            double carAverageHP = totalCarHP / vehicles.Where(o => o.Type == "car").ToList().Count;
            double truckAverageHP = totalTruckHP / vehicles.Where(o => o.Type == "truck").ToList().Count;
            Console.WriteLine($"Cars have average horsepower of: {carAverageHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAverageHP:f2}.");
        }
    }
}