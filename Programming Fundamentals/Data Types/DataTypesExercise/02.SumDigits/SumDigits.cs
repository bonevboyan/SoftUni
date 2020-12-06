using System;

namespace _02.SumDigits
{
    class SumDigits
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = num; i != 0; i /= 10)
            {
                count += i % 10;
            }
            Console.WriteLine(count);
        }
    }
}
