using System;

namespace _11.MultiplicationTable2
{
    class MultiplicationTable2
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num} X {start} = {num * start}");
            for (int i = start; i <= 10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }
        }
    }
}
