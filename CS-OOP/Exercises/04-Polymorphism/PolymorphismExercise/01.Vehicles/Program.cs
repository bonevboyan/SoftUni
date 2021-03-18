using _01.Vehicles.Contracts;
using _01.Vehicles.Vehicles;
using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            input = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            input = Console.ReadLine().Split();
            Vehicle bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                switch (input[1])
                {
                    case nameof(Car):
                        ExecuteCommand(car, input[0], double.Parse(input[2]));
                        break;
                    case nameof(Truck):
                        ExecuteCommand(truck, input[0], double.Parse(input[2]));
                        break;
                    case nameof(Bus):
                        ExecuteCommand(bus, input[0], double.Parse(input[2]));
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(value);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "DriveEmpty":
                    ((Bus)vehicle).SwitchOffAirConditioner();
                    Console.WriteLine(vehicle.Drive(value));
                    ((Bus)vehicle).SwitchOnAirConditioner();
                    break;
            }
        }
    }
}
