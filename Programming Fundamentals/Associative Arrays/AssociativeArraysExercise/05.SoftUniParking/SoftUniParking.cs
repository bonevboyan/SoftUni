using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string username = input[1];
                switch (input[0])
                {
                    case "register":
                        string planeNum = input[2];
                        if (parking.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parking[username]}");
                        }
                        else
                        {
                            parking.Add(username, planeNum);
                            Console.WriteLine($"{username} registered {planeNum} successfully");
                        }
                        break;
                    case "unregister":

                        if (parking.ContainsKey(username))
                        {
                            parking.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        break;
                }
            }
            foreach (var person in parking)
            {
                Console.WriteLine(person.Key + " => " + person.Value);
            }

        }
    }
}
