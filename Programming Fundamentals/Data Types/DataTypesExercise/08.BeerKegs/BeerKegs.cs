using System;

namespace _08.BeerKegs
{
    class BeerKegs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            String name;
            double radius;
            double height;

            String biggestName = "";
            double biggest = 0;
            for (int i = 0; i < n; i++)
            {
                name = Console.ReadLine();
                radius = double.Parse(Console.ReadLine());
                height = double.Parse(Console.ReadLine());
                if (radius * radius * height > biggest)
                {
                    biggest = radius * radius * height;
                    biggestName = name;
                }
            }
            Console.WriteLine(biggestName);
        }
    }
}
