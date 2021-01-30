using System;

namespace _05.AddAndSubtract
{
    class AddAndSubtract
    {
        public static int addAndSubtract(int firstNum, int secNum, int thirdNum)
        {
            return firstNum + secNum - thirdNum;
        }
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(addAndSubtract(firstNum, secondNum, thirdNum));

        }
    }
}
