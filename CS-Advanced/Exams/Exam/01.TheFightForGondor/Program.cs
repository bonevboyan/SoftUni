using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            List<int> plates = new List<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> orcs = new Stack<int>();
            for (int i = 0; i < numberOfWaves; i++)
            {
                orcs = new Stack<int>();
                foreach (var orc in Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse))
                {
                    orcs.Push(orc);
                }
                if((i + 1) % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }
                while (orcs.Count != 0)
                {
                    if (orcs.Peek() == plates[0])
                    {
                        orcs.Pop();
                        plates.RemoveAt(0);
                    }
                    else if (orcs.Peek() > plates[0])
                    {
                        orcs.Push(orcs.Pop() - plates[0]);
                        plates.RemoveAt(0);
                    }
                    else if (orcs.Peek() < plates[0])
                    {
                        plates[0] -= orcs.Pop();
                    }
                    if (plates.Count == 0)
                    {
                        Console.Write($"The orcs successfully destroyed the Gondor's defense.\nOrcs left: ");
                        List<int> remaining = new List<int>();
                        foreach (var orc in orcs)
                        {
                            remaining.Add(orc);
                        }
                        Console.WriteLine(string.Join(", ", remaining));

                        return;
                    }
                }
            }
            
            Console.WriteLine($"The people successfully repulsed the orc's attack.\nPlates left: {string.Join(", ", plates)}");
        }
    }
}
