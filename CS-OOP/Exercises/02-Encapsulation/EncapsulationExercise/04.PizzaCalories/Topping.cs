using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        private string Name
        {
            get => name;

            set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        private double Weight
        {
            get => weight;
            set
            {
                if (value >= 1 && value <= 50)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range of [1...50].");
                }
            }
        }

        private double GetToppingCaloriesModifier()
        {
            double toppingCaloriesModifier = 0;

            if (this.Name.ToLower() == "meat")
            {
                toppingCaloriesModifier = 1.2;
            }
            else if (this.Name.ToLower() == "veggies")
            {
                toppingCaloriesModifier = 0.8;
            }
            else if (this.Name.ToLower() == "cheese")
            {
                toppingCaloriesModifier = 1.1;
            }
            else if (this.Name.ToLower() == "sauce")
            {
                toppingCaloriesModifier = 0.9;
            }

            return toppingCaloriesModifier;
        }

        internal double GetToppingCalories()
        {
            double toppingCaloriesModifier = GetToppingCaloriesModifier();

            double toppingCalories = this.Weight * 2 * toppingCaloriesModifier;

            return toppingCalories;
        }
    }
}