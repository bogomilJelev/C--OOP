using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int maxhorse;
        private int minhorse;
        private int horsepower;
        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if(string.IsNullOrEmpty(value) && value.Length < 4)
                {
                    throw new ArgumentException($"Model {model} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return horsepower;
            }
            private set
            {
                if(value<minhorse || value > maxhorse)
                {
                    throw new ArgumentException($"Invalid horse power: {horsepower}.");
                }
                horsepower = value;
            }
        }

        public double CubicCentimeters { get; private set; }
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            this.horsepower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minhorse = minHorsePower;
            this.maxhorse = maxHorsePower;
        }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
