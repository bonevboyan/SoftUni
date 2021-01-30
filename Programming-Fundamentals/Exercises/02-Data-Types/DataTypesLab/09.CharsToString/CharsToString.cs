using System;

namespace _09.CharsToString
{
    class CharsToString
    {
        static void Main(string[] args)
        {
            char a = Console.ReadLine()[0];
            char b = Console.ReadLine()[0];
            char c = Console.ReadLine()[0];

            string result = "" + a + b + c;

            Console.WriteLine(result);
        }
    }
}
