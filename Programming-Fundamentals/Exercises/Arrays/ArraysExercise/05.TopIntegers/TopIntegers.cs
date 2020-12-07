using System;
using System.Linq;

namespace _05.TopIntegers
{
    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool[] isTop = new bool[arr.Length];
            for (int i = 0; i < isTop.Length; i++)
            {
                isTop[i] = true;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j] && i != j)
                    {
                        isTop[i] = false;
                        break;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (isTop[i])
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
