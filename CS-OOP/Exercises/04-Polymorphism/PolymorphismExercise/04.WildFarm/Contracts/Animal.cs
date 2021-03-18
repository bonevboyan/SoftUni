using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
    abstract class Animal
    {
        protected abstract double WeightIncrease { get; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract string MakeSound();
        public void Eat(string food, int quantity)
        {
            if (CheckFood(food))
            {
                Weight += WeightIncrease * quantity;
                FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
            }
        }
        public abstract bool CheckFood(string food);
        public override abstract string ToString();
    }
}
