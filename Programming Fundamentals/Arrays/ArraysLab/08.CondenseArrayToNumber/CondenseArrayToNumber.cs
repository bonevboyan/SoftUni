using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class CondenseArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
            int finalResult = 0;
            int firstLength = numbers.Length - 1;
            for (int i = 0; i < firstLength; i++)
            {
                int[] condensed = new int[numbers.Length - 1];
                for (int j = 0; j < condensed.Length; j++)
                    condensed[j] = numbers[j] + numbers[j + 1];
                numbers = condensed;
                finalResult = condensed[0];
            }
            Console.WriteLine(finalResult);
        }
    }
}
