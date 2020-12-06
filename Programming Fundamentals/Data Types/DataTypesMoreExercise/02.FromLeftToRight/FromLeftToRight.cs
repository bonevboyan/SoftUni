using System;

namespace _02.FromLeftToRight
{
    class FromLeftToRight
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 1; i <= counter; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(" ");
                string part1 = parts[0];
                string part2 = parts[1];
                long number1 = long.Parse(part1);
                long number2 = long.Parse(part2);
                long biggest = Math.Max(number1, number2);
                long sum = 0;

                while (biggest != 0)
                {
                    sum +=  biggest % 10;
                    biggest /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}
