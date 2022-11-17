using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Citizens:ICitizentLive
    {
        private string name;
        private int age;

        public string ID { get; private set; }

        public Citizens(string name,int age,string id)
        {
            this.name = name;
            this.age = age;
            ID = id;
        }
    }
}
