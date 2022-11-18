using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Track : Vehicle
    {
        public Track(double fuelq, double fuelcons) 
            : base(fuelq, fuelcons)
        {
        }
        public override double FuelConsumption => base.FuelConsumption+1.6;
        public override void Refuel(double amount)
        {
            base.Refuel(amount*0.95);
        }
    }
}
