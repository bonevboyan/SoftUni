using System;

namespace _04.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(charArray);
        }
    }
}
