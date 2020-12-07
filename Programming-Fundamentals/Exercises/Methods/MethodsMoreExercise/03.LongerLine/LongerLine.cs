using System;

namespace _03.LongerLine
{
    class LongerLine
    {
        public static void findClosest(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distance2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (Math.Min(distance1, distance2) == distance1)
            {
                Console.Write($"({x1:f0}, {y1:f0})");
                Console.WriteLine($"({x2:f0}, {y2:f0})");
            }
            else
            {
                Console.Write($"({x2:f0}, {y2:f0})");
                Console.WriteLine($"({x1:f0}, {y1:f0})");
            }
        }
        public static void findLongest(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double distance1 = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
            double distance2 = Math.Sqrt(Math.Pow(Math.Abs(x3 - x4), 2) + Math.Pow(Math.Abs(y3 - y4), 2));
            if (Math.Max(distance1, distance2) == distance1)
            {
                findClosest(x1, y1, x2, y2);
            }
            else
            {
                findClosest(x3, y3, x4, y4);
            }
        }
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            findLongest(x1, y1, x2, y2, x3, y3, x4, y4);
        }
    }
}
