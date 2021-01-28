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
				int row = bombs[i][0];
				int col = bombs[i][1];
				int damage = matrix[row, col];
				if (matrix[row, col] > 0)
				{
					matrix[row, col] = 0;
					if (row < matrix.GetLength(0) - 1)
					{
						if (matrix[row + 1, col] > 0)
						{
							matrix[row + 1, col] -= damage;
						}
						if (col < matrix.GetLength(1) - 1)
						{
							if (matrix[row + 1, col + 1] > 0)
							{
								matrix[row + 1, col + 1] -= damage;
							}
						}
						if (col > 0)
						{
							if (matrix[row + 1, col - 1] > 0)
							{
								matrix[row + 1, col - 1] -= damage;
							}
						}
					}
					if (col < matrix.GetLength(1) - 1)
					{
						if (matrix[row, col + 1] > 0)
						{
							matrix[row, col + 1] -= damage;
						}

					}
					if (row > 0)
					{
						if (matrix[row - 1, col] > 0)
						{
							matrix[row - 1, col] -= damage;
						}
						if (col > 0)
						{
							if (matrix[row - 1, col - 1] > 0)
							{
								matrix[row - 1, col - 1] -= damage;
							}
						}
						if (col < matrix.GetLength(1) - 1)
						{
							if (matrix[row - 1, col + 1] > 0)
							{
								matrix[row - 1, col + 1] -= damage;
							}

						}
					}
					if (col > 0)
					{
						if (matrix[row, col - 1] > 0)
						{
							matrix[row, col - 1] -= damage;
						}
					}
				}
			}
			int sum = 0, aliveCells = 0;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] > 0)
					{
						aliveCells++;
						sum += matrix[i, j];
					}
				}
			}
            Console.WriteLine("Alive cells: " + aliveCells);
            Console.WriteLine("Sum: " + sum);
			for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
		}
	}
}
