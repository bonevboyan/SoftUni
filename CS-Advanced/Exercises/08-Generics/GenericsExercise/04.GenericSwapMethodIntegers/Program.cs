using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> items = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                items.Add(new Box<int> { Value = input });
            }
            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            foreach (var item in Swap<Box<int>>(items, indexes[0], indexes[1]))
            {
                Console.WriteLine(item.ToString());
            }
        }
        static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T firstElement = list[firstIndex], secondElement = list[secondIndex];
            list[firstIndex] = secondElement;
            list[secondIndex] = firstElement;
            return list;
        }
    }
}
