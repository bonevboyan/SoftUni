using System;

namespace _05.Orders
{
    class Orders
    {
        public static void determineCost(String product, int quantity)
        {
            double result = 0;
            switch (product)
            {
                case "coffee":
                    result = 1.5 * quantity;
                    break;
                case "water":
                    result = 1.0 * quantity;
                    break;
                case "coke":
                    result = 1.4 * quantity;
                    break;
                case "snacks":
                    result = 2.0 * quantity;
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            determineCost(product, quantity);
        }
    }
}
