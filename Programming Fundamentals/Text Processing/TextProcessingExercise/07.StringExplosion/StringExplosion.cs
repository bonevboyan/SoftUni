using System;

namespace _07.StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int stength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    stength += int.Parse(input[i + 1].ToString());
                }
                else if (stength > 0)
                {
                    input = input.Remove(i, 1);
                    stength--;
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
