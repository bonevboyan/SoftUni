using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            while (line != "Retire")
            {
                string[] input = line.Split(" ").ToArray();
                int index, startIndex, endIndex, damage, health;
                switch (input[0])
                {
                    case "Fire":
                        index = int.Parse(input[1]);
                        damage = int.Parse(input[2]);
                        if (index >= 0 && index < warShip.Count)
                        {
                            warShip[index] -= damage;
                            if (warShip[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        startIndex = int.Parse(input[1]);
                        endIndex = int.Parse(input[2]);
                        damage = int.Parse(input[3]);
                        if (startIndex >= 0 && startIndex < pirateShip.Count && endIndex >= 0 && endIndex < pirateShip.Count && damage >= 0)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i]-=damage; 
                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        index = int.Parse(input[1]);
                        health = int.Parse(input[2]);
                        if (index >= 0 && index < warShip.Count && health >= 0)
                        {
                            pirateShip[index] = Math.Min(health + pirateShip[index], maxCapacity);
                        }
                        break;
                    case "Status":
                        int count = pirateShip.Where(o => o < maxCapacity * 0.2).ToList().Count;
                        Console.WriteLine($"{count} sections need repair.");
                        break;
                }

                line = Console.ReadLine();
            }
            int warShipSum = 0, pirateShipSum = 0; 
            for (int i = 0; i < pirateShip.Count; i++)
            {
                pirateShipSum += pirateShip[i];
            }
            for (int i = 0; i < warShip.Count; i++)
            {
                warShipSum += warShip[i];
            }
            Console.WriteLine($"Pirate ship status: {pirateShipSum}\nWarship status: {warShipSum}");
        }
    }
}
