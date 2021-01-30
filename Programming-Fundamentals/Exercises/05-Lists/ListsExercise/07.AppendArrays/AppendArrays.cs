using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");
            List<int> nums = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int[] arr = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < arr.Length; j++)
                {
                    nums.Add(arr[j]);
                }
            }
            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
