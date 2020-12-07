using System;

namespace _01.Ages
{
    class Ages
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string age;
            if (n >= 0 && n <= 2)
            {
                age = "baby";
            }
            else if (n >= 3 && n <= 13)
            {
                age = "child";
            }
            else if (n >= 14 && n <= 19)
            {
                age = "teenager";
            }
            else if (n >= 20 && n <= 65)
            {
                age = "adult";
            }
            else if (n >= 66)
            {
                age = "elder";
            }
            else
            {
                age = "";
            }
            Console.WriteLine(age);
        }
    }
}
