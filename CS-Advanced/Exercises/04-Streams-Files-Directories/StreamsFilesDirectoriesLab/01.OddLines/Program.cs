﻿using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../Resources/01. Odd Lines/Input.txt"))
            {
                string current = reader.ReadLine();
                int row = 0;
                using (StreamWriter writer = new StreamWriter("../../../../Outputs/01. Odd Lines/Output.txt"))
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
