using System;

namespace _10.TopNumber
{
    class TopNumber
    {
        public static bool isTop(int num)
        {
            int sum = 0;
            bool f = false;
            for (int i = num; i != 0; i /= 10)
            {
                sum += i % 10;
                if ((i % 10) % 2 == 1)
                {
                    f = true;
                }
            }
            if (sum % 8 == 0 && f)
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
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                if (isTop(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
