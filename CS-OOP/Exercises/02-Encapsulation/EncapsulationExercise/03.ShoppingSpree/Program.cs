using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] commands = Console.ReadLine().Split(';');
            commands.ToList().ForEach(command =>
            {
                people.Add(new Person(command.Split('=')[0], decimal.Parse(command.Split('=')[1])));
            });

            commands = Console.ReadLine().Split(';');
            commands.ToList().ForEach(command =>
            {
                products.Add(new Product(command.Split('=')[0], decimal.Parse(command.Split('=')[1])));
            });
            string command = Console.ReadLine();
            while(command != "END")
            {
                commands = command.Split(' ');
                Person person = people.First(name => name.Name == commands[0]);
                Product product = products.First(name => name.Name == commands[1]);
                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.BagOfProducts.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - " + (person.BagOfProducts.Count == 0 ? $"Nothing bought" : $"{string.Join(", ", person.BagOfProducts)}"));
            }
        }
    }
}
