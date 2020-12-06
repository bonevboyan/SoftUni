using System;

namespace _07.WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int used = 0;
            int liters;
            for (int i = 0; i < n; i++)
            {
                liters = int.Parse(Console.ReadLine());
                if (used + liters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    used += liters;
                }
            }
            Console.WriteLine(used);
        }
    }
}
