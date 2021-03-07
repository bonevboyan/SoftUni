using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private int age;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.age = age;
            this.name = name;
            Id = id;
            Birthdate = birthdate;
        }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public string Name => name;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
