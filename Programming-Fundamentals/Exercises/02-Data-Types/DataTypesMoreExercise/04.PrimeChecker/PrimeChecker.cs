using System;

namespace _04.PrimeChecker
{
    class PrimeChecker
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool flag = false;
            for (int j = 2; j <= num; j++)
            {
                flag = false;
                for (int i = 2; i <= j / 2; i++)
                {
                    if (j % i == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine(j + " -> true");
                }
                else
                {
                    Console.WriteLine(j + " -> false");
                }
            }
        }
    }
}
