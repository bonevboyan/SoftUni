using System;

namespace _02.CenterPoint
{
    class CenterPoint
    {
        public static void findClosest(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distance2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (Math.Min(distance1, distance2) == distance1)
            {
                Console.WriteLine($"{x1:f0}, {y1:f0}");
            }
            else
            {
                Console.WriteLine($"{x2:f0}, {y2:f0}");
            }
        }
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            findClosest(x1, y1, x2, y2);
        }
    }
}
