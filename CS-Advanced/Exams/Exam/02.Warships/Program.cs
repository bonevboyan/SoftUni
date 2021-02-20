using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] coords = Console.ReadLine()
                .Split(',')
                .Select(o => o.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
                .ToArray();
            char[,] matrix = new char[n, n];

            int playerOneCount = 0, playerTwoCount = 0;
            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == '<')
                    {
                        playerOneCount++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoCount++;
                    }
                }
            }
            int total = playerOneCount + playerTwoCount;
            foreach (var coord in coords)
            {
                int row = coord[0], col = coord[1];
                if (row < n && col < n && row >= 0 && col >= 0)
                {
                    if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        playerOneCount--;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        playerTwoCount--;
                    }
                    else if (matrix[row, col] == '#')
                    {
                        if (row + 1 < n && col + 1 < n)
                        {
                            if (matrix[row + 1, col + 1] == '<')
                            {
                                matrix[row + 1, col + 1] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row + 1, col + 1] == '>')
                            {
                                matrix[row + 1, col + 1] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (row + 1 < n)
                        {
                            if (matrix[row + 1, col] == '<')
                            {
                                matrix[row + 1, col] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row + 1, col] == '>')
                            {
                                matrix[row + 1, col] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (col + 1 < n)
                        {
                            if (matrix[row, col + 1] == '<')
                            {
                                matrix[row, col + 1] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row, col + 1] == '>')
                            {
                                matrix[row, col + 1] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (row - 1 >= 0 && col - 1 >= 0)
                        {
                            if (matrix[row - 1, col - 1] == '<')
                            {
                                matrix[row - 1, col - 1] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row - 1, col - 1] == '>')
                            {
                                matrix[row - 1, col - 1] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (row - 1 >= 0)
                        {
                            if (matrix[row - 1, col] == '<')
                            {
                                matrix[row - 1, col] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row - 1, col] == '>')
                            {
                                matrix[row - 1, col] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (col - 1 >= 0)
                        {
                            if (matrix[row, col - 1] == '<')
                            {
                                matrix[row, col - 1] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row, col - 1] == '>')
                            {
                                matrix[row, col - 1] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (row - 1 >= 0 && col + 1 < n)
                        {
                            if (matrix[row - 1, col + 1] == '<')
                            {
                                matrix[row - 1, col + 1] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row - 1, col + 1] == '>')
                            {
                                matrix[row - 1, col + 1] = 'X';
                                playerTwoCount--;
                            }
                        }
                        if (col - 1 >= 0 && row + 1 < n)
                        {
                            if (matrix[row + 1, col - 1] == '<')
                            {
                                matrix[row + 1, col - 1] = 'X';
                                playerOneCount--;
                            }
                            else if (matrix[row + 1, col - 1] == '>')
                            {
                                matrix[row + 1, col - 1] = 'X';
                                playerTwoCount--;
                            }
                        }
                    }
                    if (playerOneCount == 0)
                    {
                        Console.WriteLine($"Player Two has won the game! {total - (playerOneCount + playerTwoCount)} ships have been sunk in the battle.");
                        return;
                    }
                    else if (playerTwoCount == 0)
                    {
                        Console.WriteLine($"Player One has won the game! {total - (playerOneCount + playerTwoCount)} ships have been sunk in the battle.");
                        return;
                    }
                }
            }
            Console.WriteLine($"It's a draw! Player One has {playerOneCount} ships left. Player Two has {playerTwoCount} ships left.");
        }
    }
}
