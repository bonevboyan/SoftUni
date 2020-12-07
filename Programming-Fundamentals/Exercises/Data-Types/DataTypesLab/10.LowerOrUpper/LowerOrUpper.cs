using System;

namespace _10.LowerOrUpper
{
    class LowerOrUpper
    {
        static void Main(string[] args)
        {
            char ch = Console.ReadLine()[0];
            if (Char.IsUpper(ch))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
