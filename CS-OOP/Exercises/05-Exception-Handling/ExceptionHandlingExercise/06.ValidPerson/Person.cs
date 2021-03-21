using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.ValidPerson
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public string FirstName { 
            get 
            {
                return this.firstName;
            } 
            set 
            {
                if (value.Length == 0 || value == null)
                {
                    throw new ArgumentNullException("value", "First name cannot be empty or null");
                }
                if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("First name must contain only letters!");
                }
                firstName = value;
            } 
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length == 0 || value == null)
                {
                    throw new ArgumentNullException("value", "Last name cannot be empty or null");
                }
                if (!value.All(char.IsLetter))
                {
                    throw new InvalidPersonNameException("Last name must contain only letters!");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value >= 0 && value <= 120)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value","Age must be in the range [0;120]");
                }
            }
        }

    }
}
