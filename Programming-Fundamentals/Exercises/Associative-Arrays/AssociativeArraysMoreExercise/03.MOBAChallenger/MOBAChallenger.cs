using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class MOBAChallenger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> statistics = new Dictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();
            while (line != "Season end")
            {
                if (line.Contains(" -> "))
                {
                    string[] input = line.Split(" -> ");
                    if (!statistics.ContainsKey(input[0]))
                    {
                        statistics.Add(input[0], new Dictionary<string, int>());
                    }
                    if (!statistics[input[0]].ContainsKey(input[1]))
                    {
                        statistics[input[0]].Add(input[1], 0);
                    }
                    if (statistics[input[0]][input[1]] < int.Parse(input[2]))
                    {
                        statistics[input[0]][input[1]] = int.Parse(input[2]);
                    }
                }
                else if (line.Contains(" vs "))
                {
                    string[] input = line.Split(" vs ");
                    if (statistics.ContainsKey(input[0]) && statistics.ContainsKey(input[1]))
                    {
                        foreach (var position in statistics[input[0]].Keys)
                        {
                            if (statistics[input[1]].ContainsKey(position))
                            {
                                if (statistics[input[0]].Values.Sum() > statistics[input[1]].Values.Sum())
                                {
                                    statistics.Remove(input[1]);
                                }
                                else if (statistics[input[1]].Values.Sum() > statistics[input[0]].Values.Sum())
                                {
                                    statistics.Remove(input[0]);
                                }
                                break;
                            }
                        }
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var player in statistics.OrderByDescending(o => o.Value.Values.Sum()).ThenBy(o => o.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var role in player.Value.OrderByDescending(o => o.Value).ThenBy(o => o.Key))
                {
                    Console.WriteLine($"- {role.Key} <::> {role.Value}");
                }
            }
        }
    }
}
