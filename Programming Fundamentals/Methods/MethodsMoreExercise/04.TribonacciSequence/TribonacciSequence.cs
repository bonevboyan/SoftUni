using System;

namespace _04.TribonacciSequence
{
    class TribonacciSequence
    {
        static int printTribRec(int n)
        {

            if (n == 0 || n == 1 || n == 2)
                return 0;

            if (n == 3)
                return 1;
            else
                return printTribRec(n - 1) +
                        printTribRec(n - 2) +
                        printTribRec(n - 3);
        }

        static void printTrib(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (printTribRec(i) != 0)
                {
                    Console.Write(printTribRec(i) + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            printTrib(int.Parse(Console.ReadLine()) + 2);
        }
    }
}
