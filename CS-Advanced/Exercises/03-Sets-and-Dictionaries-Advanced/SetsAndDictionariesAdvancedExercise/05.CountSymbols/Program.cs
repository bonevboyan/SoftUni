using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            foreach (var ch in line)
            {
                if (!chars.ContainsKey(ch))
                {
                    chars.Add(ch, 0);
                }
                chars[ch]++;
            }
            foreach (var ch in chars)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
