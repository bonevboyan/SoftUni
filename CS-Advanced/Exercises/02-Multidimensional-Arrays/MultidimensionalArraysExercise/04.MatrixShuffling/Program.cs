using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static bool isValid(int row, int col, int rows, int cols)
        {
            if(row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command.Contains("swap") && tokens.Length == 5)
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);
                    if (isValid(row1, col1, rows, cols) && isValid(row2, col2, rows, cols))
                    {
                        string swap = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = swap;
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }
    }
}
