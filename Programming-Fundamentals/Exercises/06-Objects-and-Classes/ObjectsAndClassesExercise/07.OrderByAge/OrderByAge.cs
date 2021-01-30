using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
    }
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] input = line.Split(" ");

                string name = input[0];
                int id = int.Parse(input[1]);
                int age = int.Parse(input[2]);

                Person person = new Person
                {
                    Name = name,
                    ID = id,
                    Age = age
                };
                people.Add(person);
                line = Console.ReadLine();
            }
            people = people.OrderBy(o => o.Age).ToList();
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{people[i].Name} with ID: {people[i].ID} is {people[i].Age} years old.");
            }
        }
    }
}
