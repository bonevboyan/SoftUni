using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double caffeine)
           : base(name, price, milliliters)
        {
            Milliliters = 50;
            Price = 3.5M;
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
