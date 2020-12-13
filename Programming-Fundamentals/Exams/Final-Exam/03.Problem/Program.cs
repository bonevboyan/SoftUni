using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class User
    {
        public int Sent { get; set; }
        public int Received { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();
            int capacity = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            while (line != "Statistics")
            {
                string[] input = line.Split("=");
                if (input[0] == "Add")
                {
                    string username = input[1];
                    int sent = int.Parse(input[2]);
                    int received = int.Parse(input[3]);
                    if (!users.ContainsKey(username))
                    {
                        User user = new User
                        {
                            Sent = sent,
                            Received = received
                        };
                        users.Add(username, user);
                    }
                }
                else if (input[0] == "Message")
                {
                    string sender = input[1];
                    string receiver = input[2];
                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender].Sent++;
                        users[receiver].Received++;
                        if(users[sender].Sent + users[sender].Received >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            users.Remove(sender);
                        }
                        if (users[receiver].Sent + users[receiver].Received >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            users.Remove(receiver);
                        }
                    }
                }
                else if(input[0] == "Empty")
                {
                    string username = input[1];
                    if(username == "All")
                    {
                        users.Clear();
                    }
                    else
                    {
                        if (users.ContainsKey(username))
                        {
                            users.Remove(username);
                        }
                    }
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Users count: " + users.Count);
            foreach (var user in users.OrderByDescending(o => o.Value.Received).ThenBy(o => o.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value.Sent + user.Value.Received}");
            }
        }
    }
}
