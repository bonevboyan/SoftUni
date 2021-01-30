using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> expression = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                expression.Push(input[i]);
            }
            while (expression.Count > 1)
            {
                int sum = int.Parse(expression.Pop());
                if(expression.Pop() == "-")
                {
                    sum -= int.Parse(expression.Pop());
                }
                else
                {
                    sum += int.Parse(expression.Pop());
                }
                expression.Push(sum.ToString());
            }
            Console.WriteLine(expression.Pop());
        }
    }
}
