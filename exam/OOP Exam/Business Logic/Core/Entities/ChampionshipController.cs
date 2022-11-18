using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IDriver> drivers;
        private readonly IRepository<IRace> races;

        public ChampionshipController()
        {
            races = new RaceRepository();
            cars = new CarRepository();
            drivers = new DriverRepository();

        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = cars.GetByName(carModel);
            var driver = drivers.GetByName(driverName);
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found");
            }
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found");
            }
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";

        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = races.GetByName(raceName);
            var driver = drivers.GetByName(driverName);
            if (races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            drivers.Remove(driver);
            return $"Driver {driverName} added in {raceName} race.";


        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car { model } is already created.");
            }

            ICar car=null;
            
            if (type == "Muscle")
            {
              car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
               car = new SportsCar(model, horsePower);
            }
            cars.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var drive = new Driver(driverName);
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            drivers.Add(drive);
            return $"Driver {drive.Name} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race(name, laps);
            if (races.GetByName(name)!=null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");

            }
            races.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var driver = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToArray();
            var sb = new StringBuilder();
                sb.AppendLine($"Driver {driver[0]} wins {raceName} race.");
                sb.AppendLine($"Driver {driver[1]} wins {raceName} race.");
                sb.AppendLine($"Driver {driver[2]} wins {raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
