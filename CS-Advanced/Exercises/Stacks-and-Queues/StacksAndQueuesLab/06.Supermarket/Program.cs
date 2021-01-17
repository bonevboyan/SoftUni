﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                if(command == "Paid")
                {
                    while(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(queue.Count + " people remaining.");
        }
    }
}
