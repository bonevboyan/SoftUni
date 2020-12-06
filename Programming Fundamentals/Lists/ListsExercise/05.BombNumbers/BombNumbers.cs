using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int specialNum = input[0], power = input[1], sum = 0;
            while (nums.Contains(specialNum)) {
                int specialNumIndex = nums.IndexOf(specialNum);
                int count = nums.Count - 1;
                for (int i = Math.Max(0, specialNumIndex - power); i <= Math.Min(count, specialNumIndex + power); i++)
                    nums.RemoveAt(Math.Max(0, specialNumIndex - power));
            }
            for (int i = 0; i < nums.Count; i++)
                sum += nums[i];
            Console.WriteLine(sum);
        }
    }
}
