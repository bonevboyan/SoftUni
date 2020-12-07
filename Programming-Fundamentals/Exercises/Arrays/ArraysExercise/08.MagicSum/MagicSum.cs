using System;
using System.Linq;

namespace _08.MagicSum
{
    class MagicSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool[] hasBeenPrinted = new bool[arr.Length];
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j && arr[i] + arr[j] == n)
                    {
                        if (!hasBeenPrinted[i] && !hasBeenPrinted[j])
                            Console.WriteLine(arr[i] + " " + arr[j]);
                        hasBeenPrinted[i] = true;
                        hasBeenPrinted[j] = true;
                    }
                }
            }
        }
    }
}
