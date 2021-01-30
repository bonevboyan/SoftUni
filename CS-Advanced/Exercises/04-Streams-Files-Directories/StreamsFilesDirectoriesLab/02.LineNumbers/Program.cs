using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../../Resources/02. Line Numbers/Input.txt"))
            {
                using(StreamWriter writer = new StreamWriter("../../../../Outputs/02. Line Numbers/Output.txt"))
                {
                    string line = reader.ReadLine();
                    int row = 1;
                    while(line != null)
                    {
                        writer.WriteLine($"{row}. {line}");
                        row++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
