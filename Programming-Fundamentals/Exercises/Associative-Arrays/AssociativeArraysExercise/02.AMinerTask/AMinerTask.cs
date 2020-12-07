using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> strs = new Dictionary<string, int>();
            string line = Console.ReadLine();
            while (line != "stop")
            {
                int value = int.Parse(Console.ReadLine());
                string[] input = line.Split();
                if (strs.ContainsKey(line))
                {
                    strs[line]+=value;
                }
                else
                {
                    strs.Add(line, value);
                }
                line = Console.ReadLine();
            }
            foreach (var ch in strs)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}
