using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> forceUsers = new Dictionary<string, string>();
            string line = Console.ReadLine();
            while (line != "Lumpawaroo")
            {
                string[] input = line.Split(' ');
                string forceSide;// = input[0];
                string dl = input[1];
                string forceUser;// = input[2];
                switch (dl)
                {
                    case "|":
                        forceSide = input[0];
                        forceUser = input[2];
                        if (!forceUsers.ContainsKey(forceUser))
                        {
                            forceUsers.Add(forceUser, forceSide);
                        }
                        break;
                    case "->":
                        forceSide = input[2];
                        forceUser = input[0];
                        if (forceUsers.ContainsKey(forceUser))
                        {
                            forceUsers[forceUser] = forceSide;
                        }
                        else
                        {
                            forceUsers.Add(forceUser, forceSide);
                        }
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        break;
                }
                line = Console.ReadLine();
            }
            foreach (var orderedSide in forceUsers.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {orderedSide.Key}, Members: {orderedSide.Count()}");
                foreach (var orderedUser in orderedSide.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"! {orderedUser.Key}");
                }
            }
        }
    }
}
