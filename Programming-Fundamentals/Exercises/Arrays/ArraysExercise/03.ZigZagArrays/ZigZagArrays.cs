using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            int counter = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    firstArray[counter] = line[0];
                    secondArray[counter] = line[1];
                }
                else
                {
                    firstArray[counter] = line[1];
                    secondArray[counter] = line[0];
                }
                counter++;
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write(firstArray[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write(secondArray[i] + " ");
            }
        }
    }
}
