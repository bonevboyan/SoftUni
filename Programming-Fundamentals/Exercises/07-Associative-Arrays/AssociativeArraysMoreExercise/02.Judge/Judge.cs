using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();
            int i = 1;
            while (line!="no more time")
            {
                string[] input = line.Split(" -> ");
                if (contests.ContainsKey(input[1]))
                {
                    if (!contests[input[1]].ContainsKey(input[0]))
                    {
                        contests[input[1]].Add(input[0], int.Parse(input[2]));
                    }
                    else if(contests[input[1]][input[0]] < int.Parse(input[2]))
                    {
                        contests[input[1]][input[0]] = int.Parse(input[2]);
                    }
                }
                else
                {
                    contests.Add(input[1], new Dictionary<string, int>());
                    contests[input[1]].Add(input[0], int.Parse(input[2]));
                }
                line = Console.ReadLine();
            }
            foreach (var contest in contests.OrderByDescending(o => o.Value.Count).ThenBy(o => o.Key))
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                i = 1;
                foreach (var student in contest.Value.OrderByDescending(o => o.Value))
                {
                    Console.WriteLine($"{i}. {student.Key} <::> {student.Value}");
                    i++;
                }
            }
            Dictionary<string, int> standings = new Dictionary<string, int>();
            foreach (var contest in contests)
            {
                foreach (var student in contest.Value)
                {
                    if (standings.ContainsKey(student.Key))
                    {
                        standings[student.Key] += student.Value;
                    }
                    else
                    {
                        standings.Add(student.Key, student.Value);
                    }
                }
            }
            i = 1;
            Console.WriteLine("Individual standings:");
            foreach (var student in standings.OrderByDescending(o => o.Value))
            {
                Console.WriteLine($"{i}. {student.Key} -> {student.Value}");
                i++;
            }
        }
    }
}
