using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string current = reader.ReadLine();
                int row = 0;
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (current != null)
                    {
                        if (row % 2 == 1)
                        {
                            writer.WriteLine(current);
                        }
                        current = reader.ReadLine();
                        row++;
                    }
                }
            }
        }
    }
}
