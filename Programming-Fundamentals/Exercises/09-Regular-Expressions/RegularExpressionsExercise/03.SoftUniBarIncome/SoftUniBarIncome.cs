using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\w*%(?<name>[A-Z][a-z]+)%\w*<(?<product>[a-zA-Z]+)>\w*\|(?<quantity>\d+)\|[a-zA-Z]*(?<price>\d+(\.\d+)?)\$");
            string line = Console.ReadLine();
            StringBuilder str = new StringBuilder("");
            bool f = false;
            decimal total = 0;
            while (line != "end of shift")
            {
                if (regex.IsMatch(line))
                {
                    Match match = regex.Match(line);
                    if (f)
                    {
                        str.Append($"\n{match.Groups["name"]}: {match.Groups["product"]} - {decimal.Parse(match.Groups["quantity"].Value) * decimal.Parse(match.Groups["price"].Value):f2}");
                    }
                    else
                    {
                        str.Append($"{match.Groups["name"]}: {match.Groups["product"]} - {decimal.Parse(match.Groups["quantity"].Value) * decimal.Parse(match.Groups["price"].Value):f2}");
                        f = true;
                    }
                    total += decimal.Parse(match.Groups["quantity"].Value) * decimal.Parse(match.Groups["price"].Value);
                }
                line = Console.ReadLine();
            }
            if (str.Length != 0)
                Console.WriteLine(str.ToString());
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}