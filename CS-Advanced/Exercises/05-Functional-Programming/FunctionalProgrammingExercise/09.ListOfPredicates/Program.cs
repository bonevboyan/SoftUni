using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            dividers.ForEach(divisor => predicates.Add(num => num % divisor == 0));

            for (int i = 1; i <= range; i++)
            {
                bool isTrue = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isTrue = false;
                        break;
                    }
                }
                if (isTrue)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
