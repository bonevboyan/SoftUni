using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class CountCharsInAString
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> chars = new Dictionary<char, int>();
            foreach (var ch in input)
            {
                if (ch != ' ')
                {
                    if (chars.ContainsKey(ch))
                    {
                        chars[ch]++;
                    }
                    else
                    {
                        chars.Add(ch, 1);
                    }
                }
            }
            foreach(var ch in chars)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}
