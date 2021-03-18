using _03.Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.HeroTypes
{
    class Rogue : BaseHero
    {
        public Rogue(string name)
           : base(name)
        {
            Power = 80;
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {this.Power} damage";
        }
    }
}
