using _04.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    abstract class Bird : Animal
    {
        public double WingSize { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
