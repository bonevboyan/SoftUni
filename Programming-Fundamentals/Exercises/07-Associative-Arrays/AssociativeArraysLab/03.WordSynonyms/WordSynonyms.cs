using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class WordSynonyms
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var words = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                }
                words[word].Add(synonym);
            }
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");

            }
        }
    }
}
