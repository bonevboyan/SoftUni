using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Car
    {
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public Cargo CarCargo { get; set; }
        public Car(string[] input)
        {
            Model = input[0];
            Engine engine = new Engine();
            engine.Speed = int.Parse(input[1]);
            engine.Power = int.Parse(input[2]);
            CarEngine = engine;
            Cargo cargo = new Cargo();
            cargo.Weight = int.Parse(input[3]);
            cargo.Type = input[4];
            CarCargo = cargo;
        }
    }
    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

    }
    class Cargo 
    {
        public int Weight { get; set; }
        public string Type { get; set; }
    }
    class RawData
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                cars.Add(new Car(input));
            }

            string cargoType = Console.ReadLine();
            if (cargoType == "fragile") 
            {
                cars = cars.Where(o => o.CarCargo.Type == cargoType).Where(o => o.CarCargo.Weight < 1000).ToList();
            }
            else if(cargoType == "flamable")
            {
                cars = cars.Where(o => o.CarCargo.Type == cargoType).Where(o => o.CarEngine.Power > 250).ToList();
            }

            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine(cars[i].Model);
            }
        }
    }
}
