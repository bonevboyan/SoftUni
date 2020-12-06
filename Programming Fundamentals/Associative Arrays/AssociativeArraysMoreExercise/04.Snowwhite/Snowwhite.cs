using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Snowwhite
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drawfs = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "Once upon a time")
            {
                string[] input = line.Split(" <:> ");
                string dl = $"({input[1]}) {input[0]}";
                if (!drawfs.ContainsKey(dl))
                {
                    drawfs.Add(dl, 0);
                }
                if (drawfs[dl] < int.Parse(input[2]))
                {
                    drawfs[dl] = int.Parse(input[2]);
                }
                line = Console.ReadLine();
            }

            foreach (var drawf in drawfs.OrderByDescending(o => o.Value).ThenByDescending(o => drawfs.Where(a => a.Key.Split(")")[0] == o.Key.Split(")")[0]).Count()))
            {
                Console.WriteLine($"{drawf.Key} <-> {drawf.Value}");
            }

        }
    }
}
