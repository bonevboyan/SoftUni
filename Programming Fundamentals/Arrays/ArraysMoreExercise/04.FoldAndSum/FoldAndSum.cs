using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] firstRow = new int[arr.Length / 2];
            int[] secondRow = new int[arr.Length / 2];
            int[] firstRow1 = new int[arr.Length / 4], firstRow2 = new int[arr.Length / 4];
            int atFirst1 = 0, atFirst2 = 0, atSecond = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(i< arr.Length / 4)
                {
                    firstRow1[atFirst1] = arr[i];
                    atFirst1++;
                }
                else if (i >= arr.Length * 3 / 4)
                {
                    firstRow2[atFirst2] = arr[i];
                    atFirst2++;
                }
                else
                {
                    secondRow[atSecond] = arr[i];
                    atSecond++;
                }
            }
            Array.Reverse(firstRow1);
            for (int i = 0; i < firstRow1.Length; i++)
            {
                firstRow[i] = firstRow1[i];
                firstRow[firstRow.Length - i - 1] = firstRow2[i];
            }
            for (int i = 0; i < firstRow.Length; i++)
            {
                Console.Write(firstRow[i] + secondRow[i] + " ");
            }
        }
    }
}
