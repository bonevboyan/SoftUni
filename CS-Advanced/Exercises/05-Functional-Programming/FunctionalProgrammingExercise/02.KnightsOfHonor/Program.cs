using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine("Sir " + string.Join("\nSir ", names));
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            print(names);
        }
    }
}
