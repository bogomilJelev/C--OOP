using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personnames = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            string[] prodname = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> list = new List<Person>();
            List<Product> list2 = new List<Product>();
            bool ask = true;
            for (int i = 0; i < personnames.Length; i++)
            {
                try
                {
                    string[] spliter = personnames[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = spliter[0];
                    decimal money = decimal.Parse(spliter[1]);
                    var person = new Person(name, money);
                    list.Add(person);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    ask = false;
                    break;
                }
            }
            for (int i = 0; i < prodname.Length ; i++)
            {
                try
                {
                    string[] sparler = prodname[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = sparler[0];
                    decimal cost = decimal.Parse(sparler[1]);
                    var prod = new Product(name, cost);
                    list2.Add(prod);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    ask = false;
                    break;
                }

            }
            if (ask)
            {
            while (true)
            {

                string ints = Console.ReadLine();
                if (ints == "END")
                {
                    break;
                }
                string[] ints2 = ints.Split();
                string name = ints2[0];
                string naemprod = ints2[1];

                var person = list.FirstOrDefault(x => x.Name == name);
                var prod = list2.FirstOrDefault(x => x.Name == naemprod);
                person.AddMember(prod);
            }
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }

            }
        }
    }
}
