using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Race
    {
        static void Main(string[] args)
        {
            Regex nameRegex = new Regex(@"[a-zA-Z]+");
            Regex distanceRegex = new Regex(@"[0-9]");
            List<string> participants = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (var participant in participants)
            {
                results.Add(participant, 0);
            }
            string line = Console.ReadLine();
            int total = 0;
            StringBuilder name = new StringBuilder(string.Empty);
            while(line != "end of race")
            {
                while (nameRegex.IsMatch(line))
                {
                    Match chars = nameRegex.Match(line);
                    name.Append(chars);
                    int index = line.IndexOf(chars.Value);
                    line = line.Remove(index, chars.Value.Length);
                }
                if (results.ContainsKey(name.ToString()))
                {
                    while (distanceRegex.IsMatch(line))
                    {
                        Match nums = distanceRegex.Match(line);
                        total += int.Parse(nums.Value);
                        int index = line.ToString().IndexOf(nums.Value);
                        line = line.Remove(index, nums.Value.Length);
                    }
                    results[name.ToString()] += total;
                }
                name.Clear();
                total = 0;
                line = Console.ReadLine();
            }
            results = results.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, o => o.Value);
            var first = results.First().Key;
            int i = 0;
            foreach (var item in results)
            {
                if (i == 0)
                {
                    Console.WriteLine("1st place: " + item.Key);
                }
                else if (i == 1)
                {
                    Console.WriteLine("2nd place: " + item.Key);
                }
                else
                {
                    Console.WriteLine("3rd place: " + item.Key);
                }
                i++;
                if (i == 3) break;
            }
        }
    }
}