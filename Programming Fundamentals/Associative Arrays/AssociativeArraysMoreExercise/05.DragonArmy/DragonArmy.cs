using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int[]>> dragons = new Dictionary<string, Dictionary<string, int[]>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[2] == "null")
                {
                    input[2] = "45";
                }
                if (input[3] == "null")
                {
                    input[3] = "250";
                }
                if (input[4] == "null")
                {
                    input[4] = "10";
                }
                if (!dragons.ContainsKey(input[0]))
                {
                    dragons.Add(input[0], new Dictionary<string, int[]>());
                }
                if (!dragons[input[0]].ContainsKey(input[1]))
                {
                    dragons[input[0]].Add(input[1], new int[3]);
                }
                dragons[input[0]][input[1]][0] = int.Parse(input[2]);
                dragons[input[0]][input[1]][1] = int.Parse(input[3]);
                dragons[input[0]][input[1]][2] = int.Parse(input[4]);
            }
            foreach (var type in dragons)
            {
                double avgDmg = 0;
                double avgHP = 0;
                double avgArm = 0;
                int counter = 0;
                foreach (var stat in type.Value)
                {
                    avgDmg += stat.Value[0];
                    avgHP += stat.Value[1];
                    avgArm += stat.Value[2];
                    counter++;
                }
                Console.WriteLine($"{type.Key}::({avgDmg / counter:f2}/{avgHP / counter:f2}/{avgArm / counter:f2})");
                foreach (var dragon in type.Value.OrderBy(o => o.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}
