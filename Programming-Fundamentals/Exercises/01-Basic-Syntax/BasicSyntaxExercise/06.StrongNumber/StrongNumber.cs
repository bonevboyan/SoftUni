using System;

namespace _06.StrongNumber
{
    class StrongNumber
    {
        static int factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return (n * factorial(n - 1));
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = n; i != 0; i /= 10)
            {
                sum += factorial(i % 10);
            }
            if (sum == n)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
