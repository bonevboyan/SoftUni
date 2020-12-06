using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Family
    {
        public List<Person> members { get; set; } = new List<Person>();
        public void AddMember(string[] memberInfo)
        {
            Person newMember = new Person
            {
                Name = memberInfo[0],
                Age = int.Parse(memberInfo[1])
            };
            members.Add(newMember);
        }
        public Person GetOldestMember()
        {
            return this.members.OrderByDescending(o => o.Age).ToList()[0];
        }
    }
    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                family.AddMember(input);
            }
            Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
        }
    }
}
