using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.ListManipulationAdvanced
{
    class ListManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isChanged = false;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "Add":
                        nums.Add(int.Parse(tokens[1]));
                        isChanged = true;
                        break;
                    case "Remove":
                        nums.Remove(int.Parse(tokens[1]));
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        nums.RemoveAt(int.Parse(tokens[1]));
                        isChanged = true;
                        break;
                    case "Insert":
                        nums.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        isChanged = true;
                        break;
                    case "Contains":
                        if (nums.Contains(int.Parse(tokens[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0)
                            {
                                Console.Write(nums[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "PrintOdd":

                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 != 0)
                            {
                                Console.Write(nums[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < nums.Count; i++)
                        {
                            sum += nums[i];
                        }
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            switch (tokens[1])
                            {
                                case "<":
                                    if (nums[i] < int.Parse(tokens[2]))
                                    {
                                        Console.Write(nums[i] + " ");
                                    }
                                    break;
                                case ">":
                                    if (nums[i] > int.Parse(tokens[2]))
                                    {
                                        Console.Write(nums[i] + " ");
                                    }
                                    break;
                                case ">=":
                                    if (nums[i] >= int.Parse(tokens[2]))
                                    {
                                        Console.Write(nums[i] + " ");
                                    }
                                    break;
                                case "<=":
                                    if (nums[i] <= int.Parse(tokens[2]))
                                    {
                                        Console.Write(nums[i] + " ");
                                    }
                                    break;
                            }
                        }
                        Console.WriteLine();
                        break;
                }
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
