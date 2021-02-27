using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public void Add(string el)
        {
            base.Add(el);
            Console.WriteLine($"Added the string {el} and we have custom functionalities");
        }

        public string RandomString()
        {
            return this[random.Next(0, this.Count)];
        }
    }
}
