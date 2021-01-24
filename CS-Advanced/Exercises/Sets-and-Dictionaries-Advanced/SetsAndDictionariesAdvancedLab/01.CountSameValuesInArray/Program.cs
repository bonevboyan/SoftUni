using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dictionary.ContainsKey(arr[i]))
                {
                    dictionary.Add(arr[i], 0);
                }
                dictionary[arr[i]]++;
            }
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}//-2,5 4 3 -2,5 -5,5 4 3 3 -2,5 3
