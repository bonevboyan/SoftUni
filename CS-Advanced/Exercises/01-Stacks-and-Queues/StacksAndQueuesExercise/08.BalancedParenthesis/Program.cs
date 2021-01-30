using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> elements = new Stack<char>();

            if (input != null)
                foreach (var t in input)
                {
                    switch (t)
                    {
                        case '(':
                            elements.Push(t);
                            break;
                        case '[':
                            elements.Push(t);
                            break;
                        case '{':
                            elements.Push(t);
                            break;
                        case ')':
                            if (!elements.Any() || elements.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (!elements.Any() || elements.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case '}':
                            if (!elements.Any() || elements.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }

            Console.WriteLine("YES");
        }
    }
}
