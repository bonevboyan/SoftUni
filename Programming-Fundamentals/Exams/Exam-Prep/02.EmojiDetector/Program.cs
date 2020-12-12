using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex emojiRegex = new Regex(@"\:\:[A-Z][a-z][a-z]+\:\:|\*\*[A-Z][a-z][a-z]+\*\*");
            Regex numRegex = new Regex(@"[0-9]");
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            string input = Console.ReadLine();
            MatchCollection emojis = emojiRegex.Matches(input);
            MatchCollection nums = numRegex.Matches(input);
            int coolThreshold = 1;
            foreach (var emoji in emojis)
            {
                int sum = 0;
                foreach (char ch in emoji.ToString())
                    sum += ch;
                keyValuePairs.Add(emoji.ToString(), sum);
            }
            foreach (var num in nums)
            {
                coolThreshold *= int.Parse(num.ToString());
            }
            Console.WriteLine("Cool threshold: " + coolThreshold);
            Console.WriteLine(keyValuePairs.Count + " emojis found in the text. The cool ones are:");
            foreach (var keyValuePair in keyValuePairs.Where(o => o.Value >= coolThreshold))
            {
                Console.WriteLine(keyValuePair.Key);
            }
        }
    }
}
