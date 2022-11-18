using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public abstract class Driver : IDriver
    {
        private string name;
        private bool canpar;
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) && value.Length < 5)
                {
                    throw new ArgumentException($"Name {name} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate 
        {
            get
            {
                return canpar;
            }
            private set
            {
                if (Car != null)
                {
                    canpar = true;
                }
                else
                {
                    canpar = false;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Car cannot be null.");
            }
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public Driver(string name)
        {
            Name = name;
        }
    }
}
