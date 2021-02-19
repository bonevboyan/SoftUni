using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            CustomStack<string> stack = new CustomStack<string>();
            while(command != "END")
            {
                if (command.Contains("Pop"))
                {
                    stack.Pop();
                }
                else if (command.Contains("Push"))
                {
                    foreach (var item in command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(i => i.Split(',').First()))
                    {
                        stack.Push(item);
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
