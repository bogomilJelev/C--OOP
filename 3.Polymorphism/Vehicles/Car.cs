using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelq, double fuelcons) 
            : base(fuelq, fuelcons)
        {
        }
        public override double FuelConsumption => base.FuelConsumption+0.9;
    }
}
