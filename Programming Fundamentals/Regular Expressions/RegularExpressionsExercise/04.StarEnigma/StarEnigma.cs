using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
	class StarEnigma
	{
		static void Main(string[] args)
		{
			Regex decrypt = new Regex(@"[starSTAR]");
			Regex regex = new Regex(@"[^\@\-\!\:\>]*\@(?<name>[a-zA-Z]+)[^\@\-\!\:\>]*\:(?<population>\d+)[^\@\-\!\:\>]*\!(?<type>[AD])\![^\@\-\!\:\>]*\-\>(?<soldierCount>\d+)");

			List<string> attackedPlanets = new List<string>();
			List<string> destroyedPlanets = new List<string>();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string line = Console.ReadLine();
				MatchCollection matches = decrypt.Matches(line);
				string newLine = string.Empty;

                for (int j = 0; j < line.Length; j++)
                {
					newLine += ((char)(line[j] - matches.Count)).ToString();
                }

                if (regex.IsMatch(newLine))
                {
					Match match = regex.Match(newLine);

					string name = match.Groups["name"].Value;
					int population = int.Parse(match.Groups["population"].Value);
					string type = match.Groups["type"].Value;
					int soldierCount = int.Parse(match.Groups["soldierCount"].Value);

                    switch (type)
					{
						case "D":
							destroyedPlanets.Add(name);
							break;
						case "A":
							attackedPlanets.Add(name);
							break;
                    }
                }

			}
            Console.WriteLine("Attacked planets: " + attackedPlanets.Count);
            foreach (var planet in attackedPlanets.OrderBy(o => o))
            {
                Console.WriteLine("-> " + planet);
            }

			Console.WriteLine("Destroyed planets: " + destroyedPlanets.Count);
			foreach (var planet in destroyedPlanets.OrderBy(o => o))
			{
				Console.WriteLine("-> " + planet);
			}
		}
	}
}
