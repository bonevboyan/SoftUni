using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ComparingObjects
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (name.CompareTo(other.name) != 0)
            {
                return name.CompareTo(other.name);
            }

            if (age.CompareTo(other.age) != 0)
            {
                return age.CompareTo(other.age);
            }

            return town.CompareTo(other.town);
        }
    }
}
