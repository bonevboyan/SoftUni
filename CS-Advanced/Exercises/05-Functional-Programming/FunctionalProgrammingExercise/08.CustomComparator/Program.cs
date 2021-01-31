using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(arr);

            Func<int, bool> isEven = p => Math.Abs(p) % 2 == 0;
            Func<int, bool> isOdd = p => Math.Abs(p) % 2 == 1;

            Console.WriteLine(string.Join(' ', arr.Where(isEven)) + ' ' + string.Join(' ', arr.Where(isOdd)));

        }
    }
}
