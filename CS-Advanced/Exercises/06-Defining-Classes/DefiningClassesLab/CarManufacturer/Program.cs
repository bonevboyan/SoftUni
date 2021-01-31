using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Tire[]> tires = new List<Tire[]>();
            while(command!="No more tires")
            {
                double[] inputs = command.Split().Select(double.Parse).ToArray();
                Tire[] curentTires = new Tire[4]
                {
                    new Tire((int) inputs[0], inputs[1]),
                    new Tire((int) inputs[2], inputs[3]),
                    new Tire((int) inputs[4], inputs[5]),
                    new Tire((int) inputs[6], inputs[7]),
                };
                tires.Add(curentTires);
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            List<Engine> engines = new List<Engine>();
            while (command != "Engines done")
            {
                double[] inputs = command.Split().Select(double.Parse).ToArray();
                Engine engine = new Engine((int)inputs[0], inputs[1]);
                engines.Add(engine);
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            List<Car> cars = new List<Car>();
            while (command != "Show special")
            {
                string[] inputs = command.Split().ToArray();
                Car car = new Car(inputs[0], 
                    inputs[1], 
                    int.Parse(inputs[2]), 
                    double.Parse(inputs[3]), 
                    double.Parse(inputs[4]),
                    engines[int.Parse(inputs[5])],
                    tires[int.Parse(inputs[6])]);
                cars.Add(car);
                command = Console.ReadLine();
            }
            List<Car> specialCars = new List<Car>();
            foreach (Car car in cars)
            {
                if(car.Year >= 2017 && car.TiresSum() >= 9 && car.TiresSum() <= 10 && car.Engine.HorsePower >= 330)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}