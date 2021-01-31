using System;
using System.Linq;

namespace _03.CustomMinFuction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> Min = CustomMin;
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(Min(arr));
        }
        static int CustomMin(int[] nums)
        {
            int min = int.MaxValue;
            foreach (var num in nums)
            {
                if(num < min)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}
