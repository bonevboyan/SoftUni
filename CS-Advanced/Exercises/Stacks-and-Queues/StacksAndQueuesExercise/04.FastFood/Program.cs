using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Console.WriteLine(orders.Max());
            while(orders.Count > 0)
            {
                if(foodQuantity - orders.Peek() >= 0)
                {
                    foodQuantity -= orders.Peek();
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", orders));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
