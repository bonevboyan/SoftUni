using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> Models;
        public CarRepository()
        {
            Models = new Dictionary<string, ICar>();
        }
        public void Add(ICar model)
        {
            Models.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {

            return Models.Values.ToList();
        }

        public ICar GetByName(string name)
        {
            return Models[name];
        }

        public bool Remove(ICar model)
        {
            return Models.Remove(model.Model);
        }
    }
}
