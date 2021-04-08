using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly IDictionary<string, IDriver> Models;
        public DriverRepository()
        {
            Models = new Dictionary<string, IDriver>();
        }
        public void Add(IDriver model)
        {
            if (Models.ContainsKey(model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, model.Name));
            }
            Models.Add(model.Name, model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return Models.Values.ToList();
        }

        public IDriver GetByName(string name)
        {
            if (Models.ContainsKey(name))
            {
                return Models[name];
            }
            throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, name));
        }

        public bool Remove(IDriver model)
        {
            return Models.Remove(model.Name);
        }
    }
}
