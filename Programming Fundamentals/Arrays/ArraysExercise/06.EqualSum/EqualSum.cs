using System;
using System.Linq;

namespace _06.EqualSum
{
    class EqualSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                int firstSum = 0, secondSum = 0;
                for (int j = 0; j < i; j++)
                {
                    firstSum += arr[j];
                }
                for (int j = i + 1; j < arr.Length; j++)
                {
                    secondSum += arr[j];
                }
                if (firstSum == secondSum)
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
