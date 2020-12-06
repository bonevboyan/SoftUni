using System;

namespace _06.CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        public static double getRectangleArea(double width, double height)
        {
            return width * height;
        }
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = getRectangleArea(width, height);
            Console.WriteLine($"{area:f0}");
        }
    }
}
