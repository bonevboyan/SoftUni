using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            int[] sorted = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();
           
            for (int i = 0; i < Math.Min(sorted.Length, 3); i++)
            {
                Console.Write(sorted[i] + " ");
            }
        }
    }
}
