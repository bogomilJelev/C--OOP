using System;
using System.Collections.Generic;
using System.Text;

namespace ask
{
    public class Topping
    {
        private string type;
        private double weight;

        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new Exception($"Cannot place {valueName} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 0 || value > 50)
                {
                    var valueName = this.type[0].ToString().ToUpper() + this.type.Substring(1);
                    throw new Exception($"{valueName} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public Topping(string t, double w)
        {
            Type = t;
            Weight = w;
        }
        private double Calc()
        {
            double cal = 2.0;
            if (type.ToLower() == "meat")
            {
                cal = 1.2;
            }
            else if (type.ToLower() == "veggies")
            {
                cal = 0.8;
            }
            else if (type.ToLower() == "cheese")
            {
                cal = 1.1;

            }
            else if (type == "sauce")
            {
                cal = 0.9;
            }
            return cal;
        }
        public double CalculaTop()
        {
           return 2 * Calc() * weight ;
        }
    }
}
