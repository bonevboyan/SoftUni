using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class ListManipulationBasics
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "end")
                {
                    break;
                }
                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "Add":
                        nums.Add(int.Parse(tokens[1]));
                        break;
                    case "Remove":
                        nums.Remove(int.Parse(tokens[1]));
                        break;
                    case "RemoveAt":
                        nums.RemoveAt(int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        nums.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
