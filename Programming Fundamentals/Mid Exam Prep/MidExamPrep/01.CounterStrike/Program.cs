using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int totalBattles = 0;
            string line = Console.ReadLine();
            while(line != "End of battle")
            {
                int distance = int.Parse(line);
                if (totalBattles % 3 == 0)
                {
                    initialEnergy += 10;
                }
                if (initialEnergy - distance > 0)
                {
                    initialEnergy -= distance;
                    totalBattles++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {totalBattles} won battles and {initialEnergy} energy");
                    return;
                }

                line = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {totalBattles}. Energy left: {initialEnergy}");

        }
    }
}
