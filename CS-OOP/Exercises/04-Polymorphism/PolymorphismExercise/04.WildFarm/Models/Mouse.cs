using _04.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    class Mouse : Mammal
    {
        protected override double WeightIncrease { get => 0.1; }
        public override bool CheckFood(string food)
        {
            switch (food)
            {
                case nameof(Vegetable):
                case nameof(Fruit):
                    return true;

                default:
                    return false;
            }
        }
        public override string MakeSound()
        {
            return "Squeak";
        }
    }
}
