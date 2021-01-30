using System;

namespace _09.GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int firstInt = int.Parse(Console.ReadLine());
                    int secondInt = int.Parse(Console.ReadLine());
                    int resultInt = getMax(firstInt, secondInt);
                    Console.WriteLine(resultInt);
                    break;
                case "char":
                    char firstChar = Console.ReadLine()[0];
                    char secondChar = Console.ReadLine()[0];
                    char resultChar = getMax(firstChar, secondChar);
                    Console.WriteLine(resultChar);
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    string resultString = getMax(firstString, secondString);
                    Console.WriteLine(resultString);
                    break;
            }
        }
        private static int getMax(int firstNum, int secondNum)
        {
            if (firstNum > secondNum)
            {
                return firstNum;
            }
            return secondNum;
        }

        private static char getMax(char first, char second)
        {
            if (first > second)
            {
                return first;
            }
            return second;
        }

        private static string getMax(string first, string second)
        {
            int first1 = first.CompareTo(second);
            if (first1 >= 0)
            {
                return first;
            }

            return second;
        }
    }

}
