using System;
using System.Linq;
using Telephony.Models;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] number = Console.ReadLine().Split().ToArray();
            string[] site = Console.ReadLine().Split().ToArray();
            var smartphone = new SmartPhone();
            var telephone = new StationaryPhone();

            for (int i = 0; i < number.Length; i++)
            {
                try
                {
                   if (number[i].Length == 7)
                   {
                       Console.WriteLine(telephone.Call(number[i]));
                   }
                   else
                   {
                       Console.WriteLine(smartphone.Call(number[i]));
                   }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            for (int i = 0; i < site.Length; i++)
            {
                try
                {
                  Console.WriteLine(smartphone.Brows(site[i]));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
