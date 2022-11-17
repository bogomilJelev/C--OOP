using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<IBuyeble> list = new List<IBuyeble>();
            for (int i = 0; i < people; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command.Length == 3)
                {
                    var rebel = new Rebel(command[0], int.Parse(command[1]), command[2]);
                    list.Add(rebel);
                }
                else if (command.Length == 4)
                {
                    var citizen = new Citizen(command[0], int.Parse(command[1]), command[2], command[3]);
                    list.Add(citizen);
                }
            }
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (item.Name == name)
                        {
                            item.Buy();
                        }
                    }
                }
            }
            int sum = 0;
            foreach (var item in list)
            {
                sum += item.Food;
            }
            Console.WriteLine(sum);
        }
    }
}
