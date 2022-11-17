using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
     public interface IBuyeble
    {
        public void Buy();
        public int Food { get; }
        public string Name { get;}
    }
}
