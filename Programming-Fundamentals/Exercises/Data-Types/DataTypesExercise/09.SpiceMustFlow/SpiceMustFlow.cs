using System;

namespace _09.SpiceMustFlow
{
    class SpiceMustFlow
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int amount = 0;
            int days = 0;

            while (startingYield > 0)
            {
                if (startingYield < 100)
                {
                    if (amount < 26)
                    {
                        break;
                    }
                    amount -= 26;
                    break;
                }
                amount += startingYield - 26;
                startingYield -= 10;

                days++;
            }
            Console.WriteLine(days + "\n" + amount);
        }
    }
}
