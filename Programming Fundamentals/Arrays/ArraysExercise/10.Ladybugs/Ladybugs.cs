using System;
using System.Linq;

namespace _10.Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int[] field = new int[int.Parse(Console.ReadLine())];
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] >= 0 && indexes[i] < field.Length)
                {
                    field[indexes[i]] = 1;
                }
            }
            String command;
            while (!(command = Console.ReadLine()).Equals("end"))
            {
                String[] input = command.Split(" ");
                int index = int.Parse(input[0]);
                String direction = input[1];
                int flight = int.Parse(input[2]);

                if (index < 0 || index >= field.Length || field[index] == 0)
                {
                    continue;
                }
                field[index] = 0;
                int currentFlight = flight;
                if (direction.Equals("right"))
                {
                    while (index + currentFlight < field.Length && index + currentFlight >= 0)
                    {
                        if (field[index + currentFlight] == 0)
                        {
                            field[index + currentFlight] = 1;
                            break;
                        }
                        else
                        {
                            currentFlight += flight;
                        }
                    }
                }
                else if (direction.Equals("left"))
                {
                    while (index - currentFlight >= 0 && index - currentFlight < field.Length)
                    {
                        if (field[index - currentFlight] == 0)
                        {
                            field[index - currentFlight] = 1;
                            break;
                        }
                        else
                        {
                            currentFlight += flight;
                        }
                    }
                }
            }
            foreach (int cell in field)
            {
                Console.Write(cell + " ");
            }
        }
    }
}
