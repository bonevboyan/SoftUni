using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Person
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> Products { get; set; }
    }
    class Product
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(';');
            List<Person> people = new List<Person>(line.Length);
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Length != 0)
                {
                    string[] input = line[i].Split('=');
                    Person person = new Person
                    {
                        Name = input[0],
                        Money = decimal.Parse(input[1]),
                        Products = new List<Product>()
                    };
                    people.Add(person);
                }
            }
            line = Console.ReadLine().Split(';');
            List<Product> products = new List<Product>(line.Length);
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Length != 0)
                {
                    string[] input = line[i].Split('=');
                    Product product = new Product
                    {
                        Name = input[0],
                        Cost = decimal.Parse(input[1])
                    };
                    products.Add(product);
                }
            }
            line = Console.ReadLine().Split();
            while (line[0] != "END")
            {
                Person person = people[people.FindIndex(o => o.Name == line[0])];
                Product product = products[products.FindIndex(o => o.Name == line[1])];
                if (person.Money >= product.Cost) 
                {
                    person.Products.Add(product);
                    person.Money -= product.Cost;
                    Console.WriteLine(person.Name + " bought " + product.Name);
                }
                else
                {
                    Console.WriteLine(person.Name + " can't afford " + product.Name);
                }
                line = Console.ReadLine().Split();
            }
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Products.Count != 0)
                {
                    Console.WriteLine(people[i].Name + " - " + string.Join(", ", people[i].Products.Select(o => o.Name)));
                }
                else
                {
                    Console.WriteLine(people[i].Name + " - Nothing bought");
                }
            }
        }
    }
}
