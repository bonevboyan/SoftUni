using System;

namespace _06.JaggedArrayManipulator
{
	class Program
	{
		static void Main(string[] args)
		{
			double[][] jagged = new double[int.Parse(Console.ReadLine())][];

			for (int row = 0; row < jagged.Length; row++)
			{
				string[] inputNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
				jagged[row] = new double[inputNumbers.Length];

				for (int col = 0; col < jagged[row].Length; col++)
				{
					jagged[row][col] = int.Parse(inputNumbers[col]);
				}

			}
			for (int row = 0; row < jagged.Length - 1; row++)
			{
				if (jagged[row].Length == jagged[row + 1].Length)
				{
					for (int col = 0; col < jagged[row].Length; col++)
					{
						jagged[row][col] *= 2;
					}
					for (int col = 0; col < jagged[row + 1].Length; col++)
					{
						jagged[row + 1][col] *= 2;
					}
				}
				else
				{
					for (int col = 0; col < jagged[row].Length; col++)
					{
						jagged[row][col] /= 2;
					}
					for (int col = 0; col < jagged[row + 1].Length; col++)
					{
						jagged[row + 1][col] /= 2;
					}
				}
				
			}
			string command = Console.ReadLine();
			while (command != "End")
			{
				string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				if (command.Contains("Add"))
				{
					int row = int.Parse(tokens[1]);
					int col = int.Parse(tokens[2]);
					int value = int.Parse(tokens[3]);
					if (jagged.Length > row && row >= 0)
					{
						if(jagged[row].Length > col && col >= 0)
						{
							jagged[row][col] += value;
						}
					}
				}
				else if (command.Contains("Subtract"))
				{
					int row = int.Parse(tokens[1]);
					int col = int.Parse(tokens[2]);
					int value = int.Parse(tokens[3]);
					if (jagged.Length > row && row >= 0)
					{
						if (jagged[row].Length > col && col >= 0)
						{
							jagged[row][col] -= value;
						}
					}
				}
				command = Console.ReadLine();
			}
			for (int row = 0; row < jagged.Length; row++)
			{
				for (int col = 0; col < jagged[row].Length; col++)
				{
					Console.Write(jagged[row][col] + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
