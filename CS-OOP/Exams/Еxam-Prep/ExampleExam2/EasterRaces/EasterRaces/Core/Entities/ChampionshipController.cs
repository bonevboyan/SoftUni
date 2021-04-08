using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;
        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository= new DriverRepository();
            raceRepository= new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);

            driverRepository.Remove(driver);

            driver.AddCar(car);
            driverRepository.Add(driver);

            return string.Format(OutputMessages.CarAdded, driver.Name, car.Model);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            IRace race = raceRepository.GetByName(raceName);
            if (driver.CanParticipate)
            {
                raceRepository.Remove(race);
            }
            race.AddDriver(driver);
            raceRepository.Add(race);
            return string.Format(OutputMessages.DriverAdded, driver.Name, race.Name);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if(type == "Muscle")
            {
                carRepository.Add(new MuscleCar(model, horsePower));
            }
            else if(type == "Sports")
            {
                carRepository.Add(new SportsCar(model, horsePower));
            }
            return string.Format(OutputMessages.CarCreated, type + "Car", model);
        }

        public string CreateDriver(string driverName)
        {
            driverRepository.Add(new Driver(driverName));
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            raceRepository.Add(new Race(name, laps));
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, race.Name, 3));
            }

            StringBuilder stringBuilder = new StringBuilder();
            int place = 0;

            string[] messages = new string[] 
            {
                OutputMessages.DriverFirstPosition,
                OutputMessages.DriverSecondPosition,
                OutputMessages.DriverThirdPosition 
            };
            race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList()
                .ForEach(d =>
                {
                    stringBuilder.AppendLine(string.Format(messages[place], d.Name, race.Name));
                    place++;
                });

            return stringBuilder.ToString().Trim();
        }
    }
}
