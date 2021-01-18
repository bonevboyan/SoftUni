using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> queue = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    queue.Push(input[1]);
                }
                else if(input[0] == 2)
                {
                    queue.Pop();
                }
                else if(queue.Count > 0)
                {
                    if (input[0] == 3)
                    {
                        Console.WriteLine(queue.Max());
                    }
                    else if (input[0] == 4)
                    {
                        Console.WriteLine(queue.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
