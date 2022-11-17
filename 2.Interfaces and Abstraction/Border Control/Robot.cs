using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Robot:ICitizentLive
    {
        private string model;
        public string ID { get; private set; }


        public Robot(string model,string id)
        {
            this.model = model;
            ID = id;
        }
    }
}
