using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (double number in arr)
            {
                int rounded = (int)Math.Round(number, MidpointRounding.AwayFromZero);
                Console.WriteLine("{0} => {1}", number, rounded);
            }
        }
    }
}
