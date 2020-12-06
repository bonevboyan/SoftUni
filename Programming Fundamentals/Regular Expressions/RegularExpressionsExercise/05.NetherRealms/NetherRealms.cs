using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            Regex nameRegex = new Regex(@"([^\d\+\-\*/\.])");
            Regex numRegex = new Regex(@"((\+|\-)?(\d+(\.\d+)?))");
            Regex multAndDivRegex = new Regex(@"(/|\*)");

            List<string> demons = Console.ReadLine().Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var demon in demons.OrderBy(n => n))
            {
                string demonName = "";
                foreach (var letter in nameRegex.Matches(demon))
                {
                    demonName += letter.ToString();
                }
                List<Match> numbers = numRegex.Matches(demon).ToList();
                decimal damage = 0;
                if (numbers.Count > 0)
                {
                    foreach (var num in numbers)
                    {
                        damage += decimal.Parse(num.ToString());
                    }
                    MatchCollection multiAndDiv = multAndDivRegex.Matches(demon);
                    if (multiAndDiv.Count() > 0)
                    {
                        foreach (var symbol in multiAndDiv)
                        {
                            if (symbol.ToString() == "*")
                            {
                                damage *= 2;
                            }
                            else if (symbol.ToString() == "/")
                            {
                                damage /= 2;
                            }
                        }
                    }
                }
                int hp = 0;
                foreach (var ch in demonName)
                {
                    hp += ch;
                }
                Console.WriteLine($"{demon} - {hp} health, {damage:F2} damage");
            }
        }
    }
}
