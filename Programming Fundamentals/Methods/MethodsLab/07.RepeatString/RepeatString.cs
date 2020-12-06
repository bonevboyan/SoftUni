using System;

namespace _07.RepeatString
{
    class RepeatString
    {
        public static string repeatString(string str, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += str;
            }
            return result;
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(repeatString(str, count));
        }
    }
}
