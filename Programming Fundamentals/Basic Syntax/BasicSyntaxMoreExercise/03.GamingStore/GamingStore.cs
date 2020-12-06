using System;

namespace _03.GamingStore
{
    class GamingStore
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine();

            double balance = double.Parse(input);
            double totalMoney = balance;
            double totalSpend = 0;
            double price;

            while ("Game time".ToLower() != (input = Console.ReadLine()).ToLower())
            {
                price = 0;
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                if (balance >= price && price > 0)
                {

                    totalSpend += price;
                    balance -= price;
                    Console.WriteLine($"Bought {input}");

                }
                else if (balance < price && price > 0)
                {

                    Console.WriteLine("Too Expensive");
                }
            }
            if (balance > 0)
            {
                Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${totalMoney - totalSpend:f2}");
            }
        }
    }
}
