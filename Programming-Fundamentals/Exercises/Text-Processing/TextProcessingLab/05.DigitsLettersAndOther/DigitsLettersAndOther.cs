using System;

namespace _05.DigitsLettersAndOther
{
    class DigitsLettersAndOther
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    Console.Write(input[i]); 
                }
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    Console.Write(input[i]);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetterOrDigit(input[i]))
                {
                    Console.Write(input[i]);
                }
            }
        }
    }
}
