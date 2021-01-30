using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Vlogger
    {
        public List<string> followers { get; set; }
        public int following { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();
            string command = Console.ReadLine();
            while(command != "Statistics")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.Contains("joined"))
                {
                    if (!vloggers.ContainsKey(tokens[0]))
                    {
                        vloggers.Add(tokens[0], new Vlogger
                        {
                            followers = new List<string>(),
                            following = 0
                        });
                    }
                }
                else if (command.Contains("followed"))
                {
                    if (vloggers.ContainsKey(tokens[2]) && vloggers.ContainsKey(tokens[0]) && tokens[0] != tokens[2])
                    {
                        if (!vloggers[tokens[2]].followers.Contains(tokens[0]))
                        {
                            vloggers[tokens[0]].following++;
                            vloggers[tokens[2]].followers.Add(tokens[0]);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            int counter = 1;
            bool isFirst = true;
            Console.WriteLine("The V-Logger has a total of " + vloggers.Count + " vloggers in its logs.");
            foreach (var vlogger in vloggers.OrderByDescending(o => o.Value.followers.Count).ThenBy(o => o.Value.following))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following} following");
                if (isFirst)
                {
                    isFirst = false;
                    foreach (var follower in vlogger.Value.followers.OrderBy(o => o))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
