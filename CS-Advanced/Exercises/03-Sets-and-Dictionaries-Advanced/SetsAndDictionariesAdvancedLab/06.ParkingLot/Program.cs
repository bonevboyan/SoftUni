using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carPlates = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(", ").ToArray();
                if(tokens[0] == "IN")
                {
                    carPlates.Add(tokens[1]);
                }
                else if(tokens[0] == "OUT")
                {
                    if (carPlates.Contains(tokens[1]))
                    {
                        carPlates.Remove(tokens[1]);
                    }
                }
                command = Console.ReadLine();
            }
            if (carPlates.Any())
            {
                Console.WriteLine(string.Join("\n", carPlates));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
