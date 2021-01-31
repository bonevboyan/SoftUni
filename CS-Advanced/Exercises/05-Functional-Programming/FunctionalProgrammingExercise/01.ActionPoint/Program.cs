using System;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine(string.Join("\n", names));
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            print(names);
        }
    }
}
