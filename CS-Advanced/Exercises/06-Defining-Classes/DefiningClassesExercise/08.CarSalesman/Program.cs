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
            List<Engine> engines = new List<Engine>(n);
            double outp = 0;
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine();

                engine.Model = inputs[0];
                engine.Power = double.Parse(inputs[1]);
                engine.Displacement = inputs.Length > 2 ? double.TryParse(inputs[2], out outp) ? double.Parse(inputs[2]) : -1 : -1;
                engine.Efficiency = inputs.Length == 3 ? engine.Displacement == -1 ? inputs[2] : "n/a" : inputs.Length == 4 ? inputs[3] : "n/a";
                engines.Add(engine);
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(m);
            for (int i = 0; i < m; i++)
            { 
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car();
                car.Model = inputs[0];
                car.Engine = engines.Where(e => e.Model == inputs[1]).ToList()[0];
                car.Weight = inputs.Length > 2 ? double.TryParse(inputs[2], out outp) ? double.Parse(inputs[2]) : -1 : -1;
                car.Color = inputs.Length == 3 ? car.Weight == -1 ? inputs[2] : "n/a" : inputs.Length == 4 ? inputs[3] : "n/a";
                cars.Add(car);
            }
            cars.ForEach(c =>
            {
                Console.WriteLine($"{c.Model}:\n" +
                    $"  {c.Engine.Model}:\n" +
                    $"    Power: {c.Engine.Power}\n" +
                    $"    Displacement: {(c.Engine.Displacement != -1 ? c.Engine.Displacement.ToString() : "n/a")}\n" +
                    $"    Efficiency: {c.Engine.Efficiency}\n" +
                    $"  Weight: {(c.Weight != -1 ? c.Weight.ToString() : "n/a")}\n" +
                    $"  Color: {c.Color}");

            });
        }
    }
}
