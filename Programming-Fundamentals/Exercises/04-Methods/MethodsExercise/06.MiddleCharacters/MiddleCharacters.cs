using System;

namespace _06.MiddleCharacters
{
    class MiddleCharacters
    {
        public static void printMiddle(String str)
        {
            int middle = str.Length / 2;
            if (str.Length % 2 == 0)
            {
                Console.Write(str[middle - 1]);
                Console.WriteLine(str[middle]);
            }
            else
            {
                Console.WriteLine(str[middle]);
            }
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            printMiddle(str);
        }
    }
}
