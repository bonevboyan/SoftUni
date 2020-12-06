using System;

namespace _02.PoundsToDollars
{
    class PoundsToDollars
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal dollars = pounds * (decimal) 1.31;
            Console.WriteLine($"{ dollars:f3}");
        }
    }
}
