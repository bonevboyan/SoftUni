using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = num[j];
                }
            }
            int primaryDiagonalSum = 0, secondaryDiagonalSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == j)
                    {
                        primaryDiagonalSum += arr[i, j];
                    }
                    if (i + j == n - 1)
                    {
                        secondaryDiagonalSum += arr[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum-secondaryDiagonalSum));
        }
    }
}
