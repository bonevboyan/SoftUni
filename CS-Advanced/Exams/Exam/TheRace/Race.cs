using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public List<Racer> data { get; set; }
        public void Add(Racer Racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            if (data.Contains(data.FirstOrDefault(r => r.Name == name)))
            {
                data.Remove(data.FirstOrDefault(r => r.Name == name));
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).ThenBy(r => r.Name).ToList()[0];
        }
        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(r => r.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Car.Speed).ThenBy(r => r.Name).ToList()[0];
        }
        public string Report()
        {
            return $"Racers participating at {Name}:\n{string.Join("\n", data)}\n";
        }
    }
}
