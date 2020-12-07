using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> check = new Dictionary<string, List<decimal>>();                                               
            string line = Console.ReadLine();
            while (line != "buy")
            {
                string[] input = line.Split();
                string key = input[0];
                decimal price = decimal.Parse(input[1]);
                decimal count = decimal.Parse(input[2]);

                if (!check.ContainsKey(key))
                {
                    check.Add(key, new List<decimal>() { price, count });
                }
                else
                {
                    check[key][0] = price;
                    check[key][1] += count;

                }
                line = Console.ReadLine();
            }
            foreach (var product in check)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }
        }
    }
}
