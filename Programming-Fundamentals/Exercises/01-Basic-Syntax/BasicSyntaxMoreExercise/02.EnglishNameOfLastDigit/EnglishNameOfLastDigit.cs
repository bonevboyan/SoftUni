using System;

namespace _02.EnglishNameOfLastDigit
{
    class EnglishNameOfLastDigit
    {
        static void Main(string[] args)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Console.WriteLine(digits[int.Parse(Console.ReadLine())%10]);
        }
    }
}
