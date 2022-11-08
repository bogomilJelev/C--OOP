using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var gorrila = new Gorilla(Console.ReadLine());
            Console.WriteLine(gorrila.Name);
;
        }
    }
}