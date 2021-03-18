using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Contracts
{
    abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public int Power { get; set; }
        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name}";
        }
    }
}
