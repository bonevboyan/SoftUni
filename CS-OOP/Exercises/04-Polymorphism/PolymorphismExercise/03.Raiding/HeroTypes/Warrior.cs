using _03.Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.HeroTypes
{
    class Warrior : BaseHero
    {
        public Warrior(string name)
           : base(name)
        {
            Power = 100;
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {this.Power} damage";
        }
    }
}
