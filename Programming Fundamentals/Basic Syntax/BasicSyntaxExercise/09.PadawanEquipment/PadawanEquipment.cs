using System;

namespace _09.PadawanEquipment
{
    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsNumber = int.Parse(Console.ReadLine());
            double priceLightSabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double additionalLightSabers = Math.Ceiling(0.10 * studentsNumber);

            double totalLightSabers = (studentsNumber + additionalLightSabers) * priceLightSabers;
            double totalRobes = priceRobes * studentsNumber;

            double freeBelts = Math.Floor(studentsNumber / 6.00);
            double totalBelts = priceBelts * (studentsNumber - freeBelts);

            double moneyNeeded = totalBelts + totalLightSabers + totalRobes;
            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                double moneyDiff = moneyNeeded - budget;
                Console.WriteLine($"Ivan Cho will need {moneyDiff:f2}lv more.");
            }
        }
    }
}
