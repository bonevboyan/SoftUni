using System;
using System.Linq;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = Console.ReadLine();
            while(command != "Sign up")
            {
                string[] input = command.Split();
                if(input[0] == "Case")
                {
                    if(input[1] == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }
                    Console.WriteLine(username);
                }
                else if (input[0] == "Reverse")
                {
                    int start = int.Parse(input[1]);
                    int end = int.Parse(input[2]);
                    if (start >= 0 && end < username.Length && start <= end)
                    {
                        char[] reverse = username.Substring(start, end - start + 1).ToCharArray();
                        Array.Reverse(reverse);
                        string reversed = new string(reverse);
                        Console.WriteLine(reversed);
                    }
                }
                else if(input[0] == "Cut")
                {
                    if (username.Contains(input[1]))
                    {
                        username = username.Replace(input[1], "");
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {input[1]}.");
                    }
                }
                else if(input[0] == "Replace")
                {
                    username = username.Replace(input[1], "*");
                    Console.WriteLine(username);
                }
                else if (input[0] == "Check")
                {
                    if (username.Contains(input[1]))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {input[1]}.");
                    }
                }
                    command = Console.ReadLine();
            }
        }
    }
}
