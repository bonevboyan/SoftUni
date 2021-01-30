using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\+359)( |-)2\2\d{3}\2\d{4}\b");
            MatchCollection nums = regex.Matches(Console.ReadLine());

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
