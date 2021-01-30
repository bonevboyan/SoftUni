using System;
using System.Collections.Generic;
using System.Linq;


namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<char> text = new Stack<char>();
            Stack<string> texts = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                if (command[0] == "1")
                {
                    char[] chArr = text.ToArray();
                    Array.Reverse(chArr);
                    texts.Push(new string(chArr));
                    foreach (var ch in command[1])
                    {
                        text.Push(ch);
                    }
                }
                else if (command[0] == "2")
                {
                    char[] chArr = text.ToArray();
                    Array.Reverse(chArr);
                    texts.Push(new string(chArr));
                    for (int j = 0; j < int.Parse(command[1]); j++)
                    {
                        text.Pop();
                    }
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(text.Reverse().ToArray()[int.Parse(command[1]) - 1]);
                }
                else if(command[0] == "4")
                {
                    text.Clear();
                    foreach (char ch in texts.Pop().ToCharArray())
                    {
                        text.Push(ch);
                    }
                }
            }
        }
    }
}
