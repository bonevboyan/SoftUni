using System;

namespace _01.ConvertMetersToKilometers
{
    class ConvertMetersToKilometers
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            Console.WriteLine($"{(decimal)meters / 1000:f2}");
        }
    }
}
