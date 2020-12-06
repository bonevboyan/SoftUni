using System;

namespace _01.Train
{
    class Train
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] train = new int[n];
            for (int i = 0; i < train.Length; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            for (int i = 0; i < train.Length; i++)
            {
                Console.Write(train[i] + " ");
                sum += train[i];
            }
           Console.WriteLine("\n" + sum);
        }
    }
}
