using System;

namespace _07.VendingMachine
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            double n = 0;
            string input = "0";
            double sum = 0;

            do
            {
                n = double.Parse(input);
                if (!(n == 0.1 || n == 0.2 || n == 0.5 || n == 1 || n == 2) && n != 0)
                {
                    Console.WriteLine($"Cannot accept {n:f2}");
                    n = 0;
                }
                sum += n;
                input = Console.ReadLine();
            } while (input != "Start");
            do
            {
                switch (input.ToLower())
                {
                    case "nuts":
                        n = 2;
                        break;
                    case "water":
                        n = 0.7;
                        break;
                    case "crisps":
                        n = 1.5;
                        break;
                    case "soda":
                        n = 0.8;
                        break;
                    case "coke":
                        n = 1;
                        break;
                    case "start":
                        n = 0;
                        break;
                    default:
                        n = -1;
                        break;
                }
                if (n == -1)
                {
                    Console.WriteLine("Invalid product");
                }
                else if (n != 0)
                {
                    if (sum - n >= 0)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= n;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                input = Console.ReadLine();

            } while (input != "End");
            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
