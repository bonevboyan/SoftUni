using System;

namespace _01.SignOfIntegerNumbers
{
    class SignOfIntegerNumbers
    {
        public static void printSign(int n)
        {
            if (n > 0)
            {
                Console.WriteLine("The number " + n + " is positive.");
            }
            else if (n < 0)
            {
                Console.WriteLine("The number " + n + " is negative.");
            }
            else
            {
                Console.WriteLine("The number 0 is zero.");
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            printSign(n);
        }
    }
}
