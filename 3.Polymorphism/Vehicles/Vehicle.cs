using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
   public abstract class Vehicle
    {
        public double FuelQuamtity { get; private set; }
        public virtual double FuelConsumption { get; }
        protected Vehicle(double fuelq,double fuelc)
        {
            FuelQuamtity = fuelq;
            FuelConsumption = fuelc;

        }
        public virtual void Refuel(double amount)
        {
            FuelQuamtity += amount;
        }
        public bool CanDrive(double distance)
        {
            bool canDrive = this.FuelQuamtity - FuelConsumption * distance >= 0;
            if (!canDrive)
            {
                return false;
            }
            this.FuelQuamtity -= this.FuelConsumption * distance;
            return true;
        }
    }
}
