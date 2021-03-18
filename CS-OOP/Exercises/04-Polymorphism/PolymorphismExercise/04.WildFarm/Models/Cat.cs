using _04.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    class Cat : Feline
    {
        protected override double WeightIncrease { get => 0.3; }

        public override bool CheckFood(string food)
        {
            switch (food)
            {
                case nameof(Vegetable):
                case nameof(Meat):
                    return true;

                default:
                    return false;
            }
        }

        public override string MakeSound()
        {
            return "Meow";
        }
    }
}
