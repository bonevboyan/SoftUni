using System;
using System.Linq;

namespace _05.WordFilter
{
    class WordFilter
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", Console.ReadLine().Split().Where(w => w.Length % 2 == 0).ToArray()));
        }
    }
}
