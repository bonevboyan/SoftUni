using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family
            {
                FamilyMembers = new List<Person>()
            };
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person member = new Person(input[0], int.Parse(input[1]));
                family.AddMember(member);
            }
            family.FamilyMembers
                .Where(m => m.Age > 30)
                .OrderBy(m => m.Name)
                .ToList()
                .ForEach(m => 
                { 
                    Console.WriteLine($"{m.Name} - {m.Age}"); 
                });
        }
    }
}
