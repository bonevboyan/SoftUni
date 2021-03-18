using _03.Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.HeroTypes
{
    class Paladin : BaseHero
    {
        public Paladin(string name)
           : base(name)
        {
            Power = 100;
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {this.Power}";
        }
    }
}
