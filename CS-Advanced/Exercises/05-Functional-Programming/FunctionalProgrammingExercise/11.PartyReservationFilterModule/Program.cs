using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initial = Console.ReadLine()
                 .Split()
                 .ToList();

            Func<string, string, bool> startsWith = (a, b) => a.StartsWith(b);
            Func<string, string, bool> endsWith = (a, b) => a.EndsWith(b);
            Func<string, string, bool> contains = (a, b) => a.Contains(b);
            Func<string, int, bool> checkLength = (a, b) => a.Length == b;

            List<string> result = new List<string>(initial);
            List<string> filtered = new List<string>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] tokens = command.Split(';');
                switch (tokens[1])
                {
                    case "Starts with":
                        filtered = initial
                            .Where(i => startsWith(i, tokens[2]))
                            .ToList();
                        break;
                    case "Ends with":
                        filtered = initial
                            .Where(i => endsWith(i, tokens[2]))
                            .ToList();
                        break;
                    case "Length":
                        filtered = initial
                            .Where(i => checkLength(i, int.Parse(tokens[2])))
                            .ToList();
                        break;
                    case "Contains":
                        filtered = initial
                            .Where(i => contains(i, tokens[2]))
                            .ToList();
                        break;
                }

                switch (tokens[0])
                {
                    case "Add filter":
                        result
                            .RemoveAll(r => filtered.Contains(r));
                        break;
                    case "Remove filter":
                        result.AddRange(filtered);
                        result = result.Distinct().ToList();
                        break;
                }
                command = Console.ReadLine();
            }

            initial.RemoveAll(i => !result.Contains(i));
            Console.WriteLine(string.Join(" ", initial));
        }
    }
}
