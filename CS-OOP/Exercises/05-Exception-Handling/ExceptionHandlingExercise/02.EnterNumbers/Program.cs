using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10];
        start:;
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.Write($"a{i+1}:");
                    nums[i] = ReadNumber(1,100);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Try again!");
                goto start;
            }
        }
        static int ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());
            if (num < start || num > end)
            {
                throw new Exception();
            }
            return num;

        }
    }
}
