using System;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (input != "find")
            {
                StringBuilder message = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    message.Append(Convert.ToChar(input[i] - key[i % key.Length]));
                }

                string messageAsStr = message.ToString();

                int startIndexOfTreasure = messageAsStr.IndexOf("&") + 1;
                int treasureLength = messageAsStr.LastIndexOf("&") - startIndexOfTreasure;

                string treasure = messageAsStr.Substring(startIndexOfTreasure, treasureLength);

                int startIndexOfCoordinates = messageAsStr.IndexOf("<") + 1;
                int coordinatesLength = messageAsStr.IndexOf(">") - startIndexOfCoordinates;

                string coordinates = messageAsStr.Substring(startIndexOfCoordinates, coordinatesLength);

                Console.WriteLine($"Found {treasure} at {coordinates}");

                input = Console.ReadLine();
            }
        }
    }
}
