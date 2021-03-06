using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split(' ');
                Pizza pizza = new Pizza(pizzaInput[1]);

                string[] doughInfo = Console.ReadLine().Split(' ');
                pizza.Dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingInfo = command.Split(' ');
                    pizza.AddTopping(new Topping(toppingInfo[1], double.Parse(toppingInfo[2])));

                    command = Console.ReadLine();
                }

                double pizzaCalories = pizza.GetCalories();

                Console.WriteLine($"{pizza.Name} - {pizzaCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
                Console.WriteLine(exceptionMessage);
            }
        }
    }
}
