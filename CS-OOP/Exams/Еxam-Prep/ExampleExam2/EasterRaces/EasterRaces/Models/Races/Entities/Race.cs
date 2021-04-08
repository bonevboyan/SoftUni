using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int minNameLength = 5;
        private const int minLapCount = 1;
        private string name;
        private int laps;
        private readonly IDictionary<string, IDriver> driversByName;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            driversByName = new Dictionary<string, IDriver>();
        }
        public string Name 
        {
            get => name;   
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < minNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, minNameLength));
                }
                name = value;
            }
        }
        public int Laps
        {
            get => laps;
            private set
            {
                if (laps < minLapCount)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, minLapCount));
                }
                laps = value;
            }
        }
        public IReadOnlyCollection<IDriver> Drivers => driversByName.Values.ToList();

        public void AddDriver(IDriver driver)
        {
            if(driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if(driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (driversByName.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }
            driversByName.Add(driver.Name, driver);
        }
    }
}
