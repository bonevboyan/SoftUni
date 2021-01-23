using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];

            string str = Console.ReadLine();

            int index = 0;

            bool isRight = true;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (isRight)
                    {
                        matrix[row, col] = str[index];
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - col - 1] = str[index];
                    }
                    index++;
                    if(isRight && col == cols - 1)
                    {
                        isRight = false;
                    }
                    else if(!isRight && col == cols - 1)
                    {
                        isRight = true;
                    }
                    if (index == str.Length)
                    {
                        index = 0;
                    }
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
