using System;
namespace _01.RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");
            Random rnd = new Random();
            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = rnd.Next(words.Length);
                string swap = words[pos1];
                words[pos1] = words[pos2];
                words[pos2] = swap;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
