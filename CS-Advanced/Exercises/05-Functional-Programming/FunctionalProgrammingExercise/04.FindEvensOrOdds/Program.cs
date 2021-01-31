using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> even = num => num % 2 == 0;

            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            List<int> result = new List<int>();

            Enumerable.Range(range[0], range[1] - range[0] + 1).Where(x => command == "even" ? even(x) : !even(x)).ToList().ForEach(result.Add);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
