﻿using System;
using System.Text;

namespace _02.RepeatStrings
{
    class RepeatStrings
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder result = new StringBuilder();
            foreach (var word in words)
            {
                int count = word.Length;
                for (int i = 0; i < count; i++)
                {
                    result.Append(word);
                }
            }
            Console.WriteLine(result);
        }
    }
}
