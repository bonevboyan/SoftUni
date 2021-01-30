using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
	class Ranking
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> contests = new Dictionary<string, string>();
			string line = Console.ReadLine();
			while (line != "end of contests")
			{
				string[] input = line.Split(':');
				contests.Add(input[0], input[1]);
				line = Console.ReadLine();
			}
			Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
			line = Console.ReadLine();
			while (line != "end of submissions")
			{
				string[] input = line.Split("=>");
				if (contests.ContainsKey(input[0]))
				{
					if (contests[input[0]] == input[1])
					{
						if (!students.ContainsKey(input[2]))
						{
							students.Add(input[2], new Dictionary<string, int>());
						}
						if (!students[input[2]].ContainsKey(input[0]))
						{
							students[input[2]].Add(input[0], int.Parse(input[3]));
                        }
                        else if (students[input[2]][input[0]] < int.Parse(input[3]))
                        {
							students[input[2]][input[0]] = int.Parse(input[3]);
						}
					}
				}
				line = Console.ReadLine(); 
			}
			string winnerName = string.Empty;
			int curr = 0, max = 0;
            foreach (var student in students)
            {
				foreach (var result in student.Value)
				{
					curr += result.Value;
				}
				if(curr > max)
                {
					max = curr;
					winnerName = student.Key;
                }
				curr = 0;
			}
            Console.WriteLine($"Best candidate is {winnerName} with total {max} points.");
            Console.WriteLine("Ranking: ");
            foreach (var student in students.OrderBy(o => o.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var result in student.Value.OrderByDescending(o => o.Value))
                {
                    Console.WriteLine($"#  {result.Key} -> {result.Value}");
                }
            }
		}
	}
}