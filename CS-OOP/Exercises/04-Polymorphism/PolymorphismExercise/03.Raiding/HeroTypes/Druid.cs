using _03.Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.HeroTypes
{
    class Druid : BaseHero
    {
        public Druid(string name)
           :base(name)
        {
            Power = 80;
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {this.Power}";
        }
    }
}
