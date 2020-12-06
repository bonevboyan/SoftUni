using System;

namespace _09.PalindromeIntegers
{
    class PalindromeIntegers
    {
        public static bool checkIfPalindrome(String input)
        {
            int num = int.Parse(input);
            bool f = true;
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    f = false;
                }
            }
            return f;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            do
            {
                if (checkIfPalindrome(input))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            } while (!input.Equals("END"));
        }

    }
}
