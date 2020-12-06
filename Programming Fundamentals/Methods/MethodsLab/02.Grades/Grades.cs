using System;

namespace _02.Grades
{
    class Grades
    {
        public static void printGrade(double n)
        {
            if (n >= 5.5)
            {
                Console.WriteLine("Excellent");
            }
            else if (n >= 4.5)
            {
                Console.WriteLine("Very good");
            }
            else if (n >= 3.5)
            {
                Console.WriteLine("Good");
            }
            else if (n >= 3)
            {
                Console.WriteLine("Poor");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            printGrade(n);
        }
    }
}
