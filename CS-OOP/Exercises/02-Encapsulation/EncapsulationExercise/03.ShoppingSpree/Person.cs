using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }
        public List<Product> BagOfProducts { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (value == string.Empty)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                money = value;
            }
        }
    }
}
