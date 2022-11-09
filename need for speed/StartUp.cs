namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car(200, 100);
            var motor = new RaceMotorcycle(200, 100);
            car.Drive(2);
            motor.Drive(2);
        }
    }
}
