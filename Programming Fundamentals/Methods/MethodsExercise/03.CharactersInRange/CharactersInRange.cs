using System;

namespace _03.CharactersInRange
{
    class CharactersInRange
    {

        public static void charsInRange(char ch1, char ch2)
        {
            int end = Math.Max(ch1, ch2);
            int start = Math.Min(ch1, ch2);
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    static void Main(string[] args)
        {
        char start = Console.ReadLine()[0];
        char end = Console.ReadLine()[0];
        charsInRange(start, end);
    }
    }
}
