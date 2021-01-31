using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isBigger = (a, b) => a.Sum(c => c) >= b;

            Func<Func<string, int, bool>, List<string>, string> returnFirst = (a, b) => b.FirstOrDefault(s => a(s, sum));

            string result = returnFirst(isBigger, names);

            if (result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
}
