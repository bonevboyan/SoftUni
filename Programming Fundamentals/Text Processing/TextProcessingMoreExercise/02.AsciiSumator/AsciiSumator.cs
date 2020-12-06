using System;

namespace _02.AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            int firstChar = Console.ReadLine()[0];
            int secondChar = Console.ReadLine()[0];
            string input = Console.ReadLine();
            int sum = 0;
            foreach (var symbol in input)
            {
                if (symbol > Math.Min(firstChar, secondChar) && 
                    symbol < Math.Max(firstChar, secondChar))
                {
                    sum += symbol;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
