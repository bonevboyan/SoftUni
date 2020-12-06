using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "end")
                {
                    break;
                }
                if(command[0] == "Add")
                {
                    nums.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if(nums[i] + int.Parse(command[0]) <= capacity)
                        {
                            nums[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
