using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
    abstract class Feline : Mammal
    {
        public string Breed { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
