using System;

namespace _03.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        static int GetFibonacci(int n)
        {

            if(n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }
    }
}
