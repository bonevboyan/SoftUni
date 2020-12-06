using System;

namespace _08.FactorialDivision
{
    class FactorialDivision
    {
        public static double factorial(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"{(double)factorial(firstNum) / factorial(secondNum):f2}");
        }
    }
}
