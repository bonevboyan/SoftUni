using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Fish = new List<IFish>();
            this.Decorations = new List<IDecoration>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public int Comfort => Decorations.Select(d => d.Comfort).Sum();

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(Fish.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            Fish.Add(fish);
        }

        public void Feed()
        {
            Fish.ToList().ForEach(f => f.Eat());
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({GetType().Name}):");
            sb.Append("Fish: ");
            if(Fish.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                sb.AppendLine(string.Join(", ", Fish.Select(f => f.Name)));
            }
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().Trim();
        }
        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
    }
}
