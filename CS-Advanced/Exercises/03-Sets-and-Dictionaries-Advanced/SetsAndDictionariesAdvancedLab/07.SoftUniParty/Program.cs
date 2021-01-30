using System;
using System.Collections.Generic;
using System.Linq;


namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPs = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "PARTY")
            {
                if(command[0] >= '0' && command[0] <= '9')
                {
                    VIPs.Add(command);
                }
                else
                {
                    regulars.Add(command);
                }
                command = Console.ReadLine();
            }
            while (command != "END")
            {
                if (VIPs.Contains(command))
                {
                    VIPs.Remove(command);
                }
                else if(regulars.Contains(command))
                {
                    regulars.Remove(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(VIPs.Count + regulars.Count);
            if (VIPs.Any())
            {
                Console.WriteLine(string.Join("\n", VIPs));
            }
            Console.WriteLine(string.Join("\n", regulars));
        }
    }
}
