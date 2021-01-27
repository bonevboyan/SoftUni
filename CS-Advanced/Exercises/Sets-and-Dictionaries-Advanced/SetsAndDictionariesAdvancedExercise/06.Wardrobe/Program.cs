using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                if (!clothes.ContainsKey(input[0]))
                {
                    clothes.Add(input[0], new Dictionary<string, int>());
                }
                string[] items = input[1].Split(",");
                foreach (var token in items)
                {
                    if (!clothes[input[0]].ContainsKey(token))
                    {
                        clothes[input[0]].Add(token, 0);
                    }
                    clothes[input[0]][token]++;
                }
            }
            string[] inputs = Console.ReadLine().Split();
            string color = inputs[0];
            string item = inputs[1];
            foreach (var kvp in clothes)
            {
                Console.WriteLine($"{kvp.Key} clothes: ");
                foreach (var value in kvp.Value)
                {
                    if(value.Key == item && color == kvp.Key)
                    {
                        Console.WriteLine($"* {value.Key} - {value.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {value.Key} - {value.Value}");
                    }
                }
            }
        }
    }
}
