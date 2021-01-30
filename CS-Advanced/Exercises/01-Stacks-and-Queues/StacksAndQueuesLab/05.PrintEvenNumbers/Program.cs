using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> nums = new Queue<int>(input);
            Queue<int> evenNums = new Queue<int>();
            while (nums.Count > 0)
            {
                if (nums.Peek() % 2 == 0)
                {
                    evenNums.Enqueue(nums.Dequeue());
                }
                else
                {
                    nums.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
