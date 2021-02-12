using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> items = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                items.Add(new Box<double> { Value = input });
            }
            double item = double.Parse(Console.ReadLine());

            Console.WriteLine(Count(items, item));
        }
        static int Count<T>(List<Box<T>> collection, T element)
        where T : IComparable<T>
        {
            int counter = 0;

            foreach (var item in collection)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
