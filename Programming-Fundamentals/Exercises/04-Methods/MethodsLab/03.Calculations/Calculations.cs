using System;

namespace _03.Calculations
{
    class Calculations
    {
        public static void calculate(string action, int firstNum, int secondNum)
        {
            int result;
            switch (action)
            {
                case "add":
                    result = firstNum + secondNum;
                    break;
                case "multiply":
                    result = firstNum * secondNum;
                    break;
                case "subtract":
                    result = firstNum - secondNum;
                    break;
                case "divide":
                    result = firstNum / secondNum;
                    break;
                default:
                    result = -1;
                    break;
            }
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            String action = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            calculate(action, firstNum, secondNum);
        }
    }
}
