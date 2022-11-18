using System;

namespace Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] car = Console.ReadLine().Split();
            Car car1 = new Car(double.Parse(car[1]),double.Parse( car[2]));
            string[] truck = Console.ReadLine().Split();
            Track track = new Track(double.Parse(truck[1]),double.Parse(truck[2]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] com = Console.ReadLine().Split();
                if(com[0] == "Drive")
                {
                    if (com[1] == "Car")
                    {
                        if (car1.CanDrive(double.Parse(com[2])))
                        {
                            Console.WriteLine($"Car travelled {double.Parse(com[2])} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else
                    {
                        if (track.CanDrive(double.Parse(com[2])))
                        {
                            Console.WriteLine($"Truck travelled {double.Parse(com[2])} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else
                {
                    if (com[1] == "Car")
                    {
                        car1.Refuel(double.Parse((com[2])));
                    }
                    else
                    {
                        track.Refuel(double.Parse(com[2]));
                    }
                }
            }
            Console.WriteLine($"Car: {car1.FuelQuamtity:F2}");
            Console.WriteLine($"Truck: {track.FuelQuamtity:F2}");

        }
    }
}
