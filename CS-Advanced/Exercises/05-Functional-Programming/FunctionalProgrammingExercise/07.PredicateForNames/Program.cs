using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Func<string, bool> isShorter = name => name.Length <= length;
            Console.WriteLine(string.Join('\n', Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(isShorter)));

        }
    }
}
