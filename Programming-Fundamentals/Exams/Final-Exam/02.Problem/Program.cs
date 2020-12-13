using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"U\$(?<username>[A-Z][a-z][a-z]+)U\$P@\$(?<password>[a-z][a-z][a-z][a-z][a-z]+\d+)P@\$");
            int n = int.Parse(Console.ReadLine());
            int totalRegistrations = 0;
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (regex.IsMatch(line))
                {
                    Match match = regex.Match(line);
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["username"]}, Password: {match.Groups["password"]}");
                    totalRegistrations++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine("Successful registrations: " + totalRegistrations);

        }
    }
}
