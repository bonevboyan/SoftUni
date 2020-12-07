using System;
using System.Collections.Generic;
using System.Dynamic;

namespace _03.HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ");
                if(tokens.Length == 3){
                    if (!names.Contains(tokens[0]))
                    {
                        names.Add(tokens[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[0]} is already in the list!");
                    }
                }
                else
                {
                    if (!names.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} is not in the list!");
                    }
                    else
                    {
                        names.Remove(tokens[0]);
                    }
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
