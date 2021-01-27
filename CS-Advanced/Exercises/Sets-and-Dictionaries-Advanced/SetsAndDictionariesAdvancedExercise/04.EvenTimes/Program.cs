using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>(); 
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!nums.ContainsKey(num))
                {
                    nums.Add(num, 0);
                }
                nums[num]++;
            }
            nums = nums.Where(o => o.Value % 2 == 0).ToDictionary(k => k.Key, v => v.Value);
            foreach (var value in nums)
            {
                Console.WriteLine(value.Key);
            }
        }
    }
}
