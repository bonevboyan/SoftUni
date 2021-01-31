using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {;
            Func<int[], int[]> reverse = arr =>
            {
                int[] reversedArr = new int[arr.Length];
                int count = arr.Length - 1;
                foreach (var num in arr)
                {
                    reversedArr[count] = num;
                    count--;
                }
                return reversedArr;
            };

            int[] nums = reverse(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> isDivisible = num => num % divisor != 0;
            Console.WriteLine(string.Join(" ", nums.Where(isDivisible)));
        }
    }
}
