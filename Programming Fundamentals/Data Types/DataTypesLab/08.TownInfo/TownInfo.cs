using System;

namespace _08.TownInfo
{
    class TownInfo
    {
        static void Main(string[] args)
        {
            String name = Console.ReadLine();
            int pop = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());
            Console.WriteLine($"Town {name} has population of {pop} and area {area} square km.");
        
        }
    }
}
