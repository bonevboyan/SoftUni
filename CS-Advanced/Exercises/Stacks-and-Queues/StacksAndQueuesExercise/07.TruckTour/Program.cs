using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> pumps = new Queue<int>();
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(input[0] - input[1]);
            }

            for (int i = 0; i < n; i++)
            {
                if (pumps.Peek() >= 0)
                {
                    foreach (var pump in pumps)
                    {
                        sum += pump;
                        if (sum < 0)
                        {
                            break;
                        }
                    }

                    if (sum >= 0)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                    else
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        sum = 0;
                    }
                }
                else
                {
                    pumps.Enqueue(pumps.Dequeue());
                }
            }

        }
    }
}
