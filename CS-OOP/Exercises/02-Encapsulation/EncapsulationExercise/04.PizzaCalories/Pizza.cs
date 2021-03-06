using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get => dough; set => dough = value; }

        public IReadOnlyCollection<Topping> Toppings => this.toppings;

        public void AddTopping(Topping topping)
        {

            if (this.Toppings.Count < 0 || this.Toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            double pizzaCalories = 0;

            pizzaCalories += this.Dough.GetDoughCalories();

            foreach (Topping topping in this.Toppings)
            {
                pizzaCalories += topping.GetToppingCalories();
            }

            return pizzaCalories;
        }
    }
}