using _04.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    class Hen : Bird
    {
        protected override double WeightIncrease { get => 0.35; }
        public override bool CheckFood(string food)
        {
            return true;
        }
        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
