using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen:IBuyeble
    {
       
        private int age;
        private string id;
        private string birthday;
        
        public Citizen(string name,int age,string id,string bird)
        {
            Name = name;
            this.age = age;
            this.id = id;
            this.birthday = bird;
            Food = 0;
        }

        public int Food { get; private set; }

        public string Name { get; private set; }

        public void Buy()
        {
            Food += 10;
        }
    }
}
