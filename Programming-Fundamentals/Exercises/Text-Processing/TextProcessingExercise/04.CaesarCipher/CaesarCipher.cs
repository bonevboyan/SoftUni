using System;

namespace _04.CaesarCipher
{
    class CaesarCipher
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(ShiftByThree(line[i]));
            }
        }
        public static char ShiftByThree(char ch)
        {
            return (char)(ch + 3);
        }
    }
}
