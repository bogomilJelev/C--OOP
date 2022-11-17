using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel:IBuyeble
    {
        public string Name { get; private set; }
        private int age;
        private string team;
        public Rebel(string name,int age,string team)
        {
            Name = name;
            this.age = age;
            this.team = team;
            Food = 0;
        }

        public int Food { get; private set; }

        public void Buy()
        {
            Food += 5;
        }
    }
}
