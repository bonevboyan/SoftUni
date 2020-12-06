using System;

namespace _10.RageExpenses
{
    class RageExpenses
    {
        static void Main(string[] args)
        {
            int games = int.Parse(Console.ReadLine());
            double handsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double handsetCost = (games / 2) * handsetPrice;
            double mouseCost = (games / 3) * mousePrice;
            double keyboardCost = (games / 6) * keyboardPrice;
            double displayCost = (games / 12) * displayPrice;

            double totalCost = handsetCost + mouseCost + keyboardCost + displayCost;

            Console.WriteLine($"Rage expenses: {totalCost:f2} lv.\n");
        }
    }
}
