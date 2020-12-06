using System;
using System.Collections.Generic;

namespace _01.ExtractPersonInformation
{
    class ExtractPersonInformation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string name = input.Substring(input.IndexOf("@") + 1, input.IndexOf("|") - (input.IndexOf("@") + 1));
                int age = int.Parse(input.Substring(input.IndexOf("#") + 1, input.IndexOf("*") - (input.IndexOf("#") + 1)));
                people.Add(name, age);
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Key} is {person.Value} years old.");
            }

        }
    }
}
