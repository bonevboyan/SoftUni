using System;

namespace _01.CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal flourPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal apronPrice = decimal.Parse(Console.ReadLine());

            int freePackages = students / 5;
            decimal moneyNeeded = students * 10 * eggPrice + Math.Ceiling(students * (decimal)1.2) * apronPrice + flourPrice * (students - freePackages);

            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"Items purchased for {moneyNeeded:f2}$.");
            }
            else
            {
                Console.WriteLine($"{moneyNeeded - budget:f2}$ more needed.");
            }
        }
    }
}
