using System;

namespace _02.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] prevArr = { 1 };
            Console.WriteLine("1");
            for (int i = 1; i < n; i++)
            {
                int[] arr = new int[i + 1];
                arr[0] = prevArr[0];
                Console.Write(arr[0] + " ");
                for (int j = 1; j < arr.Length-1; j++)
                {
                    arr[j] = prevArr[j] + prevArr[j - 1];
                    Console.Write(arr[j] + " ");
                }
                arr[arr.Length - 1] = prevArr[prevArr.Length - 1];
                Console.Write(arr[arr.Length - 1] + " ");
                prevArr = arr;
                Console.WriteLine();
            }
        }
    }
}
