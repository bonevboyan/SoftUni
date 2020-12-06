using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "End")
                {
                    break;
                }
                switch (command[0])
                {
                    case "Add":
                        nums.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        if (int.Parse(command[2]) < nums.Count && int.Parse(command[2]) >= 0)
                            nums.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        else
                            Console.WriteLine("Invalid index");
                        break;
                    case "Remove":
                        if (int.Parse(command[1]) < nums.Count && int.Parse(command[1]) >= 0)
                            nums.RemoveAt(int.Parse(command[1]));
                        else
                            Console.WriteLine("Invalid index");
                        break;
                    case "Shift":
                        if (command[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                int num = nums[0];
                                nums.RemoveAt(0);
                                nums.Add(num);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < int.Parse(command[2]); i++)
                            {
                                int num = nums[nums.Count - 1];
                                nums.RemoveAt(nums.Count - 1);
                                nums.Insert(0, num);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
