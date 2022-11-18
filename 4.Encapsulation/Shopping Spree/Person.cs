using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class Person
    {
        private string name;
        private List<string> bagOfProducts;
        private decimal money;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<string> BagOfProducts
        {
            get { return bagOfProducts; }
        }
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<string>();
        }
        public void AddMember(Product prod)
        {
            if (this.Money < prod.Cost)
            {
                Console.WriteLine($"{name} can't afford {prod.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} bought {prod.Name}");
                Money -= prod.Cost;
                bagOfProducts.Add(prod.Name);
            }
        }
        public void Get()
        {

            Console.WriteLine($"{name} - {string.Join(", ", bagOfProducts)}");

        }
        public override string ToString()
        {
            string person = $"{this.Name} - ";

            if (this.bagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }
            else
            {
                person += string.Join(", ", this.bagOfProducts);
            }

            return person;
        }
    }
}