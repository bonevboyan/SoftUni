using System;
using System.Collections.Generic;

namespace _01.GenericBoxOfString
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
                items.Add(new Box<string> { Value = input }) ;
            }
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
