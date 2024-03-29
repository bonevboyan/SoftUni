﻿using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    string[] pizzaInput = Console.ReadLine().Split(' ');
            //    Pizza pizza = new Pizza(pizzaInput[1]);

            //    string[] doughInfo = Console.ReadLine().Split(' ');
            //    pizza.Dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

            //    string command = Console.ReadLine();

            //    while (command != "END")
            //    {
            //        string[] toppingInfo = command.Split(' ');
            //        pizza.AddTopping(new Topping(toppingInfo[1], double.Parse(toppingInfo[2])));

            //        command = Console.ReadLine();
            //    }

            //    double pizzaCalories = pizza.GetCalories();

            //    Console.WriteLine($"{pizza.Name} - {pizzaCalories:f2} Calories.");
            //}
            //catch (Exception ex)
            //{
            //    string exceptionMessage = ex.Message;
            //    Console.WriteLine(exceptionMessage);
            //}
            try
            {
                var pizzaName = Console.ReadLine().Split()[1];
                var doughData = Console.ReadLine().Split();

                var flourType = doughData[1];
                var bakingTechnique = doughData[2];
                var weight = int.Parse(doughData[3]);

                var dough = new Dough(flourType, bakingTechnique, weight);
                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }
                    var parts = line.Split();

                    var toppingName = parts[1];
                    var toppingWeight = int.Parse(parts[2]);

                    var topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
