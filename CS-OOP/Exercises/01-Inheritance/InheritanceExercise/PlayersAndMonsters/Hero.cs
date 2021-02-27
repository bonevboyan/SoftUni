using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string username, int level)
        {
            Level = level;
            Username = username;
        }
        public int Level { get; set; }
        public string Username { get; set; }
        public override string ToString()
        {
            return $"Type: {GetType().Name} Username: {Username} Level: {Level}";
        }
    }
}
