namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var knight = new Knight("Goshko", 7);
            System.Console.WriteLine(knight.ToString());
        }
    }
}