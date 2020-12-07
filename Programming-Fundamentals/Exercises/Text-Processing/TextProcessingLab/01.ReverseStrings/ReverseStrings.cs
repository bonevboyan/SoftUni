using System;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while(line != "end")
            {
                string reversed = "";
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reversed += line[i];
                }
                Console.WriteLine($"{line} = {reversed}");
                line = Console.ReadLine();
            }
        }
    }
}