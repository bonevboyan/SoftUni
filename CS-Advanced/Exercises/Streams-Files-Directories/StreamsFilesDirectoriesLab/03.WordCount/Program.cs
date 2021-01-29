using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (StreamReader wordReader = new StreamReader("../../../words.txt"))
            {
                string[] wordsArr = wordReader.ReadToEnd().Split();
                foreach (var word in wordsArr)
                {
                    words.Add(word, 0);
                }
                using (StreamReader textReader = new StreamReader("../../../Input.txt"))
                {
                    string[] text = textReader.ReadToEnd().Split().Select(o => o.Replace(",", "").Replace("-", "").Replace(".", "").Replace("!", "").Replace("?", "").ToLower()).ToArray();
                    foreach (var word in text)
                    {
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in words.OrderByDescending(o => o.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
            

        }
    }
}
