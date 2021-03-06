using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
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
        public decimal Cost
        {
            get => cost;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                cost = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
