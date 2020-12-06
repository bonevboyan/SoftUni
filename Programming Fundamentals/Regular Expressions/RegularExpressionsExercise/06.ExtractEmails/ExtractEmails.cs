using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\s[a-z]+[\w.-]+\w)@([a-z]+[-a-z]*?([.][a-z]+)+)\b");

            string input = Console.ReadLine();

            Console.WriteLine(string.Join("\n", regex.Matches(input)));
        }
    }
}
