using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class MatchDates
    {
        static void Main(string[] args)
        {
            Regex dateRegex = new Regex(@"(?<day>\d{2})(?<delimiter>.|-|\/)(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b");

            MatchCollection validDates = dateRegex.Matches(Console.ReadLine());

            foreach (Match date in validDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
        }
    }
}
