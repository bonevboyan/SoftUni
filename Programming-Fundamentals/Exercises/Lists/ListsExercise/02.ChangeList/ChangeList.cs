using System;
using System.Linq;

namespace _02.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "end")
                {
                    break;
                }
                switch (command[0])
                {
                    case "Delete":
                        while (nums.Contains(int.Parse(command[1])))
                        {
                            nums.Remove(int.Parse(command[1]));
                        }
                        break;
                    case "Insert":
                        nums.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
