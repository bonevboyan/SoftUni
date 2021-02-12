using System;
using System.Collections.Generic;

namespace _02.GenericBoxOfInteger
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
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
