using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<product>\w+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)\b");
            string line = Console.ReadLine();
            decimal sum = 0;
            StringBuilder str = new StringBuilder("Bought furniture:");
            while (line != "Purchase")
            {
                if (regex.IsMatch(line)) {
                    Match furniture = regex.Match(line);
                    str.Append("\n" + furniture.Groups["product"]);
                    sum += decimal.Parse(furniture.Groups["price"].ToString()) * decimal.Parse(furniture.Groups["quantity"].ToString());
                }
                line = Console.ReadLine();
                
            }
            Console.WriteLine($"{str.ToString()}\nTotal money spend: {sum:f2}");
        }
    }
}