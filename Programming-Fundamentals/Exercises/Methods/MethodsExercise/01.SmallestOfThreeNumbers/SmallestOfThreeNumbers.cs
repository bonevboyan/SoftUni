using System;

namespace _01.SmallestOfThreeNumbers
{
    class SmallestOfThreeNumbers
    {
        public static int findSmallestNum(int firstNum, int secNum, int thirdNum)
        {
            int smallest = Math.Min(Math.Min(firstNum, secNum), thirdNum);
            return smallest;
        }
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallestNum = findSmallestNum(firstNum, secNum, thirdNum);

            Console.WriteLine(smallestNum);
        }
    }
}
