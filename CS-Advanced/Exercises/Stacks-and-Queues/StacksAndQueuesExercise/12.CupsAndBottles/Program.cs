using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0, currentCup = cups.Peek();
            while(cups.Any() && bottles.Any())
            {
                if(currentCup <= bottles.Peek())
                {
                    wastedWater += bottles.Peek() - currentCup;
                    cups.Dequeue();
                    if(cups.Any())
                        currentCup = cups.Peek();
                }
                else
                {
                    currentCup -= bottles.Peek();
                }
                bottles.Pop();
            }
            if (cups.Any())
            {
                Console.WriteLine("Cups: " + string.Join(" ", cups));
            }
            else
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottles));
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
