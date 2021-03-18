using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
    abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
