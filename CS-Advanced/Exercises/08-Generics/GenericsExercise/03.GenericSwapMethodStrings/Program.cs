using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> items = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                items.Add(new Box<string> { Value = input });
            }
            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            foreach (var item in Swap<Box<string>>(items, indexes[0], indexes[1]))
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
