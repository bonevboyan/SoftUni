using System;

namespace _08.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            decimal result = 0, total = 0;
            foreach (var str in input)
            {
                char firstChar = str[0];
                char secondChar = str[str.Length - 1];
                int num = int.Parse(str.Substring(1, str.Length - 2));
                result = 0;
                if (char.IsUpper(firstChar))
                {
                    result += num / (decimal) (firstChar - 64);
                }
                else
                {
                    result += num * (decimal) (firstChar - 96);
                }
                if (char.IsUpper(secondChar))
                {
                    result -= secondChar - 64;
                }
                else
                {
                    result += secondChar - 96;
                }
                total += result;
            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
