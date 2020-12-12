using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"(@#+)[A-Z][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9]+[A-Z]\1");
            Regex numRegex = new Regex(@"\d");
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (regex.IsMatch(line))
                {
                    string group = "00";
                    if (numRegex.IsMatch(line))
                    {
                        group = string.Empty;
                        foreach (var match in numRegex.Matches(line))
                        {
                            group += match.ToString();
                        }
                    }
                    Console.WriteLine("Product group: " + group);
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
