using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            Func<string, string, bool> startsWith = (a, b) => a.StartsWith(b);
            Func<string, string, bool> endsWith = (a, b) => a.EndsWith(b);
            Func<string, int, bool> length = (a, b) => a.Length == b;

            Func<List<string>, List<string>, List<string>> doublePeople = (a, b) =>
            {
                foreach (string doubled in b)
                {
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a[i] == doubled)
                        {
                            a.Insert(i, doubled);
                            i++;
                        }
                    }
                }

                return a;
            };

            List<string> output = new List<string>();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] tokens = command.Split();
                switch (tokens[1])
                {
                    case "StartsWith":
                        output = people
                            .Where(p => startsWith(p, tokens[2]))
                            .Distinct()
                            .ToList();
                        break;
                    case "EndsWith":
                        output = people
                            .Where(p => endsWith(p, tokens[2]))
                            .Distinct()
                            .ToList();
                        break;
                    case "Length":
                        output = people
                            .Where(p => length(p, int.Parse(tokens[2])))
                            .Distinct()
                            .ToList();
                        break;
                }

                switch (tokens[0])
                {
                    case "Remove":
                        people = people
                            .Where(p => !output.Contains(p))
                            .ToList();
                        break;
                    case "Double":
                        people = doublePeople(people, output);
                        break;
                }
                command = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
