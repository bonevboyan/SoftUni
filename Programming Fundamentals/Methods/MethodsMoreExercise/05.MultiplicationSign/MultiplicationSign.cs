using System;

namespace _05.MultiplicationSign
{
    class MultiplicationSign
    {
        public static bool checkSign(int num1, int num2, int num3)
        {
            int negative = 0;
            if (num1 < 0)
            {
                negative++;
            }
            if (num2 < 0)
            {
                negative++;
            }
            if (num3 < 0)
            {
                negative++;
            }
            if (negative % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (checkSign(num1, num2, num3))
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
