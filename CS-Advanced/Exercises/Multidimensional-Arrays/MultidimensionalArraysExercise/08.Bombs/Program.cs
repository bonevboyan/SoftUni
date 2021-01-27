using System;
using System.Linq;

namespace _08.Bombs
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int n = input[0];

			int[,] matrix = new int[n, n];

			for (int row = 0; row < n; row++)
			{
				int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int col = 0; col < n; col++)
				{
					matrix[row, col] = rowData[col];
				}
			}
			int[][] bombs = Console.ReadLine().Split(' ').Select(o => o.Split(",").Select(int.Parse).ToArray()).ToArray();
			for (int i = 0; i < bombs.Length; i++)
			{
				matrix[bombs[i][0]][bombs[i][1]]
				if(bombs[i][0] < matrix.GetLength(0) - 1)
				{

				} 
				else if (bombs[i][1] < matrix.GetLength(1) - 1)
				{

				}
				else if (bombs[i][0] > 0)
				{

				}
				else if (bombs[i][1] > 0)
				{

				}
			}
		}
	}
}
