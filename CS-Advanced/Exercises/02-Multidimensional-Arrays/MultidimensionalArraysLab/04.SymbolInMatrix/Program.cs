using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            char ch = char.Parse(Console.ReadLine());
            int r = -1;
            int c = -1;
            bool isTrue = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(matrix[row,col] == ch)
                    {
                        isTrue = true;
                        r = row;
                        c = col;
                        goto outer;
                    }
                }
            }
            outer:;
            if (r != -1)
            {
                Console.WriteLine($"({r}, {c})");
            }
            else
            {
                Console.WriteLine($"{ch} does not occur in the matrix");
            }
        }
    }
}
