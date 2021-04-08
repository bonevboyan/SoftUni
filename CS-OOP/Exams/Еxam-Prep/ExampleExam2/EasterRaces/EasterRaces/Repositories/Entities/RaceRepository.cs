using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
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
            Models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return Models.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            return Models[name];
        }

        public bool Remove(IRace model)
        {
            return Models.Remove(model.Name);
        }
    }
}
