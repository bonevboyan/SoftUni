using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../../Resources/text.txt"))
            {
                string current = reader.ReadLine();
                int row = 0;
                while (current != null)
                {
                    if (row % 2 == 0)
                    {
                        string[] text = current.Split().Select(o => o.Replace(",", "@").Replace("-", "@").Replace(".", "@").Replace("!", "@").Replace("?", "@")).ToArray();
                        Array.Reverse(text);
                        Console.WriteLine(string.Join(" ", text));
                    }
                    current = reader.ReadLine();
                    row++;
                }
            }
        }
    }
}
