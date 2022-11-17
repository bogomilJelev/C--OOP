using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
     class Program
    {
        static void Main(string[] args)
        {
            List<ICitizentLive> list = new List<ICitizentLive>();
            while (true)
            {
                string[] ask = Console.ReadLine().Split();
                if (ask[0] == "End")
                {
                    break;
                }
                else if (ask.Length == 3)
                { 
                    list.Add(new Citizens(ask[0],int.Parse(ask[1]),ask[2]));
                }
                else if (ask.Length == 2)
                {
                    list.Add(new Robot(ask[0], ask[1]));
                }
            }
            string lastdig = Console.ReadLine();

            list.Where(x => x.ID.EndsWith(lastdig)).Select(x => x.ID).ToList().ForEach(Console.WriteLine);
        }
    }
}
