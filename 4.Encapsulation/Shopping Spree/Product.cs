using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be empty");
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                cost = value;
            }
        }
    }
}
