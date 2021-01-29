﻿using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader1 = new StreamReader("../../../Input1.txt"))
            {
                using (StreamReader reader2 = new StreamReader("../../../Input2.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                    {
                        string r1 = reader1.ReadLine();
                        string r2 = reader2.ReadLine();
                        while (r1 != null && r2 != null)
                        {
                            writer.WriteLine(r1);
                            writer.WriteLine(r2);
                            r1 = reader1.ReadLine();
                            r2 = reader2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
