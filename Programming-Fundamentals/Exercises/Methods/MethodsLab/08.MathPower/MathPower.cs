using System;

namespace _08.MathPower
{
    class MathPower
    {
        public static double mathPower(double num, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= num;
            }
            return result;
        }
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());

            Console.WriteLine(mathPower(num, pow));
        }
    }
}
