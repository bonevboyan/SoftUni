using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int usedBullets = 0, currentlyInRevolver = barrelSize;

            while(bullets.Any() && locks.Any())
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                usedBullets++;
                currentlyInRevolver--;
                if (currentlyInRevolver == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentlyInRevolver = Math.Min(bullets.Count, barrelSize);
                }
            }
            if(bullets.Count == 0 && locks.Count!=0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - usedBullets*bulletPrice}");
            }
        }
    }
}
