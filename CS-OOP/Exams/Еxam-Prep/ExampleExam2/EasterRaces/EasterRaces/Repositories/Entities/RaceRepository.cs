using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IDictionary<string, IRace> Models;
        public RaceRepository()
        {
            Models = new Dictionary<string, IRace>();
        }
        public void Add(IRace model)
        {
            if (Models.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RaceExists, model.Name));
            }
            Models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return Models.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            if (Models.ContainsKey(name))
            {
                return Models[name];
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, name));
        }

        public bool Remove(IRace model)
        {
            return Models.Remove(model.Name);
        }
    }
}
