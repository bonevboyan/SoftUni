using System;

namespace _06.BalancedBrackets
{
    class BalancedBrackets
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            int openingBracketsCount = 0;
            int closingBracketsCount = 0;
            bool isBalanced = true;

            for (int i = 1; i <= inputLines; i++)
            {

                String input = Console.ReadLine();

                if (input.Equals("("))
                {
                    openingBracketsCount++;
                    if (openingBracketsCount - closingBracketsCount >= 2)
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (input.Equals(")"))
                {
                    closingBracketsCount++;

                    if (closingBracketsCount > openingBracketsCount)
                    {
                        isBalanced = false;
                        break;
                    }
                }

            }
            if (openingBracketsCount != closingBracketsCount)
            {
                isBalanced = false;
            }

            if (!isBalanced)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}
