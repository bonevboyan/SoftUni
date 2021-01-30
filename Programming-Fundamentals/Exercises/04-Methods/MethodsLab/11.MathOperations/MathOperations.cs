using System;

namespace _11.MathOperations
{
    class MathOperations
    {
        public static double calculate(int a, string op, int b)
        {
            double result = 0;

            switch (op)
            {
            case "+":
                result = a + b;
                break;
            case "-":
                result = a - b;
                break;
            case "/":
                result = a / b;
                break;
            case "*":
                result = a * b;
                break;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"{calculate(int.Parse(Console.ReadLine()), Console.ReadLine(), int.Parse(Console.ReadLine()))}");
        }
    }
}
