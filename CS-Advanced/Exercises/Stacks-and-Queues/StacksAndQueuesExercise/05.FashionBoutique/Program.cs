using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRack = 0, rackCount = 1;
            while (clothes.Count > 0)
            {
                currentRack += clothes.Peek();
                if (currentRack > rackCapacity)
                {
                    rackCount++;
                    currentRack = 0;
                }
                else
                {
                    clothes.Pop();
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
