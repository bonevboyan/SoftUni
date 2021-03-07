using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    class Rebel : IBuyer
    {
        private int age;
        private string name;
        private string group;
        public Rebel(string name, int age, string group)
        {
            this.name = name;
            this.age = age;
            this.group = group;
        }
        public int Food { get; set; }

        public string Name => name;

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
