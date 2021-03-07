using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Pet : IBirthable
    {
        private string name;
        public Pet(string name, string birthdate)
        {
            this.name = name;
            Birthdate = birthdate;
        }

        public string Birthdate { get; set; }
    }
}
