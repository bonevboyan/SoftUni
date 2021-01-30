using System;

namespace _06.ReplaceRepeatingChars
{
	class ReplaceRepeatingChars
	{
		static void Main(string[] args)
		{
			string line = Console.ReadLine();
			Console.Write(line[0]);
			for (int i = 1; i < line.Length; i++)
			{
				if(line[i] != line[i - 1])
				{
					Console.Write(line[i]);
				}
			} 
		}
	}
}
