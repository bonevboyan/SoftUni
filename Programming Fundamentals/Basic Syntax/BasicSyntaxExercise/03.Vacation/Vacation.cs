using System;

namespace _03.Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());
            String type = Console.ReadLine();
            String day = Console.ReadLine();
            double price = 0;
            switch (type.ToLower())
            {
                case "students":
                    switch (day.ToLower())
                    {
                        case "friday":
                            price = 8.45;
                            break;
                        case "saturday":
                            price = 9.80;
                            break;
                        case "sunday":
                            price = 10.46;
                            break;
                    }
                    if (totalPeople >= 30)
                    {
                        price *= 0.85;
                    }
                    break;
                case "business":
                    switch (day.ToLower())
                    {
                        case "friday":
                            price = 10.90;
                            break;
                        case "saturday":
                            price = 15.60;
                            break;
                        case "sunday":
                            price = 16.00;
                            break;
                    }
                    if (totalPeople >= 100)
                    {
                        totalPeople -= 10;
                    }
                    break;
                case "regular":
                    switch (day.ToLower())
                    {
                        case "friday":
                            price = 15.00;
                            break;
                        case "saturday":
                            price = 20.00;
                            break;
                        case "sunday":
                            price = 22.50;
                            break;
                    }
                    if (totalPeople >= 10 && totalPeople <= 20)
                    {
                        price *= 0.95;
                    }
                    break;
            }
            Console.WriteLine($"Total price: {price * totalPeople:f2}");
        }
    }
}
