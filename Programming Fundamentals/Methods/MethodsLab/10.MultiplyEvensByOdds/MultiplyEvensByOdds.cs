using System;

namespace _10.MultiplyEvensByOdds
{
    class MultiplyEvensByOdds
    {
        private static int getMultipleEvensAndOdds(String str)
        {
            int evenSum = 0;
            int oddSum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int currNum = (int)Math.Abs(char.GetNumericValue(str[i]));
                if (str[i] != '-')
                {
                    if (currNum % 2 == 0)
                    {
                        evenSum += currNum;
                    }
                    else
                    {
                        oddSum += currNum;
                    }
                }
            }
            return evenSum * oddSum;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(getMultipleEvensAndOdds(input));
        }
    }
}
