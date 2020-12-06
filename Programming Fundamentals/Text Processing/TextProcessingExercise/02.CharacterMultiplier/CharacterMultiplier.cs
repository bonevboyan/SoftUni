using System;

namespace _02.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int sum = 0, min = Math.Min(input[0].Length, input[1].Length);
            for (int i = 0; i < min; i++)
            {
                sum += multChar(input[0][i], input[1][i]);
            }
            if (input[0].Length > min)
            {
                for (int i = min; i < input[0].Length; i++)
                {
                    sum += input[0][i];
                }
            }
            if (input[1].Length > min)
            {
                for (int i = min; i < input[1].Length; i++)
                {
                    sum += input[1][i];
                }
            }
            Console.WriteLine(sum);
        }
        public static int multChar(char a, char b)
        {
            return a * b;
        }
    }
}
