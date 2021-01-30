using System;

namespace _05.PrintPartOfTheASCIITable
{
    class PrintPartOfTheASCIITable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            for (int i = n; i <= p; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
