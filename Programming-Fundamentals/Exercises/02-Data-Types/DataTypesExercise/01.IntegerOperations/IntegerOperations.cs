﻿using System;

namespace _01.IntegerOperations
{
    class IntegerOperations
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine(((a+b)/c)*d);
        }
    }
}
